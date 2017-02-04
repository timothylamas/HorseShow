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
            

            frmAddShow showData = new frmAddShow();

            showData.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataViewShowsTable.viewShowsTable' table. You can move, or remove it, as needed.
            this.viewShowsTableTableAdapter.Fill(this.dataViewShowsTable.viewShowsTable);

        }

        private void btnRefreshShows_Click(object sender, EventArgs e)
        {
            grdShowsTable.DataSource = viewShowsTableBindingSource;
        }
    }
}
