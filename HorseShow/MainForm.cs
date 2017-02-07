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
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
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
                frmEditShow editShow = new frmEditShow(a);
                editShow.Show();

            }else if (e.ColumnIndex == 1) //Delete
            {
                //delete logic goes here
            }
        }
    }
}
