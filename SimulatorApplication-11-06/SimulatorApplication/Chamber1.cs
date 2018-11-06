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
    public partial class Chamber1 : Form
    {
        SqlConnectionStringBuilder scsb;
        List<string> strStepname1 = new List<string>();
        public static string mySec;
        public static int Sec;


       


        public Chamber1()
        {
            InitializeComponent();
            Form1 form1 = new Form1();
            // form1.loadchamber1 += new Form1.LoadChamber1(Chamber1_Load);
            form1.loaddata += new Form1.LoadData(loaddata);
      

        }

        
        

        private void Chamber1_Load(object sender, EventArgs e)

        {
            //Form1 form1 = new Form1();
            // form1.loaddata += new Form1.LoadData(loaddata);
           // form1.loadchamber1 += new Form1.LoadChamber1(Chamber1_Load);
            btnHighRange.Image = Properties.Resources.close;
            btnHighRange.Image.Tag = "close";
            btnLowRange.Image = Properties.Resources.close;
            btnLowRange.Image.Tag = "close";
            btnPoint.Image = Properties.Resources.close;
            btnPoint.Image.Tag = "close";
            btnHeliumChamber.Image = Properties.Resources.close; 
            btnHeliumChamber.Image.Tag = "close";
            btnHeliumPump.Image = Properties.Resources.close;
            btnHeliumPump.Image.Tag = "close";
            btnRoughing.Image = Properties.Resources.close;
            btnRoughing.Image.Tag = "close";
            btnTurbo.Image = Properties.Resources.close;
            btnTurbo.Image.Tag = "close";
            btnChamberBypass.Image = Properties.Resources.close;
            btnChamberBypass.Image.Tag = "close";
            btnCI2ValvePurge.Image = Properties.Resources.close;
            btnCI2ValvePurge.Image.Tag = "close";
            btnCI2ValveIn.Image = Properties.Resources.close;
            btnCI2ValveIn.Image.Tag = "close";
            btnCI2ValveOut.Image = Properties.Resources.close;
            btnCI2ValveOut.Image.Tag = "close";
            btnBCI3ValvePurge.Image = Properties.Resources.close;
            btnBCI3ValvePurge.Image.Tag = "close";
            btnBCI3ValveIn.Image = Properties.Resources.close;
            btnBCI3ValveIn.Image.Tag = "close";
            btnBCI3ValveOut.Image = Properties.Resources.close;
            btnBCI3ValveOut.Image.Tag = "close";
            btnSF6ValvePurge.Image = Properties.Resources.close;
            btnSF6ValvePurge.Image.Tag = "close";
            btnSF6ValveIn.Image = Properties.Resources.close;
            btnSF6ValveIn.Image.Tag = "close";
            btnSF6ValveOut.Image = Properties.Resources.close;
            btnSF6ValveOut.Image.Tag = "close";
            btnCHF3ValvePurge.Image = Properties.Resources.close;
            btnCHF3ValvePurge.Image.Tag = "close";
            btnCHF3ValveIn.Image = Properties.Resources.close;
            btnCHF3ValveIn.Image.Tag = "close";
            btnCHF3ValveOut.Image = Properties.Resources.close;
            btnCHF3ValveOut.Image.Tag = "close";
            btnOxygenValvePurge.Image = Properties.Resources.close;
            btnOxygenValvePurge.Image.Tag = "close";
            btnOxygenValveIn.Image = Properties.Resources.close;
            btnOxygenValveIn.Image.Tag = "close";
            btnOxygenValveOut.Image = Properties.Resources.close;
            btnOxygenValveOut.Image.Tag = "close";
            btnOxygen1ValvePurge.Image = Properties.Resources.close;
            btnOxygen1ValvePurge.Image.Tag = "close";
            btnOxygen1ValveIn.Image = Properties.Resources.close;
            btnOxygen1ValveIn.Image.Tag = "close";
            btnOxygen1ValveOut.Image = Properties.Resources.close;
            btnOxygen1ValveOut.Image.Tag = "close";
            btnNitrogenValveIn.Image = Properties.Resources.close;
            btnNitrogenValveIn.Image.Tag = "close";
            btnNitrogenValveOut.Image = Properties.Resources.close;
            btnNitrogenValveOut.Image.Tag = "close";
            btnArgonValveIn.Image = Properties.Resources.close;
            btnArgonValveIn.Image.Tag = "close";
            btnArgonValveOut.Image = Properties.Resources.close;
            btnArgonValveOut.Image.Tag = "close";
            btnN2Inlet.Image = Properties.Resources.close;
            btnN2Inlet.Image.Tag = "close";
            btnManifold.Image = Properties.Resources.close;
            btnManifold.Image.Tag = "close";



            if (Form1.chamberload == "LimeGreen")
            {

                loaddata();

            }








        }


        private void btnHighRange_Click(object sender, EventArgs e)
        {
            switch (btnHighRange.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "High range sensor isolation Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnHighRange.Image = Properties.Resources.open;
                        btnHighRange.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "High range sensor isolation Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnHighRange.Image = Properties.Resources.close;
                        btnHighRange.Image.Tag = "close";

                    }


                    break;


            }



        }

        private void btnLowRange_Click(object sender, EventArgs e)
        {
            switch (btnLowRange.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Low range sensor isolation Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnLowRange.Image = Properties.Resources.open;
                        btnLowRange.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Low range sensor isolation Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnLowRange.Image = Properties.Resources.close;
                        btnLowRange.Image.Tag = "close";

                    }


                    break;


            }





        }

        public async void loaddata()
        {
            if (Form1.chamberload == "LimeGreen")
            {
              //  lblWafer.BackColor = Color.Red;
             //   lblWafer.Text = "A1";
                lblData.Text = "";
                lblProcess.Text = "Processing";
                lblProcessStep.Text = "Process Step";
                scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = @"HP-PC\SQLEXPRESS";
                scsb.InitialCatalog = "RecipeType";
                scsb.IntegratedSecurity = true;
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe ";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                }

                con.Close();
                con.Open();
                string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                }

                con.Close();
                con.Open();
                string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                // SqlDataReader reader2 = cmd2.ExecuteReader();
                cmd2.ExecuteNonQuery();



                //while (reader2.Read())
                //{
                //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                // int row = strStepname.Count();
                for (int i = 0; i < strStepname1.Count(); i += 1)
                {


                    int count = i + 1;
                    // await Task.Delay(2000);

                    lblStepName.Text = strStepname1[i];

                    lblnum.Text = "," + count + "/" + strStepname1.Count();
                    // lblnum.Text = "," + count + "/" + strStepname.Count();

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////跑參數

                    //con.Open();

                    /* for (i = 1; i <= Sec; i++)
                     {
                         lblData.Text = i.ToString() + "/" + mySec.ToString();
                         await Task.Delay(1000);


                     }*/
                    ////////////
                    con.Close();
                    con.Open();

                    string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                    SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                    cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                    cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                    SqlDataReader reader2 = cmd3.ExecuteReader();
                    while (reader2.Read())
                    {


                        lblCI2.Text = string.Format("{0}", reader2["CI2"]) + " " + "sccm";
                        backCI2.BackColor = Color.LimeGreen;
                        if (lblCI2.Text == "0.0 sccm")
                        {
                            backCI2.BackColor = Color.Silver;
                        }
                        lblBCI3.Text = string.Format("{0}", reader2["BCI3"]) + " " + "sccm";
                        backBCI3.BackColor = Color.LimeGreen;
                        if (lblBCI3.Text == "0.0 sccm")
                        {
                            backBCI3.BackColor = Color.Silver;
                        }
                        lblSF6.Text = string.Format("{0}", reader2["SF6"]) + " " + "sccm";
                        backSF6.BackColor = Color.LimeGreen;
                        if (lblSF6.Text == "0.0 sccm")
                        {
                            backSF6.BackColor = Color.Silver;
                        }
                        lblCHF3.Text = string.Format("{0}", reader2["CHF3"]) + " " + "sccm";
                        backCHF3.BackColor = Color.LimeGreen;
                        if (lblCHF3.Text == "0.0 sccm")
                        {
                            backCHF3.BackColor = Color.Silver;
                        }
                        lblOxygen.Text = string.Format("{0}", reader2["Oxygen"]) + " " + "sccm";
                        backOxygen.BackColor = Color.LimeGreen;
                        if (lblOxygen.Text == "0.0 sccm")
                        {
                            backOxygen.BackColor = Color.Silver;
                        }
                        lblOxygen1.Text = string.Format("{0}", reader2["Oxygen1"]) + " " + "sccm";
                        backOxygen1.BackColor = Color.LimeGreen;
                        if (lblOxygen1.Text == "0.0 sccm")
                        {
                            backOxygen1.BackColor = Color.Silver;
                        }
                        lblNitrogen.Text = string.Format("{0}", reader2["Nitrogen"]) + " " + "sccm";
                        backNitrogen.BackColor = Color.LimeGreen;
                        if (lblNitrogen.Text == "0.0 sccm")
                        {
                            backNitrogen.BackColor = Color.Silver;
                        }
                        lblArgon.Text = string.Format("{0}", reader2["Argon"]) + " " + "sccm";
                        backArgon.BackColor = Color.LimeGreen;
                        if (lblArgon.Text == "0.0 sccm")
                        {
                            backArgon.BackColor = Color.Silver;
                        }
                    }


                    ////////


                    con.Close();








                    ///////////


                    con.Open();
                    string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                    SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                    cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                    SqlDataReader readerSec = cmdSec.ExecuteReader();


                    while (readerSec.Read())
                    {
                        mySec = readerSec["ProcessTime"].ToString();
                        // lblSec.Text = readerSec["ProcessPressure"].ToString();
                        Int32.TryParse(mySec, out Sec);



                    }

                    for (int j = 1; j <= Sec; j++)
                    {
                        lblData.Text = j.ToString() + "/" + mySec.ToString() + " Sec";

                        await Task.Delay(1000);


                    }



                    con.Close();

                   // lblWafer.BackColor = Color.White;
                  //  lblWafer.Text = "";





                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    /*  for (int j = 1; j <= 12; j += 1)
                      {

                      }*/
                    // con.Open();
                    // string strSQLStepSec = "select * from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where newrecipe.stepname = @NewSec";






                    //  await Task.Delay(3000);

                  

                }

                //}










                /*  string strSQL3 = "select * from newrecipe where stepname = @Newstepname";

                  SqlCommand cmd3 = new SqlCommand(strSQL3,con);
                  cmd3.Parameters.AddWithValue("@Newstepname",lblStepName.Text);
                  SqlDataReader reader2 = cmd3.ExecuteReader();
                  while (reader2.Read())
                  {
                      lblCI2.Text = string.Format("{0}", reader2["CI2"])+""+"sccm";

                  }*/

                this.Close();

            }

        }


        private void btnPoint_Click(object sender, EventArgs e)
        {
            switch (btnPoint.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Point of use Valve Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnPoint.Image = Properties.Resources.open;
                        btnPoint.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Point of use Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnPoint.Image = Properties.Resources.close;
                        btnPoint.Image.Tag = "close";

                    }


                    break;


            }

        }

        private void btnHeliumChamber_Click(object sender, EventArgs e)
        {
            switch (btnHeliumChamber.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Helium Chamber Valve is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnHeliumChamber.Image = Properties.Resources.open;
                        btnHeliumChamber.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Helium Chamber Valve is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnHeliumChamber.Image = Properties.Resources.close;
                        btnHeliumChamber.Image.Tag = "close";

                    }


                    break;


            }



        }

        private void btnHeliumPump_Click(object sender, EventArgs e)
        {
            switch (btnHeliumPump.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Helium Pump Valve is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnHeliumPump.Image = Properties.Resources.open;
                        btnHeliumPump.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Helium Pump Valve is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnHeliumPump.Image = Properties.Resources.close;
                        btnHeliumPump.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnTurbo_Click(object sender, EventArgs e)
        {
            switch (btnTurbo.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Turbo Nitrogen bleed valve is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnTurbo.Image = Properties.Resources.open;
                        btnTurbo.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Turbo Nitrogen bleed valve is open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnTurbo.Image = Properties.Resources.close;
                        btnTurbo.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnRoughing_Click(object sender, EventArgs e)
        {
            switch (btnRoughing.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Roughing Valve is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnRoughing.Image = Properties.Resources.open;
                        btnRoughing.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Roughing Valve is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnRoughing.Image = Properties.Resources.close;
                        btnRoughing.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnChamberBypass_Click(object sender, EventArgs e)
        {
            switch (btnChamberBypass.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Chamber bypass valve is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnChamberBypass.Image = Properties.Resources.open;
                        btnChamberBypass.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Chamber bypass valve is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnChamberBypass.Image = Properties.Resources.close;
                        btnChamberBypass.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnCI2ValvePurge_Click(object sender, EventArgs e)
        {
            switch (btnCI2ValvePurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "CI2 Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnCI2ValvePurge.Image = Properties.Resources.open;
                        btnCI2ValvePurge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "CI2 Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnCI2ValvePurge.Image = Properties.Resources.close;
                        btnCI2ValvePurge.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnCI2ValveIn_Click(object sender, EventArgs e)
        {
            switch (btnCI2ValveIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "CI2 Valve in Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnCI2ValveIn.Image = Properties.Resources.open;
                        btnCI2ValveIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Ammonia in Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnCI2ValveIn.Image = Properties.Resources.close;
                        btnCI2ValveIn.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnCHF3ValveOut_Click(object sender, EventArgs e)
        {
            switch (btnCHF3ValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "CHF3 Valve out Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnCHF3ValveOut.Image = Properties.Resources.open;
                        btnCHF3ValveOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Ammonia Valve out Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnCHF3ValveOut.Image = Properties.Resources.close;
                        btnCHF3ValveOut.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnCI2ValveOut_Click(object sender, EventArgs e)
        {
            switch (btnCI2ValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "CI2 Valve out Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnCI2ValveOut.Image = Properties.Resources.open;
                        btnCI2ValveOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "CI2 Valve out Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnCI2ValveOut.Image = Properties.Resources.close;
                        btnCI2ValveOut.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnBCI3ValvePurge_Click(object sender, EventArgs e)
        {
            switch (btnBCI3ValvePurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "BCI3 Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnBCI3ValvePurge.Image = Properties.Resources.open;
                        btnBCI3ValvePurge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "BCI3 Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnBCI3ValvePurge.Image = Properties.Resources.close;
                        btnBCI3ValvePurge.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnBCI3ValveIn_Click(object sender, EventArgs e)
        {
            switch (btnBCI3ValveIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "BCI3 Valve in Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnBCI3ValveIn.Image = Properties.Resources.open;
                        btnBCI3ValveIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "BCI3 Valve in Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnBCI3ValveIn.Image = Properties.Resources.close;
                        btnBCI3ValveIn.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnBCI3ValveOut_Click(object sender, EventArgs e)
        {
            switch (btnBCI3ValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "BCI3 Valve out Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnBCI3ValveOut.Image = Properties.Resources.open;
                        btnBCI3ValveOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "BCI3 Valve out Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnBCI3ValveOut.Image = Properties.Resources.close;
                        btnBCI3ValveOut.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnSF6ValvePurge_Click(object sender, EventArgs e)
        {
            switch (btnSF6ValvePurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "SF6 Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnSF6ValvePurge.Image = Properties.Resources.open;
                        btnSF6ValvePurge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "SF6 Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnSF6ValvePurge.Image = Properties.Resources.close;
                        btnSF6ValvePurge.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnSF6ValveIn_Click(object sender, EventArgs e)
        {
            switch (btnSF6ValveIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "SF6 Valve in Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnSF6ValveIn.Image = Properties.Resources.open;
                        btnSF6ValveIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "SF6 Valve in Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnSF6ValveIn.Image = Properties.Resources.close;
                        btnSF6ValveIn.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnSF6ValveOut_Click(object sender, EventArgs e)
        {
            switch (btnSF6ValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "SF6 Valve out Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnSF6ValveOut.Image = Properties.Resources.open;
                        btnSF6ValveOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "SF6 Valve out Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnSF6ValveOut.Image = Properties.Resources.close;
                        btnSF6ValveOut.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnCHF3ValvePurge_Click(object sender, EventArgs e)
        {
            switch (btnCHF3ValvePurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "CHF3 Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnCHF3ValvePurge.Image = Properties.Resources.open;
                        btnCHF3ValvePurge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "CHF3 Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnCHF3ValvePurge.Image = Properties.Resources.close;
                        btnCHF3ValvePurge.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnCHF3ValveIn_Click(object sender, EventArgs e)
        {
            switch (btnCHF3ValveIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "CHF3 Valve in Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnCHF3ValveIn.Image = Properties.Resources.open;
                        btnCHF3ValveIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "CHF3 Valve in Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnCHF3ValveIn.Image = Properties.Resources.close;
                        btnCHF3ValveIn.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnOxygenValvePurge_Click(object sender, EventArgs e)
        {
            switch (btnOxygenValvePurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Oxygen Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnOxygenValvePurge.Image = Properties.Resources.open;
                        btnOxygenValvePurge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygenValvePurge.Image = Properties.Resources.close;
                        btnOxygenValvePurge.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnOxygenValveIn_Click(object sender, EventArgs e)
        {
            switch (btnOxygenValveIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Oxygen Valve in Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnOxygenValveIn.Image = Properties.Resources.open;
                        btnOxygenValveIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve in Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygenValveIn.Image = Properties.Resources.close;
                        btnOxygenValveIn.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnOxygenValveOut_Click(object sender, EventArgs e)
        {
            switch (btnOxygenValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Oxygen Valve out Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnOxygenValveOut.Image = Properties.Resources.open;
                        btnOxygenValveOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve out Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygenValveOut.Image = Properties.Resources.close;
                        btnOxygenValveOut.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnOxygen1ValvePurge_Click(object sender, EventArgs e)
        {
            switch (btnOxygen1ValvePurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Oxygen Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnOxygen1ValvePurge.Image = Properties.Resources.open;
                        btnOxygen1ValvePurge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygen1ValvePurge.Image = Properties.Resources.close;
                        btnOxygen1ValvePurge.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnOxygen1ValveIn_Click(object sender, EventArgs e)
        {
            switch (btnOxygen1ValveIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "oxygen Valve in Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnOxygen1ValveIn.Image = Properties.Resources.open;
                        btnOxygen1ValveIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve in Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygen1ValveIn.Image = Properties.Resources.close;
                        btnOxygen1ValveIn.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnOxygen1ValveOut_Click(object sender, EventArgs e)
        {
            switch (btnOxygen1ValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Oxygen Valve out Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnOxygen1ValveOut.Image = Properties.Resources.open;
                        btnOxygen1ValveOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve out Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygen1ValveOut.Image = Properties.Resources.close;
                        btnOxygen1ValveOut.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnNitrogenValveIn_Click(object sender, EventArgs e)
        {
            switch (btnNitrogenValveIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Nithrogen Valve in Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnNitrogenValveIn.Image = Properties.Resources.open;
                        btnNitrogenValveIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Nithrogen Valve in Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnNitrogenValveIn.Image = Properties.Resources.close;
                        btnNitrogenValveIn.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnNitrogenValveOut_Click(object sender, EventArgs e)
        {
            switch (btnNitrogenValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Nitrogen Valve out Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnNitrogenValveOut.Image = Properties.Resources.open;
                        btnNitrogenValveOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Nitrogen Valve out Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnNitrogenValveOut.Image = Properties.Resources.close;
                        btnNitrogenValveOut.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnArgonValveIn_Click(object sender, EventArgs e)
        {
            switch (btnSF6ValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Argon Valve in Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnArgonValveIn.Image = Properties.Resources.open;
                        btnArgonValveIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Argon Valve in Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnArgonValveIn.Image = Properties.Resources.close;
                        btnArgonValveIn.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnArgonValveOut_Click(object sender, EventArgs e)
        {
            switch (btnArgonValveOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Argon Valve out Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnArgonValveOut.Image = Properties.Resources.open;
                        btnArgonValveOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Argon Valve out Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnArgonValveOut.Image = Properties.Resources.close;
                        btnArgonValveOut.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnN2Inlet_Click(object sender, EventArgs e)
        {
            switch (btnN2Inlet.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "N2 inlet Valve Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnN2Inlet.Image = Properties.Resources.open;
                        btnN2Inlet.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "N2 inlet Valve Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnN2Inlet.Image = Properties.Resources.close;
                        btnN2Inlet.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void btnManifold_Click(object sender, EventArgs e)
        {
            switch (btnManifold.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Manifold isolation is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        btnManifold.Image = Properties.Resources.open;
                        btnManifold.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Manifold isolation is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnManifold.Image = Properties.Resources.close;
                        btnManifold.Image.Tag = "close";

                    }


                    break;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PointOpen pointopen = new PointOpen();
            pointopen.label1.Text = "Gas Interlock";
            pointopen.button1.Text = "Set";
            pointopen.button2.Text = "Cancel Action";
            DialogResult dr = pointopen.ShowDialog();

            if (dr == DialogResult.OK)
            {

                

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICP icp = new ICP();
            icp.ShowDialog();





        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointOpen pointopen = new PointOpen();
            pointopen.label1.Text = "RF Interlock";
            pointopen.button1.Text = "Set";
            pointopen.button2.Text = "Cancel Action";
            DialogResult dr = pointopen.ShowDialog();

            if (dr == DialogResult.OK)
            {



            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Close();


        }
    }
}
