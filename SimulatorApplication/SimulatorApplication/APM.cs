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
    public partial class APM : Form
    {
      
        public APM()
        


        {
            InitializeComponent();
        }
        public static string selectmodulerecipe;
        public Form1 form1 = new Form1();
        string button;
        List<string> strStepname1 = new List<string>();
        public string mySec1;
        public int Sec1;
       
        SqlConnectionStringBuilder scsb;
        private async void btnidle_Click(object sender, EventArgs e)
        {

         /*   form1.lblProcess.Text = "Going to idle";
            form1.label2.BackColor = Color.LimeGreen;
            await Task.Delay(2000);
            form1.label2.BackColor = Color.Blue;
            form1.lblProcess.Text = "idle";*/

            button = "1";

        }

        private void APM_Load(object sender, EventArgs e)
        {
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (button == "1")
            {
                form1.lblProcess.Text = "Going to idle";
                form1.lblProcess.BackColor = Color.LimeGreen;
                form1.lblProcessStep.BackColor = Color.LimeGreen;
                form1.lblRecipe.BackColor = Color.LimeGreen;
                form1.lblStepName.BackColor = Color.LimeGreen;
                form1.lblnum.BackColor = Color.LimeGreen;
                form1.lblData.BackColor = Color.LimeGreen;
                form1.label2.BackColor = Color.LimeGreen;

                await Task.Delay(2000);
                form1.label2.BackColor = Color.Blue;
                form1.lblProcess.BackColor = Color.Blue;
                form1.lblProcessStep.BackColor = Color.Blue;
                form1.lblRecipe.BackColor = Color.Blue;
                form1.lblStepName.BackColor = Color.Blue;
                form1.lblnum.BackColor = Color.Blue;
                form1.lblData.BackColor = Color.Blue;



                form1.lblProcess.Text = "Idle";



            }


          if (button=="2")
            {
                form1.lblRecipe.BackColor = Color.LimeGreen;
                form1.lblStepName.BackColor = Color.LimeGreen;
               
                form1.lblnum.BackColor = Color.LimeGreen;

                form1.lblRecipe.Text = selectmodulerecipe;

                form1.lblData.BackColor = Color.LimeGreen;
                form1.lblData.Text = "";
                form1.label2.BackColor = Color.LimeGreen;



                form1.lblProcess.Text = "Processing";
                form1.lblProcess.BackColor = Color.LimeGreen;
                form1.lblProcessStep.Text = "Process Step";
                form1.lblProcessStep.BackColor = Color.LimeGreen;

                scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = Form1.datasource;
                scsb.InitialCatalog = "RecipeType";
                scsb.IntegratedSecurity = true;
                SqlConnection con = new SqlConnection(scsb.ToString());
             //   await Task.Delay(2000);
                con.Open();

               /* string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewWaferRecipe", selectmodulerecipe);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    form1.lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                }*/

                

                con.Close();
                con.Open();
                string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                cmd1.Parameters.AddWithValue("@Myrecipename", selectmodulerecipe);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                }

                con.Close();


                con.Open();
                string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                cmd2.Parameters.AddWithValue("@Newrecipename", form1.lblRecipe.Text);

                cmd2.ExecuteNonQuery();

                for (int j = 0; j < strStepname1.Count(); j += 1)
                {
                    await Task.Delay(1000);

                    // ListStepStartTime.Add(DateTime.Now);


                    int count = j + 1;


                    form1.lblStepName.Text = strStepname1[j];
                    form1.lblnum.Text = "," + count + "/" + strStepname1.Count();


                    con.Close();

                    con.Open();
                    string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                    SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                    cmdSec.Parameters.AddWithValue("@NewSec", form1.lblStepName.Text);

                    SqlDataReader readerSec = cmdSec.ExecuteReader();


                    while (readerSec.Read())
                    {
                        mySec1 = readerSec["ProcessTime"].ToString();

                        Int32.TryParse(mySec1, out Sec1);

                    }

                    for (int k = 1; k <= Sec1; k++)
                    {
                        form1.lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                        await Task.Delay(1000);


                    }
                    //    ListStepEndTime.Add(DateTime.Now);

                    con.Close();



                }
                await Task.Delay(1000);
                strStepname1.Clear();


                form1.label2.BackColor = Color.Blue;
                form1.lblProcess.BackColor = Color.Blue;
                form1.lblProcessStep.BackColor = Color.Blue;
                form1.lblRecipe.BackColor = Color.Blue;
                form1.lblStepName.BackColor = Color.Blue;
                form1.lblData.BackColor = Color.Blue;
                form1.lblnum.BackColor = Color.Blue;

                form1.lblProcess.Text = "Aborted";
                form1.lblProcessStep.Text = "";
                form1.lblRecipe.Text = "";
                form1.lblStepName.Text = "";
                form1.lblnum.Text = "";
                form1.lblData.Text = "???????????";

            }
        }

        private async void btnprocess_Click(object sender, EventArgs e)
        {

            button = "2";

            listBox1.Items.Clear();
           
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSql = "select * from recipe ";
            SqlCommand cmd = new SqlCommand(strSql, con);
            SqlDataReader reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                listBox1.Items.Add(reader["recipeName"]);

            }
            // RecipeType_Load(sender, e);
            con.Close();










        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectmodulerecipe = listBox1.SelectedItem.ToString();





        }
    }
}
