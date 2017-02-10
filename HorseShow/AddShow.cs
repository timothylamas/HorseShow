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
    public partial class frmAddShow : Form
    {
        private readonly Action _updateShowsTable; //pass in the Main form for updating

        public frmAddShow(Action updateShowsTable) //Action and variable for updating Shows table on the main form
        {
            _updateShowsTable = updateShowsTable; //for updating the Shows table on the main form 

            InitializeComponent();

            this.ActiveControl = txtShowProducer;

            // Create Show, Event, Class, Additional Money, and Entry Fee temp tables. 
            // We may not have to link the Events to the Show but we will need to link the Class temp table to the Events temp table, then AdditionalMoney and EntryFee temp tables 
            // to the Event and Class temp tables. This way the user can see what the event, class, fee, and addl money structure looks like before saving to the real tables. 
            //


            string dbConnectString = getConnectionString();

            string createTempClassesQuery = "create table tempClasses (eventIndex int, className varchar(50), entryfee float, additionalMoneyAmount float)";

            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                conn.Open();

                SqlCommand removeClassesTemp = new SqlCommand("IF OBJECT_ID('tempClasses') IS NOT NULL DROP TABLE tempClasses", conn);
                removeClassesTemp.ExecuteNonQuery();

                SqlCommand createTempClassesTable = new SqlCommand(createTempClassesQuery, conn);
                createTempClassesTable.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void btnAddEditShowCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {

            string newEvent = txtNewEventInput.Text;

            if (newEvent == "")
            {
                //do nothing
            }
            else
            {
                listEvents.Items.Add(newEvent);

                txtNewEventInput.Text = "";
            }
        }

        
        private void btnAddClass_Click(object sender, EventArgs e)
        {

            //SQL attempt
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
                string insertClassQuery = "insert into tempClasses (eventIndex, className, entryfee, additionalMoneyAmount) values (" + selectedEventIndex + ", '" + newClass + "', " + txtEntryFee.Text + ", " + txtAdditionalMoney.Text + ")";

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
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
            }
        }

        private void listEvents_SelectedValueChanged(object sender, EventArgs e)
        {
            //for debug
            //int entryIndex = listEvents.SelectedIndex;
            //MessageBox.Show("Event Index is " + entryIndex);

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

        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            //TODO: Need to prevent removal of an event after a Rider/Horse entry has been added and updated with a Time using that Event. 
            //      This is needed to prevent data integrity issues.

            int eventToDeleteIndex = listEvents.SelectedIndex;
            string connection = getConnectionString();
            string deleteClassesFromRemovedEvent = "delete from tempClasses where eventIndex = " + eventToDeleteIndex;
            string classTempUpdateQuery = "update tempClasses set eventIndex = (eventIndex - 1) where eventIndex > " + eventToDeleteIndex;

            if (listEvents.SelectedIndex != -1)
            {
                listEvents.Items.RemoveAt(eventToDeleteIndex);

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlCommand updateClassTemp = new SqlCommand(classTempUpdateQuery, conn);
                    SqlCommand deleteClassTemp = new SqlCommand(deleteClassesFromRemovedEvent, conn);
                    deleteClassTemp.ExecuteNonQuery();
                    updateClassTemp.ExecuteNonQuery();
                }

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
                string deleteClassFromTempClass = "delete from tempClasses where className = '" + classNameToDelete + "' and eventIndex = " + eventIndexForClassToDelete;

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlCommand deleteClass = new SqlCommand(deleteClassFromTempClass, conn);
                    deleteClass.ExecuteNonQuery();
                }

                updateClassList();
            }
        }

        private void frmAddShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dbConnectString = getConnectionString();

            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                conn.Open();
                SqlCommand removeClassesTemp = new SqlCommand("IF OBJECT_ID('tempClasses') IS NOT NULL DROP TABLE tempClasses", conn);
                removeClassesTemp.ExecuteNonQuery();
                conn.Close();
            }
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
            string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30";

            return dbConnectString;
        }

        private void btnAddEditShowSave_Click(object sender, EventArgs e)
        {
            //To save this to the database tables first we will need to insert the Show data and get the ID of the written record (see example below).
            //Once we have the ID of the show we need to iterate through the list of items in listEvents and create a new Event record for each, insertng the saved ShowID.
            //In each iteration we need to check the classTemp database for all Classes for that eventIndex, and write a Classes record for each, returning the ID of each record written
            //and using that ID to write a EventMoney record with the saved EventID, entryFee and AdditionalMoneyAmount in their respective columns.
            //This will write the relationships between the data.

            //Adding Records via sql...
            //Add the following line to the end of the Sql Query...
            //SELECT SCOPE_IDENTITY()
            //And then use the ExecuteScalar method on the SqlCommand object...
            //var rowCount = command.ExecuteScalar()

            string connection = getConnectionString();
            string insertShowsTableQuery = "insert into Shows (ShowProducer, ShowContact, ShowPhoneNumber, ShowDate, ShowLocation, ShowNotes) values ('" + txtShowProducer.Text + "', '" + txtContactName.Text + "', '" + txtPhoneNumber.Text + "', '" + dateShowDate.Value.Date.ToString() + "', '" + txtLocation.Text + "', '" + txtNotes.Text + "') SELECT SCOPE_IDENTITY()";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand insertShows = new SqlCommand(insertShowsTableQuery, conn);
                var showID = insertShows.ExecuteScalar();
                int showIDint = Convert.ToInt32(showID);

                //foreach (object item in listEvents.Items)
                for (int i=0; i < listEvents.Items.Count; i++)
                {
                    string eventName = listEvents.Items[i].ToString();
                    string insertEventsQuery = "insert into Events (EventName, Link2ShowID) values ('" + eventName + "', " + showIDint + ") SELECT SCOPE_IDENTITY()";
                    string returnClassesInEventQuery = "select className, entryfee, additionalMoneyAmount from tempClasses where eventIndex = " + i;

                    SqlConnection events = new SqlConnection(connection);
                    SqlCommand insertEvents = new SqlCommand(insertEventsQuery, events);
                    events.Open();
                    var EventID = insertEvents.ExecuteScalar();
                    int eventIDint = Convert.ToInt32(EventID);

                    SqlCommand returnClasses = new SqlCommand(returnClassesInEventQuery, conn);

                    using (SqlDataReader reader = returnClasses.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string insertClassesQuery = "insert into Classes (ClassName, Link2EventID) values ('" + reader["className"].ToString() + "', " + eventIDint + ") SELECT SCOPE_IDENTITY()";
                            SqlConnection conn2 = new SqlConnection(connection);
                            SqlCommand insertClasses = new SqlCommand(insertClassesQuery, conn2);
                            conn2.Open();
                            var ClassID = insertClasses.ExecuteScalar();
                            int classIDint = Convert.ToInt32(ClassID);

                            string insertEventMoneyQuery = "insert into EventMoney (Link2EventID, Link2ClassID, EntryFee, AdditionalMoneyAmount) values (" + eventIDint + ", " + classIDint + ", " + reader["entryFee"].ToString() + ", " + reader["additionalMoneyAmount"].ToString() + ")";
                            SqlCommand insertEventMoney = new SqlCommand(insertEventMoneyQuery, conn2);
                            insertEventMoney.ExecuteNonQuery();
                        }
                    }
                }
            }

            //for debug
            //MessageBox.Show("Record added!");

            _updateShowsTable(); //for updating the Shows table on the main form

            this.Close();
        }
    }
}
