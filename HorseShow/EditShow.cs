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

        public frmEditShow(string showIDValue)
        {
            InitializeComponent();

            lblHiddenValue.Text = showIDValue; //setting the ShowID from what was passed in from the main form

            //Create the tempClasses and tempEvents DB so we can load the Event/Class structure into it. 
            string dbConnectString = getConnectionString();
            string createTempClassesQuery = "create table tempClasses (eventIndex int, link2eventID int, className varchar(50), classIndex int, entryfee float, additionalMoneyAmount float)";
            string createTempEventsQuery = "create table tempEvents (eventIndex int, eventID int, eventName varchar(50))";
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
                        string insertTempEventQuery = "insert into tempEvents (eventindex, eventID, eventname) values (" + i + ", " + readEvents["eventID"].ToString() + ", '" + readEvents["eventName"].ToString() + "')";
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
                                    string insertTempClassesQuery = "insert into tempClasses (eventIndex, link2eventID, className, classIndex) values (" + i + ", " + readClasses["link2eventID"].ToString() + ", '" + readClasses["className"].ToString() + "', " + c + ")";
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
            string classListView = "select className from tempClasses where eventIndex = " + selectedEventIndex;


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
            string className = listClasses.SelectedItem.ToString();
            string connection = getConnectionString();
            string getMoneyQuery = "select entryFee, additionalMoneyAmount from tempClasses where className = '" + className + "' and eventIndex = " + eventIndex;

            //populate the entry fees and additional money

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

        private void reInitializeLists()
        {
            string showIDValue = lblHiddenValue.Text; //setting the ShowID from what was passed in from the main form

            //Create the tempClasses and tempEvents DB so we can load the Event/Class structure into it. 
            string dbConnectString = getConnectionString();
            string createTempClassesQuery = "create table tempClasses (eventIndex int, link2eventID int, className varchar(50), classIndex int, entryfee float, additionalMoneyAmount float)";
            string createTempEventsQuery = "create table tempEvents (eventIndex int, eventID int, eventName varchar(50))";
            string retreiveShowsQuery = "select showproducer, showcontact, showphonenumber, showdate, showlocation, shownotes from Shows where showID = " + showIDValue;
            string retreiveEventsQuery = "select eventid, eventname from events where link2showID = " + showIDValue;

            listEvents.Items.Clear();
            listClasses.Items.Clear();

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
                        string insertTempEventQuery = "insert into tempEvents (eventindex, eventID, eventname) values (" + i + ", " + readEvents["eventID"].ToString() + ", '" + readEvents["eventName"].ToString() + "')";
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
                                    string insertTempClassesQuery = "insert into tempClasses (eventIndex, link2eventID, className, classIndex) values (" + i + ", " + readClasses["link2eventID"].ToString() + ", '" + readClasses["className"].ToString() + "', " + c + ")";
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
    }
}
