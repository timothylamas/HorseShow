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
    public partial class frmAdminConsole : Form
    {
        public frmAdminConsole()
        {
            InitializeComponent();
        }

        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            string connect = getConnectionString();
            string sqlQuery = txtSQLQuery.Text;

            using (SqlConnection conn = new SqlConnection(connect))
            {
                try
                {


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, conn);

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);

                    grdSQLResults.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem with your query: \n\n" + ex.GetBaseException(),"Error");
                }
            }

        }

        private void txtSQLQuery_KeyDown(object sender, KeyEventArgs e)
        {
            //allows pressing Enter to run the query

            if (e.KeyCode == Keys.Enter)
            {
                btnRunQuery_Click(this, new EventArgs());
            }
        }

        public static string getConnectionString()
        {
            string dbConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HorseShowDB.mdf;Integrated Security=True;Connect Timeout=30";

            return dbConnectString;
        }
    }
}
