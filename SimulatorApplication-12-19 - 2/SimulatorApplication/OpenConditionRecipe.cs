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
    public partial class OpenConditionRecipe : Form
    {
        SqlConnectionStringBuilder scsb;

        public delegate void UpdateListbox(object sender, EventArgs e);

        public UpdateListbox updatelistbox;

        public string strtag;
        List<string> listmodulename = new List<string>();
        List<string> listtrigger = new List<string>();
        List<string> listparameter = new List<string>();
        List<string> listrecipe = new List<string>();
        List<string> listid = new List<string>();
        public OpenConditionRecipe()
        {
            InitializeComponent();
        }

        private void OpenConditionRecipe_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;

            lblid.Visible = false;
            lblid2.Visible = false;
            lblid3.Visible = false;
            lblid4.Visible = false;
            lblid5.Visible = false;
            lblid6.Visible = false;
            lblid7.Visible = false;
            lblid8.Visible = false;
            lblid9.Visible = false;
            lblid10.Visible = false;

            tbModulename.Text = "APM";
            tbModulename2.Text = "APM";
            tbModulename3.Text = "APM";
            tbModulename4.Text = "APM";
            tbModulename5.Text = "APM";
            tbModulename6.Text = "APM";
            tbModulename7.Text = "APM";
            tbModulename8.Text = "APM";
            tbModulename9.Text = "APM";
            tbModulename10.Text = "APM";

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
           
            SqlConnection con = new SqlConnection(scsb.ToString());

            con.Open();


            string strSQL1 = "select * from recipe ";

            SqlCommand cmd1 = new SqlCommand(strSQL1, con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                cmbRecipe.Items.Add(reader1["recipeName"]);
                cmbRecipe2.Items.Add(reader1["recipeName"]);
                cmbRecipe3.Items.Add(reader1["recipeName"]);
                cmbRecipe4.Items.Add(reader1["recipeName"]);
                cmbRecipe5.Items.Add(reader1["recipeName"]);
                cmbRecipe6.Items.Add(reader1["recipeName"]);
                cmbRecipe7.Items.Add(reader1["recipeName"]);
                cmbRecipe8.Items.Add(reader1["recipeName"]);
                cmbRecipe9.Items.Add(reader1["recipeName"]);
                cmbRecipe10.Items.Add(reader1["recipeName"]);

            }

            con.Close();
            con.Open();

            string strSQL = "select * from conditioning inner join conditionrecipe on conditioning.conditionrecipename = conditionrecipe.conditionrecipename where conditioning.conditionrecipename = @name";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@name", RecipeType.strSearchName);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listmodulename.Add(reader["modulename"].ToString());
               listtrigger.Add(reader["trigger"].ToString());
                listparameter.Add(reader["parameter"].ToString());
                listrecipe.Add(reader["recipe"].ToString());
                listid.Add(reader["conditioningid"].ToString());


            }

            if (listmodulename.Count == 1)
            {
                tbModulename.Text = listmodulename[0];
                cmbTrigger.Text = listtrigger[0];
                cmbParameter.Text = listparameter[0];
                cmbRecipe.Text = listrecipe[0];
                lblid.Text = listid[0];
                strtag = "panel1";


            }
            else if (listmodulename.Count == 2)
            {
                tbModulename.Text = listmodulename[0];
                cmbTrigger.Text = listtrigger[0];
                cmbParameter.Text = listparameter[0];
                cmbRecipe.Text = listrecipe[0];
                lblid.Text = listid[0];

                tbModulename2.Text = listmodulename[1];
                cmbTrigger2.Text = listtrigger[1];
                cmbParameter2.Text = listparameter[1];
                cmbRecipe2.Text = listrecipe[1];
                lblid2.Text = listid[1];

                panel2.Visible = true;

                strtag = "panel2";
            }
            else if (listmodulename.Count == 3)
            {
                tbModulename.Text = listmodulename[0];
                cmbTrigger.Text = listtrigger[0];
                cmbParameter.Text = listparameter[0];
                cmbRecipe.Text = listrecipe[0];
                lblid.Text = listid[0];


                tbModulename2.Text = listmodulename[1];
                cmbTrigger2.Text = listtrigger[1];
                cmbParameter2.Text = listparameter[1];
                cmbRecipe2.Text = listrecipe[1];
                lblid2.Text = listid[1];
                panel2.Visible = true;
                tbModulename3.Text = listmodulename[2];
                cmbTrigger3.Text = listtrigger[2];
                cmbParameter3.Text = listparameter[2];
                cmbRecipe3.Text = listrecipe[2];
                lblid3.Text = listid[2];
                panel3.Visible = true;

                strtag = "panel3";

            }
            else if (listmodulename.Count == 4)
            {
                tbModulename.Text = listmodulename[0];
                cmbTrigger.Text = listtrigger[0];
                cmbParameter.Text = listparameter[0];
                cmbRecipe.Text = listrecipe[0];
                lblid.Text = listid[0];

                tbModulename2.Text = listmodulename[1];
                cmbTrigger2.Text = listtrigger[1];
                cmbParameter2.Text = listparameter[1];
                cmbRecipe2.Text = listrecipe[1];
                lblid2.Text = listid[1];

                tbModulename3.Text = listmodulename[2];
                cmbTrigger3.Text = listtrigger[2];
                cmbParameter3.Text = listparameter[2];
                cmbRecipe3.Text = listrecipe[2];
                lblid3.Text = listid[2];

                tbModulename4.Text = listmodulename[3];
                cmbTrigger4.Text = listtrigger[3];
                cmbParameter4.Text = listparameter[3];
                cmbRecipe4.Text = listrecipe[3];
                lblid4.Text = listid[3];
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;

                strtag = "panel4";

            }
            else if (listmodulename.Count == 5)
            {
                tbModulename.Text = listmodulename[0];
                cmbTrigger.Text = listtrigger[0];
                cmbParameter.Text = listparameter[0];
                cmbRecipe.Text = listrecipe[0];
                lblid.Text = listid[0];

                tbModulename2.Text = listmodulename[1];
                cmbTrigger2.Text = listtrigger[1];
                cmbParameter2.Text = listparameter[1];
                cmbRecipe2.Text = listrecipe[1];
                lblid2.Text = listid[1];

                tbModulename3.Text = listmodulename[2];
                cmbTrigger3.Text = listtrigger[2];
                cmbParameter3.Text = listparameter[2];
                cmbRecipe3.Text = listrecipe[2];
                lblid3.Text = listid[2];

                tbModulename4.Text = listmodulename[3];
                cmbTrigger4.Text = listtrigger[3];
                cmbParameter4.Text = listparameter[3];
                cmbRecipe4.Text = listrecipe[3];
                lblid4.Text = listid[3];

                tbModulename5.Text = listmodulename[4];
                cmbTrigger5.Text = listtrigger[4];
                cmbParameter5.Text = listparameter[4];
                cmbRecipe5.Text = listrecipe[4];
                lblid5.Text = listid[4];
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;

                strtag = "panel5";
            }




        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (strtag)
            {


                case "panel2":
                    panel2.Visible = false;
                    strtag = "panel1";
                    break;

                case "panel3":
                    panel3.Visible = false;
                    strtag = "panel2";
                    break;
                case "panel4":
                    panel4.Visible = false;
                    strtag = "panel3";
                    break;

                case "panel5":
                    panel5.Visible = false;
                    strtag = "panel4";
                    break;

                case "panel6":
                    panel6.Visible = false;
                    strtag = "panel5";
                    break;

                case "panel7":
                    panel7.Visible = false;
                    strtag = "panel6";
                    break;

                case "panel8":
                    panel8.Visible = false;
                    strtag = "panel7";
                    break;

                case "panel9":
                    panel9.Visible = true;
                    strtag = "pane8";
                    break;

                case "pane10":
                    panel10.Visible = true;
                    strtag = "panel9";
                    break;

            
                    break;

            }














        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());



            con.Open();



            string strSQL = "update conditioning set modulename=@1,[trigger]=@2,parameter=@3,recipe=@4 where conditioningid = @id";
            string strSQL1 = "insert into conditioning(conditionrecipename,modulename,[trigger],parameter,recipe) values(@1,@2,@3,@4,@5)";
            string strDelete = "delete from conditioning where conditioningid = @id";


            if (strtag == "panel1"&&lblid2.Text =="no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

            }

            else if (strtag == "panel1" && lblid2.Text!="no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();



                SqlCommand cmd2 = new SqlCommand(strDelete, con);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();


            }





            else if (strtag == "panel2" && lblid2.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();


                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();


            }


            else if (strtag == "panel2" && lblid2.Text == "no") //lblid insert 1筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL1, con);
                cmd2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                cmd2.ExecuteNonQuery();
            }

            else if (strtag == "panel3" && lblid3.Text != "no" && lblid2.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbModulename3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbTrigger3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbParameter3.Text);
                cmd3.Parameters.AddWithValue("@4", cmbRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();

            }

            else if (strtag == "panel3" && lblid3.Text == "no" && lblid2.Text != "no")//lblid2 insert 1 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL1, con);
                cmd3.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd3.Parameters.AddWithValue("@2", tbModulename3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbTrigger3.Text);
                cmd3.Parameters.AddWithValue("@4", cmbParameter3.Text);
                cmd3.Parameters.AddWithValue("@5", cmbRecipe3.Text);
                cmd3.ExecuteNonQuery();


            }

            else if (strtag == "pane3" && lblid3.Text == "no" && lblid2.Text == "no")//lblid insert 2 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL1, con);
                cmd2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                cmd2.ExecuteNonQuery();




                SqlCommand cmd3 = new SqlCommand(strSQL1, con);
                cmd3.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd3.Parameters.AddWithValue("@2", tbModulename3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbTrigger3.Text);
                cmd3.Parameters.AddWithValue("@4", cmbParameter3.Text);
                cmd3.Parameters.AddWithValue("@5", cmbRecipe3.Text);
                cmd3.ExecuteNonQuery();


            }


            else if (strtag == "panel4" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")
            {

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbModulename3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbTrigger3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbParameter3.Text);
                cmd3.Parameters.AddWithValue("@4", cmbRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand(strSQL, con);
                cmd4.Parameters.AddWithValue("@1", tbModulename4.Text);
                cmd4.Parameters.AddWithValue("@2", cmbTrigger4.Text);
                cmd4.Parameters.AddWithValue("@3", cmbParameter4.Text);
                cmd4.Parameters.AddWithValue("@4", cmbRecipe4.Text);
                cmd4.Parameters.AddWithValue("@id", lblid4.Text);
                cmd4.ExecuteNonQuery();

            }

            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text != "no" && lblid2.Text != "no")//lblid3 insert 1 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbModulename3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbTrigger3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbParameter3.Text);
                cmd3.Parameters.AddWithValue("@4", cmbRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand(strSQL1, con);
                cmd4.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd4.Parameters.AddWithValue("@2", tbModulename4.Text);
                cmd4.Parameters.AddWithValue("@3", cmbTrigger4.Text);
                cmd4.Parameters.AddWithValue("@4", cmbParameter4.Text);
                cmd4.Parameters.AddWithValue("@5", cmbRecipe4.Text);
                cmd4.ExecuteNonQuery();

            }

            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text != "no")//lblid2 insert 2 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL1, con);
                cmd3.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd3.Parameters.AddWithValue("@2", tbModulename3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbTrigger3.Text);
                cmd3.Parameters.AddWithValue("@4", cmbParameter3.Text);
                cmd3.Parameters.AddWithValue("@5", cmbRecipe3.Text);
                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand(strSQL1, con);
                cmd4.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd4.Parameters.AddWithValue("@2", tbModulename4.Text);
                cmd4.Parameters.AddWithValue("@3", cmbTrigger4.Text);
                cmd4.Parameters.AddWithValue("@4", cmbParameter4.Text);
                cmd4.Parameters.AddWithValue("@5", cmbRecipe4.Text);
                cmd4.ExecuteNonQuery();
            }

            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text == "no")//lblid insert 3 筆
            {


                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL1, con);
                cmd2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                cmd2.ExecuteNonQuery();


                SqlCommand cmd3 = new SqlCommand(strSQL1, con);
                cmd3.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd3.Parameters.AddWithValue("@2", tbModulename3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbTrigger3.Text);
                cmd3.Parameters.AddWithValue("@4", cmbParameter3.Text);
                cmd3.Parameters.AddWithValue("@5", cmbRecipe3.Text);
                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand(strSQL1, con);
                cmd4.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmd4.Parameters.AddWithValue("@2", tbModulename4.Text);
                cmd4.Parameters.AddWithValue("@3", cmbTrigger4.Text);
                cmd4.Parameters.AddWithValue("@4", cmbParameter4.Text);
                cmd4.Parameters.AddWithValue("@5", cmbRecipe4.Text);
                cmd4.ExecuteNonQuery();




            }

            else if (strtag == "panel5" && lblid5.Text != "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbModulename.Text);
                cmd.Parameters.AddWithValue("@2", cmbTrigger.Text);
                cmd.Parameters.AddWithValue("@3", cmbParameter.Text);
                cmd.Parameters.AddWithValue("@4", cmbRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbModulename2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbTrigger2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbParameter2.Text);
                cmd2.Parameters.AddWithValue("@4", cmbRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbModulename3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbTrigger3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbParameter3.Text);
                cmd3.Parameters.AddWithValue("@4", cmbRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand(strSQL, con);
                cmd4.Parameters.AddWithValue("@1", tbModulename4.Text);
                cmd4.Parameters.AddWithValue("@2", cmbTrigger4.Text);
                cmd4.Parameters.AddWithValue("@3", cmbParameter4.Text);
                cmd4.Parameters.AddWithValue("@4", cmbRecipe4.Text);
                cmd4.Parameters.AddWithValue("@id", lblid4.Text);
                cmd4.ExecuteNonQuery();

                SqlCommand cmd5 = new SqlCommand(strSQL, con);
                cmd5.Parameters.AddWithValue("@1", tbModulename5.Text);
                cmd5.Parameters.AddWithValue("@2", cmbTrigger5.Text);
                cmd5.Parameters.AddWithValue("@3", cmbParameter5.Text);
                cmd5.Parameters.AddWithValue("@4", cmbRecipe5.Text);
                cmd5.Parameters.AddWithValue("@id", lblid5.Text);
                cmd5.ExecuteNonQuery();
            }

            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")//lblid4 insert 1 筆 
            {

            }
            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text != "no" && lblid2.Text != "no")//lblid3 insert 2 筆 
            {

            }
            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text != "no")//lblid2 insert 3 筆 
            {

            }
            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text == "no")//lblid4 insert 1 筆 
            {

            }

            MessageBox.Show("Save Successfully");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            switch (strtag)
            {
                case "panel1":
                    panel2.Visible = true;
                    strtag = "panel2";
                    break;

                case "panel2":
                    panel3.Visible = true;
                    strtag = "panel3";
                    break;

                case "panel3":
                    panel4.Visible = true;
                    strtag = "panel4";
                    break;
                case "panel4":
                    panel5.Visible = true;
                    strtag = "panel5";
                    break;

                case "panel5":
                    panel6.Visible = true;
                    strtag = "panel6";
                    break;

                case "panel6":
                    panel7.Visible = true;
                    strtag = "panel7";
                    break;

                case "panel7":
                    panel8.Visible = true;
                    strtag = "panel8";
                    break;

                case "panel8":
                    panel9.Visible = true;
                    strtag = "panel9";
                    break;

                case "panel9":
                    panel10.Visible = true;
                    strtag = "pane10";
                    break;

               


            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSQL = "insert into conditionrecipe(conditionrecipename,conditionrecipedate)values(@name,@date)";
            string strSQL1 = "insert into conditioning(conditionrecipename,modulename,[trigger],parameter,recipe)values(@1,@2,@3,@4,@5)";


            CustomMessageBox customMessageBox = new CustomMessageBox();
            DialogResult dr = customMessageBox.ShowDialog();

            if (dr == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@name", customMessageBox.GetMsg().ToString());
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                if (strtag == "panel1")
                {
                    if (tbModulename.Text.Length > 0)
                    {

                        SqlCommand cmd1 = new SqlCommand(strSQL1, con);

                        cmd1.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                        cmd1.Parameters.AddWithValue("@2", tbModulename.Text);
                        cmd1.Parameters.AddWithValue("@3", cmbTrigger.Text);
                        cmd1.Parameters.AddWithValue("@4", cmbParameter.Text);
                        cmd1.Parameters.AddWithValue("@5", cmbRecipe.Text);
                        cmd1.ExecuteNonQuery();




                    }



                }

                else if (strtag == "panel2")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);

                    cmd1.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbModulename.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbTrigger.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbParameter.Text);
                    cmd1.Parameters.AddWithValue("@5", cmbRecipe.Text);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                    cmd2.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                    cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                    cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                    cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                    cmd2.ExecuteNonQuery();


                }
                else if (strtag == "panel3")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);

                    cmd1.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbModulename.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbTrigger.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbParameter.Text);
                    cmd1.Parameters.AddWithValue("@5", cmbRecipe.Text);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                    cmd2.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                    cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                    cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                    cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(strSQL1, con);

                    cmd3.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd3.Parameters.AddWithValue("@2", tbModulename2.Text);
                    cmd3.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                    cmd3.Parameters.AddWithValue("@4", cmbParameter2.Text);
                    cmd3.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                    cmd3.ExecuteNonQuery();



                }

                else if (strtag == "panel4")
                {

                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);

                    cmd1.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbModulename.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbTrigger.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbParameter.Text);
                    cmd1.Parameters.AddWithValue("@5", cmbRecipe.Text);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                    cmd2.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                    cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                    cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                    cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(strSQL1, con);

                    cmd3.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd3.Parameters.AddWithValue("@2", tbModulename3.Text);
                    cmd3.Parameters.AddWithValue("@3", cmbTrigger3.Text);
                    cmd3.Parameters.AddWithValue("@4", cmbParameter3.Text);
                    cmd3.Parameters.AddWithValue("@5", cmbRecipe3.Text);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                    cmd4.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd4.Parameters.AddWithValue("@2", tbModulename4.Text);
                    cmd4.Parameters.AddWithValue("@3", cmbTrigger4.Text);
                    cmd4.Parameters.AddWithValue("@4", cmbParameter4.Text);
                    cmd4.Parameters.AddWithValue("@5", cmbRecipe4.Text);
                    cmd4.ExecuteNonQuery();


                }

                else if (strtag == "panel5")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);

                    cmd1.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbModulename.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbTrigger.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbParameter.Text);
                    cmd1.Parameters.AddWithValue("@5", cmbRecipe.Text);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                    cmd2.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                    cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                    cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                    cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(strSQL1, con);

                    cmd3.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd3.Parameters.AddWithValue("@2", tbModulename3.Text);
                    cmd3.Parameters.AddWithValue("@3", cmbTrigger3.Text);
                    cmd3.Parameters.AddWithValue("@4", cmbParameter3.Text);
                    cmd3.Parameters.AddWithValue("@5", cmbRecipe3.Text);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                    cmd4.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd4.Parameters.AddWithValue("@2", tbModulename4.Text);
                    cmd4.Parameters.AddWithValue("@3", cmbTrigger4.Text);
                    cmd4.Parameters.AddWithValue("@4", cmbParameter4.Text);
                    cmd4.Parameters.AddWithValue("@5", cmbRecipe4.Text);
                    cmd4.ExecuteNonQuery();

                    SqlCommand cmd5 = new SqlCommand(strSQL1, con);

                    cmd5.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd5.Parameters.AddWithValue("@2", tbModulename5.Text);
                    cmd5.Parameters.AddWithValue("@3", cmbTrigger5.Text);
                    cmd5.Parameters.AddWithValue("@4", cmbParameter5.Text);
                    cmd5.Parameters.AddWithValue("@5", cmbRecipe5.Text);
                    cmd5.ExecuteNonQuery();

                }

                else if (strtag == "panel6")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);

                    cmd1.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbModulename.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbTrigger.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbParameter.Text);
                    cmd1.Parameters.AddWithValue("@5", cmbRecipe.Text);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                    cmd2.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                    cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                    cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                    cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(strSQL1, con);

                    cmd3.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd3.Parameters.AddWithValue("@2", tbModulename3.Text);
                    cmd3.Parameters.AddWithValue("@3", cmbTrigger3.Text);
                    cmd3.Parameters.AddWithValue("@4", cmbParameter3.Text);
                    cmd3.Parameters.AddWithValue("@5", cmbRecipe3.Text);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                    cmd4.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd4.Parameters.AddWithValue("@2", tbModulename4.Text);
                    cmd4.Parameters.AddWithValue("@3", cmbTrigger4.Text);
                    cmd4.Parameters.AddWithValue("@4", cmbParameter4.Text);
                    cmd4.Parameters.AddWithValue("@5", cmbRecipe4.Text);
                    cmd4.ExecuteNonQuery();

                    SqlCommand cmd5 = new SqlCommand(strSQL1, con);

                    cmd5.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd5.Parameters.AddWithValue("@2", tbModulename5.Text);
                    cmd5.Parameters.AddWithValue("@3", cmbTrigger5.Text);
                    cmd5.Parameters.AddWithValue("@4", cmbParameter5.Text);
                    cmd5.Parameters.AddWithValue("@5", cmbRecipe5.Text);
                    cmd5.ExecuteNonQuery();

                    SqlCommand cmd6 = new SqlCommand(strSQL1, con);

                    cmd6.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd6.Parameters.AddWithValue("@2", tbModulename6.Text);
                    cmd6.Parameters.AddWithValue("@3", cmbTrigger6.Text);
                    cmd6.Parameters.AddWithValue("@4", cmbParameter6.Text);
                    cmd6.Parameters.AddWithValue("@5", cmbRecipe6.Text);
                    cmd6.ExecuteNonQuery();

                }

                else if (strtag == "panel7")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);

                    cmd1.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbModulename.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbTrigger.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbParameter.Text);
                    cmd1.Parameters.AddWithValue("@5", cmbRecipe.Text);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                    cmd2.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd2.Parameters.AddWithValue("@2", tbModulename2.Text);
                    cmd2.Parameters.AddWithValue("@3", cmbTrigger2.Text);
                    cmd2.Parameters.AddWithValue("@4", cmbParameter2.Text);
                    cmd2.Parameters.AddWithValue("@5", cmbRecipe2.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(strSQL1, con);

                    cmd3.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd3.Parameters.AddWithValue("@2", tbModulename3.Text);
                    cmd3.Parameters.AddWithValue("@3", cmbTrigger3.Text);
                    cmd3.Parameters.AddWithValue("@4", cmbParameter3.Text);
                    cmd3.Parameters.AddWithValue("@5", cmbRecipe3.Text);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                    cmd4.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd4.Parameters.AddWithValue("@2", tbModulename4.Text);
                    cmd4.Parameters.AddWithValue("@3", cmbTrigger4.Text);
                    cmd4.Parameters.AddWithValue("@4", cmbParameter4.Text);
                    cmd4.Parameters.AddWithValue("@5", cmbRecipe4.Text);
                    cmd4.ExecuteNonQuery();

                    SqlCommand cmd5 = new SqlCommand(strSQL1, con);

                    cmd5.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd5.Parameters.AddWithValue("@2", tbModulename5.Text);
                    cmd5.Parameters.AddWithValue("@3", cmbTrigger5.Text);
                    cmd5.Parameters.AddWithValue("@4", cmbParameter5.Text);
                    cmd5.Parameters.AddWithValue("@5", cmbRecipe5.Text);
                    cmd5.ExecuteNonQuery();

                    SqlCommand cmd6 = new SqlCommand(strSQL1, con);

                    cmd6.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd6.Parameters.AddWithValue("@2", tbModulename6.Text);
                    cmd6.Parameters.AddWithValue("@3", cmbTrigger6.Text);
                    cmd6.Parameters.AddWithValue("@4", cmbParameter6.Text);
                    cmd6.Parameters.AddWithValue("@5", cmbRecipe6.Text);
                    cmd6.ExecuteNonQuery();

                    SqlCommand cmd7 = new SqlCommand(strSQL1, con);

                    cmd7.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                    cmd7.Parameters.AddWithValue("@2", tbModulename7.Text);
                    cmd7.Parameters.AddWithValue("@3", cmbTrigger7.Text);
                    cmd7.Parameters.AddWithValue("@4", cmbParameter7.Text);
                    cmd7.Parameters.AddWithValue("@5", cmbRecipe7.Text);
                    cmd7.ExecuteNonQuery();

                }
                else if (strtag == "panel8")
                {



                }
                else if (strtag == "panel9")
                {



                }

                else if (strtag == "panel10")
                {



                }




                /*   for (int i = 0; i < listModuleName.Count(); i += 1)
                   {
                       SqlCommand cmd1 = new SqlCommand(strSQL1, con);

                       cmd1.Parameters.AddWithValue("@1", customMessageBox.GetMsg().ToString());
                       cmd1.Parameters.AddWithValue("@2", listModuleName[i]);
                       cmd1.Parameters.AddWithValue("@3", listTrigger[i]);
                       cmd1.Parameters.AddWithValue("@4", listParameter[i]);
                       cmd1.Parameters.AddWithValue("@5", listRecipe[i]);
                       cmd1.ExecuteNonQuery();
                   }*/
                con.Close();
                MessageBox.Show("Save Successfully");

                /////////////////////////////////////////////////清空暫存資料表
                con.Open();
                string strSQL2 = "TRUNCATE table Temconditioning";
                SqlCommand cmdClear = new SqlCommand(strSQL2, con);
                cmdClear.ExecuteNonQuery();
                con.Close();
                ////////////////////////////////////////清空集合

             /*   listModuleName.Clear();
                listTrigger.Clear();
                listParameter.Clear();
                listRecipe.Clear();*/




                ////////////////////////////////////////更新RecipType.listboxrecipeName

                updatelistbox(sender, e);


            }





        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cmbRecipe.SelectedItem.ToString().Length > 0)
            {
                /*  selectwaferrecipe = cmbWaferRecipe.SelectedItem.ToString();
                  SqlConnection con = new SqlConnection(scsb.ToString());
                  con.Open();
                  string strSQL = "select * from newrecipe where recipename like @1";
                  SqlCommand cmd = new SqlCommand(strSQL, con);
                  cmd.Parameters.AddWithValue("@1", selectwaferrecipe);*/
                Openrecipe openrecipe = new Openrecipe();
                openrecipe.ShowDialog();

            }
        }
    }
}
