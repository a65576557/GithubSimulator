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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
         public  Form1 form1 = new Form1();
        SqlConnectionStringBuilder scsb;


        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "username"&&txtpassword.Text=="password")
            {
                this.DialogResult = DialogResult.OK;

               form1.button1.Enabled = true;
                form1.btnVCH.Enabled = true;
                form1.btnAPM.Enabled = true;
                form1.btntm.Enabled = true;
                
                form1.button7.Enabled = true;
                form1.btnRecipe.Enabled = true;
                form1.btnEventLog.Enabled = true;
                form1.btnLogger.Enabled = true;
                form1.btnconfig.Enabled = true;
               // form1.button4.Enabled = true;
               // form1.button5.Enabled = true;
              //  form1.button3.Enabled = true;

                form1.lbllog.Text = "System: Control";

                form1.btnLogIn.Tag = "LogOut";



                scsb = new SqlConnectionStringBuilder();
             
                scsb.DataSource = @"HP-PC\SQLEXPRESS";
                scsb.InitialCatalog = "RecipeType";
                scsb.IntegratedSecurity = true;
                SqlConnection con = new SqlConnection(scsb.ToString());

                con.Open();

                string strSQL = "insert into EventLog (Date,Event,Info) values(@1,@2,@3)";
                SqlCommand cmd = new SqlCommand(strSQL,con);

                cmd.Parameters.AddWithValue("@1",DateTime.Now);
                cmd.Parameters.AddWithValue("@2", "Machine user logged in");
                cmd.Parameters.AddWithValue("@3", "User:username access level: me with control");

                cmd.ExecuteNonQuery();
                con.Close();


            }
            if(txtusername.Text!="username"&&txtpassword.Text!="password")
            {

                MessageBox.Show("Unknown user"+" "+txtusername.Text);

            }
            if (txtusername.Text == "username" && txtpassword.Text != "password")
            {
                MessageBox.Show("Invaild password for user username" );
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
