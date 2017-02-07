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

            //Create the tempClasses DB so we can load the Event/Class structure into it.
            string dbConnectString = getConnectionString();
            string createTempClassesQuery = "create table tempClasses (eventIndex int, className varchar(50), entryfee float, additionalMoneyAmount float)";

            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                conn.Open();

                SqlCommand removeClassesTemp = new SqlCommand("IF OBJECT_ID('tempClasses') IS NOT NULL DROP TABLE tempClasses", conn);
                removeClassesTemp.ExecuteNonQuery();

                SqlCommand createTempClassesTable = new SqlCommand(createTempClassesQuery, conn);
                createTempClassesTable.ExecuteNonQuery();
            }

            //Now the fun part of getting the data from the database and filling in the values of all controls on the page, keeping data integrity. 
            //For the Events, maybe we need a temp Events table and a temp Reference table to keep track of which listIndex value goes with which EventID from the database.
            //Updating the Events table, dealing with existing vs new events, will be tricky. We cannot under any circumstance edit an Event or Class if someone is signed up for it. 
            //The whole show will need to be deleted in that case. 

            string retreiveDataQuery = "select showproducer, showcontact, showphonenumber, showdate, showlocation, shownotes from Shows where showID = " + showIDValue;


            using (SqlConnection conn = new SqlConnection(dbConnectString))
            {
                SqlCommand retreiveData = new SqlCommand(retreiveDataQuery, conn);
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
                }

                //need to populate the Events and Classes lsits
            }

        }

        private void btnAddEditShowCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string getConnectionString()
        {
            string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30";

            return dbConnectString;
        }
    }
}
