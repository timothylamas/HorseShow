﻿using System;
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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();

            //Code to remove the tabs from the tabForms
            //copied from answer on this page: http://stackoverflow.com/questions/552579/how-to-hide-tabpage-from-tabcontrol
            //tabForms.Appearance = TabAppearance.FlatButtons;
            tabForms.ItemSize = new Size(0, 1);
            tabForms.SizeMode = TabSizeMode.Fixed;

            updateShowsTable();

            //add the Edit and Delete buttons to the grdShowsTable datagridview 
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            grdShowsTable.Columns.Add(btnEdit);
            btnEdit.Text = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            grdShowsTable.Columns.Add(btnDelete);
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;

            grdShowsTable.Columns[0].Visible = false;

            //add checkbox column to Classes list entry
            DataGridViewCheckBoxColumn classesEntryCheckboxColumn = new DataGridViewCheckBoxColumn();
            classesEntryCheckboxColumn.Width = 35;
            classesEntryCheckboxColumn.ReadOnly = false;
            classesEntryCheckboxColumn.TrueValue = 1;
            classesEntryCheckboxColumn.FalseValue = 0;
            grdClassesEntry.Columns.Add(classesEntryCheckboxColumn);

            //fill in the Shows drop-down on the Rider/Horse Entry tab
            string connectionString = getConnectionString();

            DataTable showsTable = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT showID, showProducer + ' - ' + CONVERT(varchar(50),showDate,1) as 'showName' from Shows", con);
                    adapter.Fill(showsTable);

                    cmbRiderHorseEntryShowSelection.DataSource = showsTable;
                    cmbRiderHorseEntryShowSelection.DisplayMember = "showName";
                    cmbRiderHorseEntryShowSelection.ValueMember = "showID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tabForms.SelectedTab = tabHorseRiderEntry;
        }

        private void stripShows_Click(object sender, EventArgs e)
        {
            tabForms.SelectedTab = tabShows;
        }

        private void btnNewShow_Click(object sender, EventArgs e)
        {
            
            frmAddShow showData = new frmAddShow(updateShowsTable);

            showData.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataViewShowsTable1.viewShowsTable' table. You can move, or remove it, as needed.
            this.viewShowsTableTableAdapter.Fill(this.dataViewShowsTable1.viewShowsTable);
            //// TODO: This line of code loads data into the 'dataViewShowsTable.viewShowsTable' table. You can move, or remove it, as needed.
            //this.viewShowsTableTableAdapter.Fill(this.dataViewShowsTable.viewShowsTable);
            //// TODO: This line of code loads data into the 'dataViewShowsTable.viewShowsTable' table. You can move, or remove it, as needed.
            //this.viewShowsTableTableAdapter.Fill(this.dataViewShowsTable.viewShowsTable);
            updateShowsTable();

        }

        private void btnRefreshShows_Click(object sender, EventArgs e)
        {

            updateShowsTable();

        }

        public void updateShowsTable()
        {
            string connect = getConnectionString();
            string updateQuery = "select * from viewShowsTable";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(updateQuery, connect);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            grdShowsTable.DataSource = table;
        }

        public static string getConnectionString()
        {
            string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30";

            return dbConnectString;
        }

        private void adminConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminConsole admin = new frmAdminConsole();

            admin.Show();
        }

        private void grdShowsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit columnIndex is 0
            //Delete columnIndex is 1

            //get the ShowID (which is in a hidden column) from the Shows table
            int selectedrowindex = grdShowsTable.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = grdShowsTable.Rows[selectedrowindex];
            string a = selectedRow.Cells["ID"].Value.ToString();

            //for debug
            //MessageBox.Show("ShowID to pass is " + a + ", column index is "+e.ColumnIndex);

            if (e.ColumnIndex == 0) //Edit
            {
                frmEditShow editShow = new frmEditShow(a, updateShowsTable);
                editShow.Show();

            }else if (e.ColumnIndex == 1) //Delete
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the entire show? The data will be permanently lost!", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string connection = getConnectionString();
                    string deleteEventMoneyQuery = "delete em from eventMoney em join events ev on ev.eventID = em.link2eventID join shows sh on sh.showID = ev.link2showID where sh.showID = " + a;
                    string deleteClassesQuery = "delete cl from Classes cl join events ev on cl.link2eventID = ev.eventID join shows sh on ev.link2showID = sh.showid where sh.showid = " + a;
                    string deleteEventsQuery = "delete ev from Events ev join Shows sh on ev.link2showID = sh.showID where sh.showID = " + a;
                    string deleteShowQuery = "delete from shows where showID = " + a;

                    using (SqlConnection conn = new SqlConnection(connection))
                    {
                        SqlCommand deleteEventMoney = new SqlCommand(deleteEventMoneyQuery, conn);
                        SqlCommand deleteClasses = new SqlCommand(deleteClassesQuery, conn);
                        SqlCommand deleteEvents = new SqlCommand(deleteEventsQuery, conn);
                        SqlCommand deleteShow = new SqlCommand(deleteShowQuery, conn);

                        conn.Open();

                        deleteEventMoney.ExecuteNonQuery();
                        deleteClasses.ExecuteNonQuery();
                        deleteEvents.ExecuteNonQuery();
                        deleteShow.ExecuteNonQuery();

                    }

                    MessageBox.Show("Show has been deleted.");
                    updateShowsTable();
                }
                else if (dialogResult == DialogResult.No)
                {
                    updateShowsTable();
                }
            }
        }

        private void cmbRiderHorseEntryShowSelection_Click(object sender, EventArgs e)
        {
            //When the user clicks the Show selection drop-down we need to populate it with  list of shows. 
            //I went with showing the date as well since its possible to have many entries of the same ShowProducer. 

            string connectionString = getConnectionString();

            DataTable showsTable = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT showID, showProducer + ' - ' + CONVERT(varchar(50),showDate,1) as 'showName' from Shows", con);
                    adapter.Fill(showsTable);

                    cmbRiderHorseEntryShowSelection.DataSource = showsTable;
                    cmbRiderHorseEntryShowSelection.DisplayMember = "showName";
                    cmbRiderHorseEntryShowSelection.ValueMember = "showID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            // Add the initial item - you can add this even if the options from the
            // db were not successfully loaded
            //cmbRiderHorseEntryShowSelection.Items.Insert(0, new ListItem("<Select Subject>", "0"));

        }

        private void cmbRiderHorseEntryShowSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When a show is selected we need to update the Events list with events for that show. 

            //for debug
            label2.Text = cmbRiderHorseEntryShowSelection.SelectedValue.ToString();

            DataTable eventTable = new DataTable();
            string connect = getConnectionString();
            string viewEventsForShowQuery = "select eventName, eventID from Events where link2showID = " + cmbRiderHorseEntryShowSelection.SelectedValue.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(viewEventsForShowQuery, conn);
                    dataAdapter.Fill(eventTable);

                    cmbEventEntry.DataSource = eventTable;
                    cmbEventEntry.DisplayMember = "eventName";
                    cmbEventEntry.ValueMember = "eventID";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            

        }

        private void cmbEventEntry_SelectedValueChanged(object sender, EventArgs e)
        {
            string connnection = getConnectionString();
            string viewClassesForEventsEntryQuery = "select classname, classID from classes where link2eventID = " + cmbEventEntry.SelectedValue.ToString();

            //for debug
            //MessageBox.Show("eventID is " + cmbEventEntry.SelectedValue.ToString());
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(viewClassesForEventsEntryQuery, connnection);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                grdClassesEntry.DataSource = table;
                grdClassesEntry.Columns[1].ReadOnly = true;
                grdClassesEntry.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
