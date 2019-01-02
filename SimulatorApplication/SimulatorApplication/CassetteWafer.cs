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
    public partial class CassetteWafer : Form
       
    {
        public delegate void UpdateListbox(object sender, EventArgs e);

        public UpdateListbox updatelistbox;

        public string selectwaferrecipe;
     
        List<string> strNoOfWafers = new List<string>();
        List<string> strWaferRecipe = new List<string>();
        List<string> strConditioningRecipe = new List<string>();

        public static string searchrecipename;

        ListViewItem itm;

        string strtag = "panel1";



        SqlConnectionStringBuilder scsb;
        public CassetteWafer()
        {
            InitializeComponent();
            
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            //將資料從暫存資料表新增到主要資料表
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
           
            string strSQL = "insert into CassetteRecipe (CassetterecipeName,CassetterecipeDate) values(@NewrecipeName,@NewrecipeDate)";
          
            string strSQL1 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4)";
            string strSQL2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42)";
            string strSQL3 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43)";
            string strSQL4 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44)";
            string strSQL5 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45)";
            string strSQL6 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46)";
            string strSQL7 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47)";
            string strSQL8 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48)";
            string strSQL9 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)";
            string strSQL10 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410)";
            string strSQL11 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411)";
            string strSQL12 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412)";
            string strSQL13 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413)";
            string strSQL14 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414)";
            string strSQL15 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415)";
            string strSQL16 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416)";
            string strSQL17 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416),(@117,@217,@317,@417)";
            string strSQL18 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416),(@117,@217,@317,@417),(@118,@218,@318,@418)";
            string strSQL19 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416),(@117,@217,@317,@417),(@118,@218,@318,@418),(@119,@219,@319,@419)";
            string strSQL20 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416),(@117,@217,@317,@417),(@118,@218,@318,@418),(@119,@219,@319,@419),(@120,@220,@320,@420)";
            SqlCommand cmd = new SqlCommand(strSQL, con);


            CustomMessageBox messgebox = new CustomMessageBox();
            DialogResult dr = messgebox.ShowDialog();
            if (dr == DialogResult.OK && tbNoOfWafers.Text.Length > 0)
            {

                //recipeName=  messgebox.GetMsg();
                cmd.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());
                cmd.Parameters.AddWithValue("@NewrecipeDate", DateTime.Now);
                // SqlDataReader reader1 = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();


                con.Close();

                con.Open();
                //reader1.Close();

                if (strtag == "panel1")
                {
                    if (tbNoOfWafers.Text.Length > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                        cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                        cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                        cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                        cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);

                        cmd1.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("123");
                    }
                }
                else if (strtag == "panel2")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL2, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);

                    cmd1.ExecuteNonQuery();
                }
                else if (strtag == "panel3")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL3, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3.Text);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3.Text);

                    cmd1.ExecuteNonQuery();


                }
                else if (strtag == "panel4")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL4, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.ExecuteNonQuery();




                }
                else if (strtag == "panel5")
                {

                    SqlCommand cmd1 = new SqlCommand(strSQL5, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3.Text);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4.Text);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5.Text);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5.Text);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5.Text);
                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel6")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL6, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.ExecuteNonQuery();




                }
                else if (strtag == "panel7")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL7, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);

                    cmd1.ExecuteNonQuery();



                }
                else if (strtag == "panel8")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL8, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);

                    cmd1.ExecuteNonQuery();


                }
                else if (strtag == "panel9")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL9, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);

                    cmd1.ExecuteNonQuery();



                }
                else if (strtag == "panel10")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL10, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);

                    cmd1.ExecuteNonQuery();




                }
                else if (strtag == "panel11")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL11, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);

                    cmd1.ExecuteNonQuery();





                }


                else if (strtag == "panel12")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL12, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);

                    cmd1.ExecuteNonQuery();





                }

                else if (strtag == "panel13")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL13, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);

                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel14")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL14, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);

                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel15")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL15, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);


                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel16")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL16, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);

                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel17")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL17, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);
                    cmd1.Parameters.AddWithValue("@117", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@217", tbNoOfWafers17);
                    cmd1.Parameters.AddWithValue("@317", cmbWaferRecipe17);
                    cmd1.Parameters.AddWithValue("@417", cmbConditioningRecipe17);


                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel18")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL18, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);
                    cmd1.Parameters.AddWithValue("@117", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@217", tbNoOfWafers17);
                    cmd1.Parameters.AddWithValue("@317", cmbWaferRecipe17);
                    cmd1.Parameters.AddWithValue("@417", cmbConditioningRecipe17);
                    cmd1.Parameters.AddWithValue("@118", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@218", tbNoOfWafers18);
                    cmd1.Parameters.AddWithValue("@318", cmbWaferRecipe18);
                    cmd1.Parameters.AddWithValue("@418", cmbConditioningRecipe18);


                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel19")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL19, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);
                    cmd1.Parameters.AddWithValue("@117", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@217", tbNoOfWafers17);
                    cmd1.Parameters.AddWithValue("@317", cmbWaferRecipe17);
                    cmd1.Parameters.AddWithValue("@417", cmbConditioningRecipe17);
                    cmd1.Parameters.AddWithValue("@118", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@218", tbNoOfWafers18);
                    cmd1.Parameters.AddWithValue("@318", cmbWaferRecipe18);
                    cmd1.Parameters.AddWithValue("@418", cmbConditioningRecipe18);
                    cmd1.Parameters.AddWithValue("@119", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@219", tbNoOfWafers19);
                    cmd1.Parameters.AddWithValue("@319", cmbWaferRecipe19);
                    cmd1.Parameters.AddWithValue("@419", cmbConditioningRecipe19);


                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel20")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL20, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);
                    cmd1.Parameters.AddWithValue("@117", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@217", tbNoOfWafers17);
                    cmd1.Parameters.AddWithValue("@317", cmbWaferRecipe17);
                    cmd1.Parameters.AddWithValue("@417", cmbConditioningRecipe17);
                    cmd1.Parameters.AddWithValue("@118", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@218", tbNoOfWafers18);
                    cmd1.Parameters.AddWithValue("@318", cmbWaferRecipe18);
                    cmd1.Parameters.AddWithValue("@418", cmbConditioningRecipe18);
                    cmd1.Parameters.AddWithValue("@119", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@219", tbNoOfWafers19);
                    cmd1.Parameters.AddWithValue("@319", cmbWaferRecipe19);
                    cmd1.Parameters.AddWithValue("@419", cmbConditioningRecipe19);
                    cmd1.Parameters.AddWithValue("@120", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@20", tbNoOfWafers20);
                    cmd1.Parameters.AddWithValue("@320", cmbWaferRecipe20);
                    cmd1.Parameters.AddWithValue("@420", cmbConditioningRecipe20);


                    cmd1.ExecuteNonQuery();





                }
                con.Close();
                MessageBox.Show("Save Successfully");
                /////////////////////////////////////////////////清空暫存資料表
                con.Open();
                string strSQLtruncate = "TRUNCATE table TemCassetteWafer";
                SqlCommand cmdClear = new SqlCommand(strSQLtruncate, con);
                cmdClear.ExecuteNonQuery();
                con.Close();
                ////////////////////////////////////////清空集合

                strNoOfWafers.Clear();
                strWaferRecipe.Clear();
                strConditioningRecipe.Clear();




                ////////////////////////////////////////更新RecipType.listboxrecipeName

                updatelistbox(sender, e);

                //RecipeType recipe = new RecipeType();
                // RecipeType.update();

                //recipetype.btnCassette_Click();
                // recipetype.btnCassette_Click(sender,e);

                //  UpdateListbox updatelistbox = new UpdateListbox();


                // RecipeType recipetype = new RecipeType();
                // recipetype.update();



            }
            else
            {
                MessageBox.Show("Field No of wafers can not be blank");
            }


            /*  con.Open();
              RecipeType recipetype = new RecipeType();
              if (recipetype.label1.Text == "Cassette Recipe Name")
              {
                  recipetype.listboxRecipeName.Items.Clear();
                  //  con.Open();
                  string strSQLUpdate = "select * from CassetteRecipe";
                  SqlCommand cmdupdate = new SqlCommand(strSQLUpdate, con);
                  SqlDataReader readerupdate = cmdupdate.ExecuteReader();
                  while (readerupdate.Read())
                  {
                      recipetype.listboxRecipeName.Items.Add(readerupdate["CassetterecipeName"]);



                  }
                  con.Close();
              }

              //  RecipeType rcp = new RecipeType();

              // rcp.Refresh();
              // con.Close();

              */




        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            if (tbNoOfWafers.Text.Length > 0)
            {
                ///////////////////////////////////////// //將資料新增到暫存資料表


                scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = Form1.datasource;
                scsb.InitialCatalog = "RecipeType";
                scsb.IntegratedSecurity = true;
                SqlConnection con = new SqlConnection(scsb.ToString());
                // SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL1 = "insert into TemCassetteWafer (NoOfWafers,WaferRecipe,conditioningRecipe) values(@NewNoOfWafers,@NewWaferRecipe,@NewconditioningRecipe)";

                SqlCommand cmd = new SqlCommand(strSQL1, con);
                cmd.Parameters.AddWithValue("@NewNoOfWafers", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@NewWaferRecipe", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@NewconditioningRecipe", cmbConditioningRecipe.Text);

              /*  strNoOfWafers.Add(tbNoOfWafers.Text);
                strWaferRecipe.Add(cmbWaferRecipe.Text);
                strConditioningRecipe.Add(cmbConditioningRecipe.Text);*/



                cmd.ExecuteNonQuery();
                con.Close();
                //////////////////////////////////////////將資料加入字串集合內
                /*  con.Open();
                  string strSQL3 = "select * from TemCassetteWafer";
                  SqlCommand cmd2 = new SqlCommand(strSQL3, con);
                  SqlDataReader reader1 = cmd2.ExecuteReader();
                  while (reader1.Read())
                  {
                      strNoOfWafers.Add(string.Format("{0}",reader1["NoOfWafers"]));
                      strWaferRecipe.Add(string.Format("{0}", reader1["WaferRecipe"]));
                      strConditioningRecipe.Add(string.Format("{0}", reader1["ConditioningRecipe"]));






                  }
                  con.Close();*/
                con.Open();
                ////////////////////////////////////////// //更新listbox上面的資料
               

                strNoOfWafers.Clear();
                strWaferRecipe.Clear();
                strConditioningRecipe.Clear();

                string strSQL2 = "select * from TemCassetteWafer";
                SqlCommand cmd1 = new SqlCommand(strSQL2, con);
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {


                    strNoOfWafers.Add(reader["Noofwafers"].ToString());
                    strWaferRecipe.Add(reader["waferrecipe"].ToString());
                    strConditioningRecipe.Add(reader["conditioningrecipe"].ToString());


                }
              
              

               

            }

            else
                MessageBox.Show("Please insert no of wafer");

        }

        private void CassetteWafer_Load(object sender, EventArgs e)
        {
           
            panel1.Tag = "panel1";
            panel2.Tag = "panel2";
            panel3.Tag = "panel3";
            panel4.Tag = "panel4";
            panel5.Tag = "panel5";
            panel6.Tag = "panel6";
            panel7.Tag = "panel7";
            panel8.Tag = "panel8";
            panel9.Tag = "panel9";
            panel10.Tag = "panel10";
            panel11.Tag = "panel11";
            panel12.Tag = "panel12";
            panel13.Tag = "panel13";
            panel14.Tag = "panel14";
            panel15.Tag = "panel15";
            panel16.Tag = "panel16";
            panel17.Tag = "panel17";
            panel18.Tag = "panel18";
            panel19.Tag = "panel19";
            panel20.Tag = "panel20";
           





            //////////////////////////////////////////////////////將ICP recipe 資料加入cmbWaferRecipe裡面
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

                cmbWaferRecipe.Items.Add(reader["recipeName"]);
                cmbWaferRecipe2.Items.Add(reader["recipeName"]);
                cmbWaferRecipe3.Items.Add(reader["recipeName"]);
                cmbWaferRecipe4.Items.Add(reader["recipeName"]);
                cmbWaferRecipe5.Items.Add(reader["recipeName"]);
                cmbWaferRecipe6.Items.Add(reader["recipeName"]);
                cmbWaferRecipe7.Items.Add(reader["recipeName"]);
                cmbWaferRecipe8.Items.Add(reader["recipeName"]);
                cmbWaferRecipe9.Items.Add(reader["recipeName"]);
                cmbWaferRecipe10.Items.Add(reader["recipeName"]);
                cmbWaferRecipe11.Items.Add(reader["recipeName"]);
                cmbWaferRecipe12.Items.Add(reader["recipeName"]);
                cmbWaferRecipe13.Items.Add(reader["recipeName"]);
                cmbWaferRecipe14.Items.Add(reader["recipeName"]);
                cmbWaferRecipe15.Items.Add(reader["recipeName"]);
                cmbWaferRecipe16.Items.Add(reader["recipeName"]);
                cmbWaferRecipe17.Items.Add(reader["recipeName"]);
                cmbWaferRecipe18.Items.Add(reader["recipeName"]);
                cmbWaferRecipe19.Items.Add(reader["recipeName"]);
                cmbWaferRecipe20.Items.Add(reader["recipeName"]);

            }

            cmbWaferRecipe.Text = cmbWaferRecipe.Items[0].ToString();

            con.Close();
            //////////////////////////////////////////////////////////////將 Conditionrecipe 加入cmbconditionrecipe
            con.Open();

            string strcondition = "select * from conditionrecipe";

            SqlCommand cmdcondition = new SqlCommand(strcondition, con);
            SqlDataReader readercondition = cmdcondition.ExecuteReader();

            while (readercondition.Read())
            {
                cmbConditioningRecipe.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe2.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe3.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe4.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe5.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe6.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe7.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe8.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe9.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe10.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe11.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe12.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe13.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe14.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe15.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe16.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe17.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe18.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe19.Items.Add(readercondition["conditionrecipename"]);
                cmbConditioningRecipe20.Items.Add(readercondition["conditionrecipename"]);


            }
            cmbConditioningRecipe.Text = cmbConditioningRecipe.Items[0].ToString();



            /*     scsb = new SqlConnectionStringBuilder();
                 scsb.DataSource = @"HP-PC\SQLEXPRESS";
                 scsb.InitialCatalog = "RecipeType";
                 scsb.IntegratedSecurity = true;
                 SqlConnection con = new SqlConnection(scsb.ToString());

                 con.Open();
                 string strSQL = "select NoOfWafers from TemCassetteWafer";
                 SqlCommand cmd = new SqlCommand(strSQL, con);
                 SqlDataReader reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     listboxNoOfWafers.Items.Add(reader["NoOfWafers"]);


                 }
                 */

        }

        private void listboxNoOfWafers_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  string strSelected = listboxNoOfWafers.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from TemCassetteWafer where NoOfWafers like @NewNoOfWafers";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@NewNoOfWafers", strSelected);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

               tbNoOfWafers.Text = string.Format("{0}", reader["NoOfWafers"]);
                cmbWaferRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);
                cmbConditioningRecipe.Text = string.Format("{0}", reader["ConditioningRecipe"]);
                

            }
            con.Close();*/



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            /////////////////////////////////////////////////清空暫存資料表
            SqlConnection con = new SqlConnection(scsb.ToString());
        
            con.Open();
            string strSQL2 = "TRUNCATE table TemCassetteWafer";
            SqlCommand cmdClear = new SqlCommand(strSQL2, con);
            cmdClear.ExecuteNonQuery();
            con.Close();
            ////////////////////////////////////////清空集合

            strNoOfWafers.Clear();
            strWaferRecipe.Clear();
            strConditioningRecipe.Clear();

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
                 string strSQL = "delete from TemCassettewafer where NoOfWafers like @1 ";

                 SqlCommand cmd = new SqlCommand(strSQL, con);
                 string strSelected = listView1.SelectedItems[0].SubItems[0].Text;
                 //string strSelected1 = listView1.SelectedItems[0].SubItems[2].Text;
                 cmd.Parameters.AddWithValue("@1", strSelected);

                 cmd.ExecuteNonQuery();
                 con.Close();

                 /////////////////////////////////////////////////////////////////重新讀取ListBox
                 con.Open();
                 this.listView1.Items.Clear();
                 string strSQL2 = "select * from TemCassetteWafer";
                 SqlCommand cmd1 = new SqlCommand(strSQL2, con);
                 SqlDataReader reader = cmd1.ExecuteReader();
                 while (reader.Read())
                 {
                     itm = new ListViewItem(reader["noofwafers"].ToString());
                     itm.SubItems.Add(reader["waferrecipe"].ToString());
                     itm.SubItems.Add(reader["conditioningrecipe"].ToString());

                     listView1.Items.Add(itm);


                 }
                 con.Close();
             }
             else
             {
                 MessageBox.Show("Please select item");


             }
             */
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

                case "panel11":
                    panel12.Visible = true;
                    strtag = "panel12";
                    break;

                case "panel12":
                    panel12.Visible = false;
                    strtag = "panel11";
                    break;

                case "panel13":
                    panel13.Visible = false;
                    strtag = "panel12";
                    break;

                case "panel14":
                    panel14.Visible = false;
                    strtag = "panel13";
                    break;

                case "panel15":
                    panel15.Visible = false;
                    strtag = "panel14";
                    break;

                case "panel16":
                    panel16.Visible = false;
                    strtag = "panel15";
                    break;
                case "panel17":
                    panel17.Visible = false;
                    strtag = "panel16";
                    break;
                case "panel18":
                    panel18.Visible = false;
                    strtag = "panel17";
                    break;
                case "panel19":
                    panel19.Visible = false;
                    strtag = "panel18";
                    break;
                case "panel20":
                    panel20.Visible = false;
                    strtag = "panel19";
                    break;

            }




            }
        

            private void btnOpen_Click(object sender, EventArgs e)
        {
           if( cmbWaferRecipe.SelectedItem.ToString().Length>0)
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

        private void CassetteWafer_FormClosing(object sender, FormClosingEventArgs e)
        {
            /////////////////////////////////////////////////清空暫存資料表
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            
            string strSQL2 = "TRUNCATE table TemCassetteWafer";
            SqlCommand cmdClear = new SqlCommand(strSQL2, con);
            cmdClear.ExecuteNonQuery();
            con.Close();
            ////////////////////////////////////////清空集合

            strNoOfWafers.Clear();
            strWaferRecipe.Clear();
            strConditioningRecipe.Clear();
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

                case "pane10":
                    panel11.Visible = true;
                    strtag = "panel11";
                    break;

                case "panel11":
                    panel12.Visible = true;
                    strtag = "panel12";
                    break;

                case "panel12":
                    panel13.Visible = true;
                    strtag = "panel13";
                    break;

                case "panel13":
                    panel14.Visible = true;
                    strtag = "panel14";
                    break;

                case "panel14":
                    panel15.Visible = true;
                    strtag = "panel15";
                    break;

                case "panel15":
                    panel16.Visible = true;
                    strtag = "panel16";
                    break;

                case "panel16":
                    panel17.Visible = true;
                    strtag = "panel17";
                    break;
                case "panel17":
                    panel18.Visible = true;
                    strtag = "panel18";
                    break;
                case "panel18":
                    panel19.Visible = true;
                    strtag = "panel19";
                    break;
                case "panel19":
                    panel20.Visible = true;
                    strtag = "panel20";
                    break;
                case "panel20":
                    MessageBox.Show("maximum 20");
                    break;


            }
        }

        private void cmbWaferRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cmbWaferRecipe_Click(object sender, EventArgs e)
        {
            searchrecipename = cmbWaferRecipe.SelectedItem.ToString();
        }
    }
}
