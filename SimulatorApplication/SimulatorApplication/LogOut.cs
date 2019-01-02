using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorApplication
{
    public partial class LogOut : Form
    {
        public Form1 form1 = new Form1();
        public LogOut()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder scsb;

        private void button1_Click(object sender, EventArgs e)
        {
            form1.button1.Enabled = false;
            form1.btnVCH.Enabled = false;
            form1.btnAPM.Enabled = false;
            form1.btntm.Enabled = false;

            form1.btnChamber.Enabled = false;
            form1.button7.Enabled = false;
            form1.btnRecipe.Enabled = false;
            form1.btnEventLog.Enabled = false;
            form1.btnLogger.Enabled = false;
            form1.btnconfig.Enabled = false;

            //  form1.button3.Enabled = false;
            //  form1.button4.Enabled = false;
            //  form1.button5.Enabled = false;

            form1.btnLogIn.Image = Properties.Resources.login;

            form1.btnLogIn.Tag = "LogIn";
            form1.lbllog.Text = "System: Monitor";

            scsb = new SqlConnectionStringBuilder();

            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());

            con.Open();

            string strSQL = "insert into EventLog (Date,Event,Info) values(@1,@2,@3)";
            SqlCommand cmd = new SqlCommand(strSQL, con);

            cmd.Parameters.AddWithValue("@1", DateTime.Now);
            cmd.Parameters.AddWithValue("@2", "Machine user logged out");
            cmd.Parameters.AddWithValue("@3", "User:username access level: me with control");

            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void LogOut_Load(object sender, EventArgs e)
        {

        }
    }
}
