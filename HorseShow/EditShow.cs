using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HorseShow
{
    public partial class frmEditShow : Form
    {
        private readonly Action _updateShowsTable; //pass in the Main form for updating
        public frmEditShow(string showIDValue, Action updateShowsTable)
        {
            _updateShowsTable = updateShowsTable; //for updating the Shows table on the main form 
            InitializeComponent();

            lblHiddenValue.Text = showIDValue; //setting the ShowID from what was passed in from the main form

            //Create the tempClasses and tempEvents DB so we can load the Event/Class structure into it. 
            string dbConnectString = getConnectionString();
            string createTempClassesQuery = "create table tempClasses (eventIndex int, link2eventID int, className varchar(50), classIndex int, classID int, entryfee float, additionalMoneyAmount float, deleted int)";
            string createTempEventsQuery = "create table tempEvents (eventIndex int, eventID int, eventName varchar(50), deleted int)";
            string retreiveShowsQuery = "select showproducer, showcontact, showphonenumber, showdate, showlocation, shownotes from Shows where showID = " + showIDValue;
            string retreiveEventsQuery = "select eventid, eventname from events where link2showID = " + showIDValue;

            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                conn.Open();

                SqlCommand removeClassesTemp = new SqlCommand("IF OBJECT_ID('tempClasses') IS NOT NULL DROP TABLE tempClasses", conn);
                removeClassesTemp.ExecuteNonQuery();

                SqlCommand createTempClassesTable = new SqlCommand(createTempClassesQuery, conn);
                createTempClassesTable.ExecuteNonQuery();

                SqlCommand removeEventsTemp = new SqlCommand("IF OBJECT_ID('tempEvents') IS NOT NULL DROP TABLE tempEvents", conn);
                removeEventsTemp.ExecuteNonQuery();

                SqlCommand createTempEventsTable = new SqlCommand(createTempEventsQuery, conn);
                createTempEventsTable.ExecuteNonQuery();
            }

            //Now the fun part of getting the data from the database and filling in the values of all controls on the page, keeping data integrity. 
            //For the Events, maybe we need a temp Events table and a temp Reference table to keep track of which listIndex value goes with which EventID from the database.
            //Updating the Events table, dealing with existing vs new events, will be tricky. We cannot under any circumstance edit an Event or Class if someone is signed up for it. 
            //The whole show will need to be deleted in that case. 
            
            //Load up the Show data
            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                SqlCommand retreiveData = new SqlCommand(retreiveShowsQuery, conn);
                conn.Open();
                using (SqlDataReader readData = retreiveData.ExecuteReader())
                {
                    while (readData.Read())
                    {
                        txtShowProducer.Text = readData["showproducer"].ToString();
                        txtContactName.Text = readData["showcontact"].ToString();
                        txtPhoneNumber.Text = readData["showphonenumber"].ToString();
                        dateShowDate.Text = readData["showdate"].ToString();
                        txtLocation.Text = readData["showlocation"].ToString();
                        txtNotes.Text = readData["shownotes"].ToString();
                    }
                    readData.Close();
                }

            }
            
            //For populating the events and classes we will have to iterate through the Events table, then for each event iterate through the Classes table, and finally for each Class
            //iterate through the EventMoney table to fill in all the required info into the temp tables. Nested loops here we go!

            using (SqlConnection connect = new SqlConnection(dbConnectString))
            {
                //get the events
                SqlCommand getEvents = new SqlCommand(retreiveEventsQuery, connect);
                connect.Open();
                using (SqlDataReader readEvents = getEvents.ExecuteReader())
                {
                    int i = 0;
                    int c = 0;
                    while (readEvents.Read())
                    {
                        string insertTempEventQuery = "insert into tempEvents (eventindex, eventID, eventname, deleted) values (" + i + ", " + readEvents["eventID"].ToString() + ", '" + readEvents["eventName"].ToString() + "', 0)";
                        SqlCommand insertTempEvent = new SqlCommand(insertTempEventQuery, connect);
                        insertTempEvent.ExecuteNonQuery();
                        listEvents.Items.Add(readEvents["eventName"].ToString());

                        string eventID = readEvents["eventID"].ToString();
                        string retreiveClassesQuery = "select classid, classname, link2eventID from classes where link2eventID = " + eventID;

                        //now get the Classes for each EventID
                        using (SqlConnection classConn = new SqlConnection(dbConnectString))
                        {
                            SqlCommand getClasses = new SqlCommand(retreiveClassesQuery, classConn);
                            classConn.Open();
                            using (SqlDataReader readClasses = getClasses.ExecuteReader())
                            {
                                while (readClasses.Read())
                                {
                                    string classID = readClasses["classID"].ToString();
                                    string insertTempClassesQuery = "insert into tempClasses (eventIndex, link2eventID, className, classIndex, classID, deleted) values (" + i + ", " + readClasses["link2eventID"].ToString() + ", '" + readClasses["className"].ToString() + "', " + c + ", "+readClasses["classID"].ToString()+ ", 0)";
                                    SqlCommand insertTempClass = new SqlCommand(insertTempClassesQuery, classConn);
                                    insertTempClass.ExecuteNonQuery();

                                    //now get EventMoney records for each event + class
                                    using (SqlConnection getMoney = new SqlConnection(dbConnectString))
                                    {
                                        string getEventMoneyQuery = "select entryfee, additionalmoneyamount from eventmoney where link2eventID = " + eventID + " and link2classID = " + classID;
                                        SqlCommand getEventMoney = new SqlCommand(getEventMoneyQuery, getMoney);
                                        getMoney.Open();
                                        using (SqlDataReader readMoney = getEventMoney.ExecuteReader())
                                        {
                                            while (readMoney.Read())
                                            {
                                                string updateTempClassesQuery = "update tempclasses set entryfee = " + readMoney["entryfee"].ToString() + ", additionalmoneyamount = " + readMoney["additionalmoneyamount"].ToString() + " where classIndex = " + c + " and eventindex = " + i;
                                                SqlCommand updateTempClasses = new SqlCommand(updateTempClassesQuery, getMoney);
                                                updateTempClasses.ExecuteNonQuery();
                                            }
                                        }

                                    }
                                        //increment Class Index
                                        c++;
                                }
                            }
                            //increment Event Index
                            i++;
                        }
                    }
                }
            }

            updateClassList();
        }

        private void btnAddEditShowCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void updateClassList()
        {
            //Call this function any time the Class listview needs to be updated. 
            int selectedEventIndex = listEvents.SelectedIndex;
            string connection = getConnectionString();
            string classListView = "select className from tempClasses where deleted = 0 and eventIndex = " + selectedEventIndex;


            listClasses.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand sqlListClasses = new SqlCommand(classListView, conn);
                conn.Open();
                using (SqlDataReader reader = sqlListClasses.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listClasses.Items.Add(reader["className"].ToString());
                    }
                }
            }
        }

        public void updateEventsList()
        {
            string showID = lblHiddenValue.Text;
            string connection = getConnectionString();
            string eventListview = "select eventname from tempEvents where deleted = 0";

            listEvents.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand getEventsList = new SqlCommand(eventListview, conn);
                conn.Open();
                using (SqlDataReader readEvents = getEventsList.ExecuteReader())
                {
                    while (readEvents.Read())
                    {
                        listEvents.Items.Add(readEvents["eventName"].ToString());
                    }
                }
            }
        }

        public static string getConnectionString()
        {
            //added MultipleActiveResultSets=True to this connection string to resolve issues with "There is already an open DataReader associated with this Command which must be closed first” errors.
            //http://stackoverflow.com/questions/6062192/there-is-already-an-open-datareader-associated-with-this-command-which-must-be-c
            //
            string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";

            return dbConnectString;
        }

        private void frmEditShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dbConnectString = getConnectionString();

            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                conn.Open();
                SqlCommand removeClassesTemp = new SqlCommand("IF OBJECT_ID('tempClasses') IS NOT NULL DROP TABLE tempClasses", conn);
                removeClassesTemp.ExecuteNonQuery();

                SqlCommand removeEventsTemp = new SqlCommand("IF OBJECT_ID('tempEvents') IS NOT NULL DROP TABLE tempEvents", conn);
                removeEventsTemp.ExecuteNonQuery();
            }
        }

        private void listEvents_SelectedValueChanged(object sender, EventArgs e)
        {
            updateClassList();
        }

        private void listClasses_SelectedValueChanged(object sender, EventArgs e)
        {
            int eventIndex = listEvents.SelectedIndex;
            string connection = getConnectionString();
            
            //populate the entry fees and additional money

            if (listClasses.SelectedIndex != -1)
            {
                string className = listClasses.SelectedItem.ToString();
                string getMoneyQuery = "select entryFee, additionalMoneyAmount from tempClasses where className = '" + className + "' and eventIndex = " + eventIndex;

                txtEntryFee.Text = "";
                txtAdditionalMoney.Text = "";

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlCommand getMoney = new SqlCommand(getMoneyQuery, conn);
                    getMoney.ExecuteNonQuery();

                    using (SqlDataReader reader = getMoney.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtAdditionalMoney.Text = (reader["additionalMoneyAmount"].ToString());
                            txtEntryFee.Text = (reader["entryFee"].ToString());
                        }
                    }
                }
            }
        }

        private void btnAddEditShowSaveChanges_Click(object sender, EventArgs e)
        {
            //Thoughts: A stored procedure that will compare records between the Events and tempEvents databases, with logic to decide if an event needs to be added, removed, or renamed.
            //          It will need to iterate through the classes and do the same for those, updating entryfee and additionalmoneyamount as it goes. 

            //Update the Show details, the easy part...
            string connection = getConnectionString();
            string showID = lblHiddenValue.Text;
            string updateShowQuery = "update Shows set showProducer = '" + txtShowProducer.Text + "', showContact = '" + txtContactName.Text + "', showPhoneNumber = '" + txtPhoneNumber.Text + "', showDate = '" + dateShowDate.Value.Date.ToString() + "', showLocation = '" + txtLocation.Text + "', showNotes = '" + txtNotes.Text + "' where showID = " + showID;

            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand updateShows = new SqlCommand(updateShowQuery, conn);
                conn.Open();
                updateShows.ExecuteNonQuery();

                //Now we need to iterate through every item in the tempEvents table. 
                SqlCommand loadTempEvents = new SqlCommand("select eventIndex, eventID, eventName, deleted from tempEvents", conn);
                using (SqlDataReader loadEvents = loadTempEvents.ExecuteReader())
                {
                    //Are there any Events to Edit?
                    while (loadEvents.Read())
                    {
                        string eventID = loadEvents["eventID"].ToString();
                        string updateEventQuery = "update Events set eventName = '" + loadEvents["eventName"].ToString() + "' where eventID = " + eventID + " and link2showID = " + showID;
                        SqlCommand updateEvent = new SqlCommand(updateEventQuery, conn);
                        updateEvent.ExecuteNonQuery();

                        //Need to insert new classes for existing events
                        string loadNewClassExistingEventQuery = "select eventIndex, link2eventID, className, classIndex, classID, entryfee, additionalMoneyAmount, deleted from tempclasses where classID = -1 and deleted = 0 and link2eventID = " + eventID;
                        SqlCommand loadNewClassExistingEvent = new SqlCommand(loadNewClassExistingEventQuery, conn);
                        using (SqlDataReader readNewClassExistingEvent = loadNewClassExistingEvent.ExecuteReader())
                        {
                            while (readNewClassExistingEvent.Read())
                            {
                                string insertNewClassExistingEventQuery = "insert into classes (classname, link2eventID) values ('" + readNewClassExistingEvent["className"].ToString() + "', " + eventID + ") SELECT SCOPE_IDENTITY()";
                                SqlCommand insertNewClassExistingEvent = new SqlCommand(insertNewClassExistingEventQuery, conn);
                                var newClassID = insertNewClassExistingEvent.ExecuteScalar();
                                int newClassIDint = Convert.ToInt32(newClassID);

                                string insertNewMoneyExistingEventQuery = "insert into eventMoney (link2eventID, link2classID, entryfee, additionalmoneyamount) values (" + eventID + ", " + newClassIDint + ", " + readNewClassExistingEvent["entryFee"].ToString() + ", " + readNewClassExistingEvent["additionalmoneyamount"].ToString() + ")";
                                SqlCommand insertNewMoneyExistingEvent = new SqlCommand(insertNewMoneyExistingEventQuery, conn);
                                insertNewMoneyExistingEvent.ExecuteNonQuery();
                            }
                        }
                            
                    }   
                    
                }

                //Are there any Events to Add?
                string loadTempNewEventsQuery = "select eventIndex, eventID, eventName, deleted from tempEvents where eventID = -1 and deleted = 0";
                SqlCommand loadTempNewEvents = new SqlCommand(loadTempNewEventsQuery, conn);
                using (SqlDataReader readTempNewEvent = loadTempNewEvents.ExecuteReader())
                {
                    while (readTempNewEvent.Read())
                    {
                        string eventIndex = readTempNewEvent["eventIndex"].ToString();
                        string insertEventsQuery = "insert into Events (eventName, link2showID) values ('" + readTempNewEvent["eventName"].ToString() + "', " + showID + ") SELECT SCOPE_IDENTITY()";
                        SqlCommand insertEvents = new SqlCommand(insertEventsQuery, conn);
                        var newEventID = insertEvents.ExecuteScalar();
                        int newEventIDint = Convert.ToInt32(newEventID);

                        //Iterate through each class added to each new Event and add it to the Class table
                        SqlCommand loadTempNewClasses = new SqlCommand("select eventIndex, link2eventID, className, classIndex, classID, entryfee, additionalMoneyAmount, deleted from tempClasses where eventIndex = "+eventIndex+" and classID = -1 and deleted = 0", conn);
                        using (SqlDataReader readTempNewClasses = loadTempNewClasses.ExecuteReader())
                        {

                            while (readTempNewClasses.Read())
                            {
                                string insertClassQuery = "insert into Classes (className, link2eventID) values ('" + readTempNewClasses["className"].ToString() + "', " + newEventIDint + ") SELECT SCOPE_IDENTITY()";
                                SqlCommand insertClass = new SqlCommand(insertClassQuery, conn);
                                var newClassID = insertClass.ExecuteScalar();
                                int newClassIDint = Convert.ToInt32(newClassID);

                                //Add EventMoney records for the new Class entry
                                string insertEventMoneyQuery = "insert into eventMoney (link2eventID, link2ClassID, entryFee, AdditionalMoneyAmount) values (" + newEventIDint + ", " + newClassIDint + ", " + readTempNewClasses["entryFee"].ToString() + ", " + readTempNewClasses["additionalMoneyAmount"].ToString() + ")";
                                SqlCommand insertEventMoney = new SqlCommand(insertEventMoneyQuery, conn);
                                insertEventMoney.ExecuteNonQuery();
                            }
                        }
                    }
                }

                //Are there any Classes to edit?
                SqlCommand loadTempClasses = new SqlCommand("select eventIndex, link2eventID, className, classIndex, classID, entryfee, additionalMoneyAmount, deleted from tempclasses where link2eventID is not null", conn);
                using (SqlDataReader readTempClasses = loadTempClasses.ExecuteReader())
                {
                    while (readTempClasses.Read())
                    {
                        string updateClassQuery = "update classes set className = '" + readTempClasses["className"].ToString() + "' where classID = " + readTempClasses["classID"].ToString() + " and link2eventID = " + readTempClasses["link2eventID"].ToString();
                        SqlCommand updateClasses = new SqlCommand(updateClassQuery, conn);
                        updateClasses.ExecuteNonQuery();

                        //While we're iterating the tempClasses table, let's update the EventMoney table too.
                        string updateEventMoneyQuery = "update eventMoney set entryfee = "+readTempClasses["entryFee"].ToString()+", additionalMoneyAmount = "+readTempClasses["additionalMoneyAmount"].ToString()+" where link2classID = " + readTempClasses["classID"].ToString() + " and link2eventID = " + readTempClasses["link2eventID"].ToString();
                        SqlCommand updateEventMoney = new SqlCommand(updateEventMoneyQuery, conn);
                        updateEventMoney.ExecuteNonQuery();
                    }
                }
            }

            _updateShowsTable(); //for updating the Shows table on the main form
            this.Close();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            string connection = getConnectionString();
            string newEventName = txtNewEventInput.Text;
            int eventIndex = listEvents.Items.Count;
            string insertEventsTempQuery = "insert into tempEvents (eventindex, eventID, eventname, deleted) values (" + eventIndex + ", -1, '" + newEventName + "', 0)";
            //using -1 as the eventID to identify it as a new record


            if (newEventName == "")
            {
                //do nothing
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand insertEventsTemp = new SqlCommand(insertEventsTempQuery, conn);
                    conn.Open();
                    insertEventsTemp.ExecuteNonQuery();
                    listEvents.Items.Add(newEventName);
                }

                txtNewEventInput.Text = "";
                updateEventsList();
            }
        }

        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            //Thoughts: when an Event is removed from the list we need to set the Deleted flag = 1. 
            //Then for every eventIndex afterward for all the indexes of a higher number than the deleted index we reduce them by 1, and do the same for all 
            //tempClass records too. 

            //TODO: Need to check to see if that EventID has any Horse/Rider records related to it and if so prevent event deletion!

            string connection = getConnectionString();
            int selectedIndex = listEvents.SelectedIndex;
            string deleteEventQuery = "update tempevents set deleted = 1 where eventIndex = " + selectedIndex;
            string deleteRelatedClassesQuery = "update tempClasses set deleted = 1 where eventIndex = " + selectedIndex;
            string updateEventsIndexesQuery = "update tempEvents set eventIndex = eventIndex - 1 where deleted = 0 and eventIndex > " + selectedIndex;
            string updateClassIndexesQuery = "update tempClasses set eventIndex = eventIndex - 1 where deleted = 0 and eventIndex > " + selectedIndex;

            if (selectedIndex != -1)
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand deleteEvent = new SqlCommand(deleteEventQuery, conn);
                    SqlCommand deleteRelatedClasses = new SqlCommand(deleteRelatedClassesQuery, conn);
                    SqlCommand updateEventsIndexes = new SqlCommand(updateEventsIndexesQuery, conn);
                    SqlCommand updateClassIndexes = new SqlCommand(updateClassIndexesQuery, conn);
                    conn.Open();
                    deleteEvent.ExecuteNonQuery();
                    deleteRelatedClasses.ExecuteNonQuery();
                    updateEventsIndexes.ExecuteNonQuery();
                    updateClassIndexes.ExecuteNonQuery();
                }

                updateEventsList();
                updateClassList();

                txtNewEventInput.Text = "";
            }
        }

        private void btnRenameEvent_Click(object sender, EventArgs e)
        {
            string connection = getConnectionString();
            int selectedIndex = listEvents.SelectedIndex;
            string newEventName = txtNewEventInput.Text;
            string updateEventNameQuery = "update tempEvents set eventName = '" + newEventName + "' where eventIndex = " + selectedIndex;

            if (txtNewEventInput.Text != "")
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand updateEventName = new SqlCommand(updateEventNameQuery, conn);
                    conn.Open();
                    updateEventName.ExecuteNonQuery();
                }

                updateEventsList();
                updateClassList();
                txtNewEventInput.Text = "";
            }

        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            string newClass = txtNewClassInput.Text;
            int selectedEventIndex = listEvents.SelectedIndex;
            string connection = getConnectionString();
            string classListView = "select className from tempClasses where eventIndex = " + selectedEventIndex;
            int val;

            if (listEvents.Items.Count == 0)
            {
                MessageBox.Show("Please add an Event first!");
            }
            else if (newClass == "")
            {
                //do nothing
            }
            else if (listEvents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Event for this Class.");
            }
            else if (!(int.TryParse(txtAdditionalMoney.Text, out val)) || !(int.TryParse(txtEntryFee.Text, out val)))
            {
                MessageBox.Show("Please enter a number for EntryFee and AdditionalMoney for the new class.");
                txtEntryFee.Text = "";
                txtAdditionalMoney.Text = "";
            }
            else
            {

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string eventID = "-1";
                    string checkEventsForExistingQuery = "select eventID from tempEvents where eventIndex = " + selectedEventIndex;
                    SqlCommand checkEventsForExisting = new SqlCommand(checkEventsForExistingQuery, conn);
                    conn.Open();
                    using (SqlDataReader readEventsForExisting = checkEventsForExisting.ExecuteReader())
                    {
                        while (readEventsForExisting.Read())
                        {
                            eventID = readEventsForExisting["eventID"].ToString();
                        }
                    }

                    string insertClassQuery = "insert into tempClasses (eventIndex, link2eventID, className, entryfee, additionalMoneyAmount, classID, deleted) values (" + selectedEventIndex + ", "+eventID+", '" + newClass + "', " + txtEntryFee.Text + ", " + txtAdditionalMoney.Text + ",-1,0)";
                    //using -1 for classID to indicate new class record

                    SqlCommand insertClass = new SqlCommand(insertClassQuery);
                    insertClass.Connection = conn;
                    insertClass.ExecuteNonQuery();

                    SqlCommand sqlListClasses = new SqlCommand(classListView, conn);

                    listClasses.Items.Clear();

                    using (SqlDataReader reader = sqlListClasses.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listClasses.Items.Add(reader["className"].ToString());
                        }
                    }
                }

                txtNewClassInput.Text = "";
                updateClassList();
            }
        }

        private void btnRemoveClass_Click(object sender, EventArgs e)
        {
            int eventIndexForClassToDelete = listEvents.SelectedIndex;
            string connection = getConnectionString();

            //for debug
            //MessageBox.Show("Going to delete " + classNameToDelete + "with eventIndex of " + eventIndexForClassToDelete);
            if (listClasses.SelectedIndex != -1)
            {
                string classNameToDelete = listClasses.SelectedItem.ToString();
                string deleteClassFromTempClass = "update tempClasses set deleted = 1 where className = '" + classNameToDelete + "' and eventIndex = " + eventIndexForClassToDelete;

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlCommand deleteClass = new SqlCommand(deleteClassFromTempClass, conn);
                    deleteClass.ExecuteNonQuery();
                }

                updateClassList();
            }

        }

        private void btnRenameClass_Click(object sender, EventArgs e)
        {
            string connection = getConnectionString();
            int eventIndex = listEvents.SelectedIndex;

            if (listClasses.SelectedIndex != -1)
            {
                string className = listClasses.SelectedItem.ToString();
                string newClassName = txtNewClassInput.Text;
                string renameClassQuery = "update tempClasses set className = '" + newClassName + "' where classname = '" + className + "' and eventIndex = " + eventIndex;

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand renameClass = new SqlCommand(renameClassQuery, conn);
                    conn.Open();
                    renameClass.ExecuteNonQuery();
                }

                txtNewClassInput.Text = "";
                updateClassList();
            }
        }

        private void btnSaveMoney_Click(object sender, EventArgs e)
        {
            int eventIndex = listEvents.SelectedIndex;
            string entryFee = txtEntryFee.Text;
            string additionalMoney = txtAdditionalMoney.Text;
            string connection = getConnectionString();

            if ((listClasses.SelectedIndex != -1) && (txtAdditionalMoney.Text != "") && (txtEntryFee.Text != ""))
            {
                string className = listClasses.SelectedItem.ToString();
                string updateMoneyQuery = "update tempClasses set additionalMoneyAmount = " + additionalMoney + ", entryfee = " + entryFee + " where eventIndex = " + eventIndex + " and className = '" + className + "'";

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand updateMoney = new SqlCommand(updateMoneyQuery, conn);
                    conn.Open();
                    updateMoney.ExecuteNonQuery();
                }

                updateClassList();

            }
        }
    }
}
