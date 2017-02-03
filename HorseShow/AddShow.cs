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

            //string createTempShowsQuery = "create table #tempShows (ShowID int, ShowProducer varchar, ShowContact varchar, ShowPhoneNumber varchar, ShowDate date, ShowLocation varchar, ShowNotes varchar";

            //string createTempEntryFeeQuery = "create table #tempEntryFees (EntryFeeID int, Link2EventID int, Link2ClassID int, FeeAmount float)";
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

            //var eventsList = new Dictionary<string, List<eventClasses>>();



        }

        private void btnAddEditShowCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            //string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30";
            //string createTempEventQuery = "create table #tempEvents (EventID int IDENTITY (1, 1) NOT NULL, EventName varchar, Link2ShowID int)";
            //string createTempClassesQuery = "create table #tempClasses (ClassID int IDENTITY (1, 1) NOT NULL, ClassName varchar, Link2EventID int, EntryFee float, AdditionalMoneyAmount float)";


            //using (SqlConnection conn = new SqlConnection(dbConnectString))
            //{
            //    conn.Open();

            //    SqlCommand createTempEventsTable = new SqlCommand(createTempEventQuery);
            //    SqlCommand createTempClassesTable = new SqlCommand(createTempClassesQuery);
            //    SqlCommand addEvent = new SqlCommand("insert into #tempEvents (EventName, Link2ShowID) values ('" + txtNewEventInput + "', 1)");

            //    using (SqlDataAdapter a = new SqlDataAdapter("SELECT EventName FROM #tempEvents", conn))
            //    {
            //        // fill a data table
            //        var t = new DataTable();
            //        a.Fill(t);

            //        // Bind the table to the list box
            //        listEvents.DisplayMember = "Events";
            //        listEvents.ValueMember = "EventName";
            //        listEvents.DataSource = t;
            //    }
            //    conn.Close();
            //}

            //var newEvent = new eventClasses
            //{
            //    eventName = txtNewEventInput.Text
            //};

            //classViewList listOfClasses = new classViewList()
            //{
            //    classList = new List<eventClasses>()
            //};

            //listOfClasses.classList.Add(newEvent);

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
            //string newClass = txtNewClassInput.Text;

            ////Check to see if the listEvents has any entries. If not, error out. A Class is a child of an Event.
            //if (listEvents.Items.Count == 0)
            //{
            //    MessageBox.Show("Please add an Event first!");
            //} else if (newClass == "")
            //{
            //    //do nothing
            //}else if (listEvents.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Please select an Event for this Class.");
            //}else
            //{
            //    MessageBox.Show("You added a Class!"); //debug

            //    int selectedEventIndex = listEvents.SelectedIndex;

            //    var newClassEntry = new eventClasses
            //    {
            //        eventIndex = selectedEventIndex,
            //        className = newClass, 
            //        entryFee = 0,
            //        additionalMoneyAmount = 0
            //    };

            //    classViewList listOfClasses = new classViewList()
            //    {
            //        classList = new List<eventClasses>()
            //    };

            //    listOfClasses.classList.Add(newClassEntry);

            //    var classesForEvent = listOfClasses.classList.Where(item => item.eventIndex == selectedEventIndex);

            //    foreach (var index in classesForEvent)
            //    {
            //        listClasses.Items.Add(index.className);
            //    }

            //    txtNewClassInput.Text = "";

            //}

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
                    //SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlListClasses);
                    //DataTable classTable = new DataTable();
                    //sqlDataAdap.Fill(classTable);

                    //listClasses.DataSource = classTable;

                    //var reader = sqlListClasses.ExecuteReader();

                    listClasses.Items.Clear();

                    using (SqlDataReader reader = sqlListClasses.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listClasses.Items.Add(reader["className"].ToString());
                        }
                    }
                    
                    //listClasses.DataSource = reader;
                }

                

                txtNewClassInput.Text = "";
            }
        }

        private void listEvents_SelectedValueChanged(object sender, EventArgs e)
        {
            //for debug
            //int entryIndex = listEvents.SelectedIndex;
            //MessageBox.Show("Event Index is " + entryIndex);

            //int selectedEventIndex = listEvents.SelectedIndex;

            //listClasses.Items.Clear();

            //classViewList listOfClasses = new classViewList()
            //{
            //    classList = new List<eventClasses>()
            //};

            //var classesForEvent = listOfClasses.classList.Where(item => item.eventIndex == selectedEventIndex);

            //foreach (var index in classesForEvent)
            //{
            //    listClasses.Items.Add(index.className);
            //}

            //SQL Attempt
            int selectedEventIndex = listEvents.SelectedIndex;
            string connection = getConnectionString();
            string classListView = "select className from tempClasses where eventIndex = " + selectedEventIndex;

            if (!(listClasses.Items.Count == 0))
            {
                //SqlConnection conn = new SqlConnection(connection);
                //SqlCommand sqlListClasses = new SqlCommand(classListView);
                //sqlListClasses.Connection = conn; 
                //SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlListClasses);

                //DataTable classTable = new DataTable();
                //sqlDataAdap.Fill(classTable);

                //listClasses.DataSource = classTable;

                //using (SqlDataReader reader = sqlListClasses.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        listClasses.DataSource = reader["className"].ToString();
                //    }
                //}

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

                    grdClassViewTest.DataSource = listClasses; //debug
                }
            }

        }

        private void frmAddShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dbConnectString = getConnectionString();
            // example: IF OBJECT_ID('tempdb..#Results') IS NOT NULL DROP TABLE #Results

            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                conn.Open();
                //SqlCommand removeEventTemp = new SqlCommand("IF OBJECT_ID('#tempEvents') IS NOT NULL DROP TABLE #tempEvents");
                SqlCommand removeClassesTemp = new SqlCommand("IF OBJECT_ID('tempClasses') IS NOT NULL DROP TABLE tempClasses");
                conn.Close();
            }
        }

        public static string getConnectionString()
        {
            string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30";

            return dbConnectString;
        }
    }


    public class eventClasses
    {
        public float entryFee { get; set; }
        public float additionalMoneyAmount { get; set; }
        public string className { get; set; }
        public int eventIndex { get; set; }
    }

    public class classViewList
    {
        public List<eventClasses> classList { get; set; }
    }
}
