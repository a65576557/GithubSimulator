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
    public partial class RecipeType : Form
         
    {

       
        
        
        

        public static string strSearchName;
        public static string strSearchNameforcassette;

        public static string labelstring;

        

        SqlConnectionStringBuilder scsb;
        public RecipeType()
        {
            InitializeComponent();
        }
       
      

        private void button4_Click(object sender, EventArgs e)
        {
            if (label1.Visible==true)
            {
                if (label1.Text == "Recipe Name")
                {

                    NewRecipe nr = new NewRecipe();
                    nr.updatelistbox += new NewRecipe.UpdateListbox(btnModule_Click);
                    nr.ShowDialog();
                }
                else if (label1.Text == "Cassette Recipe Name")
                {

                    CassetteWafer cassette = new CassetteWafer();
                    cassette.updatelistbox += new CassetteWafer.UpdateListbox(btnCassette_Click);

                    OpenCassetteWafer opencassettewafer = new OpenCassetteWafer();
                    opencassettewafer.updatelistbox+= new OpenCassetteWafer.UpdateListbox(btnCassette_Click);


                    cassette.ShowDialog();


                    //    cassette.


                }

                else if (label1.Text == "Conditioning Recipe Name")
                {

                    NewConditioning newConditioning = new NewConditioning();
                    newConditioning.updatelistview += new NewConditioning.UpdateListView(btnConditioning_Click);

                    OpenConditionRecipe openconditionrecipe = new OpenConditionRecipe();
                    openconditionrecipe.updatelistbox += new OpenConditionRecipe.UpdateListbox(btnConditioning_Click);


                    newConditioning.ShowDialog();


                }
            }
            else { MessageBox.Show("Please select Cassette or Module"); }
        }


        private void RecipeType_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'recipeTypeDataSet.recipe' 資料表。您可以視需要進行移動或移除。
          //  this.recipeTableAdapter.Fill(this.recipeTypeDataSet.recipe);
            /*// this.Refresh();

             NewRecipe nr = new NewRecipe();
           //  listboxRecipeName.Items.Add(nr.recipeName);
             tbrecipename.ReadOnly = true;
             tbrecipeDate.ReadOnly = true;
             // TODO: 這行程式碼會將資料載入 'recipeTypeDataSet.recipe' 資料表。您可以視需要進行移動或移除。
            // this.recipeTableAdapter.Fill(this.recipeTypeDataSet.recipe);
             scsb = new SqlConnectionStringBuilder();
             scsb.DataSource = @"HP-PC\SQLEXPRESS";
             scsb.InitialCatalog = "RecipeType";
             scsb.IntegratedSecurity = true;
             SqlConnection con = new SqlConnection(scsb.ToString());
             con.Open();
             string strSql = "select * from recipe ";
             SqlCommand cmd = new SqlCommand(strSql,con);
             SqlDataReader reader = cmd.ExecuteReader();



             while (reader.Read())
             {
                 listboxRecipeName.Items.Add(reader["recipeName"]);

                     }
            // RecipeType_Load(sender, e);
             con.Close();*/
            /////////////////////////////////////////////////////////////////////////////////
              scsb = new SqlConnectionStringBuilder();
              scsb.DataSource = @"HP-PC\SQLEXPRESS";
              scsb.InitialCatalog = "RecipeType";
              scsb.IntegratedSecurity = true;
              SqlConnection con = new SqlConnection(scsb.ToString());
              con.Open();
              string strMsg = "select recipeName from recipe";
              SqlDataAdapter da = new SqlDataAdapter(strMsg, con);
              DataSet ds = new DataSet();
              da.Fill(ds);
             // dataGridView1.DataSource = ds.Tables[0];

            //dataGridView1.DefaultCellStyle.Font = new Font("微軟正黑體",12);

              con.Close();
            ///////////////////////////////////////////////////////////////////////////////////////



        }

        private void listboxRecipeName_SelectedIndexChanged(object sender, EventArgs e)
        {

            strSearchName = listboxRecipeName.SelectedItem.ToString();

            if (strSearchName.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQl = "select * from recipe where recipeName like @Searchname";
                SqlCommand cmd = new SqlCommand(strSQl, con);
                cmd.Parameters.AddWithValue("@Searchname", strSearchName.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    tbrecipename.Text = string.Format("{0}", reader["recipeName"]);
                   // dateTimePicker1.Value = (DateTime)reader["recipeDate"];
                    tbrecipeDate.Text = string.Format("{0:yyyy/MM/dd}", reader["recipeDate"]);

                    //tbrecipename.ReadOnly = true;
                    //tbrecipeDate.ReadOnly = true;
                }
                reader.Close();
                con.Close();
                con.Open();
                string strSQL2 = "select * from CassetteRecipe where CassetteRecipeName like @Searchcassetterecipename";
                SqlCommand cmd1 = new SqlCommand(strSQL2, con);
                cmd1.Parameters.AddWithValue("@Searchcassetterecipename", strSearchName.ToString());
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    tbrecipename.Text = string.Format("{0}", reader1["CassetterecipeName"]);


                    tbrecipeDate.Text = string.Format("{0:yyyy/MM/dd}", reader1["CassetterecipeDate"]);

                }

                reader1.Close();
                con.Close();
                con.Open();

                string strConditionRecipe = "select * from ConditionRecipe where ConditionRecipeName like @1";
                SqlCommand cmdconditionrecipe = new SqlCommand(strConditionRecipe, con);
                cmdconditionrecipe.Parameters.AddWithValue("@1", strSearchName.ToString());
                SqlDataReader readerconditionrecipe = cmdconditionrecipe.ExecuteReader();
                while (readerconditionrecipe.Read())
                {
                    tbrecipename.Text= string.Format("{0}", readerconditionrecipe["conditionrecipename"]);

                    tbrecipeDate.Text = string.Format("{0:yyyy/MM/dd}", readerconditionrecipe["conditionrecipedate"]);
                }

                readerconditionrecipe.Close();
                con.Close();
            }

            else {
                MessageBox.Show("please select");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbrecipename.Text.Length > 0)
            {
                if (MessageBox.Show("Delete this recipe?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {




                    SqlConnection con = new SqlConnection(scsb.ToString());
                    con.Open();

                    string strSQl = "delete from recipe where recipeName = @Searchname";
                    string strSQl1 = "delete from Cassetterecipe where CassetterecipeName = @Searchname1";
                    string strSQL2 = "select * from recipe";
                    string strSQL3 = "select * from  Cassetterecipe";
                    string strSQL4 = "delete from Newrecipe where recipename = @Searchname3";
                    string strSQL5 = "delete from CassetteWafer where CassetterecipeName = @Searchname4";



                    SqlCommand cmd = new SqlCommand(strSQl, con);

                    cmd.Parameters.AddWithValue("@Searchname", tbrecipename.Text);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                    con.Open();

                    SqlCommand cmdDeleteNewRecipe = new SqlCommand(strSQL4, con);
                    cmdDeleteNewRecipe.Parameters.AddWithValue("@Searchname3", tbrecipename.Text);
                    cmdDeleteNewRecipe.ExecuteNonQuery();
                    con.Close();


                    con.Open();


                    SqlCommand cmd1 = new SqlCommand(strSQl1, con);
                    cmd1.Parameters.AddWithValue("@Searchname1", tbrecipename.Text);
                    // cmd1.Parameters.AddWithValue(" @Searchname1", tbrecipename.Text);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    reader1.Close();
                    con.Close();

                    con.Open();
                    SqlCommand cmdDeleteCassetteWafer = new SqlCommand(strSQL5, con);
                    cmdDeleteCassetteWafer.Parameters.AddWithValue("@Searchname4", tbrecipename.Text);
                    cmdDeleteCassetteWafer.ExecuteNonQuery();
                    con.Close();

                    /////////////////////////////////////////////////////conditionrecipe
                    string strCondition = "delete from conditionrecipe where conditionrecipename = @name";


                    con.Open();
                    SqlCommand cmdcondition = new SqlCommand(strCondition, con);

                    cmdcondition.Parameters.AddWithValue("name", tbrecipename.Text);

                    cmdcondition.ExecuteNonQuery();

                    con.Close();
                    /////////////////////////////////////////////////////
                   // MessageBox.Show("Delete Successfully");
                    listboxRecipeName.Items.Clear();

                    if (label1.Text == "Recipe Name")
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            listboxRecipeName.Items.Add(reader2["recipeName"]);
                        }


                    }
                    con.Close();
                    if (label1.Text == "Cassette Recipe Name")
                    {
                        con.Open();
                        SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                        SqlDataReader reader3 = cmd3.ExecuteReader();
                        while (reader3.Read())
                        {
                            listboxRecipeName.Items.Add(reader3["CassetterecipeName"]);



                        }
                    }
                    con.Close();

                    if (label1.Text == "Conditioning Recipe Name")
                    {
                        /* string strCondition = "delete from conditionrecipe where conditionrecipename = @name";


                         con.Open();
                         SqlCommand cmdcondition = new SqlCommand(strCondition,con);

                         cmdcondition.Parameters.AddWithValue("name",tbrecipename.Text);

                         cmdcondition.ExecuteNonQuery();*/

                        con.Open();
                        string strsearchcondition = "select * from conditionrecipe";
                        SqlCommand cmdsearchcondition = new SqlCommand(strsearchcondition,con);
                        SqlDataReader readercondition = cmdsearchcondition.ExecuteReader();

                        while (readercondition.Read())
                        {
                            listboxRecipeName.Items.Add(readercondition["conditionrecipename"]);



                        }
                        con.Close();
                    }









                }

            }
            else
                MessageBox.Show("Please select recipe");
        }

        private void btnModule_Click(object sender, EventArgs e)
        {

            

            label1.Visible = true;
            label2.Visible = true;
            tbrecipename.Visible = true;
            tbrecipeDate.Visible = true;
            listboxRecipeName.Visible = true;
            // this.Refresh();
            listboxRecipeName.Items.Clear();

            label1.Text = "Recipe Name";
            labelstring = "Recipe Name";
            tbrecipeDate.Clear();
            tbrecipename.Clear();
            NewRecipe nr = new NewRecipe();
            //  listboxRecipeName.Items.Add(nr.recipeName);
            tbrecipename.ReadOnly = true;
            tbrecipeDate.ReadOnly = true;
            // TODO: 這行程式碼會將資料載入 'recipeTypeDataSet.recipe' 資料表。您可以視需要進行移動或移除。
            // this.recipeTableAdapter.Fill(this.recipeTypeDataSet.recipe);
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSql = "select * from recipe ";
            SqlCommand cmd = new SqlCommand(strSql, con);
            SqlDataReader reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                listboxRecipeName.Items.Add(reader["recipeName"]);

            }
            // RecipeType_Load(sender, e);
            con.Close();
           






        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
           // string strSearchName = listboxRecipeName.SelectedItem.ToString();
            if (tbrecipename.Text.Length > 0)
            {
                if (label1.Text=="Recipe Name")
                {
                    Openrecipe openrecipe = new Openrecipe();
                    openrecipe.recipetype = this;
                    openrecipe.ShowDialog();


                }
                if (label1.Text == "Cassette Recipe Name")
                {
                    OpenCassetteWafer opencassette = new OpenCassetteWafer();

                    opencassette.updatelistbox += new OpenCassetteWafer.UpdateListbox(btnCassette_Click);



                    opencassette.ShowDialog();
                }
                if (label1.Text== "Conditioning Recipe Name")
                {

                    OpenConditionRecipe openconditionRecipe = new OpenConditionRecipe();

                    openconditionRecipe.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("pleace select recipe");

            }

        }
        
        public void btnCassette_Click(object sender, EventArgs e)
        {

            label1.Visible = true;
            label2.Visible = true;
            tbrecipename.Visible = true;
            tbrecipeDate.Visible = true;
            listboxRecipeName.Visible = true;
            // this.Refresh();
            listboxRecipeName.Items.Clear();
            label1.Text = "Cassette Recipe Name";
            labelstring = "Cassette Recipe Name";
            
            tbrecipename.Text = "";
            tbrecipeDate.Text = "";
            NewRecipe nr = new NewRecipe();
            //  listboxRecipeName.Items.Add(nr.recipeName);
            tbrecipename.ReadOnly = true;
            tbrecipeDate.ReadOnly = true;
            // TODO: 這行程式碼會將資料載入 'recipeTypeDataSet.recipe' 資料表。您可以視需要進行移動或移除。
            // this.recipeTableAdapter.Fill(this.recipeTypeDataSet.recipe);
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
                listboxRecipeName.Items.Add(reader["CassetteRecipeName"]);

            }
          
            con.Close();

           

        }


        public  void update()
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
                listboxRecipeName.Items.Add(reader["CassetteRecipeName"]);

            }
            // RecipeType_Load(sender, e);
            con.Close();


        }

        private void btnConditioning_Click(object sender, EventArgs e)
        {

            label1.Visible = true;
            label2.Visible = true;
            tbrecipename.Visible = true;
            tbrecipeDate.Visible = true;
            listboxRecipeName.Visible = true;
            listboxRecipeName.Items.Clear();
            label1.Text = "Conditioning Recipe Name";
            

            tbrecipename.Text = "";
            tbrecipeDate.Text = "";
            tbrecipename.ReadOnly = true;
            tbrecipeDate.ReadOnly = true;

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSql = "select * from ConditionRecipe ";
            SqlCommand cmd = new SqlCommand(strSql, con);
            
           SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                listboxRecipeName.Items.Add(reader["ConditionRecipeName"]);

            }

            con.Close();
        }
    }
}
