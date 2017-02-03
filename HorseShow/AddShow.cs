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

        public frmAddShow()
        {
            InitializeComponent();

            //// Create Show, Event, Class, Additional Money, and Entry Fee temp tables. 
            //// We may not have to link the Events to the Show but we will need to link the Class temp table to the Events temp table, then AdditionalMoney and EntryFee temp tables 
            //// to the Event and Class temp tables. This way the user can see what the event, class, fee, and addl money structure looks like before saving to the real tables. 
            ////
            ////Adding Records via sql...
            ////Add the following line to the end of the Sql Query...
            ////SELECT SCOPE_IDENTITY()
            ////And then use the ExecuteScalar method on the SqlCommand object...
            ////var rowCount = command.ExecuteScalar()

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
            string insertClassQuery = "insert into tempClasses (eventIndex, className, entryfee, additionalMoneyAmount) values (" + selectedEventIndex + ", '" + newClass + "',0.0,0.0)";
            string classListView = "select className from tempClasses where eventIndex = " + selectedEventIndex;

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
            else
            {
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

            //SQL Attempt
            int selectedEventIndex = listEvents.SelectedIndex;
            string connection = getConnectionString();
            string classListView = "select className from tempClasses where eventIndex = " + selectedEventIndex;

            if (!(listClasses.Items.Count == 0))
            {

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
        }

        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            //remove logic will require an algorithm to update the eventIndex column in the tempClasses table to be one index less for 
            //all indexes with a number greater than the index deleted, updated to be 1 less
            //delete all classes associated with the selected eventIndex.
            //TODO: Need to prevent removal of an event after a Rider/Horse entry has been added and updated with a Time using that Event. 
            //      This is needed to prevent data integrity issues.

            int eventToDeleteIndex = listEvents.SelectedIndex;
            string connection = getConnectionString();

            listEvents.Items.RemoveAt(eventToDeleteIndex);


        }

        private void frmAddShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dbConnectString = getConnectionString();
            // example: IF OBJECT_ID('tempdb..#Results') IS NOT NULL DROP TABLE #Results

            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                conn.Open();
                SqlCommand removeClassesTemp = new SqlCommand("IF OBJECT_ID('tempClasses') IS NOT NULL DROP TABLE tempClasses", conn);
                removeClassesTemp.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static string getConnectionString()
        {
            string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30";

            return dbConnectString;
        }
    }
}
