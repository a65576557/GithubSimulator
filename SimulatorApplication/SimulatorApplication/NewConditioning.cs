﻿using System;
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
    public partial class NewConditioning : Form
    {
        public NewConditioning()
        {
            InitializeComponent();
        }

        public delegate void UpdateListView(object sender, EventArgs e);
        public UpdateListView updatelistview;

        public string strtag = "panel1";


        SqlConnectionStringBuilder scsb;
        List<string> listModuleName = new List<string>();
        List<string> listTrigger = new List<string>();
        List<string> listParameter = new List<string>();
        List<string> listRecipe = new List<string>();

        private void btnAppend_Click(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSQL = "insert into TemConditioning (ModuleName,[Trigger],Parameter,Recipe) values(@2,@3,@4,@5)";
            SqlCommand cmd = new SqlCommand(strSQL, con);
          //  cmd.Parameters.AddWithValue("@1", "1");
            cmd.Parameters.AddWithValue("@2", tbModulename.Text);
            cmd.Parameters.AddWithValue("@3", cmbTrigger.Text);
            cmd.Parameters.AddWithValue("@4", cmbParameter.Text);
            cmd.Parameters.AddWithValue("@5", cmbRecipe.Text);

           
            
            cmd.ExecuteNonQuery();

         /*   listModuleName.Add(tbModulename.Text);
            listTrigger.Add(cmbTrigger.Text);
            listParameter.Add(cmbParameter.Text);
            listRecipe.Add(cmbRecipe.Text);*/
            con.Close();

            ////////////////////////////////////////////////////////更新listview
            con.Open();
           
          /*  this.listView1.FullRowSelect = true;
            listView1.View = View.Details;

            ListViewItem itm;
            listView1.Columns.Add("Module Name", 70);
            listView1.Columns.Add("Trigger", 70);
            listView1.Columns.Add("Parameter", 70);
            listView1.Columns.Add("Recipe", 70);*/

            string strlistview = "select * from Temconditioning";

            SqlCommand cmdlistview = new SqlCommand(strlistview, con);
            SqlDataReader readerlistview = cmdlistview.ExecuteReader();
            listModuleName.Clear();
            listTrigger.Clear();
            listParameter.Clear();
            listRecipe.Clear();
            while (readerlistview.Read())
            {
                listModuleName.Add(readerlistview["modulename"].ToString());
                listTrigger.Add(readerlistview["trigger"].ToString());
                listParameter.Add(readerlistview["parameter"].ToString());
                listRecipe.Add(readerlistview["recipe"].ToString());

            }
           

           


        }

        private void NewConditioning_Load(object sender, EventArgs e)
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

            /* scsb = new SqlConnectionStringBuilder();
             scsb.DataSource = @"HP-PC\SQLEXPRESS";
             scsb.InitialCatalog = "RecipeType";
             scsb.IntegratedSecurity = true;
             SqlConnection con = new SqlConnection(scsb.ToString());
             con.Open();*/

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSQL = "select * from recipe ";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                cmbRecipe.Items.Add(reader["recipeName"]);



            }

            cmbRecipe.Text = cmbRecipe.Items[0].ToString();




        }

        private void NewConditioning_FormClosing(object sender, FormClosingEventArgs e)
        {

            /////////////////////////////////////////////////清空暫存資料表
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSQL2 = "TRUNCATE table TemConditioning";
            SqlCommand cmdClear = new SqlCommand(strSQL2, con);
            cmdClear.ExecuteNonQuery();
            con.Close();
            ////////////////////////////////////////清空集合

            listModuleName.Clear();
            listTrigger.Clear();
            listParameter.Clear();
            listRecipe.Clear();





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

            string strSQL = "insert into conditionrecipe(conditionrecipename,conditionrecipedate)values(@name,@date)";
            string strSQL1 = "insert into conditioning(conditionrecipename,modulename,[trigger],parameter,recipe)values(@1,@2,@3,@4,@5)";
          

            CustomMessageBox customMessageBox = new CustomMessageBox();
            DialogResult dr = customMessageBox.ShowDialog();

            if (dr==DialogResult.OK)
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

                listModuleName.Clear();
                listTrigger.Clear();
                listParameter.Clear();
                listRecipe.Clear();




                ////////////////////////////////////////更新RecipType.listboxrecipeName

                updatelistview(sender, e);


            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /* if (listView1.SelectedItems != null)
             {
                 scsb = new SqlConnectionStringBuilder();
                 scsb.DataSource = @"HP-PC\SQLEXPRESS";
                 scsb.InitialCatalog = "RecipeType";
                 scsb.IntegratedSecurity = true;
                 SqlConnection con = new SqlConnection(scsb.ToString());
                 con.Open();
                 string strSQL = "delete from Temconditioning where [trigger] like @1 and parameter like @2 ";

                 SqlCommand cmd = new SqlCommand(strSQL, con);


                 cmd.Parameters.AddWithValue("@1", strSelected);
                 cmd.Parameters.AddWithValue("@2", strparameter);
                 cmd.ExecuteNonQuery();
                 con.Close();

                 /////////////////////////////////////////////////////////////////重新讀取ListView
                 con.Open();
                 // listboxNoOfWafers.Items.Clear();

                 string strSQL2 = "select * from Temconditioning";
                 SqlCommand cmd1 = new SqlCommand(strSQL2, con);
                 SqlDataReader reader = cmd1.ExecuteReader();
                 while (reader.Read())
                 {
                     //  listboxNoOfWafers.Items.Add(reader["NoOfWafers"]);







                 }
                 con.Close();
             }
             else
             {
                 MessageBox.Show("Please select item");


             }*/

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

        

            }



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
