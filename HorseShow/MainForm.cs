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

            //initialize the grdEntryTable 
            DataTable entryTable = new DataTable();
            string viewEntryTableQuery = "select entryID, drawNumber as 'Draw Number', riderName as 'Rider Name', horseName as 'Horse Name', runtime as 'Run Time', entryfee as 'Entry Fee', randomized from Entry where link2showID = 0 and link2eventID = 0 and link2classID = 0";

            try
            {
                using (SqlConnection conn = new SqlConnection(getConnectionString()))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(viewEntryTableQuery, conn);
                    conn.Open();
                    dataAdapter.Fill(entryTable);

                    grdEntryTable.DataSource = entryTable;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            
            //add the Delete buttons to the grdEntryTable datagridview
            DataGridViewButtonColumn btnEntryDelete = new DataGridViewButtonColumn();
            grdEntryTable.Columns.Add(btnEntryDelete);
            btnEntryDelete.Text = "Delete";
            btnEntryDelete.UseColumnTextForButtonValue = true;

            grdEntryTable.Columns["entryID"].Visible = false;
            grdEntryTable.Columns["randomized"].Visible = false;

            //make specific columns in grdEntryTable read-only, so that only Run Time is editable
            grdEntryTable.Columns["Draw Number"].ReadOnly = true;
            grdEntryTable.Columns["Rider Name"].ReadOnly = true;
            //grdEntryTable.Columns["Horse Name"].ReadOnly = true;
            grdEntryTable.Columns["Entry Fee"].ReadOnly = true;

            //add checkbox column to Classes list entry
            DataGridViewCheckBoxColumn classesEntryCheckboxColumn = new DataGridViewCheckBoxColumn();
            classesEntryCheckboxColumn.Name = "isChecked";
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

        private void adminConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminConsole admin = new frmAdminConsole();

            admin.Show();
        }

        private void grdShowsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit columnIndex is 0
            //Delete columnIndex is 1

            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
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

                    }
                    else if (e.ColumnIndex == 1) //Delete
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
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void grdEntryTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cell Index is 0 for Delete button

            //for debug
            //MessageBox.Show("Index is " + e.ColumnIndex);
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    if (e.ColumnIndex == 0)
                    {
                        int selectedRowIndex = grdEntryTable.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = grdEntryTable.Rows[selectedRowIndex];
                        string index = selectedRow.Cells["entryID"].Value.ToString();
                        string randomized = selectedRow.Cells["randomized"].Value.ToString();

                        if (randomized != "1")
                        {  
                            using (SqlConnection conn = new SqlConnection(getConnectionString()))
                            {
                                conn.Open();
                                string deleteEntryRecordQuery = "delete from entry where entryID = " + index;
                                SqlCommand deleteEntryRecord = new SqlCommand(deleteEntryRecordQuery, conn);
                                deleteEntryRecord.ExecuteNonQuery();
                            }

                            updateEntryTable(); 
                        }
                        else
                        {
                            MessageBox.Show("The draw order for this entry has already been determined!\nThe entry can not be deleted.");
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
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

            DataTable eventTable = new DataTable();
            DataTable eventDataTable = new DataTable();
            string connect = getConnectionString();
            string viewEventsForShowQuery = "select eventName, eventID from Events where link2showID = " + cmbRiderHorseEntryShowSelection.SelectedValue.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(viewEventsForShowQuery, conn);
                    dataAdapter.Fill(eventTable);
                    dataAdapter.Fill(eventDataTable);

                    cmbEventEntry.DataSource = eventTable;
                    cmbEventEntry.DisplayMember = "eventName";
                    cmbEventEntry.ValueMember = "eventID";

                    cmbEntryTableEvents.DataSource = eventDataTable;
                    cmbEntryTableEvents.DisplayMember = "eventName";
                    cmbEntryTableEvents.ValueMember = "eventID";
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

        private void cmbEntryTableEvents_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable classDataTable = new DataTable();
            string connect = getConnectionString();
            string viewClassesForShowQuery = "select className, classID from Classes where link2eventID = " + cmbEntryTableEvents.SelectedValue.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(viewClassesForShowQuery, conn);
                    dataAdapter.Fill(classDataTable);

                    cmbEntryTableClasses.DataSource = classDataTable;
                    cmbEntryTableClasses.DisplayMember = "className";
                    cmbEntryTableClasses.ValueMember = "classID";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void cmbEntryTableClasses_SelectedValueChanged(object sender, EventArgs e)
        {
            updateEntryTable();
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            string connect = getConnectionString();
            string showID = cmbRiderHorseEntryShowSelection.SelectedValue.ToString();
            string eventID = cmbEventEntry.SelectedValue.ToString();
            string riderName = txtRiderNameEntry.Text;
            string horseName = txtHorseNameEntry.Text;
            bool classIsSelected = false;

            try
            {
                //need some validation checking here. 
                //1: Is there at least 1 Class checked? 
                //2: Does the Rider Name already exist for this Event + Class?

                foreach (DataGridViewRow row in grdClassesEntry.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["isChecked"].Value) == true)
                        classIsSelected = true;
                }

                using (SqlConnection conn = new SqlConnection(connect))
                {
                    if (!classIsSelected)
                    {
                        MessageBox.Show("Please select at least one Class to enter.");
                    }
                    else if (riderName == "")
                    {
                        MessageBox.Show("Rider name can not be blank.");
                    }
                    else if (horseName == "")
                    {
                        MessageBox.Show("Horse name can not be blank.");
                    }
                    else
                    {
                        conn.Open();

                        foreach (DataGridViewRow row in grdClassesEntry.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["isChecked"].Value) == true)
                            {
                                //for debug
                                //MessageBox.Show("ShowID is " + showID + ", EventID is "+eventID+", classID is "+ row.Cells["classID"].Value.ToString());

                                string classID = row.Cells["classID"].Value.ToString();

                                string riderNameToCheck = txtRiderNameEntry.Text.ToUpper();
                                string horseNameToCheck = txtHorseNameEntry.Text.ToUpper();
                                bool duplicateRider = false;
                                string checkRiderNameDupesQuery = "select riderName, horseName from entry where link2showID = " + showID + " and link2eventID = " + eventID + " and link2classID = " + classID;
                                SqlCommand checkRiderNameDupes = new SqlCommand(checkRiderNameDupesQuery, conn);
                                using (SqlDataReader checkDupes = checkRiderNameDupes.ExecuteReader())
                                {
                                    while (checkDupes.Read())
                                    {
                                        if (((checkDupes["riderName"].ToString().ToUpper()) == riderNameToCheck) && ((checkDupes["horseName"].ToString().ToUpper()) == horseNameToCheck))
                                        {
                                            duplicateRider = true;
                                        }
                                    }
                                }
                                if (duplicateRider)
                                {
                                    MessageBox.Show(riderName + " riding " + horseName + " is already entered in the " + row.Cells["className"].Value.ToString() + " class for the selected event.");
                                }
                                else
                                {
                                    string entryFee = "0";
                                    string getEntryFeeQuery = "select entryfee from eventmoney where link2eventID = " + eventID + " and link2classID = " + classID;
                                    SqlCommand getEntryFee = new SqlCommand(getEntryFeeQuery, conn);
                                    using (SqlDataReader reader = getEntryFee.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            entryFee = reader["entryFee"].ToString();
                                        }
                                    }

                                    string insertEntryQuery = "insert into Entry (link2showid, link2eventid, link2classid, ridername, horsename, entryfee) values (" + showID + ", " + eventID + ", " + classID + ", '" + riderName + "', '" + horseName + "', " + entryFee + ")";
                                    SqlCommand insertEntry = new SqlCommand(insertEntryQuery, conn);
                                    insertEntry.ExecuteNonQuery();
                                }
                            }
                        }

                        //blank the fields for the next entry
                        txtRiderNameEntry.Text = "";
                        txtHorseNameEntry.Text = "";

                        foreach (DataGridViewRow row in grdClassesEntry.Rows)
                        {
                            row.Cells["isChecked"].Value = 0;
                        }

                        updateEntryTable();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void grdEntryTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Column index for Run Time is 5
            //Column index for Horse Name is 4
            string showID = cmbRiderHorseEntryShowSelection.SelectedValue.ToString();
            string eventID = cmbEventEntry.SelectedValue.ToString();
            string classID = cmbEntryTableClasses.SelectedValue.ToString();

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    try
                    {
                        string newTime = grdEntryTable.SelectedCells[0].Value.ToString();
                        int selectedRowIndex = grdEntryTable.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = grdEntryTable.Rows[selectedRowIndex];
                        string index = selectedRow.Cells["entryID"].Value.ToString();
                        string riderName = selectedRow.Cells["Rider Name"].Value.ToString();
                        string horseName = selectedRow.Cells["Horse Name"].Value.ToString();

                        //for debug
                        //MessageBox.Show("your EntryID is " + index);

                        using (SqlConnection conn = new SqlConnection(getConnectionString()))
                        {
                            string updateTimeQuery = "update Entry set runtime = " + newTime + " where entryID = " + index;
                            SqlCommand updateTime = new SqlCommand(updateTimeQuery, conn);
                            conn.Open();
                            updateTime.ExecuteNonQuery();

                            //Record rollover times where applicable, prevent randomization, put them at the top of the Entry list for that class
                            string rolloverTimesQuery = "update Entry set drawNumber = 0, randomized = 1, runtime = " + newTime + " where link2classID <> "+classID+" and link2eventID = " + eventID + " and riderName = '" + riderName + "' and horseName = '" + horseName + "'";
                            SqlCommand rolloverTimes = new SqlCommand(rolloverTimesQuery, conn);
                            rolloverTimes.ExecuteNonQuery();
                        }

                        updateEntryTable();
                        grdEntryTable.Rows[selectedRowIndex].Selected = true;
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    int selectedRowIndex = grdEntryTable.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = grdEntryTable.Rows[selectedRowIndex];
                    string index = selectedRow.Cells["entryID"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(getConnectionString()))
                    {
                        string updateHorseNameQuery = "update Entry set horseName = '" + selectedRow.Cells["Horse Name"].Value.ToString() + "' where entryID = " + index;
                        SqlCommand updateHorseName = new SqlCommand(updateHorseNameQuery, conn);
                        conn.Open();
                        updateHorseName.ExecuteNonQuery();

                    }

                    updateEntryTable();
                }
            }
        }

        private void btnRandomizeEntries_Click(object sender, EventArgs e)
        {
            //Need ideas on the randomization algorithm
            //https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            //http://codereview.stackexchange.com/questions/141582/shuffles-male-or-females-names-based-on-fisher-yates-algorthim?rq=1

            //Determine the number of rows that have been randomized already. This will tell us the highest number in the draw order
            //for when entries are added after the initial draw.
            string maxDrawOrder;
            int maxDraw = 0;
            List<string> entries = new List<string>();
            List<string> randomizedEntries = new List<string>();
            string connect = getConnectionString();

            try
            {
                string eventID = cmbEntryTableEvents.SelectedValue.ToString();
                string classID = cmbEntryTableClasses.SelectedValue.ToString();
                string getMaxDrawOrderQuery = "select count(*) as count from Entry where randomized = 1 and link2showID = " + cmbRiderHorseEntryShowSelection.SelectedValue.ToString() + " and link2eventID = " + eventID + " and link2classID = " + classID;

                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlCommand getMaxDrawOrder = new SqlCommand(getMaxDrawOrderQuery, conn);
                    conn.Open();

                    using (SqlDataReader read = getMaxDrawOrder.ExecuteReader())
                    {  
                        while (read.Read())
                        {
                            maxDrawOrder = read["count"].ToString();
                            maxDraw = Convert.ToInt32(maxDrawOrder) + 1;
                        }
                    }
                }

                //Need to load entries into list before we randomize them
           
                DataTable entriesToShuffle = new DataTable();
                string loadEntriesQuery = "select entryID, drawNumber, riderName, randomized from Entry where randomized is null and link2showID = " + cmbRiderHorseEntryShowSelection.SelectedValue.ToString() + " and link2eventID = " + eventID + " and link2classID = " + classID;

                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(loadEntriesQuery, conn);
                    conn.Open();
                    dataAdapter.Fill(entriesToShuffle);

                    foreach (DataRow row in entriesToShuffle.Rows)
                    {
                        entries.Add(row["entryID"].ToString());
                    }

                    //Fisher-Yates randomize the list of EntryIDs
                    randomizedEntries = ShuffleList(entries);

                    //Iterate through the shuffled list and write them sequentially with incrementing Draw numbers
                    for (int i = 0; i < randomizedEntries.Count; i++ )
                    {
                        string updateDrawOrderQuery = "update Entry set randomized = 1, drawNumber = " + (maxDraw + i) + " where entryID = " + randomizedEntries[i];
                        SqlCommand updateDrawOrder = new SqlCommand(updateDrawOrderQuery, conn);
                        updateDrawOrder.ExecuteNonQuery();
                    }

                    updateEntryTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //After the list is shuffled we need to iterate the list for each Rider Name and check if they are within 15 riders of another of their runs
            //This will need more work.
        }

        public static string getConnectionString()
        {
            string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";

            return dbConnectString;
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

        public void updateEntryTable()
        {

            try
            {
                DataTable entryTable = new DataTable();
                string connect = getConnectionString();
                string eventID = cmbEntryTableEvents.SelectedValue.ToString();
                string classID = cmbEntryTableClasses.SelectedValue.ToString();
                string viewEntryTableQuery = "select entryID, drawNumber as 'Draw Number', riderName as 'Rider Name', horseName as 'Horse Name', CAST(runtime AS DECIMAL(10,3)) as 'Run Time', entryfee as 'Entry Fee', randomized from Entry where link2showID = " + cmbRiderHorseEntryShowSelection.SelectedValue.ToString() + " and link2eventID = " + eventID + " and link2classID = " + classID + " order by drawNumber asc";

                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(viewEntryTableQuery, conn);
                    conn.Open();
                    dataAdapter.Fill(entryTable);

                    grdEntryTable.DataSource = entryTable;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        public List<string> ShuffleList(List<string> entries)
        {
            //Fisher-Yates Shuffle
            Random random = new Random();
            string tmp = "";
            int length = entries.Count;
            for (int i = 0; i < length; i++)
            {
                int r = (int)(random.NextDouble() * (length - i));
                tmp = entries[r];
                entries[r] = entries[i];
                entries[i] = tmp;
            }

            return entries; 
        }
    }
}
