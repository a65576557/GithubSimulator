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
using Microsoft.VisualBasic;

namespace SimulatorApplication
{
    public partial class NewRecipe : Form
    {
       string strtag = "panel1";
        ListViewItem itm;
        public int row;
        List<string> strRecipeName = new List<string>();
        List<string> strStepName = new List<string>();
        List<string> strTimeDependentStep = new List<string>();
        List<string> strProcessTime = new List<string>();
        List<string> strProcessPressure = new List<string>();
        List<string> strProcessPressurePercent = new List<string>();
        List<string> strAPCSetpointPosition = new List<string>();
        List<string> strAPCMode = new List<string>();
        List<string> strActivePressureSensor = new List<string>();
        List<string> strSourcePower = new List<string>();
        List<string> strSourcePowerPercent = new List<string>();
        List<string> strSourceMUTuneCapacitor = new List<string>();
        List<string> strSourceMULoadCapacitor = new List<string>();
        List<string> strSourceRFControlMode = new List<string>();
        List<string> strPlatenPower = new List<string>();
        List<string> strPlatenPowerPercent = new List<string>();
        List<string> strPlatenCapacitorAdjust = new List<string>();
        List<string> strPlatenRFTuningCapacitor = new List<string>();
        List<string> strPlatenRFTuningCapacitorPercent = new List<string>();
        List<string> strPlatenRFLoadCapacitor = new List<string>();
        List<string> strPlatenRFLoadCapacitorPercent = new List<string>();
        List<string> strPlatenRFPaddingCapacitor = new List<string>();
        List<string> strPlatenRFControlMode = new List<string>();
        List<string> strHeliumPressure = new List<string>();
        List<string> strHeliumpressurePercent = new List<string>();
        List<string> strHeliumFlowWarningLevel = new List<string>();
        List<string> strHeliumFlowFaultLevel = new List<string>();
        List<string> strGasLineConfig = new List<string>();
        List<string> strArgon = new List<string>();
        List<string> strArgonPercent = new List<string>();
        List<string> strNitrogen = new List<string>();
        List<string> strNitrogenPercent = new List<string>();
        List<string> strOxygen = new List<string>();
        List<string> strOxygenPercent = new List<string>();
        List<string> strOxygen1 = new List<string>();
        List<string> strOxygen1Percent = new List<string>();
        List<string> strCHF3 = new List<string>();
        List<string> strCHF3Percent = new List<string>();
        List<string> strSF6 = new List<string>();
        List<string> strSF6Percent = new List<string>();
        List<string> strBCI3 = new List<string>();
        List<string> strBCI3Percent = new List<string>();
        List<string> strCI2 = new List<string>();
        List<string> strCI2Percent = new List<string>();

        public delegate void UpdateListbox(object sender, EventArgs e);
        public UpdateListbox updatelistbox;







        public  string recipeName;
        public string stepsearchname;
        SqlConnectionStringBuilder scsb;
        public NewRecipe()
        {
            InitializeComponent();
        }

        private void NewRecipe_Load(object sender, EventArgs e)
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









            //////////////////////////////////////////////////////////////////////////////////////////////////
            // if (float.Parse(tbTimeDependentStep.Text) > 10)
            //    { MessageBox.Show("請輸入小於10的數字"); }
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());

            con.Open();
            

       /*     string strSQL = "select StepName from Newrecipe";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                listboxstepname.Items.Add(reader["StepName"]);

            }*/
         //   reader.Close();
            con.Close();
            // TODO: 這行程式碼會將資料載入 'recipeTypeDataSet.Newrecipe' 資料表。您可以視需要進行移動或移除。
            // this.newrecipeTableAdapter.Fill(this.recipeTypeDataSet.Newrecipe);

            //stepsearchname= listboxnewrecipe.SelectedItem.ToString();


            /*  scsb = new SqlConnectionStringBuilder();
              scsb.DataSource = @"HP-PC\SQLEXPRESS";
              scsb.InitialCatalog = "RecipeType";
              scsb.IntegratedSecurity = true;
              RecipeType rct = new RecipeType();
              SqlConnection con = new SqlConnection(scsb.ToString());

              con.Open();


              string strSQL = "select StepName from Newrecipe inner join recipe on Newrecipe.recipeName = recipe.recipeName where Newrecipe.recipeName = @Newrecipename";

              SqlCommand cmd = new SqlCommand(strSQL, con);
              cmd.Parameters.AddWithValue("@Newrecipename", rct.tbrecipename.Text);
              SqlDataReader reader = cmd.ExecuteReader();
              while (reader.Read())
              {
                 // listboxnewrecipe.Items.Add(reader["StepName"]);


                  // tbStepName.Text = reader["Step Name"].ToString();
                  tbStepName.Text = string.Format("{0}", reader["StepName"]);

            



              }*/
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            /* SqlConnection con = new SqlConnection(scsb.ToString());
             con.Open();
             // String strSQL = "insert into Newrecipe values(@NewStepName,@NewTimeDependentStep,@NewProcessTime,@NewApcSetpointPosition,@NewApcMode)";
             string strSQL = "insert into Newrecipe(Step Name) values(@NewStepName1)";
             SqlCommand cmd = new SqlCommand(strSQL,con);
           //  SqlDataReader reader = cmd.ExecuteReader();
             cmd.Parameters.AddWithValue("@NewStepName1", tbStepName.Text);
             //cmd.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep);
             //cmd.Parameters.AddWithValue("@NewProcessTime", tbProcessTime);
             //cmd.Parameters.AddWithValue("@NewApcSetPointPosition", tbApcSetpointPosition);
             //cmd.Parameters.AddWithValue("@NewApcMode",cmbApcMode.Text);
             cmd.ExecuteNonQuery();
             con.Close();
             */
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            ////////////////////////////////////////////////////////////////////////將資料新增到暫存資料表
            string strSQL = "insert into TemNewrecipe (StepName,TimeDependentstep,ProcessTime,ProcessPressure,ProcessPressurePercent,APCSetpointPosition,APCMode,ActivePressureSensor,SourcePower,SourcePowerPercent" +
               ",SourceMUTuneCapacitor,SourceMULoadCapacitor,SourceRFControlMode,PlatenPower,PlatenPowerPercent,PlatenCapacitorAdjust,PlatenRFTuningCapacitor,PlatenRFTuningCapacitorPercent," +
               "PlatenRFLoadCapacitor,PlatenRFLoadCapacitorPercent,PlatenRFPaddingCapacitor,PlatenRFControlMode,HeliumPressure,HeliumPressurePercent,HeliumFlowWarninglevel,HeliumFlowFaultlevel," +
              "GasLineConfig,Argon,ArgonPercent,Nitrogen,NitrogenPercent,Oxygen,OxygenPercent,Oxygen1,Oxygen1Percent,CHF3,CHF3Percent,SF6,SF6Percent,BCI3,BCI3Percent,CI2,CI2Percent) values(@NewstepName,@NewTimeDependentStep,@NewProcessTime," +
              "@NewProcessPressure,@NewProcessPressurePercent,@NewAPCSetpointPosition,@NewAPCMode,@NewActivePressureSensor,@NewSoursePower,@NewSoursePowerPercent,@NewSourseMUtunecapacitor,@NewSourseMUloadcapacitor,@NewSourseRFcontrolMode," +
              "@NewPlatenPower,@NewPlatenPowerpercent,@NewplatenCapacitorAdjust,@NewPlatenRFTuningCapacitor,@NewPlatenRFTuningCapacitorpercent,@NewPlatenRFloadCapacitor,@NewPlatenRFloadCapacitorpercent,@NewPlatenRFpaddingCapacitor," +
             "@NewplatenRFcontrolMode,@NewHeliumpressure,@NewHeliumpressurepercent,@NewHeliumFlowWarninglevel,@NewHeliumFlowFaultlevel,@NewGasLineConfig,@NewArgon,@NewArgonpercent,@NewNitrogen,@NewNitrogenpercent,@NewOxygen," +
             "@NewOxygenpercent,@NewOxygen1,@NewOxygen1Percent,@NewCHF3,@NewCHF3percent,@NewSF6,@NewSF6percent,@NewBCI3,@NewBCI3percent,@NewCI2,@NewCI2percent)";
            SqlCommand cmd = new SqlCommand(strSQL, con);
           // cmd.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());
            cmd.Parameters.AddWithValue("@NewstepName", tbStepName.Text);
            cmd.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep.Text);
            cmd.Parameters.AddWithValue("@NewProcessTime", tbProcessTime.Text);
            cmd.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure.Text);
            cmd.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent.Text);
            cmd.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition.Text);
            cmd.Parameters.AddWithValue("@NewAPCMode", cmbApcMode.Text);
            cmd.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor.Text);
            cmd.Parameters.AddWithValue("@NewSoursePower", tbSourcePower.Text);
            cmd.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent.Text);
            cmd.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor.Text);
            cmd.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor.Text);
            cmd.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode.Text);
            cmd.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower.Text);
            cmd.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent.Text);
            cmd.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust.Text);
            cmd.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor.Text);
            cmd.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent.Text);
            cmd.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor.Text);
            cmd.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent.Text);
            cmd.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor.Text);
            cmd.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode.Text);
            cmd.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure.Text);
            cmd.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent.Text);
            cmd.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel.Text);
            cmd.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel.Text);
            cmd.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig.Text);
            cmd.Parameters.AddWithValue("@NewArgon", tbArgon.Text);
            cmd.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent.Text);
            cmd.Parameters.AddWithValue("@NewNitrogen", tbNitrogen.Text);
            cmd.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent.Text);
            cmd.Parameters.AddWithValue("@NewOxygen", tbOxygen.Text);
            cmd.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent.Text);
            cmd.Parameters.AddWithValue("@NewOxygen1", tbOxygen1.Text);
            cmd.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent.Text);
            cmd.Parameters.AddWithValue("@NewCHF3", tbCHF3.Text);
            cmd.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent.Text);
            cmd.Parameters.AddWithValue("@NewSF6", tbSF6.Text);
            cmd.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent.Text);
            cmd.Parameters.AddWithValue("@NewBCI3", tbBCI3.Text);
            cmd.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent.Text);
            cmd.Parameters.AddWithValue("@NewCI2", tbCI2.Text);
            cmd.Parameters.AddWithValue("@NewCI2percent", tbCI2Percent.Text);

            //////////////////////////////////////////////////////////加入字串集合

          /*  strStepName.Add(tbStepName.Text);
            strTimeDependentStep.Add(tbTimeDependentStep.Text);
            strProcessTime.Add(tbProcessTime.Text);
            strProcessPressure.Add(tbProcessPressure.Text);
            strProcessPressurePercent.Add(tbProcessPressurePercent.Text);
            strAPCSetpointPosition.Add(tbApcSetpointPosition.Text);
            strAPCMode.Add(cmbApcMode.Text);
            strActivePressureSensor.Add(cmbActivePressureSensor.Text);
            strSourcePower.Add(tbSourcePower.Text);
            strSourcePowerPercent.Add(tbSoursePowerPercent.Text);
            strSourceMUTuneCapacitor.Add(cmbSourceMUTuneCapacitor.Text);
            strSourceMULoadCapacitor.Add(cmbSourceMULoadCapacitor.Text);
            strSourceRFControlMode.Add(cmbSourceRFControlMode.Text);
            strPlatenPower.Add(tbPlatenPower.Text);
            strPlatenPowerPercent.Add(tbPlatenPowerPercent.Text);
            strPlatenCapacitorAdjust.Add(cmbPlatenCapacitorAdjust.Text);
            strPlatenRFTuningCapacitor.Add(tbPlatenRFTuningCapacitor.Text);
            strPlatenRFTuningCapacitorPercent.Add(tbPlatenRFTuningCapacitorPercent.Text);
            strPlatenRFLoadCapacitor.Add(tbPlatenRFLoadCapacitor.Text);
            strPlatenRFLoadCapacitorPercent.Add(tbPlatenRFLoadCapacitorPercent.Text);
            strPlatenRFPaddingCapacitor.Add(cmbPlatenRFPaddingCapacitor.Text);
            strPlatenRFControlMode.Add(cmbPlatenRFControlMode.Text);
            strHeliumPressure.Add(tbHeliumPressure.Text);
            strHeliumpressurePercent.Add(tbHeliumPressurePercent.Text);
            strHeliumFlowWarningLevel.Add(tbHeliumFlowWarningLevel.Text);
            strHeliumFlowFaultLevel.Add(tbHeliumFlowFaultLevel.Text);
            strGasLineConfig.Add(cmbGasLineConfig.Text);
            strArgon.Add(tbArgon.Text);
            strArgonPercent.Add(tbArgonPercent.Text);
            strNitrogen.Add(tbNitrogen.Text);
            strNitrogenPercent.Add(tbNitrogenPercent.Text);
            strOxygen.Add(tbOxygen.Text);
            strOxygenPercent.Add(tbOxygenPercent.Text);
            strOxygen1.Add(tbOxygen1.Text);
            strOxygen1Percent.Add(tbOxygen1Percent.Text);
            strCHF3.Add(tbCHF3.Text);
            strCHF3Percent.Add(tbCHF3Percent.Text);
            strSF6.Add(tbSF6.Text);
            strSF6Percent.Add(tbSF6Percent.Text);
            strBCI3.Add(tbBCI3.Text);
            strBCI3Percent.Add(tbBCI3Percent.Text);
            strCI2.Add(tbCI2.Text);
            strCI2Percent.Add(tbCI2Percent.Text);*/


            row = cmd.ExecuteNonQuery();
            con.Close();
            //////////////////////////////////////////將資料加入字串集合內
            /* con.Open();
             string strInsert = "select * from TemNewrecipe";
             SqlCommand cmd1 = new SqlCommand(strInsert, con);
              SqlDataReader reader = cmd1.ExecuteReader();

             while (reader.Read())
             {

                     strStepName.Add(string.Format("{0}", reader["StepName"]));
                     strTimeDependentStep.Add(string.Format("{0}", reader["TimeDependentStep"]));
                     strProcessTime.Add(string.Format("{0}", reader["ProcessTime"]));
                     strProcessPressure.Add(string.Format("{0}", reader["ProcessPressure"]));
                     strProcessPressurePercent.Add(string.Format("{0}", reader["ProcessPressurePercent"]));
                     strAPCSetpointPosition.Add(string.Format("{0}", reader["APCSetpointPosition"]));
                     strAPCMode.Add(string.Format("{0}", reader["APCMode"]));
                     strActivePressureSensor.Add(string.Format("{0}", reader["ActivePressureSensor"]));
                     strSourcePower.Add(string.Format("{0}", reader["SourcePower"]));
                     strSourcePowerPercent.Add(string.Format("{0}", reader["SourcePowerPercent"]));
                     strSourceMUTuneCapacitor.Add(string.Format("{0}", reader["SourceMUTuneCapacitor"]));
                     strSourceMULoadCapacitor.Add(string.Format("{0}", reader["SourceMULoadCapacitor"]));
                     strSourceRFControlMode.Add(string.Format("{0}", reader["SourceRFControlMode"]));
                     strPlatenPower.Add(string.Format("{0}", reader["PlatenPower"]));
                     strPlatenPowerPercent.Add(string.Format("{0}", reader["PlatenPowerPercent"]));
                     strPlatenCapacitorAdjust.Add(string.Format("{0}", reader["PlatenCapacitorAdjust"]));
                     strPlatenRFTuningCapacitor.Add(string.Format("{0}", reader["PlatenRFTuningCapacitor"]));
                     strPlatenRFTuningCapacitorPercent.Add(string.Format("{0}", reader["PlatenRFTuningCapacitorPercent"]));
                     strPlatenRFLoadCapacitor.Add(string.Format("{0}", reader["PlatenRFLoadCapacitor"]));
                     strPlatenRFLoadCapacitorPercent.Add(string.Format("{0}", reader["PlatenRFLoadCapacitorPercent"]));
                     strPlatenRFPaddingCapacitor.Add(string.Format("{0}", reader["ActivePressureSensor"]));
                     strPlatenRFControlMode.Add(string.Format("{0}", reader["PlatenRFControlMode"]));
                     strHeliumPressure.Add(string.Format("{0}", reader["HeliumPressure"]));
                     strHeliumpressurePercent.Add(string.Format("{0}", reader["HeliumpressurePercent"]));
                     strHeliumFlowWarningLevel.Add(string.Format("{0}", reader["HeliumFlowWarningLevel"]));
                     strHeliumFlowFaultLevel.Add(string.Format("{0}", reader["HeliumFlowFaultLevel"]));
                     strGasLineConfig.Add(string.Format("{0}", reader["GasLineConfig"]));
                     strArgon.Add(string.Format("{0}", reader["Argon"]));
                     strArgonPercent.Add(string.Format("{0}", reader["ArgonPercent"]));
                     strNitrogen.Add(string.Format("{0}", reader["Nitrogen"]));
                     strNitrogenPercent.Add(string.Format("{0}", reader["NitrogenPercent"]));
                     strOxygen.Add(string.Format("{0}", reader["Oxygen"]));
                     strOxygenPercent.Add(string.Format("{0}", reader["OxygenPercent"]));
                     strOxygen1.Add(string.Format("{0}", reader["Oxygen1"]));
                     strOxygen1Percent.Add(string.Format("{0}", reader["Oxygen1Percent"]));
                     strCHF3.Add(string.Format("{0}", reader["CHF3"]));
                     strCHF3Percent.Add(string.Format("{0}", reader["CHF3Percent"]));
                     strSF6.Add(string.Format("{0}", reader["SF6"]));
                     strSF6Percent.Add(string.Format("{0}", reader["SF6Percent"]));
                     strBCI3.Add(string.Format("{0}", reader["BCI3"]));
                     strBCI3Percent.Add(string.Format("{0}", reader["BCI3Percent"]));
                     strCI2.Add(string.Format("{0}", reader["CI2"]));
                     strCI2Percent.Add(string.Format("{0}", reader["CI2Percent"]));

             }*/
          
          
                ///////////////////////////////////////////////////////////////////////////////將StepName顯示於ListBoxStepName上
                con.Open();
         
            string strShow = "select * from TemNewrecipe";
                SqlCommand cmdShow = new SqlCommand(strShow, con);
                SqlDataReader reader1 = cmdShow.ExecuteReader();
            strStepName.Clear();
            strTimeDependentStep.Clear();
            strProcessTime.Clear();
            strProcessPressure.Clear();
            strProcessPressurePercent.Clear();
            strAPCSetpointPosition.Clear();
            strAPCMode.Clear();
            strActivePressureSensor.Clear();
            strSourcePower.Clear();
            strSourcePowerPercent.Clear();
            strSourceMUTuneCapacitor.Clear();
            strSourceMULoadCapacitor.Clear();
            strSourceRFControlMode.Clear();
            strPlatenPower.Clear();
            strPlatenPowerPercent.Clear();
            strPlatenCapacitorAdjust.Clear();
            strPlatenRFTuningCapacitor.Clear();
            strPlatenRFTuningCapacitorPercent.Clear();
            strPlatenRFLoadCapacitor.Clear();
            strPlatenRFLoadCapacitorPercent.Clear();
            strPlatenRFPaddingCapacitor.Clear();
            strPlatenRFControlMode.Clear();
            strHeliumPressure.Clear();
            strHeliumpressurePercent.Clear();
            strHeliumFlowWarningLevel.Clear();
            strHeliumFlowFaultLevel.Clear();
            strGasLineConfig.Clear();
            strArgon.Clear();
            strArgonPercent.Clear();
            strNitrogen.Clear();
            strNitrogenPercent.Clear();
            strOxygen.Clear();
            strOxygenPercent.Clear();
            strOxygen1.Clear();
            strOxygen1Percent.Clear();
            strCHF3.Clear();
            strCHF3Percent.Clear();
            strSF6.Clear();
            strSF6Percent.Clear();
            strBCI3.Clear();
            strBCI3Percent.Clear();
            strCI2.Clear();
            strCI2Percent.Clear();


            while (reader1.Read())
                {

                strStepName.Add(string.Format("{0}", reader1["StepName"]));
                strTimeDependentStep.Add(string.Format("{0}", reader1["TimeDependentStep"]));
                strProcessTime.Add(string.Format("{0}", reader1["ProcessTime"]));
                strProcessPressure.Add(string.Format("{0}", reader1["ProcessPressure"]));
                strProcessPressurePercent.Add(string.Format("{0}", reader1["ProcessPressurePercent"]));
                strAPCSetpointPosition.Add(string.Format("{0}", reader1["APCSetPointPosition"]));
                strAPCMode.Add(string.Format("{0}", reader1["APCMode"]));
                strActivePressureSensor.Add(string.Format("{0}", reader1["ActivePressureSensor"]));
                strSourcePower.Add(string.Format("{0}", reader1["SourcePower"]));
                strSourcePowerPercent.Add(string.Format("{0}", reader1["SourcePowerPercent"]));
                strSourceMUTuneCapacitor.Add(string.Format("{0}", reader1["SourceMUTuneCapacitor"]));
                strSourceMULoadCapacitor.Add(string.Format("{0}", reader1["SourceMULoadCapacitor"]));
                strSourceRFControlMode.Add(string.Format("{0}", reader1["SourceRFControlMode"]));
                strPlatenPower.Add(string.Format("{0}", reader1["PlatenPower"]));
                strPlatenPowerPercent.Add(string.Format("{0}", reader1["PlatenPowerPercent"]));
                strPlatenCapacitorAdjust.Add(string.Format("{0}", reader1["PlatenCapacitorAdjust"]));
                strPlatenRFTuningCapacitor.Add(string.Format("{0}", reader1["PlatenRFTuningCapacitor"]));
                strPlatenRFTuningCapacitorPercent.Add(string.Format("{0}", reader1["PlatenRFTuningCapacitorPercent"]));
                strPlatenRFLoadCapacitor.Add(string.Format("{0}", reader1["PlatenRFLoadCapacitor"]));
                strPlatenRFLoadCapacitorPercent.Add(string.Format("{0}", reader1["PlatenRFLoadCapacitorPercent"]));
                strPlatenRFPaddingCapacitor.Add(string.Format("{0}", reader1["PlatenRFPaddingCapacitor"]));
                strPlatenRFControlMode.Add(string.Format("{0}", reader1["PlatenRFControlMode"]));
                strHeliumPressure.Add(string.Format("{0}", reader1["HeliumPressure"]));
                strHeliumpressurePercent.Add(string.Format("{0}", reader1["HeliumPressurePercent"]));
                strHeliumFlowWarningLevel.Add(string.Format("{0}", reader1["HeliumFlowWarningLevel"]));
                strHeliumFlowFaultLevel.Add(string.Format("{0}", reader1["HeliumFlowFaultLevel"]));
                strGasLineConfig.Add(string.Format("{0}", reader1["GasLineConfig"]));
                strArgon.Add(string.Format("{0}", reader1["Argon"]));
                strArgonPercent.Add(string.Format("{0}", reader1["ArgonPercent"]));
                strNitrogen.Add(string.Format("{0}", reader1["Nitrogen"]));
                strNitrogenPercent.Add(string.Format("{0}", reader1["NitrogenPercent"]));
                strOxygen.Add(string.Format("{0}", reader1["Oxygen"]));
                strOxygenPercent.Add(string.Format("{0}", reader1["OxygenPercent"]));
                strOxygen1.Add(string.Format("{0}", reader1["Oxygen1"]));
                strOxygen1Percent.Add(string.Format("{0}", reader1["Oxygen1Percent"]));
                strCHF3.Add(string.Format("{0}", reader1["CHF3"]));
                strCHF3Percent.Add(string.Format("{0}", reader1["CHF3Percent"]));
                strSF6.Add(string.Format("{0}", reader1["SF6"]));
                strSF6Percent.Add(string.Format("{0}", reader1["SF6Percent"]));
                strBCI3.Add(string.Format("{0}", reader1["BCI3"]));
                strBCI3Percent.Add(string.Format("{0}", reader1["BCI3Percent"]));
                strCI2.Add(string.Format("{0}", reader1["CI2"]));
                strCI2Percent.Add(string.Format("{0}", reader1["CI2Percent"]));













            }


                con.Close();


          

        







        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(listView1.SelectedItems[0].SubItems[1].Text);
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSQL = "insert into recipe (recipeName,recipeDate) values(@NewrecipeName,@NewrecipeDate)";
            string strSQL1 = "insert into Newrecipe (recipeName,StepName,TimeDependentstep,ProcessTime,ProcessPressure,ProcessPressurePercent,APCSetpointPosition,APCMode,ActivePressureSensor,SourcePower,SourcePowerPercent"+
                ",SourceMUTuneCapacitor,SourceMULoadCapacitor,SourceRFControlMode,PlatenPower,PlatenPowerPercent,PlatenCapacitorAdjust,PlatenRFTuningCapacitor,PlatenRFTuningCapacitorPercent,"+
                "PlatenRFLoadCapacitor,PlatenRFLoadCapacitorPercent,PlatenRFPaddingCapacitor,PlatenRFControlMode,HeliumPressure,HeliumPressurePercent,HeliumFlowWarninglevel,HeliumFlowFaultlevel,"+
               "GasLineConfig,Argon,ArgonPercent,Nitrogen,NitrogenPercent,Oxygen,OxygenPercent,Oxygen1,Oxygen1Percent,CHF3,CHF3Percent,SF6,SF6Percent,BCI3,BCI3Percent,CI2,CI2Percent) values(@NewrecipeName,@NewstepName,@NewTimeDependentStep,@NewProcessTime,"+
               "@NewProcessPressure,@NewProcessPressurePercent,@NewAPCSetpointPosition,@NewAPCMode,@NewActivePressureSensor,@NewSoursePower,@NewSoursePowerPercent,@NewSourseMUtunecapacitor,@NewSourseMUloadcapacitor,@NewSourseRFcontrolMode,"+
               "@NewPlatenPower,@NewPlatenPowerpercent,@NewplatenCapacitorAdjust,@NewPlatenRFTuningCapacitor,@NewPlatenRFTuningCapacitorpercent,@NewPlatenRFloadCapacitor,@NewPlatenRFloadCapacitorpercent,@NewPlatenRFpaddingCapacitor,"+
              "@NewplatenRFcontrolMode,@NewHeliumpressure,@NewHeliumpressurepercent,@NewHeliumFlowWarninglevel,@NewHeliumFlowFaultlevel,@NewGasLineConfig,@NewArgon,@NewArgonpercent,@NewNitrogen,@NewNitrogenpercent,@NewOxygen,"+
              "@NewOxygenpercent,@NewOxygen1,@NewOxygen1Percent,@NewCHF3,@NewCHF3percent,@NewSF6,@NewSF6percent,@NewBCI3,@NewBCI3percent,@NewCI2,@NewCI2percent)";



            // string strSQL2 = "insert into Newrecipe(step Name)values(@NewstepName)";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            

            CustomMessageBox messgebox = new CustomMessageBox();
            DialogResult dr = messgebox.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ///////////////////////////////////////////////////////////增加新的Recipe
                //recipeName=  messgebox.GetMsg();
                cmd.Parameters.AddWithValue("@NewrecipeName",messgebox.GetMsg().ToString());
                cmd.Parameters.AddWithValue("@NewrecipeDate", DateTime.Now);
               // SqlDataReader reader1 = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                con.Close();
                ////////////////////////////////////////////將暫存資料表的資料存入NewRecipe
                con.Open();
                //reader1.Close();

                /*  for (int i = 0; i < strStepName.Count; i += 1)
                  {
                      SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                      cmd1.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                      cmd1.Parameters.AddWithValue("@NewstepName", strStepName[i]);
                      cmd1.Parameters.AddWithValue("@NewTimeDependentStep", strTimeDependentStep[i]);
                      cmd1.Parameters.AddWithValue("@NewProcessTime", strProcessTime[i]);
                      cmd1.Parameters.AddWithValue("@NewProcessPressure", strProcessPressure[i]);
                      cmd1.Parameters.AddWithValue("@NewProcessPressurePercent",strProcessPressurePercent[i]);
                      cmd1.Parameters.AddWithValue("@NewAPCSetpointPosition", strAPCSetpointPosition[i]);
                      cmd1.Parameters.AddWithValue("@NewAPCMode", strAPCMode[i]);
                      cmd1.Parameters.AddWithValue("@NewActivePressureSensor", strActivePressureSensor[i]);
                      cmd1.Parameters.AddWithValue("@NewSoursePower", strSourcePower[i]);
                      cmd1.Parameters.AddWithValue("@NewSoursePowerPercent", strSourcePowerPercent[i]);
                      cmd1.Parameters.AddWithValue("@NewSourseMUtunecapacitor", strSourceMUTuneCapacitor[i]);
                      cmd1.Parameters.AddWithValue("@NewSourseMUloadcapacitor", strSourceMULoadCapacitor[i]);
                      cmd1.Parameters.AddWithValue("@NewSourseRFcontrolMode", strSourceRFControlMode[i]);
                      cmd1.Parameters.AddWithValue("@NewPlatenPower", strPlatenPower[i]);
                      cmd1.Parameters.AddWithValue("@NewPlatenPowerpercent", strPlatenPowerPercent[i]);
                      cmd1.Parameters.AddWithValue("@NewplatenCapacitorAdjust", strPlatenCapacitorAdjust[i]);
                      cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", strPlatenRFTuningCapacitor[i]);
                      cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", strPlatenRFTuningCapacitorPercent[i]);
                      cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", strPlatenRFLoadCapacitor[i]);
                      cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", strPlatenRFLoadCapacitorPercent[i]);
                      cmd1.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", strPlatenRFPaddingCapacitor[i]);
                      cmd1.Parameters.AddWithValue("@NewplatenRFcontrolMode", strPlatenRFControlMode[i]);
                      cmd1.Parameters.AddWithValue("@NewHeliumpressure", strHeliumPressure[i]);
                      cmd1.Parameters.AddWithValue("@NewHeliumpressurepercent", strHeliumpressurePercent[i]);
                      cmd1.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", strHeliumFlowWarningLevel[i]);
                      cmd1.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", strHeliumFlowFaultLevel[i]);
                      cmd1.Parameters.AddWithValue("@NewGasLineConfig", strGasLineConfig[i]);
                      cmd1.Parameters.AddWithValue("@NewArgon", strArgon[i]);
                      cmd1.Parameters.AddWithValue("@NewArgonpercent", strArgonPercent[i]);
                      cmd1.Parameters.AddWithValue("@NewNitrogen", strNitrogen[i]);
                      cmd1.Parameters.AddWithValue("@NewNitrogenpercent", strNitrogenPercent[i]);
                      cmd1.Parameters.AddWithValue("@NewOxygen", strOxygen[i]);
                      cmd1.Parameters.AddWithValue("@NewOxygenpercent", strOxygenPercent[i]);
                      cmd1.Parameters.AddWithValue("@NewOxygen1", strOxygen1[i]);
                      cmd1.Parameters.AddWithValue("@NewOxygen1Percent", strOxygen1Percent[i]);
                      cmd1.Parameters.AddWithValue("@NewCHF3", strCHF3[i]);
                      cmd1.Parameters.AddWithValue("@NewCHF3percent", strCHF3Percent[i]);
                      cmd1.Parameters.AddWithValue("@NewSF6", strSF6[i]);
                      cmd1.Parameters.AddWithValue("@NewSF6percent", strSF6Percent[i]);
                      cmd1.Parameters.AddWithValue("@NewBCI3", strBCI3[i]);
                      cmd1.Parameters.AddWithValue("@NewBCI3percent", strBCI3Percent[i]);
                      cmd1.Parameters.AddWithValue("@NewCI2", strCI2[i]);
                      cmd1.Parameters.AddWithValue("@NewCI2percent", strCI2Percent[i]);




                      //NewRecipe_Load(sender, e);
                      //this.Refresh();




                      //SqlDataReader reader = cmd.ExecuteReader();
                      cmd1.ExecuteNonQuery();



                  }*/

                if (strtag == "panel1")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                    cmd1.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd1.Parameters.AddWithValue("@NewstepName", tbStepName.Text);
                    cmd1.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessTime", tbProcessTime.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent.Text);
                    cmd1.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition.Text);
                    cmd1.Parameters.AddWithValue("@NewAPCMode", cmbApcMode.Text);
                    cmd1.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor.Text);
                    cmd1.Parameters.AddWithValue("@NewSoursePower", tbSourcePower.Text);
                    cmd1.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel.Text);
                    cmd1.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig.Text);
                    cmd1.Parameters.AddWithValue("@NewArgon", tbArgon.Text);
                    cmd1.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewNitrogen", tbNitrogen.Text);
                    cmd1.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen", tbOxygen.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen1", tbOxygen1.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewCHF3", tbCHF3.Text);
                    cmd1.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewSF6", tbSF6.Text);
                    cmd1.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewBCI3", tbBCI3.Text);
                    cmd1.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewCI2", _tbCI2.Text);
                    cmd1.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent.Text);
                    cmd1.ExecuteNonQuery();

                }
                else if (strtag == "panel2")
                {

                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                    cmd1.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd1.Parameters.AddWithValue("@NewstepName", tbStepName.Text);
                    cmd1.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessTime", tbProcessTime.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent.Text);
                    cmd1.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition.Text);
                    cmd1.Parameters.AddWithValue("@NewAPCMode", cmbApcMode.Text);
                    cmd1.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor.Text);
                    cmd1.Parameters.AddWithValue("@NewSoursePower", tbSourcePower.Text);
                    cmd1.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel.Text);
                    cmd1.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig.Text);
                    cmd1.Parameters.AddWithValue("@NewArgon", tbArgon.Text);
                    cmd1.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewNitrogen", tbNitrogen.Text);
                    cmd1.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen", tbOxygen.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen1", tbOxygen1.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewCHF3", tbCHF3.Text);
                    cmd1.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewSF6", tbSF6.Text);
                    cmd1.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewBCI3", tbBCI3.Text);
                    cmd1.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewCI2", _tbCI2.Text);
                    cmd1.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent.Text);
                    cmd1.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);
                    cmd2.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd2.Parameters.AddWithValue("@NewstepName", tbStepName2.Text);
                    cmd2.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessTime", tbProcessTime2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition2.Text);
                    cmd2.Parameters.AddWithValue("@NewAPCMode", cmbApcMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSoursePower", tbSourcePower2.Text);
                    cmd2.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel2.Text);
                    cmd2.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig2.Text);
                    cmd2.Parameters.AddWithValue("@NewArgon", tbArgon2.Text);
                    cmd2.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewNitrogen", tbNitrogen2.Text);
                    cmd2.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen", tbOxygen2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewCHF3", tbCHF3_2.Text);
                    cmd2.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewSF6", tbSF6_2.Text);
                    cmd2.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewBCI3", tbBCI3_2.Text);
                    cmd2.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewCI2", _tbCI2_2.Text);
                    cmd2.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent2.Text);
                    cmd2.ExecuteNonQuery();









                }

                else if (strtag == "panel3")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                    cmd1.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd1.Parameters.AddWithValue("@NewstepName", tbStepName.Text);
                    cmd1.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessTime", tbProcessTime.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent.Text);
                    cmd1.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition.Text);
                    cmd1.Parameters.AddWithValue("@NewAPCMode", cmbApcMode.Text);
                    cmd1.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor.Text);
                    cmd1.Parameters.AddWithValue("@NewSoursePower", tbSourcePower.Text);
                    cmd1.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel.Text);
                    cmd1.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig.Text);
                    cmd1.Parameters.AddWithValue("@NewArgon", tbArgon.Text);
                    cmd1.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewNitrogen", tbNitrogen.Text);
                    cmd1.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen", tbOxygen.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen1", tbOxygen1.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewCHF3", tbCHF3.Text);
                    cmd1.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewSF6", tbSF6.Text);
                    cmd1.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewBCI3", tbBCI3.Text);
                    cmd1.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewCI2", _tbCI2.Text);
                    cmd1.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent.Text);
                    cmd1.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);
                    cmd2.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd2.Parameters.AddWithValue("@NewstepName", tbStepName2.Text);
                    cmd2.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessTime", tbProcessTime2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition2.Text);
                    cmd2.Parameters.AddWithValue("@NewAPCMode", cmbApcMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSoursePower", tbSourcePower2.Text);
                    cmd2.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel2.Text);
                    cmd2.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig2.Text);
                    cmd2.Parameters.AddWithValue("@NewArgon", tbArgon2.Text);
                    cmd2.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewNitrogen", tbNitrogen2.Text);
                    cmd2.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen", tbOxygen2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewCHF3", tbCHF3_2.Text);
                    cmd2.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewSF6", tbSF6_2.Text);
                    cmd2.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewBCI3", tbBCI3_2.Text);
                    cmd2.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewCI2", _tbCI2_2.Text);
                    cmd2.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent2.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(strSQL1, con);
                    cmd3.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd3.Parameters.AddWithValue("@NewstepName", tbStepName3.Text);
                    cmd3.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep3.Text);
                    cmd3.Parameters.AddWithValue("@NewProcessTime", tbProcessTime3.Text);
                    cmd3.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure3.Text);
                    cmd3.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition3.Text);
                    cmd3.Parameters.AddWithValue("@NewAPCMode", cmbApcMode3.Text);
                    cmd3.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor3.Text);
                    cmd3.Parameters.AddWithValue("@NewSoursePower", tbSourcePower3.Text);
                    cmd3.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode3.Text);
                    cmd3.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure3.Text);
                    cmd3.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel3.Text);
                    cmd3.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel3.Text);
                    cmd3.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig3.Text);
                    cmd3.Parameters.AddWithValue("@NewArgon", tbArgon3.Text);
                    cmd3.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewNitrogen", tbNitrogen3.Text);
                    cmd3.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewOxygen", tbOxygen3.Text);
                    cmd3.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_3.Text);
                    cmd3.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent3.Text);
                    cmd3.Parameters.AddWithValue("@NewCHF3", tbCHF3_3.Text);
                    cmd3.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent2.Text);
                    cmd3.Parameters.AddWithValue("@NewSF6", tbSF6_2.Text);
                    cmd3.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent3.Text);
                    cmd3.Parameters.AddWithValue("@NewBCI3", tbBCI3_3.Text);
                    cmd3.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent3.Text);
                    cmd3.Parameters.AddWithValue("@NewCI2", _tbCI2_3.Text);
                    cmd3.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent3.Text);
                    cmd3.ExecuteNonQuery();





                }
                else if (strtag == "panel4")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                    cmd1.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd1.Parameters.AddWithValue("@NewstepName", tbStepName.Text);
                    cmd1.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessTime", tbProcessTime.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure.Text);
                    cmd1.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent.Text);
                    cmd1.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition.Text);
                    cmd1.Parameters.AddWithValue("@NewAPCMode", cmbApcMode.Text);
                    cmd1.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor.Text);
                    cmd1.Parameters.AddWithValue("@NewSoursePower", tbSourcePower.Text);
                    cmd1.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor.Text);
                    cmd1.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel.Text);
                    cmd1.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel.Text);
                    cmd1.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig.Text);
                    cmd1.Parameters.AddWithValue("@NewArgon", tbArgon.Text);
                    cmd1.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewNitrogen", tbNitrogen.Text);
                    cmd1.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen", tbOxygen.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen1", tbOxygen1.Text);
                    cmd1.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewCHF3", tbCHF3.Text);
                    cmd1.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewSF6", tbSF6.Text);
                    cmd1.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewBCI3", tbBCI3.Text);
                    cmd1.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent.Text);
                    cmd1.Parameters.AddWithValue("@NewCI2", _tbCI2.Text);
                    cmd1.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent.Text);
                    cmd1.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand(strSQL1, con);
                    cmd2.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd2.Parameters.AddWithValue("@NewstepName", tbStepName2.Text);
                    cmd2.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessTime", tbProcessTime2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure2.Text);
                    cmd2.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition2.Text);
                    cmd2.Parameters.AddWithValue("@NewAPCMode", cmbApcMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSoursePower", tbSourcePower2.Text);
                    cmd2.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor2.Text);
                    cmd2.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel2.Text);
                    cmd2.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel2.Text);
                    cmd2.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig2.Text);
                    cmd2.Parameters.AddWithValue("@NewArgon", tbArgon2.Text);
                    cmd2.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewNitrogen", tbNitrogen2.Text);
                    cmd2.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen", tbOxygen2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_2.Text);
                    cmd2.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewCHF3", tbCHF3_2.Text);
                    cmd2.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewSF6", tbSF6_2.Text);
                    cmd2.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewBCI3", tbBCI3_2.Text);
                    cmd2.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent2.Text);
                    cmd2.Parameters.AddWithValue("@NewCI2", _tbCI2_2.Text);
                    cmd2.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent2.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(strSQL1, con);
                    cmd3.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd3.Parameters.AddWithValue("@NewstepName", tbStepName3.Text);
                    cmd3.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep3.Text);
                    cmd3.Parameters.AddWithValue("@NewProcessTime", tbProcessTime3.Text);
                    cmd3.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure3.Text);
                    cmd3.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition3.Text);
                    cmd3.Parameters.AddWithValue("@NewAPCMode", cmbApcMode3.Text);
                    cmd3.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor3.Text);
                    cmd3.Parameters.AddWithValue("@NewSoursePower", tbSourcePower3.Text);
                    cmd3.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor3.Text);
                    cmd3.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode3.Text);
                    cmd3.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure3.Text);
                    cmd3.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel3.Text);
                    cmd3.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel3.Text);
                    cmd3.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig3.Text);
                    cmd3.Parameters.AddWithValue("@NewArgon", tbArgon3.Text);
                    cmd3.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewNitrogen", tbNitrogen3.Text);
                    cmd3.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewOxygen", tbOxygen3.Text);
                    cmd3.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent3.Text);
                    cmd3.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_3.Text);
                    cmd3.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent3.Text);
                    cmd3.Parameters.AddWithValue("@NewCHF3", tbCHF3_3.Text);
                    cmd3.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent2.Text);
                    cmd3.Parameters.AddWithValue("@NewSF6", tbSF6_2.Text);
                    cmd3.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent3.Text);
                    cmd3.Parameters.AddWithValue("@NewBCI3", tbBCI3_3.Text);
                    cmd3.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent3.Text);
                    cmd3.Parameters.AddWithValue("@NewCI2", _tbCI2_3.Text);
                    cmd3.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent3.Text);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand(strSQL1, con);
                    cmd4.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());

                    cmd4.Parameters.AddWithValue("@NewstepName", tbStepName4.Text);
                    cmd4.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep4.Text);
                    cmd4.Parameters.AddWithValue("@NewProcessTime", tbProcessTime4.Text);
                    cmd4.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure4.Text);
                    cmd4.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition4.Text);
                    cmd4.Parameters.AddWithValue("@NewAPCMode", cmbApcMode4.Text);
                    cmd4.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor4.Text);
                    cmd4.Parameters.AddWithValue("@NewSoursePower", tbSourcePower4.Text);
                    cmd4.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor4.Text);
                    cmd4.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor4.Text);
                    cmd4.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode4.Text);
                    cmd4.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower4.Text);
                    cmd4.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust4.Text);
                    cmd4.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor4.Text);
                    cmd4.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor4.Text);
                    cmd4.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor4.Text);
                    cmd4.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode4.Text);
                    cmd4.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure4.Text);
                    cmd4.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel4.Text);
                    cmd4.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel4.Text);
                    cmd4.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig4.Text);
                    cmd4.Parameters.AddWithValue("@NewArgon", tbArgon4.Text);
                    cmd4.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewNitrogen", tbNitrogen4.Text);
                    cmd4.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewOxygen", tbOxygen4.Text);
                    cmd4.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent4.Text);
                    cmd4.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_4.Text);
                    cmd4.Parameters.AddWithValue("@NewOxygen1Percent", tbOxygen1Percent4.Text);
                    cmd4.Parameters.AddWithValue("@NewCHF3", tbCHF3_4.Text);
                    cmd4.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent4.Text);
                    cmd4.Parameters.AddWithValue("@NewSF6", tbSF6_4.Text);
                    cmd4.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent4.Text);
                    cmd4.Parameters.AddWithValue("@NewBCI3", tbBCI3_4.Text);
                    cmd4.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent4.Text);
                    cmd4.Parameters.AddWithValue("@NewCI2", _tbCI2_4.Text);
                    cmd4.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent4.Text);
                    cmd4.ExecuteNonQuery();






                }
                else if (strtag == "panel5")
                {





                }


                /////////////////////////////////////////////////////////////將暫存資料表的資料清空

                string strTRUNCATE = "TRUNCATE table TemNewrecipe";

                SqlCommand cmdTrncare = new SqlCommand(strTRUNCATE, con);
                cmdTrncare.ExecuteNonQuery();
                ////////////////////////////////////////////////////將字串集合清空
                strRecipeName.Clear();
                strStepName.Clear();
                strTimeDependentStep.Clear();
                strProcessTime.Clear();
                strProcessPressure.Clear();
                strProcessPressurePercent.Clear();
                strAPCSetpointPosition.Clear();
                strAPCMode.Clear();
                strActivePressureSensor.Clear();
                strSourcePower.Clear();
                strSourcePowerPercent.Clear();
                strSourceMUTuneCapacitor.Clear();
                strSourceMULoadCapacitor.Clear();
                strSourceRFControlMode.Clear();
                strPlatenPower.Clear();
                strPlatenPowerPercent.Clear();
                strPlatenCapacitorAdjust.Clear();
                strPlatenRFTuningCapacitor.Clear();
                strPlatenRFTuningCapacitorPercent.Clear();
                strPlatenRFLoadCapacitor.Clear();
                strPlatenRFLoadCapacitorPercent.Clear();
                strPlatenRFPaddingCapacitor.Clear();
                strPlatenRFControlMode.Clear();
                strHeliumPressure.Clear();
                strHeliumpressurePercent.Clear();
                strHeliumFlowWarningLevel.Clear();
                strHeliumFlowFaultLevel.Clear();
                strGasLineConfig.Clear();
                strArgon.Clear();
                strArgonPercent.Clear();
                strNitrogen.Clear();
                strNitrogenPercent.Clear();
                strOxygen.Clear();
                strOxygenPercent.Clear();
                strOxygen1.Clear();
                strOxygen1Percent.Clear();
                strCHF3.Clear();
                strCHF3Percent.Clear();
                strSF6.Clear();
                strSF6Percent.Clear();
                strBCI3.Clear();
                strBCI3Percent.Clear();
                strCI2.Clear();
                strCI2Percent.Clear();
                con.Close();


                

            }
            MessageBox.Show("Save Successfully");

            ////////////////////////////////////////////////////Update listbox of form recipetype

            updatelistbox(sender, e);


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            /////////////////////////////////////////////////////////////將暫存資料表的資料清空
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strTRUNCATE = "TRUNCATE table TemNewrecipe";

            SqlCommand cmdTrncare = new SqlCommand(strTRUNCATE, con);
            cmdTrncare.ExecuteNonQuery();
            ////////////////////////////////////////////////////將字串集合清空
            strRecipeName.Clear();
            strStepName.Clear();
            strTimeDependentStep.Clear();
            strProcessTime.Clear();
            strProcessPressure.Clear();
            strProcessPressurePercent.Clear();
            strAPCSetpointPosition.Clear();
            strAPCMode.Clear();
            strActivePressureSensor.Clear();
            strSourcePower.Clear();
            strSourcePowerPercent.Clear();
            strSourceMUTuneCapacitor.Clear();
            strSourceMULoadCapacitor.Clear();
            strSourceRFControlMode.Clear();
            strPlatenPower.Clear();
            strPlatenPowerPercent.Clear();
            strPlatenCapacitorAdjust.Clear();
            strPlatenRFTuningCapacitor.Clear();
            strPlatenRFTuningCapacitorPercent.Clear();
            strPlatenRFLoadCapacitor.Clear();
            strPlatenRFLoadCapacitorPercent.Clear();
            strPlatenRFPaddingCapacitor.Clear();
            strPlatenRFControlMode.Clear();
            strHeliumPressure.Clear();
            strHeliumpressurePercent.Clear();
            strHeliumFlowWarningLevel.Clear();
            strHeliumFlowFaultLevel.Clear();
            strGasLineConfig.Clear();
            strArgon.Clear();
            strArgonPercent.Clear();
            strNitrogen.Clear();
            strNitrogenPercent.Clear();
            strOxygen.Clear();
            strOxygenPercent.Clear();
            strOxygen1.Clear();
            strOxygen1Percent.Clear();
            strCHF3.Clear();
            strCHF3Percent.Clear();
            strSF6.Clear();
            strSF6Percent.Clear();
            strBCI3.Clear();
            strBCI3Percent.Clear();
            strCI2.Clear();
            strCI2Percent.Clear();
            con.Close();


        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(scsb.ToString());
            // con.Open();
            // string strSQL = "insert into Newrecipe(Step Name,Time Dependent step,Process Time,Process Pressure,Process)values()";
          //  MessageBox.Show(listView1.SelectedItems[0].SubItems[1].Text);



        }

        private void listboxstepname_SelectedIndexChanged(object sender, EventArgs e)
        {


         /* string  strSearchName1 = listboxstepname.SelectedItem.ToString();

           if (strSearchName1.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQl = "select * from TemNewrecipe where StepName like @Searchname";
                SqlCommand cmd = new SqlCommand(strSQl, con);
                cmd.Parameters.AddWithValue("@Searchname", strSearchName1);
                SqlDataReader reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    tbStepName.Text = string.Format("{0}", reader["StepName"]);
                    tbTimeDependentStep.Text = string.Format("{0}", reader["TimeDependentStep"]);
                    tbProcessTime.Text = string.Format("{0}", reader["ProcessTime"]);
                    tbProcessPressure.Text = string.Format("{0}", reader["ProcessPressure"]);
                    tbProcessPressurePercent.Text = string.Format("{0}", reader["ProcessPressurePercent"]);
                    tbApcSetpointPosition.Text = string.Format("{0}", reader["APCSetPointPosition"]);
                    cmbApcMode.Text = string.Format("{0}", reader["APCMode"]);
                    cmbActivePressureSensor.Text = string.Format("{0}", reader["ActivePressureSensor"]);
                   tbSourcePower.Text = string.Format("{0}", reader["SourcePower"]);
                    tbSoursePowerPercent.Text = string.Format("{0}", reader["SourcePowerPercent"]);
                    cmbSourceMUTuneCapacitor.Text = string.Format("{0}", reader["SourceMUTuneCapacitor"]);
                    cmbSourceMULoadCapacitor.Text = string.Format("{0}", reader["SourceMULoadCapacitor"]);
                    cmbSourceRFControlMode.Text = string.Format("{0}", reader["SourceRFControlMode"]);
                    tbPlatenPower.Text = string.Format("{0}", reader["PlatenPower"]);
                    tbPlatenPowerPercent.Text = string.Format("{0}", reader["PlatenPowerPercent"]);
                    cmbPlatenCapacitorAdjust.Text = string.Format("{0}", reader["PlatenCapacitorAdjust"]);
                    tbPlatenRFTuningCapacitor.Text = string.Format("{0}", reader["PlatenRFTuningCapacitor"]);
                    tbPlatenRFTuningCapacitorPercent.Text = string.Format("{0}", reader["PlatenRFTuningCapacitorPercent"]);
                    tbPlatenRFLoadCapacitor.Text = string.Format("{0}", reader["PlatenRFLoadCapacitor"]);
                    tbPlatenRFLoadCapacitorPercent.Text = string.Format("{0}", reader["PlatenRFLoadCapacitorPercent"]);
                    cmbPlatenRFPaddingCapacitor.Text = string.Format("{0}", reader["PlatenRFPaddingCapacitor"]);
                    cmbPlatenRFControlMode.Text = string.Format("{0}", reader["PlatenRFControlMode"]);
                    tbHeliumPressure.Text = string.Format("{0}", reader["HeliumPressure"]);
                    tbHeliumPressurePercent.Text = string.Format("{0}", reader["HeliumPressurePercent"]);
                    tbHeliumFlowWarningLevel.Text = string.Format("{0}", reader["HeliumFlowWarningLevel"]);
                    tbHeliumFlowFaultLevel.Text = string.Format("{0}", reader["HeliumFlowFaultLevel"]);
                    cmbGasLineConfig.Text = string.Format("{0}", reader["GasLineConfig"]);
                    tbArgon.Text = string.Format("{0}", reader["Argon"]);
                    tbArgonPercent.Text = string.Format("{0}", reader["ArgonPercent"]);
                    tbNitrogen.Text = string.Format("{0}", reader["Nitrogen"]);
                    tbNitrogenPercent.Text = string.Format("{0}", reader["NitrogenPercent"]);
                    tbOxygen.Text = string.Format("{0}", reader["Oxygen"]);
                    tbOxygenPercent.Text = string.Format("{0}", reader["OxygenPercent"]);
                    tbCHF3.Text = string.Format("{0}", reader["CHF3"]);
                    tbCHF3Percent.Text = string.Format("{0}", reader["CHF3Percent"]);
                   tbSF6.Text = string.Format("{0}", reader["SF6"]);
                    tbSF6Percent.Text = string.Format("{0}", reader["SF6Percent"]);
                    tbBCI3.Text = string.Format("{0}", reader["BCI3"]);
                    tbBCI3Percent.Text = string.Format("{0}", reader["BCI3Percent"]);
                    tbCI2.Text = string.Format("{0}", reader["CI2"]);
                    tbCI2.Text = string.Format("{0}", reader["CI2Percent"]);
                        



                }
                reader.Close();
                con.Close();



            }*/
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



            }


        }

        private void tbTimeDependentStep_MouseClick(object sender, MouseEventArgs e)
        {

            lblReminder.Text = "Time Dependent Step : 0~0";





        }

        private void tbApcSetpointPosition_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "APC Setpoinr Position : 0~100 %";
        }

        private void tbSourcePower_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Source Power : 0~1500 Watts";
        }

        private void tbArgon_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Argon : 0~200 Sccm";
        }

        private void tbNitrogen_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Nitrogen : 0~30 Sccm";
        }

        private void tbOxygen_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Oxygen : 0~30 Sccm";
        }

        private void tbOxygen1_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Oxygen : 0~280 Sccm";
        }

        private void tbCHF3_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "CHF3 : 0~100 Sccm";
        }

        private void tbSF6_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "SF6 : 0~50 Sccm";
        }

        private void tbBCI3_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "BCI3 : 0~50 Sccm";
        }

        private void tbCI2_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "CI2 : 0~150 Sccm";
        }

        private void tbPlatenRFTuningCapacitor_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Platen RF Tuning Capacitor : 0~99.9 %";
        }

        private void tbPlatenPower_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Platen Power : 0~300 Watts";
        }

        private void tbHeliumPressure_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Helium Pressure : 0~20 Torr";
        }

        private void tbProcessTime_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Process Time : 0~3600 Secs";
        }

        private void tbPlatenRFLoadCapacitor_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Platen RF Load Capacitor : 0~99.9 %";
        }

        private void cmbApcMode_MouseClick(object sender, MouseEventArgs e)
        {

            lblReminder.Text = "APC Mode : Manual/Automatic/Preset ";

        }
        
        private void cmbActivePressureSensor_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Active Pressure Sensor : Low/High ";
        }

        private void cmbSourceRFControlMode_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Source RF Control Mode : Forward/Load ";
        }

        private void cmbPlatenCapacitorAdjust_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Platen Capacitor Adjust : Manual/Automatic/Preset ";
        }

        private void cmbPlatenRFControlMode_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Platen RF Control Mode : Forward/Load ";
        }

        private void cmbGasLineConfig_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Gas Line Config : Flow/Purge/Pumpout/Bypass ";
        }

        private void tbSoursePowerPercent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Source Power : 0~1500 Watts";
        }

        private void tbPlatenPowerPercent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Platen Power : 0~300 Watts";
        }

        private void cmbSourceMUTuneCapacitor_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Source MU tune Capacitor : 1/2/3/4";
        }

        private void cmbSourceMULoadCapacitor_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Source MU Load Capacitor : 1/2";
        }

        private void cmbPlatenRFPaddingCapacitor_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Platen RD Padding Capacitor : 1/2/3/4";
        }

        private void tbArgonPercent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Argon : 0~200 Sccm";
        }

        private void tbNitrogenPercent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Nitrogen : 0~30 Sccm";
        }

        private void tbOxygenPercent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "Oxygen : 0~30 Sccm";
        }

        private void tbOxygen1Percent_MouseClick(object sender, MouseEventArgs e)
        {
             lblReminder.Text = "Oxygen : 0~280 Sccm";
        }

        private void tbCHF3Percent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "CHF3 : 0~100 Sccm";
        }

        private void tbSF6Percent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "SF6 : 0~50 Sccm";
        }

        private void tbBCI3Percent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "BCI3 : 0~50 Sccm";
        }

        private void tbCI2Percent_MouseClick(object sender, MouseEventArgs e)
        {
            lblReminder.Text = "CI2 : 0~150 Sccm";
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
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

        private void NewRecipe_FormClosing(object sender, FormClosingEventArgs e)
        {
            /////////////////////////////////////////////////////////////將暫存資料表的資料清空
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            
            string strTRUNCATE = "TRUNCATE table TemNewrecipe";

            SqlCommand cmdTrncare = new SqlCommand(strTRUNCATE, con);
            cmdTrncare.ExecuteNonQuery();
            ////////////////////////////////////////////////////將字串集合清空
            strRecipeName.Clear();
            strStepName.Clear();
            strTimeDependentStep.Clear();
            strProcessTime.Clear();
            strProcessPressure.Clear();
            strProcessPressurePercent.Clear();
            strAPCSetpointPosition.Clear();
            strAPCMode.Clear();
            strActivePressureSensor.Clear();
            strSourcePower.Clear();
            strSourcePowerPercent.Clear();
            strSourceMUTuneCapacitor.Clear();
            strSourceMULoadCapacitor.Clear();
            strSourceRFControlMode.Clear();
            strPlatenPower.Clear();
            strPlatenPowerPercent.Clear();
            strPlatenCapacitorAdjust.Clear();
            strPlatenRFTuningCapacitor.Clear();
            strPlatenRFTuningCapacitorPercent.Clear();
            strPlatenRFLoadCapacitor.Clear();
            strPlatenRFLoadCapacitorPercent.Clear();
            strPlatenRFPaddingCapacitor.Clear();
            strPlatenRFControlMode.Clear();
            strHeliumPressure.Clear();
            strHeliumpressurePercent.Clear();
            strHeliumFlowWarningLevel.Clear();
            strHeliumFlowFaultLevel.Clear();
            strGasLineConfig.Clear();
            strArgon.Clear();
            strArgonPercent.Clear();
            strNitrogen.Clear();
            strNitrogenPercent.Clear();
            strOxygen.Clear();
            strOxygenPercent.Clear();
            strOxygen1.Clear();
            strOxygen1Percent.Clear();
            strCHF3.Clear();
            strCHF3Percent.Clear();
            strSF6.Clear();
            strSF6Percent.Clear();
            strBCI3.Clear();
            strBCI3Percent.Clear();
            strCI2.Clear();
            strCI2Percent.Clear();
            con.Close();



        }
    }
}
