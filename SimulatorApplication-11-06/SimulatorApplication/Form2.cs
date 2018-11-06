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
    public partial class Form2 : Form
    {
        //public static string cassetterecipename;
        SqlConnectionStringBuilder scsb;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSql = "select * from CassetteRecipe ";
            SqlCommand cmd = new SqlCommand(strSql, con);
            SqlDataReader reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                listBox1.Items.Add(reader["CassetterecipeName"]);

            }
         
            con.Close();






        }
        private string Msg;

        private void btnOK_Click(object sender, EventArgs e)
        {

            Msg = listBox1.SelectedItem.ToString();



        }
        public string GetMsg()
        {
            return Msg;
        }
    }
}
