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
    public partial class Openrecipe : Form
    {
        SqlConnectionStringBuilder scsb;
        ListViewItem itm;
        public Openrecipe()
        {
            InitializeComponent();
        }
       public string strtag;
        List<string> strid = new List<string>();
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

        public RecipeType recipetype = new RecipeType();



        private void Openrecipe_Load(object sender, EventArgs e)
        {

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
            
            // listboxnewrecipe.SetSelected(0, true);
            //  listboxnewrecipe.TopIndex = 0;
           
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;



            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = Form1.datasource;
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
           // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());



            if (RecipeType.labelstring == "Recipe Name")
            {
                con.Open();


                string strSQL = "select * from Newrecipe inner join recipe on Newrecipe.recipeName = recipe.recipeName where Newrecipe.recipeName = @Newrecipename";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // listboxnewrecipe.Items.Add(reader["StepName"]);


                    // tbStepName.Text = reader["Step Name"].ToString();
                    strid.Add(string.Format("{0}", reader["Moduleicpid"]));
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









                }
                con.Close();
                if (strStepName.Count == 1)
                {
                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];

                    strtag = "panel1";

                }
                else if (strStepName.Count == 2)
                {
                    panel2.Visible = true;

                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];


                    lblid2.Text = strid[1];
                    tbStepName2.Text = strStepName[1];
                    tbTimeDependentStep2.Text = strTimeDependentStep[1];
                    tbProcessTime2.Text = strProcessTime[1];
                    tbProcessPressure2.Text = strProcessPressure[1];
                    tbProcessPressurePercent2.Text = strProcessPressurePercent[1];
                    tbApcSetpointPosition2.Text = strAPCSetpointPosition[1];
                    cmbApcMode2.Text = strAPCMode[1];
                    cmbActivePressureSensor2.Text = strActivePressureSensor[1];
                    tbSourcePower2.Text = strSourcePower[1];
                    tbSoursePowerPercent2.Text = strSourcePowerPercent[1];
                    cmbSourceMUTuneCapacitor2.Text = strSourceMUTuneCapacitor[1];
                    cmbSourceMULoadCapacitor2.Text = strSourceMULoadCapacitor[1];
                    cmbSourceRFControlMode2.Text = strSourceRFControlMode[1];
                    tbPlatenPower2.Text = strPlatenPower[1];
                    tbPlatenPowerPercent2.Text = strPlatenPowerPercent[1];
                    cmbPlatenCapacitorAdjust2.Text = strPlatenCapacitorAdjust[1];
                    tbPlatenRFTuningCapacitor2.Text = strPlatenRFTuningCapacitor[1];
                    tbPlatenRFTuningCapacitorPercent2.Text = strPlatenRFTuningCapacitorPercent[1];
                    tbPlatenRFLoadCapacitor2.Text = strPlatenRFLoadCapacitor[1];
                    tbPlatenRFLoadCapacitorPercent2.Text = strPlatenRFLoadCapacitorPercent[1];
                    cmbPlatenRFPaddingCapacitor2.Text = strPlatenRFPaddingCapacitor[1];
                    cmbPlatenRFControlMode2.Text = strPlatenRFControlMode[1];
                    tbHeliumPressure2.Text = strHeliumPressure[1];
                    tbHeliumPressurePercent2.Text = strHeliumpressurePercent[1];
                    tbHeliumFlowWarningLevel2.Text = strHeliumFlowWarningLevel[1];
                    tbHeliumFlowFaultLevel2.Text = strHeliumFlowFaultLevel[1];
                    cmbGasLineConfig2.Text = strGasLineConfig[1];
                    tbArgon2.Text = strArgon[1];
                    tbArgonPercent2.Text = strArgonPercent[1];
                    tbNitrogen2.Text = strNitrogen[1];
                    tbNitrogenPercent2.Text = strNitrogenPercent[1];
                    tbOxygen2.Text = strOxygen[1];
                    tbOxygenPercent2.Text = strOxygenPercent[1];
                    tbCHF3_2.Text = strCHF3[1];
                    tbCHF3Percent2.Text = strCHF3Percent[1];
                    tbSF6_2.Text = strSF6[1];
                    tbSF6Percent2.Text = strSF6Percent[1];
                    tbBCI3_2.Text = strBCI3[1];
                    tbBCI3Percent2.Text = strBCI3Percent[1];
                    _tbCI2_2.Text = strCI2[1];
                    _tbCI2Percent2.Text = strCI2Percent[1];

                    strtag = "panel2";


                }
                else if (strStepName.Count == 3)
                {
                    panel2.Visible = true;
                    panel3.Visible = true;

                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];


                    lblid.Text = strid[1];
                    tbStepName2.Text = strStepName[1];
                    tbTimeDependentStep2.Text = strTimeDependentStep[1];
                    tbProcessTime2.Text = strProcessTime[1];
                    tbProcessPressure2.Text = strProcessPressure[1];
                    tbProcessPressurePercent2.Text = strProcessPressurePercent[1];
                    tbApcSetpointPosition2.Text = strAPCSetpointPosition[1];
                    cmbApcMode2.Text = strAPCMode[1];
                    cmbActivePressureSensor2.Text = strActivePressureSensor[1];
                    tbSourcePower2.Text = strSourcePower[1];
                    tbSoursePowerPercent2.Text = strSourcePowerPercent[1];
                    cmbSourceMUTuneCapacitor2.Text = strSourceMUTuneCapacitor[1];
                    cmbSourceMULoadCapacitor2.Text = strSourceMULoadCapacitor[1];
                    cmbSourceRFControlMode2.Text = strSourceRFControlMode[1];
                    tbPlatenPower2.Text = strPlatenPower[1];
                    tbPlatenPowerPercent2.Text = strPlatenPowerPercent[1];
                    cmbPlatenCapacitorAdjust2.Text = strPlatenCapacitorAdjust[1];
                    tbPlatenRFTuningCapacitor2.Text = strPlatenRFTuningCapacitor[1];
                    tbPlatenRFTuningCapacitorPercent2.Text = strPlatenRFTuningCapacitorPercent[1];
                    tbPlatenRFLoadCapacitor2.Text = strPlatenRFLoadCapacitor[1];
                    tbPlatenRFLoadCapacitorPercent2.Text = strPlatenRFLoadCapacitorPercent[1];
                    cmbPlatenRFPaddingCapacitor2.Text = strPlatenRFPaddingCapacitor[1];
                    cmbPlatenRFControlMode2.Text = strPlatenRFControlMode[1];
                    tbHeliumPressure2.Text = strHeliumPressure[1];
                    tbHeliumPressurePercent2.Text = strHeliumpressurePercent[1];
                    tbHeliumFlowWarningLevel2.Text = strHeliumFlowWarningLevel[1];
                    tbHeliumFlowFaultLevel2.Text = strHeliumFlowFaultLevel[1];
                    cmbGasLineConfig2.Text = strGasLineConfig[1];
                    tbArgon2.Text = strArgon[1];
                    tbArgonPercent2.Text = strArgonPercent[1];
                    tbNitrogen2.Text = strNitrogen[1];
                    tbNitrogenPercent2.Text = strNitrogenPercent[1];
                    tbOxygen2.Text = strOxygen[1];
                    tbOxygenPercent2.Text = strOxygenPercent[1];
                    tbCHF3_2.Text = strCHF3[1];
                    tbCHF3Percent2.Text = strCHF3Percent[1];
                    tbSF6_2.Text = strSF6[1];
                    tbSF6Percent2.Text = strSF6Percent[1];
                    tbBCI3_2.Text = strBCI3[1];
                    tbBCI3Percent2.Text = strBCI3Percent[1];
                    _tbCI2_2.Text = strCI2[1];
                    _tbCI2Percent2.Text = strCI2Percent[1];


                    lblid.Text = strid[2];
                    tbStepName3.Text = strStepName[2];
                    tbTimeDependentStep3.Text = strTimeDependentStep[2];
                    tbProcessTime3.Text = strProcessTime[2];
                    tbProcessPressure3.Text = strProcessPressure[2];
                    tbProcessPressurePercent3.Text = strProcessPressurePercent[2];
                    tbApcSetpointPosition3.Text = strAPCSetpointPosition[2];
                    cmbApcMode3.Text = strAPCMode[2];
                    cmbActivePressureSensor3.Text = strActivePressureSensor[2];
                    tbSourcePower3.Text = strSourcePower[2];
                    tbSoursePowerPercent3.Text = strSourcePowerPercent[2];
                    cmbSourceMUTuneCapacitor3.Text = strSourceMUTuneCapacitor[2];
                    cmbSourceMULoadCapacitor3.Text = strSourceMULoadCapacitor[2];
                    cmbSourceRFControlMode3.Text = strSourceRFControlMode[2];
                    tbPlatenPower3.Text = strPlatenPower[2];
                    tbPlatenPowerPercent3.Text = strPlatenPowerPercent[2];
                    cmbPlatenCapacitorAdjust3.Text = strPlatenCapacitorAdjust[2];
                    tbPlatenRFTuningCapacitor3.Text = strPlatenRFTuningCapacitor[2];
                    tbPlatenRFTuningCapacitorPercent3.Text = strPlatenRFTuningCapacitorPercent[2];
                    tbPlatenRFLoadCapacitor3.Text = strPlatenRFLoadCapacitor[2];
                    tbPlatenRFLoadCapacitorPercent3.Text = strPlatenRFLoadCapacitorPercent[2];
                    cmbPlatenRFPaddingCapacitor3.Text = strPlatenRFPaddingCapacitor[2];
                    cmbPlatenRFControlMode3.Text = strPlatenRFControlMode[2];
                    tbHeliumPressure3.Text = strHeliumPressure[2];
                    tbHeliumPressurePercent3.Text = strHeliumpressurePercent[2];
                    tbHeliumFlowWarningLevel3.Text = strHeliumFlowWarningLevel[2];
                    tbHeliumFlowFaultLevel3.Text = strHeliumFlowFaultLevel[2];
                    cmbGasLineConfig3.Text = strGasLineConfig[2];
                    tbArgon3.Text = strArgon[2];
                    tbArgonPercent3.Text = strArgonPercent[2];
                    tbNitrogen3.Text = strNitrogen[2];
                    tbNitrogenPercent3.Text = strNitrogenPercent[2];
                    tbOxygen3.Text = strOxygen[2];
                    tbOxygenPercent3.Text = strOxygenPercent[2];
                    tbCHF3_3.Text = strCHF3[2];
                    tbCHF3Percent3.Text = strCHF3Percent[2];
                    tbSF6_3.Text = strSF6[2];
                    tbSF6Percent3.Text = strSF6Percent[2];
                    tbBCI3_3.Text = strBCI3[2];
                    tbBCI3Percent3.Text = strBCI3Percent[2];
                    _tbCI2_3.Text = strCI2[2];
                    _tbCI2Percent3.Text = strCI2Percent[2];

                    strtag = "panel3";

                }

                else if (strStepName.Count == 4)
                {
                    panel2.Visible = true;
                    panel3.Visible = true;
                    panel4.Visible = true;

                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];


                    lblid.Text = strid[1];
                    tbStepName2.Text = strStepName[1];
                    tbTimeDependentStep2.Text = strTimeDependentStep[1];
                    tbProcessTime2.Text = strProcessTime[1];
                    tbProcessPressure2.Text = strProcessPressure[1];
                    tbProcessPressurePercent2.Text = strProcessPressurePercent[1];
                    tbApcSetpointPosition2.Text = strAPCSetpointPosition[1];
                    cmbApcMode2.Text = strAPCMode[1];
                    cmbActivePressureSensor2.Text = strActivePressureSensor[1];
                    tbSourcePower2.Text = strSourcePower[1];
                    tbSoursePowerPercent2.Text = strSourcePowerPercent[1];
                    cmbSourceMUTuneCapacitor2.Text = strSourceMUTuneCapacitor[1];
                    cmbSourceMULoadCapacitor2.Text = strSourceMULoadCapacitor[1];
                    cmbSourceRFControlMode2.Text = strSourceRFControlMode[1];
                    tbPlatenPower2.Text = strPlatenPower[1];
                    tbPlatenPowerPercent2.Text = strPlatenPowerPercent[1];
                    cmbPlatenCapacitorAdjust2.Text = strPlatenCapacitorAdjust[1];
                    tbPlatenRFTuningCapacitor2.Text = strPlatenRFTuningCapacitor[1];
                    tbPlatenRFTuningCapacitorPercent2.Text = strPlatenRFTuningCapacitorPercent[1];
                    tbPlatenRFLoadCapacitor2.Text = strPlatenRFLoadCapacitor[1];
                    tbPlatenRFLoadCapacitorPercent2.Text = strPlatenRFLoadCapacitorPercent[1];
                    cmbPlatenRFPaddingCapacitor2.Text = strPlatenRFPaddingCapacitor[1];
                    cmbPlatenRFControlMode2.Text = strPlatenRFControlMode[1];
                    tbHeliumPressure2.Text = strHeliumPressure[1];
                    tbHeliumPressurePercent2.Text = strHeliumpressurePercent[1];
                    tbHeliumFlowWarningLevel2.Text = strHeliumFlowWarningLevel[1];
                    tbHeliumFlowFaultLevel2.Text = strHeliumFlowFaultLevel[1];
                    cmbGasLineConfig2.Text = strGasLineConfig[1];
                    tbArgon2.Text = strArgon[1];
                    tbArgonPercent2.Text = strArgonPercent[1];
                    tbNitrogen2.Text = strNitrogen[1];
                    tbNitrogenPercent2.Text = strNitrogenPercent[1];
                    tbOxygen2.Text = strOxygen[1];
                    tbOxygenPercent2.Text = strOxygenPercent[1];
                    tbCHF3_2.Text = strCHF3[1];
                    tbCHF3Percent2.Text = strCHF3Percent[1];
                    tbSF6_2.Text = strSF6[1];
                    tbSF6Percent2.Text = strSF6Percent[1];
                    tbBCI3_2.Text = strBCI3[1];
                    tbBCI3Percent2.Text = strBCI3Percent[1];
                    _tbCI2_2.Text = strCI2[1];
                    _tbCI2Percent2.Text = strCI2Percent[1];


                    lblid.Text = strid[2];
                    tbStepName3.Text = strStepName[2];
                    tbTimeDependentStep3.Text = strTimeDependentStep[2];
                    tbProcessTime3.Text = strProcessTime[2];
                    tbProcessPressure3.Text = strProcessPressure[2];
                    tbProcessPressurePercent3.Text = strProcessPressurePercent[2];
                    tbApcSetpointPosition3.Text = strAPCSetpointPosition[2];
                    cmbApcMode3.Text = strAPCMode[2];
                    cmbActivePressureSensor3.Text = strActivePressureSensor[2];
                    tbSourcePower3.Text = strSourcePower[2];
                    tbSoursePowerPercent3.Text = strSourcePowerPercent[2];
                    cmbSourceMUTuneCapacitor3.Text = strSourceMUTuneCapacitor[2];
                    cmbSourceMULoadCapacitor3.Text = strSourceMULoadCapacitor[2];
                    cmbSourceRFControlMode3.Text = strSourceRFControlMode[3];
                    tbPlatenPower3.Text = strPlatenPower[2];
                    tbPlatenPowerPercent3.Text = strPlatenPowerPercent[2];
                    cmbPlatenCapacitorAdjust3.Text = strPlatenCapacitorAdjust[2];
                    tbPlatenRFTuningCapacitor3.Text = strPlatenRFTuningCapacitor[2];
                    tbPlatenRFTuningCapacitorPercent3.Text = strPlatenRFTuningCapacitorPercent[2];
                    tbPlatenRFLoadCapacitor3.Text = strPlatenRFLoadCapacitor[2];
                    tbPlatenRFLoadCapacitorPercent3.Text = strPlatenRFLoadCapacitorPercent[2];
                    cmbPlatenRFPaddingCapacitor3.Text = strPlatenRFPaddingCapacitor[2];
                    cmbPlatenRFControlMode3.Text = strPlatenRFControlMode[2];
                    tbHeliumPressure3.Text = strHeliumPressure[2];
                    tbHeliumPressurePercent3.Text = strHeliumpressurePercent[2];
                    tbHeliumFlowWarningLevel3.Text = strHeliumFlowWarningLevel[2];
                    tbHeliumFlowFaultLevel3.Text = strHeliumFlowFaultLevel[2];
                    cmbGasLineConfig3.Text = strGasLineConfig[2];
                    tbArgon3.Text = strArgon[2];
                    tbArgonPercent3.Text = strArgonPercent[2];
                    tbNitrogen3.Text = strNitrogen[2];
                    tbNitrogenPercent3.Text = strNitrogenPercent[2];
                    tbOxygen3.Text = strOxygen[2];
                    tbOxygenPercent3.Text = strOxygenPercent[2];
                    tbCHF3_3.Text = strCHF3[2];
                    tbCHF3Percent3.Text = strCHF3Percent[2];
                    tbSF6_3.Text = strSF6[2];
                    tbSF6Percent3.Text = strSF6Percent[2];
                    tbBCI3_3.Text = strBCI3[2];
                    tbBCI3Percent3.Text = strBCI3Percent[2];
                    _tbCI2_3.Text = strCI2[2];
                    _tbCI2Percent3.Text = strCI2Percent[2];



                    lblid.Text = strid[3];
                    tbStepName4.Text = strStepName[3];
                    tbTimeDependentStep4.Text = strTimeDependentStep[3];
                    tbProcessTime4.Text = strProcessTime[3];
                    tbProcessPressure4.Text = strProcessPressure[3];
                    tbProcessPressurePercent4.Text = strProcessPressurePercent[3];
                    tbApcSetpointPosition4.Text = strAPCSetpointPosition[3];
                    cmbApcMode4.Text = strAPCMode[3];
                    cmbActivePressureSensor4.Text = strActivePressureSensor[3];
                    tbSourcePower4.Text = strSourcePower[3];
                    tbSoursePowerPercent4.Text = strSourcePowerPercent[3];
                    cmbSourceMUTuneCapacitor4.Text = strSourceMUTuneCapacitor[3];
                    cmbSourceMULoadCapacitor4.Text = strSourceMULoadCapacitor[3];
                    cmbSourceRFControlMode4.Text = strSourceRFControlMode[3];
                    tbPlatenPower4.Text = strPlatenPower[3];
                    tbPlatenPowerPercent4.Text = strPlatenPowerPercent[3];
                    cmbPlatenCapacitorAdjust4.Text = strPlatenCapacitorAdjust[3];
                    tbPlatenRFTuningCapacitor4.Text = strPlatenRFTuningCapacitor[3];
                    tbPlatenRFTuningCapacitorPercent4.Text = strPlatenRFTuningCapacitorPercent[3];
                    tbPlatenRFLoadCapacitor4.Text = strPlatenRFLoadCapacitor[3];
                    tbPlatenRFLoadCapacitorPercent4.Text = strPlatenRFLoadCapacitorPercent[3];
                    cmbPlatenRFPaddingCapacitor4.Text = strPlatenRFPaddingCapacitor[3];
                    cmbPlatenRFControlMode4.Text = strPlatenRFControlMode[3];
                    tbHeliumPressure4.Text = strHeliumPressure[3];
                    tbHeliumPressurePercent4.Text = strHeliumpressurePercent[3];
                    tbHeliumFlowWarningLevel4.Text = strHeliumFlowWarningLevel[3];
                    tbHeliumFlowFaultLevel4.Text = strHeliumFlowFaultLevel[3];
                    cmbGasLineConfig4.Text = strGasLineConfig[3];
                    tbArgon4.Text = strArgon[3];
                    tbArgonPercent4.Text = strArgonPercent[3];
                    tbNitrogen4.Text = strNitrogen[3];
                    tbNitrogenPercent4.Text = strNitrogenPercent[3];
                    tbOxygen4.Text = strOxygen[3];
                    tbOxygenPercent4.Text = strOxygenPercent[3];
                    tbCHF3_4.Text = strCHF3[3];
                    tbCHF3Percent4.Text = strCHF3Percent[3];
                    tbSF6_4.Text = strSF6[3];
                    tbSF6Percent4.Text = strSF6Percent[3];
                    tbBCI3_4.Text = strBCI3[3];
                    tbBCI3Percent4.Text = strBCI3Percent[3];
                    _tbCI2_4.Text = strCI2[3];
                    _tbCI2Percent4.Text = strCI2Percent[3];

                    strtag = "panel4";

                }
                else if (strStepName.Count == 5)
                {
                    panel2.Visible = true;
                    panel3.Visible = true;
                    panel4.Visible = true;
                    panel5.Visible = true;

                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];


                    lblid.Text = strid[1];
                    tbStepName2.Text = strStepName[1];
                    tbTimeDependentStep2.Text = strTimeDependentStep[1];
                    tbProcessTime2.Text = strProcessTime[1];
                    tbProcessPressure2.Text = strProcessPressure[1];
                    tbProcessPressurePercent2.Text = strProcessPressurePercent[1];
                    tbApcSetpointPosition2.Text = strAPCSetpointPosition[1];
                    cmbApcMode2.Text = strAPCMode[1];
                    cmbActivePressureSensor2.Text = strActivePressureSensor[1];
                    tbSourcePower2.Text = strSourcePower[1];
                    tbSoursePowerPercent2.Text = strSourcePowerPercent[1];
                    cmbSourceMUTuneCapacitor2.Text = strSourceMUTuneCapacitor[1];
                    cmbSourceMULoadCapacitor2.Text = strSourceMULoadCapacitor[1];
                    cmbSourceRFControlMode2.Text = strSourceRFControlMode[1];
                    tbPlatenPower2.Text = strPlatenPower[1];
                    tbPlatenPowerPercent2.Text = strPlatenPowerPercent[1];
                    cmbPlatenCapacitorAdjust2.Text = strPlatenCapacitorAdjust[1];
                    tbPlatenRFTuningCapacitor2.Text = strPlatenRFTuningCapacitor[1];
                    tbPlatenRFTuningCapacitorPercent2.Text = strPlatenRFTuningCapacitorPercent[1];
                    tbPlatenRFLoadCapacitor2.Text = strPlatenRFLoadCapacitor[1];
                    tbPlatenRFLoadCapacitorPercent2.Text = strPlatenRFLoadCapacitorPercent[1];
                    cmbPlatenRFPaddingCapacitor2.Text = strPlatenRFPaddingCapacitor[1];
                    cmbPlatenRFControlMode2.Text = strPlatenRFControlMode[1];
                    tbHeliumPressure2.Text = strHeliumPressure[1];
                    tbHeliumPressurePercent2.Text = strHeliumpressurePercent[1];
                    tbHeliumFlowWarningLevel2.Text = strHeliumFlowWarningLevel[1];
                    tbHeliumFlowFaultLevel2.Text = strHeliumFlowFaultLevel[1];
                    cmbGasLineConfig2.Text = strGasLineConfig[1];
                    tbArgon2.Text = strArgon[1];
                    tbArgonPercent2.Text = strArgonPercent[1];
                    tbNitrogen2.Text = strNitrogen[1];
                    tbNitrogenPercent2.Text = strNitrogenPercent[1];
                    tbOxygen2.Text = strOxygen[1];
                    tbOxygenPercent2.Text = strOxygenPercent[1];
                    tbCHF3_2.Text = strCHF3[1];
                    tbCHF3Percent2.Text = strCHF3Percent[1];
                    tbSF6_2.Text = strSF6[1];
                    tbSF6Percent2.Text = strSF6Percent[1];
                    tbBCI3_2.Text = strBCI3[1];
                    tbBCI3Percent2.Text = strBCI3Percent[1];
                    _tbCI2_2.Text = strCI2[1];
                    _tbCI2Percent2.Text = strCI2Percent[1];


                    lblid.Text = strid[2];
                    tbStepName3.Text = strStepName[2];
                    tbTimeDependentStep3.Text = strTimeDependentStep[2];
                    tbProcessTime3.Text = strProcessTime[2];
                    tbProcessPressure3.Text = strProcessPressure[2];
                    tbProcessPressurePercent3.Text = strProcessPressurePercent[2];
                    tbApcSetpointPosition3.Text = strAPCSetpointPosition[2];
                    cmbApcMode3.Text = strAPCMode[2];
                    cmbActivePressureSensor3.Text = strActivePressureSensor[2];
                    tbSourcePower3.Text = strSourcePower[2];
                    tbSoursePowerPercent3.Text = strSourcePowerPercent[2];
                    cmbSourceMUTuneCapacitor3.Text = strSourceMUTuneCapacitor[2];
                    cmbSourceMULoadCapacitor3.Text = strSourceMULoadCapacitor[2];
                    cmbSourceRFControlMode3.Text = strSourceRFControlMode[3];
                    tbPlatenPower3.Text = strPlatenPower[2];
                    tbPlatenPowerPercent3.Text = strPlatenPowerPercent[2];
                    cmbPlatenCapacitorAdjust3.Text = strPlatenCapacitorAdjust[2];
                    tbPlatenRFTuningCapacitor3.Text = strPlatenRFTuningCapacitor[2];
                    tbPlatenRFTuningCapacitorPercent3.Text = strPlatenRFTuningCapacitorPercent[2];
                    tbPlatenRFLoadCapacitor3.Text = strPlatenRFLoadCapacitor[2];
                    tbPlatenRFLoadCapacitorPercent3.Text = strPlatenRFLoadCapacitorPercent[2];
                    cmbPlatenRFPaddingCapacitor3.Text = strPlatenRFPaddingCapacitor[2];
                    cmbPlatenRFControlMode3.Text = strPlatenRFControlMode[2];
                    tbHeliumPressure3.Text = strHeliumPressure[2];
                    tbHeliumPressurePercent3.Text = strHeliumpressurePercent[2];
                    tbHeliumFlowWarningLevel3.Text = strHeliumFlowWarningLevel[2];
                    tbHeliumFlowFaultLevel3.Text = strHeliumFlowFaultLevel[2];
                    cmbGasLineConfig3.Text = strGasLineConfig[2];
                    tbArgon3.Text = strArgon[2];
                    tbArgonPercent3.Text = strArgonPercent[2];
                    tbNitrogen3.Text = strNitrogen[2];
                    tbNitrogenPercent3.Text = strNitrogenPercent[2];
                    tbOxygen3.Text = strOxygen[2];
                    tbOxygenPercent3.Text = strOxygenPercent[2];
                    tbCHF3_3.Text = strCHF3[2];
                    tbCHF3Percent3.Text = strCHF3Percent[2];
                    tbSF6_3.Text = strSF6[2];
                    tbSF6Percent3.Text = strSF6Percent[2];
                    tbBCI3_3.Text = strBCI3[2];
                    tbBCI3Percent3.Text = strBCI3Percent[2];
                    _tbCI2_3.Text = strCI2[2];
                    _tbCI2Percent3.Text = strCI2Percent[2];

                    lblid.Text = strid[3];
                    tbStepName4.Text = strStepName[3];
                    tbTimeDependentStep4.Text = strTimeDependentStep[3];
                    tbProcessTime4.Text = strProcessTime[3];
                    tbProcessPressure4.Text = strProcessPressure[3];
                    tbProcessPressurePercent4.Text = strProcessPressurePercent[3];
                    tbApcSetpointPosition4.Text = strAPCSetpointPosition[3];
                    cmbApcMode4.Text = strAPCMode[3];
                    cmbActivePressureSensor4.Text = strActivePressureSensor[3];
                    tbSourcePower4.Text = strSourcePower[3];
                    tbSoursePowerPercent4.Text = strSourcePowerPercent[3];
                    cmbSourceMUTuneCapacitor4.Text = strSourceMUTuneCapacitor[3];
                    cmbSourceMULoadCapacitor4.Text = strSourceMULoadCapacitor[3];
                    cmbSourceRFControlMode4.Text = strSourceRFControlMode[3];
                    tbPlatenPower4.Text = strPlatenPower[3];
                    tbPlatenPowerPercent4.Text = strPlatenPowerPercent[3];
                    cmbPlatenCapacitorAdjust4.Text = strPlatenCapacitorAdjust[3];
                    tbPlatenRFTuningCapacitor4.Text = strPlatenRFTuningCapacitor[3];
                    tbPlatenRFTuningCapacitorPercent4.Text = strPlatenRFTuningCapacitorPercent[3];
                    tbPlatenRFLoadCapacitor4.Text = strPlatenRFLoadCapacitor[3];
                    tbPlatenRFLoadCapacitorPercent4.Text = strPlatenRFLoadCapacitorPercent[3];
                    cmbPlatenRFPaddingCapacitor4.Text = strPlatenRFPaddingCapacitor[3];
                    cmbPlatenRFControlMode4.Text = strPlatenRFControlMode[3];
                    tbHeliumPressure4.Text = strHeliumPressure[3];
                    tbHeliumPressurePercent4.Text = strHeliumpressurePercent[3];
                    tbHeliumFlowWarningLevel4.Text = strHeliumFlowWarningLevel[3];
                    tbHeliumFlowFaultLevel4.Text = strHeliumFlowFaultLevel[3];
                    cmbGasLineConfig4.Text = strGasLineConfig[3];
                    tbArgon4.Text = strArgon[3];
                    tbArgonPercent4.Text = strArgonPercent[3];
                    tbNitrogen4.Text = strNitrogen[3];
                    tbNitrogenPercent4.Text = strNitrogenPercent[3];
                    tbOxygen4.Text = strOxygen[3];
                    tbOxygenPercent4.Text = strOxygenPercent[3];
                    tbCHF3_4.Text = strCHF3[3];
                    tbCHF3Percent4.Text = strCHF3Percent[3];
                    tbSF6_4.Text = strSF6[3];
                    tbSF6Percent4.Text = strSF6Percent[3];
                    tbBCI3_4.Text = strBCI3[3];
                    tbBCI3Percent4.Text = strBCI3Percent[3];
                    _tbCI2_4.Text = strCI2[3];
                    _tbCI2Percent4.Text = strCI2Percent[3];

                    lblid.Text = strid[4];
                    tbStepName5.Text = strStepName[4];
                    tbTimeDependentStep5.Text = strTimeDependentStep[4];
                    tbProcessTime5.Text = strProcessTime[4];
                    tbProcessPressure5.Text = strProcessPressure[4];
                    tbProcessPressurePercent5.Text = strProcessPressurePercent[4];
                    tbApcSetpointPosition5.Text = strAPCSetpointPosition[4];
                    cmbApcMode5.Text = strAPCMode[4];
                    cmbActivePressureSensor5.Text = strActivePressureSensor[4];
                    tbSourcePower5.Text = strSourcePower[4];
                    tbSoursePowerPercent5.Text = strSourcePowerPercent[4];
                    cmbSourceMUTuneCapacitor5.Text = strSourceMUTuneCapacitor[4];
                    cmbSourceMULoadCapacitor5.Text = strSourceMULoadCapacitor[4];
                    cmbSourceRFControlMode5.Text = strSourceRFControlMode[4];
                    tbPlatenPower5.Text = strPlatenPower[4];
                    tbPlatenPowerPercent5.Text = strPlatenPowerPercent[4];
                    cmbPlatenCapacitorAdjust5.Text = strPlatenCapacitorAdjust[4];
                    tbPlatenRFTuningCapacitor5.Text = strPlatenRFTuningCapacitor[4];
                    tbPlatenRFTuningCapacitorPercent5.Text = strPlatenRFTuningCapacitorPercent[4];
                    tbPlatenRFLoadCapacitor5.Text = strPlatenRFLoadCapacitor[4];
                    tbPlatenRFLoadCapacitorPercent5.Text = strPlatenRFLoadCapacitorPercent[4];
                    cmbPlatenRFPaddingCapacitor5.Text = strPlatenRFPaddingCapacitor[4];
                    cmbPlatenRFControlMode5.Text = strPlatenRFControlMode[4];
                    tbHeliumPressure5.Text = strHeliumPressure[4];
                    tbHeliumPressurePercent5.Text = strHeliumpressurePercent[4];
                    tbHeliumFlowWarningLevel5.Text = strHeliumFlowWarningLevel[4];
                    tbHeliumFlowFaultLevel5.Text = strHeliumFlowFaultLevel[4];
                    cmbGasLineConfig5.Text = strGasLineConfig[4];
                    tbArgon5.Text = strArgon[4];
                    tbArgonPercent5.Text = strArgonPercent[4];
                    tbNitrogen5.Text = strNitrogen[4];
                    tbNitrogenPercent5.Text = strNitrogenPercent[4];
                    tbOxygen5.Text = strOxygen[4];
                    tbOxygenPercent5.Text = strOxygenPercent[4];
                    tbCHF3_5.Text = strCHF3[4];
                    tbCHF3Percent5.Text = strCHF3Percent[4];
                    tbSF6_5.Text = strSF6[4];
                    tbSF6Percent5.Text = strSF6Percent[4];
                    tbBCI3_5.Text = strBCI3[4];
                    tbBCI3Percent5.Text = strBCI3Percent[4];
                    _tbCI2_5.Text = strCI2[4];
                    _tbCI2Percent5.Text = strCI2Percent[4];

                    strtag = "panel5";
                }



                ////////////////////////////////////////////////////////////////////////
                /*  con.Open();
                  string strSQL1 = "select * from Newrecipe where recipeName like @Newsearchname";
                  SqlCommand cmd1 =new SqlCommand(strSQL1, con);

                  cmd1.Parameters.AddWithValue("@Newsearchname",RecipeType.strSearchName);

                  SqlDataReader reader1 = cmd1.ExecuteReader();
                  while (reader1.Read())
                  {
                      listboxnewrecipe.Items.Add(reader1["StepName"]);

                  }
                  listboxnewrecipe.SetSelected(0, true);*/
                con.Close();
            }

            else if (RecipeType.labelstring == "Cassette Recipe Name")
            {
                con.Open();


                string strSQL = "select * from Newrecipe inner join recipe on Newrecipe.recipeName = recipe.recipeName where Newrecipe.recipeName = @Newrecipename";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@Newrecipename", CassetteWafer.searchrecipename);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // listboxnewrecipe.Items.Add(reader["StepName"]);


                    // tbStepName.Text = reader["Step Name"].ToString();
                    strid.Add(string.Format("{0}", reader["Moduleicpid"]));
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









                }
                con.Close();
                if (strStepName.Count == 1)
                {
                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];

                    strtag = "panel1";

                }
                else if (strStepName.Count == 2)
                {
                    panel2.Visible = true;

                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];


                    lblid2.Text = strid[1];
                    tbStepName2.Text = strStepName[1];
                    tbTimeDependentStep2.Text = strTimeDependentStep[1];
                    tbProcessTime2.Text = strProcessTime[1];
                    tbProcessPressure2.Text = strProcessPressure[1];
                    tbProcessPressurePercent2.Text = strProcessPressurePercent[1];
                    tbApcSetpointPosition2.Text = strAPCSetpointPosition[1];
                    cmbApcMode2.Text = strAPCMode[1];
                    cmbActivePressureSensor2.Text = strActivePressureSensor[1];
                    tbSourcePower2.Text = strSourcePower[1];
                    tbSoursePowerPercent2.Text = strSourcePowerPercent[1];
                    cmbSourceMUTuneCapacitor2.Text = strSourceMUTuneCapacitor[1];
                    cmbSourceMULoadCapacitor2.Text = strSourceMULoadCapacitor[1];
                    cmbSourceRFControlMode2.Text = strSourceRFControlMode[1];
                    tbPlatenPower2.Text = strPlatenPower[1];
                    tbPlatenPowerPercent2.Text = strPlatenPowerPercent[1];
                    cmbPlatenCapacitorAdjust2.Text = strPlatenCapacitorAdjust[1];
                    tbPlatenRFTuningCapacitor2.Text = strPlatenRFTuningCapacitor[1];
                    tbPlatenRFTuningCapacitorPercent2.Text = strPlatenRFTuningCapacitorPercent[1];
                    tbPlatenRFLoadCapacitor2.Text = strPlatenRFLoadCapacitor[1];
                    tbPlatenRFLoadCapacitorPercent2.Text = strPlatenRFLoadCapacitorPercent[1];
                    cmbPlatenRFPaddingCapacitor2.Text = strPlatenRFPaddingCapacitor[1];
                    cmbPlatenRFControlMode2.Text = strPlatenRFControlMode[1];
                    tbHeliumPressure2.Text = strHeliumPressure[1];
                    tbHeliumPressurePercent2.Text = strHeliumpressurePercent[1];
                    tbHeliumFlowWarningLevel2.Text = strHeliumFlowWarningLevel[1];
                    tbHeliumFlowFaultLevel2.Text = strHeliumFlowFaultLevel[1];
                    cmbGasLineConfig2.Text = strGasLineConfig[1];
                    tbArgon2.Text = strArgon[1];
                    tbArgonPercent2.Text = strArgonPercent[1];
                    tbNitrogen2.Text = strNitrogen[1];
                    tbNitrogenPercent2.Text = strNitrogenPercent[1];
                    tbOxygen2.Text = strOxygen[1];
                    tbOxygenPercent2.Text = strOxygenPercent[1];
                    tbCHF3_2.Text = strCHF3[1];
                    tbCHF3Percent2.Text = strCHF3Percent[1];
                    tbSF6_2.Text = strSF6[1];
                    tbSF6Percent2.Text = strSF6Percent[1];
                    tbBCI3_2.Text = strBCI3[1];
                    tbBCI3Percent2.Text = strBCI3Percent[1];
                    _tbCI2_2.Text = strCI2[1];
                    _tbCI2Percent2.Text = strCI2Percent[1];

                    strtag = "panel2";


                }
                else if (strStepName.Count == 3)
                {
                    panel2.Visible = true;
                    panel3.Visible = true;

                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];


                    lblid.Text = strid[1];
                    tbStepName2.Text = strStepName[1];
                    tbTimeDependentStep2.Text = strTimeDependentStep[1];
                    tbProcessTime2.Text = strProcessTime[1];
                    tbProcessPressure2.Text = strProcessPressure[1];
                    tbProcessPressurePercent2.Text = strProcessPressurePercent[1];
                    tbApcSetpointPosition2.Text = strAPCSetpointPosition[1];
                    cmbApcMode2.Text = strAPCMode[1];
                    cmbActivePressureSensor2.Text = strActivePressureSensor[1];
                    tbSourcePower2.Text = strSourcePower[1];
                    tbSoursePowerPercent2.Text = strSourcePowerPercent[1];
                    cmbSourceMUTuneCapacitor2.Text = strSourceMUTuneCapacitor[1];
                    cmbSourceMULoadCapacitor2.Text = strSourceMULoadCapacitor[1];
                    cmbSourceRFControlMode2.Text = strSourceRFControlMode[1];
                    tbPlatenPower2.Text = strPlatenPower[1];
                    tbPlatenPowerPercent2.Text = strPlatenPowerPercent[1];
                    cmbPlatenCapacitorAdjust2.Text = strPlatenCapacitorAdjust[1];
                    tbPlatenRFTuningCapacitor2.Text = strPlatenRFTuningCapacitor[1];
                    tbPlatenRFTuningCapacitorPercent2.Text = strPlatenRFTuningCapacitorPercent[1];
                    tbPlatenRFLoadCapacitor2.Text = strPlatenRFLoadCapacitor[1];
                    tbPlatenRFLoadCapacitorPercent2.Text = strPlatenRFLoadCapacitorPercent[1];
                    cmbPlatenRFPaddingCapacitor2.Text = strPlatenRFPaddingCapacitor[1];
                    cmbPlatenRFControlMode2.Text = strPlatenRFControlMode[1];
                    tbHeliumPressure2.Text = strHeliumPressure[1];
                    tbHeliumPressurePercent2.Text = strHeliumpressurePercent[1];
                    tbHeliumFlowWarningLevel2.Text = strHeliumFlowWarningLevel[1];
                    tbHeliumFlowFaultLevel2.Text = strHeliumFlowFaultLevel[1];
                    cmbGasLineConfig2.Text = strGasLineConfig[1];
                    tbArgon2.Text = strArgon[1];
                    tbArgonPercent2.Text = strArgonPercent[1];
                    tbNitrogen2.Text = strNitrogen[1];
                    tbNitrogenPercent2.Text = strNitrogenPercent[1];
                    tbOxygen2.Text = strOxygen[1];
                    tbOxygenPercent2.Text = strOxygenPercent[1];
                    tbCHF3_2.Text = strCHF3[1];
                    tbCHF3Percent2.Text = strCHF3Percent[1];
                    tbSF6_2.Text = strSF6[1];
                    tbSF6Percent2.Text = strSF6Percent[1];
                    tbBCI3_2.Text = strBCI3[1];
                    tbBCI3Percent2.Text = strBCI3Percent[1];
                    _tbCI2_2.Text = strCI2[1];
                    _tbCI2Percent2.Text = strCI2Percent[1];


                    lblid.Text = strid[2];
                    tbStepName3.Text = strStepName[2];
                    tbTimeDependentStep3.Text = strTimeDependentStep[2];
                    tbProcessTime3.Text = strProcessTime[2];
                    tbProcessPressure3.Text = strProcessPressure[2];
                    tbProcessPressurePercent3.Text = strProcessPressurePercent[2];
                    tbApcSetpointPosition3.Text = strAPCSetpointPosition[2];
                    cmbApcMode3.Text = strAPCMode[2];
                    cmbActivePressureSensor3.Text = strActivePressureSensor[2];
                    tbSourcePower3.Text = strSourcePower[2];
                    tbSoursePowerPercent3.Text = strSourcePowerPercent[2];
                    cmbSourceMUTuneCapacitor3.Text = strSourceMUTuneCapacitor[2];
                    cmbSourceMULoadCapacitor3.Text = strSourceMULoadCapacitor[2];
                    cmbSourceRFControlMode3.Text = strSourceRFControlMode[2];
                    tbPlatenPower3.Text = strPlatenPower[2];
                    tbPlatenPowerPercent3.Text = strPlatenPowerPercent[2];
                    cmbPlatenCapacitorAdjust3.Text = strPlatenCapacitorAdjust[2];
                    tbPlatenRFTuningCapacitor3.Text = strPlatenRFTuningCapacitor[2];
                    tbPlatenRFTuningCapacitorPercent3.Text = strPlatenRFTuningCapacitorPercent[2];
                    tbPlatenRFLoadCapacitor3.Text = strPlatenRFLoadCapacitor[2];
                    tbPlatenRFLoadCapacitorPercent3.Text = strPlatenRFLoadCapacitorPercent[2];
                    cmbPlatenRFPaddingCapacitor3.Text = strPlatenRFPaddingCapacitor[2];
                    cmbPlatenRFControlMode3.Text = strPlatenRFControlMode[2];
                    tbHeliumPressure3.Text = strHeliumPressure[2];
                    tbHeliumPressurePercent3.Text = strHeliumpressurePercent[2];
                    tbHeliumFlowWarningLevel3.Text = strHeliumFlowWarningLevel[2];
                    tbHeliumFlowFaultLevel3.Text = strHeliumFlowFaultLevel[2];
                    cmbGasLineConfig3.Text = strGasLineConfig[2];
                    tbArgon3.Text = strArgon[2];
                    tbArgonPercent3.Text = strArgonPercent[2];
                    tbNitrogen3.Text = strNitrogen[2];
                    tbNitrogenPercent3.Text = strNitrogenPercent[2];
                    tbOxygen3.Text = strOxygen[2];
                    tbOxygenPercent3.Text = strOxygenPercent[2];
                    tbCHF3_3.Text = strCHF3[2];
                    tbCHF3Percent3.Text = strCHF3Percent[2];
                    tbSF6_3.Text = strSF6[2];
                    tbSF6Percent3.Text = strSF6Percent[2];
                    tbBCI3_3.Text = strBCI3[2];
                    tbBCI3Percent3.Text = strBCI3Percent[2];
                    _tbCI2_3.Text = strCI2[2];
                    _tbCI2Percent3.Text = strCI2Percent[2];

                    strtag = "panel3";

                }

                else if (strStepName.Count == 4)
                {
                    panel2.Visible = true;
                    panel3.Visible = true;
                    panel4.Visible = true;

                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];


                    lblid.Text = strid[1];
                    tbStepName2.Text = strStepName[1];
                    tbTimeDependentStep2.Text = strTimeDependentStep[1];
                    tbProcessTime2.Text = strProcessTime[1];
                    tbProcessPressure2.Text = strProcessPressure[1];
                    tbProcessPressurePercent2.Text = strProcessPressurePercent[1];
                    tbApcSetpointPosition2.Text = strAPCSetpointPosition[1];
                    cmbApcMode2.Text = strAPCMode[1];
                    cmbActivePressureSensor2.Text = strActivePressureSensor[1];
                    tbSourcePower2.Text = strSourcePower[1];
                    tbSoursePowerPercent2.Text = strSourcePowerPercent[1];
                    cmbSourceMUTuneCapacitor2.Text = strSourceMUTuneCapacitor[1];
                    cmbSourceMULoadCapacitor2.Text = strSourceMULoadCapacitor[1];
                    cmbSourceRFControlMode2.Text = strSourceRFControlMode[1];
                    tbPlatenPower2.Text = strPlatenPower[1];
                    tbPlatenPowerPercent2.Text = strPlatenPowerPercent[1];
                    cmbPlatenCapacitorAdjust2.Text = strPlatenCapacitorAdjust[1];
                    tbPlatenRFTuningCapacitor2.Text = strPlatenRFTuningCapacitor[1];
                    tbPlatenRFTuningCapacitorPercent2.Text = strPlatenRFTuningCapacitorPercent[1];
                    tbPlatenRFLoadCapacitor2.Text = strPlatenRFLoadCapacitor[1];
                    tbPlatenRFLoadCapacitorPercent2.Text = strPlatenRFLoadCapacitorPercent[1];
                    cmbPlatenRFPaddingCapacitor2.Text = strPlatenRFPaddingCapacitor[1];
                    cmbPlatenRFControlMode2.Text = strPlatenRFControlMode[1];
                    tbHeliumPressure2.Text = strHeliumPressure[1];
                    tbHeliumPressurePercent2.Text = strHeliumpressurePercent[1];
                    tbHeliumFlowWarningLevel2.Text = strHeliumFlowWarningLevel[1];
                    tbHeliumFlowFaultLevel2.Text = strHeliumFlowFaultLevel[1];
                    cmbGasLineConfig2.Text = strGasLineConfig[1];
                    tbArgon2.Text = strArgon[1];
                    tbArgonPercent2.Text = strArgonPercent[1];
                    tbNitrogen2.Text = strNitrogen[1];
                    tbNitrogenPercent2.Text = strNitrogenPercent[1];
                    tbOxygen2.Text = strOxygen[1];
                    tbOxygenPercent2.Text = strOxygenPercent[1];
                    tbCHF3_2.Text = strCHF3[1];
                    tbCHF3Percent2.Text = strCHF3Percent[1];
                    tbSF6_2.Text = strSF6[1];
                    tbSF6Percent2.Text = strSF6Percent[1];
                    tbBCI3_2.Text = strBCI3[1];
                    tbBCI3Percent2.Text = strBCI3Percent[1];
                    _tbCI2_2.Text = strCI2[1];
                    _tbCI2Percent2.Text = strCI2Percent[1];


                    lblid.Text = strid[2];
                    tbStepName3.Text = strStepName[2];
                    tbTimeDependentStep3.Text = strTimeDependentStep[2];
                    tbProcessTime3.Text = strProcessTime[2];
                    tbProcessPressure3.Text = strProcessPressure[2];
                    tbProcessPressurePercent3.Text = strProcessPressurePercent[2];
                    tbApcSetpointPosition3.Text = strAPCSetpointPosition[2];
                    cmbApcMode3.Text = strAPCMode[2];
                    cmbActivePressureSensor3.Text = strActivePressureSensor[2];
                    tbSourcePower3.Text = strSourcePower[2];
                    tbSoursePowerPercent3.Text = strSourcePowerPercent[2];
                    cmbSourceMUTuneCapacitor3.Text = strSourceMUTuneCapacitor[2];
                    cmbSourceMULoadCapacitor3.Text = strSourceMULoadCapacitor[2];
                    cmbSourceRFControlMode3.Text = strSourceRFControlMode[3];
                    tbPlatenPower3.Text = strPlatenPower[2];
                    tbPlatenPowerPercent3.Text = strPlatenPowerPercent[2];
                    cmbPlatenCapacitorAdjust3.Text = strPlatenCapacitorAdjust[2];
                    tbPlatenRFTuningCapacitor3.Text = strPlatenRFTuningCapacitor[2];
                    tbPlatenRFTuningCapacitorPercent3.Text = strPlatenRFTuningCapacitorPercent[2];
                    tbPlatenRFLoadCapacitor3.Text = strPlatenRFLoadCapacitor[2];
                    tbPlatenRFLoadCapacitorPercent3.Text = strPlatenRFLoadCapacitorPercent[2];
                    cmbPlatenRFPaddingCapacitor3.Text = strPlatenRFPaddingCapacitor[2];
                    cmbPlatenRFControlMode3.Text = strPlatenRFControlMode[2];
                    tbHeliumPressure3.Text = strHeliumPressure[2];
                    tbHeliumPressurePercent3.Text = strHeliumpressurePercent[2];
                    tbHeliumFlowWarningLevel3.Text = strHeliumFlowWarningLevel[2];
                    tbHeliumFlowFaultLevel3.Text = strHeliumFlowFaultLevel[2];
                    cmbGasLineConfig3.Text = strGasLineConfig[2];
                    tbArgon3.Text = strArgon[2];
                    tbArgonPercent3.Text = strArgonPercent[2];
                    tbNitrogen3.Text = strNitrogen[2];
                    tbNitrogenPercent3.Text = strNitrogenPercent[2];
                    tbOxygen3.Text = strOxygen[2];
                    tbOxygenPercent3.Text = strOxygenPercent[2];
                    tbCHF3_3.Text = strCHF3[2];
                    tbCHF3Percent3.Text = strCHF3Percent[2];
                    tbSF6_3.Text = strSF6[2];
                    tbSF6Percent3.Text = strSF6Percent[2];
                    tbBCI3_3.Text = strBCI3[2];
                    tbBCI3Percent3.Text = strBCI3Percent[2];
                    _tbCI2_3.Text = strCI2[2];
                    _tbCI2Percent3.Text = strCI2Percent[2];



                    lblid.Text = strid[3];
                    tbStepName4.Text = strStepName[3];
                    tbTimeDependentStep4.Text = strTimeDependentStep[3];
                    tbProcessTime4.Text = strProcessTime[3];
                    tbProcessPressure4.Text = strProcessPressure[3];
                    tbProcessPressurePercent4.Text = strProcessPressurePercent[3];
                    tbApcSetpointPosition4.Text = strAPCSetpointPosition[3];
                    cmbApcMode4.Text = strAPCMode[3];
                    cmbActivePressureSensor4.Text = strActivePressureSensor[3];
                    tbSourcePower4.Text = strSourcePower[3];
                    tbSoursePowerPercent4.Text = strSourcePowerPercent[3];
                    cmbSourceMUTuneCapacitor4.Text = strSourceMUTuneCapacitor[3];
                    cmbSourceMULoadCapacitor4.Text = strSourceMULoadCapacitor[3];
                    cmbSourceRFControlMode4.Text = strSourceRFControlMode[3];
                    tbPlatenPower4.Text = strPlatenPower[3];
                    tbPlatenPowerPercent4.Text = strPlatenPowerPercent[3];
                    cmbPlatenCapacitorAdjust4.Text = strPlatenCapacitorAdjust[3];
                    tbPlatenRFTuningCapacitor4.Text = strPlatenRFTuningCapacitor[3];
                    tbPlatenRFTuningCapacitorPercent4.Text = strPlatenRFTuningCapacitorPercent[3];
                    tbPlatenRFLoadCapacitor4.Text = strPlatenRFLoadCapacitor[3];
                    tbPlatenRFLoadCapacitorPercent4.Text = strPlatenRFLoadCapacitorPercent[3];
                    cmbPlatenRFPaddingCapacitor4.Text = strPlatenRFPaddingCapacitor[3];
                    cmbPlatenRFControlMode4.Text = strPlatenRFControlMode[3];
                    tbHeliumPressure4.Text = strHeliumPressure[3];
                    tbHeliumPressurePercent4.Text = strHeliumpressurePercent[3];
                    tbHeliumFlowWarningLevel4.Text = strHeliumFlowWarningLevel[3];
                    tbHeliumFlowFaultLevel4.Text = strHeliumFlowFaultLevel[3];
                    cmbGasLineConfig4.Text = strGasLineConfig[3];
                    tbArgon4.Text = strArgon[3];
                    tbArgonPercent4.Text = strArgonPercent[3];
                    tbNitrogen4.Text = strNitrogen[3];
                    tbNitrogenPercent4.Text = strNitrogenPercent[3];
                    tbOxygen4.Text = strOxygen[3];
                    tbOxygenPercent4.Text = strOxygenPercent[3];
                    tbCHF3_4.Text = strCHF3[3];
                    tbCHF3Percent4.Text = strCHF3Percent[3];
                    tbSF6_4.Text = strSF6[3];
                    tbSF6Percent4.Text = strSF6Percent[3];
                    tbBCI3_4.Text = strBCI3[3];
                    tbBCI3Percent4.Text = strBCI3Percent[3];
                    _tbCI2_4.Text = strCI2[3];
                    _tbCI2Percent4.Text = strCI2Percent[3];

                    strtag = "panel4";

                }
                else if (strStepName.Count == 5)
                {
                    panel2.Visible = true;
                    panel3.Visible = true;
                    panel4.Visible = true;
                    panel5.Visible = true;

                    lblid.Text = strid[0];
                    tbStepName.Text = strStepName[0];
                    tbTimeDependentStep.Text = strTimeDependentStep[0];
                    tbProcessTime.Text = strProcessTime[0];
                    tbProcessPressure.Text = strProcessPressure[0];
                    tbProcessPressurePercent.Text = strProcessPressurePercent[0];
                    tbApcSetpointPosition.Text = strAPCSetpointPosition[0];
                    cmbApcMode.Text = strAPCMode[0];
                    cmbActivePressureSensor.Text = strActivePressureSensor[0];
                    tbSourcePower.Text = strSourcePower[0];
                    tbSoursePowerPercent.Text = strSourcePowerPercent[0];
                    cmbSourceMUTuneCapacitor.Text = strSourceMUTuneCapacitor[0];
                    cmbSourceMULoadCapacitor.Text = strSourceMULoadCapacitor[0];
                    cmbSourceRFControlMode.Text = strSourceRFControlMode[0];
                    tbPlatenPower.Text = strPlatenPower[0];
                    tbPlatenPowerPercent.Text = strPlatenPowerPercent[0];
                    cmbPlatenCapacitorAdjust.Text = strPlatenCapacitorAdjust[0];
                    tbPlatenRFTuningCapacitor.Text = strPlatenRFTuningCapacitor[0];
                    tbPlatenRFTuningCapacitorPercent.Text = strPlatenRFTuningCapacitorPercent[0];
                    tbPlatenRFLoadCapacitor.Text = strPlatenRFLoadCapacitor[0];
                    tbPlatenRFLoadCapacitorPercent.Text = strPlatenRFLoadCapacitorPercent[0];
                    cmbPlatenRFPaddingCapacitor.Text = strPlatenRFPaddingCapacitor[0];
                    cmbPlatenRFControlMode.Text = strPlatenRFControlMode[0];
                    tbHeliumPressure.Text = strHeliumPressure[0];
                    tbHeliumPressurePercent.Text = strHeliumpressurePercent[0];
                    tbHeliumFlowWarningLevel.Text = strHeliumFlowWarningLevel[0];
                    tbHeliumFlowFaultLevel.Text = strHeliumFlowFaultLevel[0];
                    cmbGasLineConfig.Text = strGasLineConfig[0];
                    tbArgon.Text = strArgon[0];
                    tbArgonPercent.Text = strArgonPercent[0];
                    tbNitrogen.Text = strNitrogen[0];
                    tbNitrogenPercent.Text = strNitrogenPercent[0];
                    tbOxygen.Text = strOxygen[0];
                    tbOxygenPercent.Text = strOxygenPercent[0];
                    tbCHF3.Text = strCHF3[0];
                    tbCHF3Percent.Text = strCHF3Percent[0];
                    tbSF6.Text = strSF6[0];
                    tbSF6Percent.Text = strSF6Percent[0];
                    tbBCI3.Text = strBCI3[0];
                    tbBCI3Percent.Text = strBCI3Percent[0];
                    _tbCI2.Text = strCI2[0];
                    _tbCI2Percent.Text = strCI2Percent[0];


                    lblid.Text = strid[1];
                    tbStepName2.Text = strStepName[1];
                    tbTimeDependentStep2.Text = strTimeDependentStep[1];
                    tbProcessTime2.Text = strProcessTime[1];
                    tbProcessPressure2.Text = strProcessPressure[1];
                    tbProcessPressurePercent2.Text = strProcessPressurePercent[1];
                    tbApcSetpointPosition2.Text = strAPCSetpointPosition[1];
                    cmbApcMode2.Text = strAPCMode[1];
                    cmbActivePressureSensor2.Text = strActivePressureSensor[1];
                    tbSourcePower2.Text = strSourcePower[1];
                    tbSoursePowerPercent2.Text = strSourcePowerPercent[1];
                    cmbSourceMUTuneCapacitor2.Text = strSourceMUTuneCapacitor[1];
                    cmbSourceMULoadCapacitor2.Text = strSourceMULoadCapacitor[1];
                    cmbSourceRFControlMode2.Text = strSourceRFControlMode[1];
                    tbPlatenPower2.Text = strPlatenPower[1];
                    tbPlatenPowerPercent2.Text = strPlatenPowerPercent[1];
                    cmbPlatenCapacitorAdjust2.Text = strPlatenCapacitorAdjust[1];
                    tbPlatenRFTuningCapacitor2.Text = strPlatenRFTuningCapacitor[1];
                    tbPlatenRFTuningCapacitorPercent2.Text = strPlatenRFTuningCapacitorPercent[1];
                    tbPlatenRFLoadCapacitor2.Text = strPlatenRFLoadCapacitor[1];
                    tbPlatenRFLoadCapacitorPercent2.Text = strPlatenRFLoadCapacitorPercent[1];
                    cmbPlatenRFPaddingCapacitor2.Text = strPlatenRFPaddingCapacitor[1];
                    cmbPlatenRFControlMode2.Text = strPlatenRFControlMode[1];
                    tbHeliumPressure2.Text = strHeliumPressure[1];
                    tbHeliumPressurePercent2.Text = strHeliumpressurePercent[1];
                    tbHeliumFlowWarningLevel2.Text = strHeliumFlowWarningLevel[1];
                    tbHeliumFlowFaultLevel2.Text = strHeliumFlowFaultLevel[1];
                    cmbGasLineConfig2.Text = strGasLineConfig[1];
                    tbArgon2.Text = strArgon[1];
                    tbArgonPercent2.Text = strArgonPercent[1];
                    tbNitrogen2.Text = strNitrogen[1];
                    tbNitrogenPercent2.Text = strNitrogenPercent[1];
                    tbOxygen2.Text = strOxygen[1];
                    tbOxygenPercent2.Text = strOxygenPercent[1];
                    tbCHF3_2.Text = strCHF3[1];
                    tbCHF3Percent2.Text = strCHF3Percent[1];
                    tbSF6_2.Text = strSF6[1];
                    tbSF6Percent2.Text = strSF6Percent[1];
                    tbBCI3_2.Text = strBCI3[1];
                    tbBCI3Percent2.Text = strBCI3Percent[1];
                    _tbCI2_2.Text = strCI2[1];
                    _tbCI2Percent2.Text = strCI2Percent[1];


                    lblid.Text = strid[2];
                    tbStepName3.Text = strStepName[2];
                    tbTimeDependentStep3.Text = strTimeDependentStep[2];
                    tbProcessTime3.Text = strProcessTime[2];
                    tbProcessPressure3.Text = strProcessPressure[2];
                    tbProcessPressurePercent3.Text = strProcessPressurePercent[2];
                    tbApcSetpointPosition3.Text = strAPCSetpointPosition[2];
                    cmbApcMode3.Text = strAPCMode[2];
                    cmbActivePressureSensor3.Text = strActivePressureSensor[2];
                    tbSourcePower3.Text = strSourcePower[2];
                    tbSoursePowerPercent3.Text = strSourcePowerPercent[2];
                    cmbSourceMUTuneCapacitor3.Text = strSourceMUTuneCapacitor[2];
                    cmbSourceMULoadCapacitor3.Text = strSourceMULoadCapacitor[2];
                    cmbSourceRFControlMode3.Text = strSourceRFControlMode[3];
                    tbPlatenPower3.Text = strPlatenPower[2];
                    tbPlatenPowerPercent3.Text = strPlatenPowerPercent[2];
                    cmbPlatenCapacitorAdjust3.Text = strPlatenCapacitorAdjust[2];
                    tbPlatenRFTuningCapacitor3.Text = strPlatenRFTuningCapacitor[2];
                    tbPlatenRFTuningCapacitorPercent3.Text = strPlatenRFTuningCapacitorPercent[2];
                    tbPlatenRFLoadCapacitor3.Text = strPlatenRFLoadCapacitor[2];
                    tbPlatenRFLoadCapacitorPercent3.Text = strPlatenRFLoadCapacitorPercent[2];
                    cmbPlatenRFPaddingCapacitor3.Text = strPlatenRFPaddingCapacitor[2];
                    cmbPlatenRFControlMode3.Text = strPlatenRFControlMode[2];
                    tbHeliumPressure3.Text = strHeliumPressure[2];
                    tbHeliumPressurePercent3.Text = strHeliumpressurePercent[2];
                    tbHeliumFlowWarningLevel3.Text = strHeliumFlowWarningLevel[2];
                    tbHeliumFlowFaultLevel3.Text = strHeliumFlowFaultLevel[2];
                    cmbGasLineConfig3.Text = strGasLineConfig[2];
                    tbArgon3.Text = strArgon[2];
                    tbArgonPercent3.Text = strArgonPercent[2];
                    tbNitrogen3.Text = strNitrogen[2];
                    tbNitrogenPercent3.Text = strNitrogenPercent[2];
                    tbOxygen3.Text = strOxygen[2];
                    tbOxygenPercent3.Text = strOxygenPercent[2];
                    tbCHF3_3.Text = strCHF3[2];
                    tbCHF3Percent3.Text = strCHF3Percent[2];
                    tbSF6_3.Text = strSF6[2];
                    tbSF6Percent3.Text = strSF6Percent[2];
                    tbBCI3_3.Text = strBCI3[2];
                    tbBCI3Percent3.Text = strBCI3Percent[2];
                    _tbCI2_3.Text = strCI2[2];
                    _tbCI2Percent3.Text = strCI2Percent[2];

                    lblid.Text = strid[3];
                    tbStepName4.Text = strStepName[3];
                    tbTimeDependentStep4.Text = strTimeDependentStep[3];
                    tbProcessTime4.Text = strProcessTime[3];
                    tbProcessPressure4.Text = strProcessPressure[3];
                    tbProcessPressurePercent4.Text = strProcessPressurePercent[3];
                    tbApcSetpointPosition4.Text = strAPCSetpointPosition[3];
                    cmbApcMode4.Text = strAPCMode[3];
                    cmbActivePressureSensor4.Text = strActivePressureSensor[3];
                    tbSourcePower4.Text = strSourcePower[3];
                    tbSoursePowerPercent4.Text = strSourcePowerPercent[3];
                    cmbSourceMUTuneCapacitor4.Text = strSourceMUTuneCapacitor[3];
                    cmbSourceMULoadCapacitor4.Text = strSourceMULoadCapacitor[3];
                    cmbSourceRFControlMode4.Text = strSourceRFControlMode[3];
                    tbPlatenPower4.Text = strPlatenPower[3];
                    tbPlatenPowerPercent4.Text = strPlatenPowerPercent[3];
                    cmbPlatenCapacitorAdjust4.Text = strPlatenCapacitorAdjust[3];
                    tbPlatenRFTuningCapacitor4.Text = strPlatenRFTuningCapacitor[3];
                    tbPlatenRFTuningCapacitorPercent4.Text = strPlatenRFTuningCapacitorPercent[3];
                    tbPlatenRFLoadCapacitor4.Text = strPlatenRFLoadCapacitor[3];
                    tbPlatenRFLoadCapacitorPercent4.Text = strPlatenRFLoadCapacitorPercent[3];
                    cmbPlatenRFPaddingCapacitor4.Text = strPlatenRFPaddingCapacitor[3];
                    cmbPlatenRFControlMode4.Text = strPlatenRFControlMode[3];
                    tbHeliumPressure4.Text = strHeliumPressure[3];
                    tbHeliumPressurePercent4.Text = strHeliumpressurePercent[3];
                    tbHeliumFlowWarningLevel4.Text = strHeliumFlowWarningLevel[3];
                    tbHeliumFlowFaultLevel4.Text = strHeliumFlowFaultLevel[3];
                    cmbGasLineConfig4.Text = strGasLineConfig[3];
                    tbArgon4.Text = strArgon[3];
                    tbArgonPercent4.Text = strArgonPercent[3];
                    tbNitrogen4.Text = strNitrogen[3];
                    tbNitrogenPercent4.Text = strNitrogenPercent[3];
                    tbOxygen4.Text = strOxygen[3];
                    tbOxygenPercent4.Text = strOxygenPercent[3];
                    tbCHF3_4.Text = strCHF3[3];
                    tbCHF3Percent4.Text = strCHF3Percent[3];
                    tbSF6_4.Text = strSF6[3];
                    tbSF6Percent4.Text = strSF6Percent[3];
                    tbBCI3_4.Text = strBCI3[3];
                    tbBCI3Percent4.Text = strBCI3Percent[3];
                    _tbCI2_4.Text = strCI2[3];
                    _tbCI2Percent4.Text = strCI2Percent[3];

                    lblid.Text = strid[4];
                    tbStepName5.Text = strStepName[4];
                    tbTimeDependentStep5.Text = strTimeDependentStep[4];
                    tbProcessTime5.Text = strProcessTime[4];
                    tbProcessPressure5.Text = strProcessPressure[4];
                    tbProcessPressurePercent5.Text = strProcessPressurePercent[4];
                    tbApcSetpointPosition5.Text = strAPCSetpointPosition[4];
                    cmbApcMode5.Text = strAPCMode[4];
                    cmbActivePressureSensor5.Text = strActivePressureSensor[4];
                    tbSourcePower5.Text = strSourcePower[4];
                    tbSoursePowerPercent5.Text = strSourcePowerPercent[4];
                    cmbSourceMUTuneCapacitor5.Text = strSourceMUTuneCapacitor[4];
                    cmbSourceMULoadCapacitor5.Text = strSourceMULoadCapacitor[4];
                    cmbSourceRFControlMode5.Text = strSourceRFControlMode[4];
                    tbPlatenPower5.Text = strPlatenPower[4];
                    tbPlatenPowerPercent5.Text = strPlatenPowerPercent[4];
                    cmbPlatenCapacitorAdjust5.Text = strPlatenCapacitorAdjust[4];
                    tbPlatenRFTuningCapacitor5.Text = strPlatenRFTuningCapacitor[4];
                    tbPlatenRFTuningCapacitorPercent5.Text = strPlatenRFTuningCapacitorPercent[4];
                    tbPlatenRFLoadCapacitor5.Text = strPlatenRFLoadCapacitor[4];
                    tbPlatenRFLoadCapacitorPercent5.Text = strPlatenRFLoadCapacitorPercent[4];
                    cmbPlatenRFPaddingCapacitor5.Text = strPlatenRFPaddingCapacitor[4];
                    cmbPlatenRFControlMode5.Text = strPlatenRFControlMode[4];
                    tbHeliumPressure5.Text = strHeliumPressure[4];
                    tbHeliumPressurePercent5.Text = strHeliumpressurePercent[4];
                    tbHeliumFlowWarningLevel5.Text = strHeliumFlowWarningLevel[4];
                    tbHeliumFlowFaultLevel5.Text = strHeliumFlowFaultLevel[4];
                    cmbGasLineConfig5.Text = strGasLineConfig[4];
                    tbArgon5.Text = strArgon[4];
                    tbArgonPercent5.Text = strArgonPercent[4];
                    tbNitrogen5.Text = strNitrogen[4];
                    tbNitrogenPercent5.Text = strNitrogenPercent[4];
                    tbOxygen5.Text = strOxygen[4];
                    tbOxygenPercent5.Text = strOxygenPercent[4];
                    tbCHF3_5.Text = strCHF3[4];
                    tbCHF3Percent5.Text = strCHF3Percent[4];
                    tbSF6_5.Text = strSF6[4];
                    tbSF6Percent5.Text = strSF6Percent[4];
                    tbBCI3_5.Text = strBCI3[4];
                    tbBCI3Percent5.Text = strBCI3Percent[4];
                    _tbCI2_5.Text = strCI2[4];
                    _tbCI2Percent5.Text = strCI2Percent[4];

                    strtag = "panel5";
                }



                ////////////////////////////////////////////////////////////////////////
                /*  con.Open();
                  string strSQL1 = "select * from Newrecipe where recipeName like @Newsearchname";
                  SqlCommand cmd1 =new SqlCommand(strSQL1, con);

                  cmd1.Parameters.AddWithValue("@Newsearchname",RecipeType.strSearchName);

                  SqlDataReader reader1 = cmd1.ExecuteReader();
                  while (reader1.Read())
                  {
                      listboxnewrecipe.Items.Add(reader1["StepName"]);

                  }
                  listboxnewrecipe.SetSelected(0, true);*/



            }
          

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listboxnewrecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*
            string strSelected = listboxnewrecipe.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from Newrecipe where StepName like @NewSelectd";

            SqlCommand cmd = new SqlCommand(strSQL,con);

            cmd.Parameters.AddWithValue("@NewSelectd", strSelected);

            SqlDataReader reader = cmd.ExecuteReader();

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
                tbSoursePower.Text = string.Format("{0}", reader["SourcePower"]);
                tbSourcePowerPercent.Text = string.Format("{0}", reader["SourcePowerPercent"]);
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
                tbCI2Percent.Text = string.Format("{0}", reader["CI2Percent"]);





            }*/
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSQL = "insert into recipe(recipename,recipedate)values(@1,@2)";

            string strSQL1 = "insert into Newrecipe (recipename,StepName,TimeDependentstep,ProcessTime,ProcessPressure,ProcessPressurePercent,APCSetpointPosition,APCMode,ActivePressureSensor,SourcePower,SourcePowerPercent" +
               ",SourceMUTuneCapacitor,SourceMULoadCapacitor,SourceRFControlMode,PlatenPower,PlatenPowerPercent,PlatenCapacitorAdjust,PlatenRFTuningCapacitor,PlatenRFTuningCapacitorPercent," +
               "PlatenRFLoadCapacitor,PlatenRFLoadCapacitorPercent,PlatenRFPaddingCapacitor,PlatenRFControlMode,HeliumPressure,HeliumPressurePercent,HeliumFlowWarninglevel,HeliumFlowFaultlevel," +
              "GasLineConfig,Argon,ArgonPercent,Nitrogen,NitrogenPercent,Oxygen,OxygenPercent,Oxygen1,Oxygen1Percent,CHF3,CHF3Percent,SF6,SF6Percent,BCI3,BCI3Percent,CI2,CI2Percent) values(@Newrecipename,@NewstepName,@NewTimeDependentStep,@NewProcessTime," +
              "@NewProcessPressure,@NewProcessPressurePercent,@NewAPCSetpointPosition,@NewAPCMode,@NewActivePressureSensor,@NewSoursePower,@NewSoursePowerPercent,@NewSourseMUtunecapacitor,@NewSourseMUloadcapacitor,@NewSourseRFcontrolMode," +
              "@NewPlatenPower,@NewPlatenPowerpercent,@NewplatenCapacitorAdjust,@NewPlatenRFTuningCapacitor,@NewPlatenRFTuningCapacitorpercent,@NewPlatenRFloadCapacitor,@NewPlatenRFloadCapacitorpercent,@NewPlatenRFpaddingCapacitor," +
             "@NewplatenRFcontrolMode,@NewHeliumpressure,@NewHeliumpressurepercent,@NewHeliumFlowWarninglevel,@NewHeliumFlowFaultlevel,@NewGasLineConfig,@NewArgon,@NewArgonpercent,@NewNitrogen,@NewNitrogenpercent,@NewOxygen," +
             "@NewOxygenpercent,@NewOxygen1,@NewOxygen1Percent,@NewCHF3,@NewCHF3percent,@NewSF6,@NewSF6percent,@NewBCI3,@NewBCI3percent,@NewCI2,@NewCI2percent)";

            string strDelete = "delete from newrecipe where moduleicpid = @id";

            if (strtag == "panel1" && lblid2.Text == "no")
            {

                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();
            }

            else if (strtag == "panel1" && lblid2.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strDelete, con);
                cmd.Parameters.AddWithValue("@id", lblid2.Text);

            }

            else if (strtag == "panel2" && lblid2.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "update newrecipe set stepname=@1,TimeDependentStep=@2,ProcessTime=@3,ProcessPressure=@4,ProcessPressurePercent=@5,APCSetPointPosition=@6,APCMode=@7,ActivePressureSensor=@8,SourcePower=@9" +
                ",SourcePowerPercent=@10,SourceMUTuneCapacitor=@11,SourceMULoadCapacitor=@12,SourceRFControlMode=@13,PlatenPower=@14,PlatenPowerPercent=@15,PlatenCapacitorAdjust=@16,PlatenRFTuningCapacitor=@17" +
                ",PlatenRFTuningCapacitorPercent=@18,PlatenRFLoadCapacitor=@19,PlatenRFLoadCapacitorPercent=@20,PlatenRFPaddingCapacitor=@21,PlatenRFControlMode=@22,HeliumPressure=@23,HeliumPressurePercent=@24" +
                ",HeliumFlowWarningLevel=@25,HeliumFlowFaultLevel=@26,GasLineConfig=@27,Argon=@28,ArgonPercent=@29,Nitrogen=@30,NitrogenPercent=@31,Oxygen=@32,OxygenPercent=@33,Oxygen1=@34,Oxygen1Percent=@35" +
                ",CHF3=@36,CHF3Percent=@37,SF6=@38,SF6Percent=@39,BCI3=@40,BCI3Percent=@41,CI2=@42,CI2Percent=@43 where ModuleICPID= @id";

            string strSQL1 = "insert into Newrecipe (recipename,StepName,TimeDependentstep,ProcessTime,ProcessPressure,ProcessPressurePercent,APCSetpointPosition,APCMode,ActivePressureSensor,SourcePower,SourcePowerPercent" +
               ",SourceMUTuneCapacitor,SourceMULoadCapacitor,SourceRFControlMode,PlatenPower,PlatenPowerPercent,PlatenCapacitorAdjust,PlatenRFTuningCapacitor,PlatenRFTuningCapacitorPercent," +
               "PlatenRFLoadCapacitor,PlatenRFLoadCapacitorPercent,PlatenRFPaddingCapacitor,PlatenRFControlMode,HeliumPressure,HeliumPressurePercent,HeliumFlowWarninglevel,HeliumFlowFaultlevel," +
              "GasLineConfig,Argon,ArgonPercent,Nitrogen,NitrogenPercent,Oxygen,OxygenPercent,Oxygen1,Oxygen1Percent,CHF3,CHF3Percent,SF6,SF6Percent,BCI3,BCI3Percent,CI2,CI2Percent) values(@Newrecipename,@NewstepName,@NewTimeDependentStep,@NewProcessTime," +
              "@NewProcessPressure,@NewProcessPressurePercent,@NewAPCSetpointPosition,@NewAPCMode,@NewActivePressureSensor,@NewSoursePower,@NewSoursePowerPercent,@NewSourseMUtunecapacitor,@NewSourseMUloadcapacitor,@NewSourseRFcontrolMode," +
              "@NewPlatenPower,@NewPlatenPowerpercent,@NewplatenCapacitorAdjust,@NewPlatenRFTuningCapacitor,@NewPlatenRFTuningCapacitorpercent,@NewPlatenRFloadCapacitor,@NewPlatenRFloadCapacitorpercent,@NewPlatenRFpaddingCapacitor," +
             "@NewplatenRFcontrolMode,@NewHeliumpressure,@NewHeliumpressurepercent,@NewHeliumFlowWarninglevel,@NewHeliumFlowFaultlevel,@NewGasLineConfig,@NewArgon,@NewArgonpercent,@NewNitrogen,@NewNitrogenpercent,@NewOxygen," +
             "@NewOxygenpercent,@NewOxygen1,@NewOxygen1Percent,@NewCHF3,@NewCHF3percent,@NewSF6,@NewSF6percent,@NewBCI3,@NewBCI3percent,@NewCI2,@NewCI2percent)";

            string strDelete = "delete from newrecipe where moduleicpid = @id";



            if (strtag == "panel1"&&lblid2.Text=="no")
            {

                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();
            }

            else if (strtag == "panel1" && lblid2.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strDelete, con);
                    cmd.Parameters.AddWithValue("@id",lblid2.Text);

            }

            else if (strtag == "panel2" && lblid2.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

            }

            else if (strtag == "panel2" && lblid2.Text == "no")//lblid insert 1 筆
            {



                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL1, con);
                // cmd.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());
                cmd2.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd2.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent2.Text);
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
            else if (strtag == "panel3" && lblid3.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbStepName3.Text);
                cmd3.Parameters.AddWithValue("@2", tbTimeDependentStep3.Text);
                cmd3.Parameters.AddWithValue("@3", tbProcessTime3.Text);
                cmd3.Parameters.AddWithValue("@4", tbProcessPressure3.Text);
                cmd3.Parameters.AddWithValue("@5", tbProcessPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@6", tbApcSetpointPosition3.Text);
                cmd3.Parameters.AddWithValue("@7", cmbApcMode3.Text);
                cmd3.Parameters.AddWithValue("@8", cmbActivePressureSensor3.Text);
                cmd3.Parameters.AddWithValue("@9", tbSourcePower3.Text);
                cmd3.Parameters.AddWithValue("@10", tbSoursePowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@13", cmbSourceRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@14", tbPlatenPower3.Text);
                cmd3.Parameters.AddWithValue("@15", tbPlatenPowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust3.Text);
                cmd3.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@22", cmbPlatenRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@23", tbHeliumPressure3.Text);
                cmd3.Parameters.AddWithValue("@24", tbHeliumPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel3.Text);
                cmd3.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel3.Text);
                cmd3.Parameters.AddWithValue("@27", cmbGasLineConfig3.Text);
                cmd3.Parameters.AddWithValue("@28", tbArgon3.Text);
                cmd3.Parameters.AddWithValue("@29", tbArgonPercent3.Text);
                cmd3.Parameters.AddWithValue("@30", tbNitrogen3.Text);
                cmd3.Parameters.AddWithValue("@31", tbNitrogenPercent3.Text);
                cmd3.Parameters.AddWithValue("@32", tbOxygen3.Text);
                cmd3.Parameters.AddWithValue("@33", tbOxygenPercent3.Text);
                cmd3.Parameters.AddWithValue("@34", tbOxygen1_3.Text);
                cmd3.Parameters.AddWithValue("@35", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@36", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@37", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@38", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@39", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@40", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@41", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@42", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@43", _tbCI2Percent3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();

            }

            else if (strtag == "panel3" && lblid3.Text == "no" && lblid2.Text == "no")//lblid insert 2 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                cmd2.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd2.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent2.Text);
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

                cmd3.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd3.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent3.Text);

                cmd3.ExecuteNonQuery();




            }

            else if (strtag == "panel3" && lblid3.Text == "no" && lblid2.Text != "no")//lblid2 insert 1 筆
            {

                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();


                SqlCommand cmd3 = new SqlCommand(strSQL1, con);

                cmd3.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd3.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent3.Text);

                cmd3.ExecuteNonQuery();







            }

            else if (strtag == "panel4" && lblid4.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbStepName3.Text);
                cmd3.Parameters.AddWithValue("@2", tbTimeDependentStep3.Text);
                cmd3.Parameters.AddWithValue("@3", tbProcessTime3.Text);
                cmd3.Parameters.AddWithValue("@4", tbProcessPressure3.Text);
                cmd3.Parameters.AddWithValue("@5", tbProcessPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@6", tbApcSetpointPosition3.Text);
                cmd3.Parameters.AddWithValue("@7", cmbApcMode3.Text);
                cmd3.Parameters.AddWithValue("@8", cmbActivePressureSensor3.Text);
                cmd3.Parameters.AddWithValue("@9", tbSourcePower3.Text);
                cmd3.Parameters.AddWithValue("@10", tbSoursePowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@13", cmbSourceRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@14", tbPlatenPower3.Text);
                cmd3.Parameters.AddWithValue("@15", tbPlatenPowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust3.Text);
                cmd3.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@22", cmbPlatenRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@23", tbHeliumPressure3.Text);
                cmd3.Parameters.AddWithValue("@24", tbHeliumPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel3.Text);
                cmd3.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel3.Text);
                cmd3.Parameters.AddWithValue("@27", cmbGasLineConfig3.Text);
                cmd3.Parameters.AddWithValue("@28", tbArgon3.Text);
                cmd3.Parameters.AddWithValue("@29", tbArgonPercent3.Text);
                cmd3.Parameters.AddWithValue("@30", tbNitrogen3.Text);
                cmd3.Parameters.AddWithValue("@31", tbNitrogenPercent3.Text);
                cmd3.Parameters.AddWithValue("@32", tbOxygen3.Text);
                cmd3.Parameters.AddWithValue("@33", tbOxygenPercent3.Text);
                cmd3.Parameters.AddWithValue("@34", tbOxygen1_3.Text);
                cmd3.Parameters.AddWithValue("@35", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@36", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@37", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@38", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@39", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@40", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@41", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@42", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@43", _tbCI2Percent3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand(strSQL, con);
                cmd4.Parameters.AddWithValue("@1", tbStepName4.Text);
                cmd4.Parameters.AddWithValue("@2", tbTimeDependentStep4.Text);
                cmd4.Parameters.AddWithValue("@3", tbProcessTime4.Text);
                cmd4.Parameters.AddWithValue("@4", tbProcessPressure4.Text);
                cmd4.Parameters.AddWithValue("@5", tbProcessPressurePercent4.Text);
                cmd4.Parameters.AddWithValue("@6", tbApcSetpointPosition4.Text);
                cmd4.Parameters.AddWithValue("@7", cmbApcMode4.Text);
                cmd4.Parameters.AddWithValue("@8", cmbActivePressureSensor4.Text);
                cmd4.Parameters.AddWithValue("@9", tbSourcePower4.Text);
                cmd4.Parameters.AddWithValue("@10", tbSoursePowerPercent4.Text);
                cmd4.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@13", cmbSourceRFControlMode4.Text);
                cmd4.Parameters.AddWithValue("@14", tbPlatenPower4.Text);
                cmd4.Parameters.AddWithValue("@15", tbPlatenPowerPercent4.Text);
                cmd4.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust4.Text);
                cmd4.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent4.Text);
                cmd4.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent4.Text);
                cmd4.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@22", cmbPlatenRFControlMode4.Text);
                cmd4.Parameters.AddWithValue("@23", tbHeliumPressure4.Text);
                cmd4.Parameters.AddWithValue("@24", tbHeliumPressurePercent4.Text);
                cmd4.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel4.Text);
                cmd4.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel4.Text);
                cmd4.Parameters.AddWithValue("@27", cmbGasLineConfig4.Text);
                cmd4.Parameters.AddWithValue("@28", tbArgon4.Text);
                cmd4.Parameters.AddWithValue("@29", tbArgonPercent4.Text);
                cmd4.Parameters.AddWithValue("@30", tbNitrogen4.Text);
                cmd4.Parameters.AddWithValue("@31", tbNitrogenPercent4.Text);
                cmd4.Parameters.AddWithValue("@32", tbOxygen4.Text);
                cmd4.Parameters.AddWithValue("@33", tbOxygenPercent4.Text);
                cmd4.Parameters.AddWithValue("@34", tbOxygen1_4.Text);
                cmd4.Parameters.AddWithValue("@35", tbOxygen1Percent4.Text);
                cmd4.Parameters.AddWithValue("@36", tbCHF3_4.Text);
                cmd4.Parameters.AddWithValue("@37", tbCHF3Percent4.Text);
                cmd4.Parameters.AddWithValue("@38", tbSF6_4.Text);
                cmd4.Parameters.AddWithValue("@39", tbSF6Percent4.Text);
                cmd4.Parameters.AddWithValue("@40", tbBCI3_4.Text);
                cmd4.Parameters.AddWithValue("@41", tbBCI3Percent4.Text);
                cmd4.Parameters.AddWithValue("@42", _tbCI2_4.Text);
                cmd4.Parameters.AddWithValue("@43", _tbCI2Percent4.Text);
                cmd4.Parameters.AddWithValue("@id", lblid4.Text);
                cmd4.ExecuteNonQuery();
            }

            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text != "no" && lblid2.Text != "no")//lblid3 insert 1 筆

            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbStepName3.Text);
                cmd3.Parameters.AddWithValue("@2", tbTimeDependentStep3.Text);
                cmd3.Parameters.AddWithValue("@3", tbProcessTime3.Text);
                cmd3.Parameters.AddWithValue("@4", tbProcessPressure3.Text);
                cmd3.Parameters.AddWithValue("@5", tbProcessPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@6", tbApcSetpointPosition3.Text);
                cmd3.Parameters.AddWithValue("@7", cmbApcMode3.Text);
                cmd3.Parameters.AddWithValue("@8", cmbActivePressureSensor3.Text);
                cmd3.Parameters.AddWithValue("@9", tbSourcePower3.Text);
                cmd3.Parameters.AddWithValue("@10", tbSoursePowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@13", cmbSourceRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@14", tbPlatenPower3.Text);
                cmd3.Parameters.AddWithValue("@15", tbPlatenPowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust3.Text);
                cmd3.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@22", cmbPlatenRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@23", tbHeliumPressure3.Text);
                cmd3.Parameters.AddWithValue("@24", tbHeliumPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel3.Text);
                cmd3.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel3.Text);
                cmd3.Parameters.AddWithValue("@27", cmbGasLineConfig3.Text);
                cmd3.Parameters.AddWithValue("@28", tbArgon3.Text);
                cmd3.Parameters.AddWithValue("@29", tbArgonPercent3.Text);
                cmd3.Parameters.AddWithValue("@30", tbNitrogen3.Text);
                cmd3.Parameters.AddWithValue("@31", tbNitrogenPercent3.Text);
                cmd3.Parameters.AddWithValue("@32", tbOxygen3.Text);
                cmd3.Parameters.AddWithValue("@33", tbOxygenPercent3.Text);
                cmd3.Parameters.AddWithValue("@34", tbOxygen1_3.Text);
                cmd3.Parameters.AddWithValue("@35", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@36", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@37", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@38", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@39", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@40", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@41", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@42", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@43", _tbCI2Percent3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                cmd4.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd4.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent4.Text);
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

            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text != "no")//lblid2 insert 2 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();


                SqlCommand cmd3 = new SqlCommand(strSQL1, con);

                cmd3.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd3.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent3.Text);

                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                cmd4.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd4.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent4.Text);
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

            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text == "no")//lblid insert 3 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                cmd2.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd2.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent2.Text);
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

                cmd3.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd3.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent3.Text);

                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                cmd4.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd4.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent4.Text);
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

            else if (strtag == "panel5" && lblid5.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbStepName3.Text);
                cmd3.Parameters.AddWithValue("@2", tbTimeDependentStep3.Text);
                cmd3.Parameters.AddWithValue("@3", tbProcessTime3.Text);
                cmd3.Parameters.AddWithValue("@4", tbProcessPressure3.Text);
                cmd3.Parameters.AddWithValue("@5", tbProcessPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@6", tbApcSetpointPosition3.Text);
                cmd3.Parameters.AddWithValue("@7", cmbApcMode3.Text);
                cmd3.Parameters.AddWithValue("@8", cmbActivePressureSensor3.Text);
                cmd3.Parameters.AddWithValue("@9", tbSourcePower3.Text);
                cmd3.Parameters.AddWithValue("@10", tbSoursePowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@13", cmbSourceRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@14", tbPlatenPower3.Text);
                cmd3.Parameters.AddWithValue("@15", tbPlatenPowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust3.Text);
                cmd3.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@22", cmbPlatenRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@23", tbHeliumPressure3.Text);
                cmd3.Parameters.AddWithValue("@24", tbHeliumPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel3.Text);
                cmd3.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel3.Text);
                cmd3.Parameters.AddWithValue("@27", cmbGasLineConfig3.Text);
                cmd3.Parameters.AddWithValue("@28", tbArgon3.Text);
                cmd3.Parameters.AddWithValue("@29", tbArgonPercent3.Text);
                cmd3.Parameters.AddWithValue("@30", tbNitrogen3.Text);
                cmd3.Parameters.AddWithValue("@31", tbNitrogenPercent3.Text);
                cmd3.Parameters.AddWithValue("@32", tbOxygen3.Text);
                cmd3.Parameters.AddWithValue("@33", tbOxygenPercent3.Text);
                cmd3.Parameters.AddWithValue("@34", tbOxygen1_3.Text);
                cmd3.Parameters.AddWithValue("@35", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@36", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@37", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@38", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@39", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@40", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@41", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@42", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@43", _tbCI2Percent3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand(strSQL, con);
                cmd4.Parameters.AddWithValue("@1", tbStepName4.Text);
                cmd4.Parameters.AddWithValue("@2", tbTimeDependentStep4.Text);
                cmd4.Parameters.AddWithValue("@3", tbProcessTime4.Text);
                cmd4.Parameters.AddWithValue("@4", tbProcessPressure4.Text);
                cmd4.Parameters.AddWithValue("@5", tbProcessPressurePercent4.Text);
                cmd4.Parameters.AddWithValue("@6", tbApcSetpointPosition4.Text);
                cmd4.Parameters.AddWithValue("@7", cmbApcMode4.Text);
                cmd4.Parameters.AddWithValue("@8", cmbActivePressureSensor4.Text);
                cmd4.Parameters.AddWithValue("@9", tbSourcePower4.Text);
                cmd4.Parameters.AddWithValue("@10", tbSoursePowerPercent4.Text);
                cmd4.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@13", cmbSourceRFControlMode4.Text);
                cmd4.Parameters.AddWithValue("@14", tbPlatenPower4.Text);
                cmd4.Parameters.AddWithValue("@15", tbPlatenPowerPercent4.Text);
                cmd4.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust4.Text);
                cmd4.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent4.Text);
                cmd4.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent4.Text);
                cmd4.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@22", cmbPlatenRFControlMode4.Text);
                cmd4.Parameters.AddWithValue("@23", tbHeliumPressure4.Text);
                cmd4.Parameters.AddWithValue("@24", tbHeliumPressurePercent4.Text);
                cmd4.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel4.Text);
                cmd4.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel4.Text);
                cmd4.Parameters.AddWithValue("@27", cmbGasLineConfig4.Text);
                cmd4.Parameters.AddWithValue("@28", tbArgon4.Text);
                cmd4.Parameters.AddWithValue("@29", tbArgonPercent4.Text);
                cmd4.Parameters.AddWithValue("@30", tbNitrogen4.Text);
                cmd4.Parameters.AddWithValue("@31", tbNitrogenPercent4.Text);
                cmd4.Parameters.AddWithValue("@32", tbOxygen4.Text);
                cmd4.Parameters.AddWithValue("@33", tbOxygenPercent4.Text);
                cmd4.Parameters.AddWithValue("@34", tbOxygen1_4.Text);
                cmd4.Parameters.AddWithValue("@35", tbOxygen1Percent4.Text);
                cmd4.Parameters.AddWithValue("@36", tbCHF3_4.Text);
                cmd4.Parameters.AddWithValue("@37", tbCHF3Percent4.Text);
                cmd4.Parameters.AddWithValue("@38", tbSF6_4.Text);
                cmd4.Parameters.AddWithValue("@39", tbSF6Percent4.Text);
                cmd4.Parameters.AddWithValue("@40", tbBCI3_4.Text);
                cmd4.Parameters.AddWithValue("@41", tbBCI3Percent4.Text);
                cmd4.Parameters.AddWithValue("@42", _tbCI2_4.Text);
                cmd4.Parameters.AddWithValue("@43", _tbCI2Percent4.Text);
                cmd4.Parameters.AddWithValue("@id", lblid4.Text);
                cmd4.ExecuteNonQuery();

                SqlCommand cmd5 = new SqlCommand(strSQL, con);
                cmd5.Parameters.AddWithValue("@1", tbStepName5.Text);
                cmd5.Parameters.AddWithValue("@2", tbTimeDependentStep5.Text);
                cmd5.Parameters.AddWithValue("@3", tbProcessTime5.Text);
                cmd5.Parameters.AddWithValue("@4", tbProcessPressure5.Text);
                cmd5.Parameters.AddWithValue("@5", tbProcessPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@6", tbApcSetpointPosition5.Text);
                cmd5.Parameters.AddWithValue("@7", cmbApcMode5.Text);
                cmd5.Parameters.AddWithValue("@8", cmbActivePressureSensor5.Text);
                cmd5.Parameters.AddWithValue("@9", tbSourcePower5.Text);
                cmd5.Parameters.AddWithValue("@10", tbSoursePowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor4.Text);
                cmd5.Parameters.AddWithValue("@13", cmbSourceRFControlMode4.Text);
                cmd5.Parameters.AddWithValue("@14", tbPlatenPower5.Text);
                cmd5.Parameters.AddWithValue("@15", tbPlatenPowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust5.Text);
                cmd5.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@22", cmbPlatenRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@23", tbHeliumPressure5.Text);
                cmd5.Parameters.AddWithValue("@24", tbHeliumPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel5.Text);
                cmd5.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel5.Text);
                cmd5.Parameters.AddWithValue("@27", cmbGasLineConfig5.Text);
                cmd5.Parameters.AddWithValue("@28", tbArgon5.Text);
                cmd5.Parameters.AddWithValue("@29", tbArgonPercent5.Text);
                cmd5.Parameters.AddWithValue("@30", tbNitrogen5.Text);
                cmd5.Parameters.AddWithValue("@31", tbNitrogenPercent5.Text);
                cmd5.Parameters.AddWithValue("@32", tbOxygen5.Text);
                cmd5.Parameters.AddWithValue("@33", tbOxygenPercent5.Text);
                cmd5.Parameters.AddWithValue("@34", tbOxygen1_5.Text);
                cmd5.Parameters.AddWithValue("@35", tbOxygen1Percent5.Text);
                cmd5.Parameters.AddWithValue("@36", tbCHF3_5.Text);
                cmd5.Parameters.AddWithValue("@37", tbCHF3Percent5.Text);
                cmd5.Parameters.AddWithValue("@38", tbSF6_5.Text);
                cmd5.Parameters.AddWithValue("@39", tbSF6Percent5.Text);
                cmd5.Parameters.AddWithValue("@40", tbBCI3_5.Text);
                cmd5.Parameters.AddWithValue("@41", tbBCI3Percent5.Text);
                cmd5.Parameters.AddWithValue("@42", _tbCI2_5.Text);
                cmd5.Parameters.AddWithValue("@43", _tbCI2Percent5.Text);
                cmd5.Parameters.AddWithValue("@id", lblid5.Text);
                cmd5.ExecuteNonQuery();

            }

            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")//lblid4 insert 1 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbStepName3.Text);
                cmd3.Parameters.AddWithValue("@2", tbTimeDependentStep3.Text);
                cmd3.Parameters.AddWithValue("@3", tbProcessTime3.Text);
                cmd3.Parameters.AddWithValue("@4", tbProcessPressure3.Text);
                cmd3.Parameters.AddWithValue("@5", tbProcessPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@6", tbApcSetpointPosition3.Text);
                cmd3.Parameters.AddWithValue("@7", cmbApcMode3.Text);
                cmd3.Parameters.AddWithValue("@8", cmbActivePressureSensor3.Text);
                cmd3.Parameters.AddWithValue("@9", tbSourcePower3.Text);
                cmd3.Parameters.AddWithValue("@10", tbSoursePowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@13", cmbSourceRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@14", tbPlatenPower3.Text);
                cmd3.Parameters.AddWithValue("@15", tbPlatenPowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust3.Text);
                cmd3.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@22", cmbPlatenRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@23", tbHeliumPressure3.Text);
                cmd3.Parameters.AddWithValue("@24", tbHeliumPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel3.Text);
                cmd3.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel3.Text);
                cmd3.Parameters.AddWithValue("@27", cmbGasLineConfig3.Text);
                cmd3.Parameters.AddWithValue("@28", tbArgon3.Text);
                cmd3.Parameters.AddWithValue("@29", tbArgonPercent3.Text);
                cmd3.Parameters.AddWithValue("@30", tbNitrogen3.Text);
                cmd3.Parameters.AddWithValue("@31", tbNitrogenPercent3.Text);
                cmd3.Parameters.AddWithValue("@32", tbOxygen3.Text);
                cmd3.Parameters.AddWithValue("@33", tbOxygenPercent3.Text);
                cmd3.Parameters.AddWithValue("@34", tbOxygen1_3.Text);
                cmd3.Parameters.AddWithValue("@35", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@36", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@37", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@38", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@39", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@40", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@41", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@42", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@43", _tbCI2Percent3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand(strSQL, con);
                cmd4.Parameters.AddWithValue("@1", tbStepName4.Text);
                cmd4.Parameters.AddWithValue("@2", tbTimeDependentStep4.Text);
                cmd4.Parameters.AddWithValue("@3", tbProcessTime4.Text);
                cmd4.Parameters.AddWithValue("@4", tbProcessPressure4.Text);
                cmd4.Parameters.AddWithValue("@5", tbProcessPressurePercent4.Text);
                cmd4.Parameters.AddWithValue("@6", tbApcSetpointPosition4.Text);
                cmd4.Parameters.AddWithValue("@7", cmbApcMode4.Text);
                cmd4.Parameters.AddWithValue("@8", cmbActivePressureSensor4.Text);
                cmd4.Parameters.AddWithValue("@9", tbSourcePower4.Text);
                cmd4.Parameters.AddWithValue("@10", tbSoursePowerPercent4.Text);
                cmd4.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@13", cmbSourceRFControlMode4.Text);
                cmd4.Parameters.AddWithValue("@14", tbPlatenPower4.Text);
                cmd4.Parameters.AddWithValue("@15", tbPlatenPowerPercent4.Text);
                cmd4.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust4.Text);
                cmd4.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent4.Text);
                cmd4.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent4.Text);
                cmd4.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor4.Text);
                cmd4.Parameters.AddWithValue("@22", cmbPlatenRFControlMode4.Text);
                cmd4.Parameters.AddWithValue("@23", tbHeliumPressure4.Text);
                cmd4.Parameters.AddWithValue("@24", tbHeliumPressurePercent4.Text);
                cmd4.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel4.Text);
                cmd4.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel4.Text);
                cmd4.Parameters.AddWithValue("@27", cmbGasLineConfig4.Text);
                cmd4.Parameters.AddWithValue("@28", tbArgon4.Text);
                cmd4.Parameters.AddWithValue("@29", tbArgonPercent4.Text);
                cmd4.Parameters.AddWithValue("@30", tbNitrogen4.Text);
                cmd4.Parameters.AddWithValue("@31", tbNitrogenPercent4.Text);
                cmd4.Parameters.AddWithValue("@32", tbOxygen4.Text);
                cmd4.Parameters.AddWithValue("@33", tbOxygenPercent4.Text);
                cmd4.Parameters.AddWithValue("@34", tbOxygen1_4.Text);
                cmd4.Parameters.AddWithValue("@35", tbOxygen1Percent4.Text);
                cmd4.Parameters.AddWithValue("@36", tbCHF3_4.Text);
                cmd4.Parameters.AddWithValue("@37", tbCHF3Percent4.Text);
                cmd4.Parameters.AddWithValue("@38", tbSF6_4.Text);
                cmd4.Parameters.AddWithValue("@39", tbSF6Percent4.Text);
                cmd4.Parameters.AddWithValue("@40", tbBCI3_4.Text);
                cmd4.Parameters.AddWithValue("@41", tbBCI3Percent4.Text);
                cmd4.Parameters.AddWithValue("@42", _tbCI2_4.Text);
                cmd4.Parameters.AddWithValue("@43", _tbCI2Percent4.Text);
                cmd4.Parameters.AddWithValue("@id", lblid4.Text);
                cmd4.ExecuteNonQuery();

                SqlCommand cmd5 = new SqlCommand(strSQL1, con);

                cmd5.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
                cmd5.Parameters.AddWithValue("@NewstepName", tbStepName5.Text);
                cmd5.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessTime", tbProcessTime5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition5.Text);
                cmd5.Parameters.AddWithValue("@NewAPCMode", cmbApcMode5.Text);
                cmd5.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor5.Text);
                cmd5.Parameters.AddWithValue("@NewSoursePower", tbSourcePower5.Text);
                cmd5.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel5.Text);
                cmd5.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig5.Text);
                cmd5.Parameters.AddWithValue("@NewArgon", tbArgon5.Text);
                cmd5.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewNitrogen", tbNitrogen5.Text);
                cmd5.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen", tbOxygen5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_4.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewCHF3", tbCHF3_5.Text);
                cmd5.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewSF6", tbSF6_5.Text);
                cmd5.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewBCI3", tbBCI3_5.Text);
                cmd5.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewCI2", _tbCI2_5.Text);
                cmd5.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent5.Text);

                cmd5.ExecuteNonQuery();


            }

            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text != "no" && lblid2.Text != "no")//lblid3 insert 2 筆
            {

                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbStepName3.Text);
                cmd3.Parameters.AddWithValue("@2", tbTimeDependentStep3.Text);
                cmd3.Parameters.AddWithValue("@3", tbProcessTime3.Text);
                cmd3.Parameters.AddWithValue("@4", tbProcessPressure3.Text);
                cmd3.Parameters.AddWithValue("@5", tbProcessPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@6", tbApcSetpointPosition3.Text);
                cmd3.Parameters.AddWithValue("@7", cmbApcMode3.Text);
                cmd3.Parameters.AddWithValue("@8", cmbActivePressureSensor3.Text);
                cmd3.Parameters.AddWithValue("@9", tbSourcePower3.Text);
                cmd3.Parameters.AddWithValue("@10", tbSoursePowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@13", cmbSourceRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@14", tbPlatenPower3.Text);
                cmd3.Parameters.AddWithValue("@15", tbPlatenPowerPercent3.Text);
                cmd3.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust3.Text);
                cmd3.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent3.Text);
                cmd3.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor3.Text);
                cmd3.Parameters.AddWithValue("@22", cmbPlatenRFControlMode3.Text);
                cmd3.Parameters.AddWithValue("@23", tbHeliumPressure3.Text);
                cmd3.Parameters.AddWithValue("@24", tbHeliumPressurePercent3.Text);
                cmd3.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel3.Text);
                cmd3.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel3.Text);
                cmd3.Parameters.AddWithValue("@27", cmbGasLineConfig3.Text);
                cmd3.Parameters.AddWithValue("@28", tbArgon3.Text);
                cmd3.Parameters.AddWithValue("@29", tbArgonPercent3.Text);
                cmd3.Parameters.AddWithValue("@30", tbNitrogen3.Text);
                cmd3.Parameters.AddWithValue("@31", tbNitrogenPercent3.Text);
                cmd3.Parameters.AddWithValue("@32", tbOxygen3.Text);
                cmd3.Parameters.AddWithValue("@33", tbOxygenPercent3.Text);
                cmd3.Parameters.AddWithValue("@34", tbOxygen1_3.Text);
                cmd3.Parameters.AddWithValue("@35", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@36", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@37", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@38", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@39", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@40", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@41", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@42", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@43", _tbCI2Percent3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);
                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                cmd4.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd4.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewCHF3", tbCHF3_4.Text);
                cmd4.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewSF6", tbSF6_4.Text);
                cmd4.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewBCI3", tbBCI3_4.Text);
                cmd4.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewCI2", _tbCI2_4.Text);
                cmd4.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent4.Text);

                cmd4.ExecuteNonQuery();





                SqlCommand cmd5 = new SqlCommand(strSQL1, con);

                cmd5.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
                cmd5.Parameters.AddWithValue("@NewstepName", tbStepName5.Text);
                cmd5.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessTime", tbProcessTime5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition5.Text);
                cmd5.Parameters.AddWithValue("@NewAPCMode", cmbApcMode5.Text);
                cmd5.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor5.Text);
                cmd5.Parameters.AddWithValue("@NewSoursePower", tbSourcePower5.Text);
                cmd5.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel5.Text);
                cmd5.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig5.Text);
                cmd5.Parameters.AddWithValue("@NewArgon", tbArgon5.Text);
                cmd5.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewNitrogen", tbNitrogen5.Text);
                cmd5.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen", tbOxygen5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_4.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewCHF3", tbCHF3_5.Text);
                cmd5.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewSF6", tbSF6_5.Text);
                cmd5.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewBCI3", tbBCI3_5.Text);
                cmd5.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewCI2", _tbCI2_5.Text);
                cmd5.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent5.Text);

                cmd5.ExecuteNonQuery();


            }
            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text != "no")//lblid2 insert 3 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbStepName2.Text);
                cmd2.Parameters.AddWithValue("@2", tbTimeDependentStep2.Text);
                cmd2.Parameters.AddWithValue("@3", tbProcessTime2.Text);
                cmd2.Parameters.AddWithValue("@4", tbProcessPressure2.Text);
                cmd2.Parameters.AddWithValue("@5", tbProcessPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@6", tbApcSetpointPosition2.Text);
                cmd2.Parameters.AddWithValue("@7", cmbApcMode2.Text);
                cmd2.Parameters.AddWithValue("@8", cmbActivePressureSensor2.Text);
                cmd2.Parameters.AddWithValue("@9", tbSourcePower2.Text);
                cmd2.Parameters.AddWithValue("@10", tbSoursePowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@13", cmbSourceRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@14", tbPlatenPower2.Text);
                cmd2.Parameters.AddWithValue("@15", tbPlatenPowerPercent2.Text);
                cmd2.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust2.Text);
                cmd2.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent2.Text);
                cmd2.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor2.Text);
                cmd2.Parameters.AddWithValue("@22", cmbPlatenRFControlMode2.Text);
                cmd2.Parameters.AddWithValue("@23", tbHeliumPressure2.Text);
                cmd2.Parameters.AddWithValue("@24", tbHeliumPressurePercent2.Text);
                cmd2.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel2.Text);
                cmd2.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel2.Text);
                cmd2.Parameters.AddWithValue("@27", cmbGasLineConfig2.Text);
                cmd2.Parameters.AddWithValue("@28", tbArgon2.Text);
                cmd2.Parameters.AddWithValue("@29", tbArgonPercent2.Text);
                cmd2.Parameters.AddWithValue("@30", tbNitrogen2.Text);
                cmd2.Parameters.AddWithValue("@31", tbNitrogenPercent2.Text);
                cmd2.Parameters.AddWithValue("@32", tbOxygen2.Text);
                cmd2.Parameters.AddWithValue("@33", tbOxygenPercent2.Text);
                cmd2.Parameters.AddWithValue("@34", tbOxygen1_2.Text);
                cmd2.Parameters.AddWithValue("@35", tbOxygen1Percent2.Text);
                cmd2.Parameters.AddWithValue("@36", tbCHF3_2.Text);
                cmd2.Parameters.AddWithValue("@37", tbCHF3Percent2.Text);
                cmd2.Parameters.AddWithValue("@38", tbSF6_2.Text);
                cmd2.Parameters.AddWithValue("@39", tbSF6Percent2.Text);
                cmd2.Parameters.AddWithValue("@40", tbBCI3_2.Text);
                cmd2.Parameters.AddWithValue("@41", tbBCI3Percent2.Text);
                cmd2.Parameters.AddWithValue("@42", _tbCI2_2.Text);
                cmd2.Parameters.AddWithValue("@43", _tbCI2Percent2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(strSQL1, con);

                cmd3.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd3.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent3.Text);

                cmd3.ExecuteNonQuery();




                SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                cmd4.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd4.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewCHF3", tbCHF3_4.Text);
                cmd4.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewSF6", tbSF6_4.Text);
                cmd4.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewBCI3", tbBCI3_4.Text);
                cmd4.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewCI2", _tbCI2_4.Text);
                cmd4.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent4.Text);

                cmd4.ExecuteNonQuery();





                SqlCommand cmd5 = new SqlCommand(strSQL1, con);

                cmd5.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
                cmd5.Parameters.AddWithValue("@NewstepName", tbStepName5.Text);
                cmd5.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessTime", tbProcessTime5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition5.Text);
                cmd5.Parameters.AddWithValue("@NewAPCMode", cmbApcMode5.Text);
                cmd5.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor5.Text);
                cmd5.Parameters.AddWithValue("@NewSoursePower", tbSourcePower5.Text);
                cmd5.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel5.Text);
                cmd5.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig5.Text);
                cmd5.Parameters.AddWithValue("@NewArgon", tbArgon5.Text);
                cmd5.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewNitrogen", tbNitrogen5.Text);
                cmd5.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen", tbOxygen5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_4.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewCHF3", tbCHF3_5.Text);
                cmd5.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewSF6", tbSF6_5.Text);
                cmd5.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewBCI3", tbBCI3_5.Text);
                cmd5.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewCI2", _tbCI2_5.Text);
                cmd5.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent5.Text);

                cmd5.ExecuteNonQuery();



            }
            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text == "no")//lblid insert 4 筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@1", tbStepName.Text);
                cmd.Parameters.AddWithValue("@2", tbTimeDependentStep.Text);
                cmd.Parameters.AddWithValue("@3", tbProcessTime.Text);
                cmd.Parameters.AddWithValue("@4", tbProcessPressure.Text);
                cmd.Parameters.AddWithValue("@5", tbProcessPressurePercent.Text);
                cmd.Parameters.AddWithValue("@6", tbApcSetpointPosition.Text);
                cmd.Parameters.AddWithValue("@7", cmbApcMode.Text);
                cmd.Parameters.AddWithValue("@8", cmbActivePressureSensor.Text);
                cmd.Parameters.AddWithValue("@9", tbSourcePower.Text);
                cmd.Parameters.AddWithValue("@10", tbSoursePowerPercent.Text);
                cmd.Parameters.AddWithValue("@11", cmbSourceMUTuneCapacitor.Text);
                cmd.Parameters.AddWithValue("@12", cmbSourceMULoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@13", cmbSourceRFControlMode.Text);
                cmd.Parameters.AddWithValue("@14", tbPlatenPower.Text);
                cmd.Parameters.AddWithValue("@15", tbPlatenPowerPercent.Text);
                cmd.Parameters.AddWithValue("@16", cmbPlatenCapacitorAdjust.Text);
                cmd.Parameters.AddWithValue("@17", tbPlatenRFTuningCapacitor.Text);
                cmd.Parameters.AddWithValue("@18", tbPlatenRFTuningCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@19", tbPlatenRFLoadCapacitor.Text);
                cmd.Parameters.AddWithValue("@20", tbPlatenRFLoadCapacitorPercent.Text);
                cmd.Parameters.AddWithValue("@21", cmbPlatenRFPaddingCapacitor.Text);
                cmd.Parameters.AddWithValue("@22", cmbPlatenRFControlMode.Text);
                cmd.Parameters.AddWithValue("@23", tbHeliumPressure.Text);
                cmd.Parameters.AddWithValue("@24", tbHeliumPressurePercent.Text);
                cmd.Parameters.AddWithValue("@25", tbHeliumFlowWarningLevel.Text);
                cmd.Parameters.AddWithValue("@26", tbHeliumFlowFaultLevel.Text);
                cmd.Parameters.AddWithValue("@27", cmbGasLineConfig.Text);
                cmd.Parameters.AddWithValue("@28", tbArgon.Text);
                cmd.Parameters.AddWithValue("@29", tbArgonPercent.Text);
                cmd.Parameters.AddWithValue("@30", tbNitrogen.Text);
                cmd.Parameters.AddWithValue("@31", tbNitrogenPercent.Text);
                cmd.Parameters.AddWithValue("@32", tbOxygen.Text);
                cmd.Parameters.AddWithValue("@33", tbOxygenPercent.Text);
                cmd.Parameters.AddWithValue("@34", tbOxygen1.Text);
                cmd.Parameters.AddWithValue("@35", tbOxygen1Percent.Text);
                cmd.Parameters.AddWithValue("@36", tbCHF3.Text);
                cmd.Parameters.AddWithValue("@37", tbCHF3Percent.Text);
                cmd.Parameters.AddWithValue("@38", tbSF6.Text);
                cmd.Parameters.AddWithValue("@39", tbSF6Percent.Text);
                cmd.Parameters.AddWithValue("@40", tbBCI3.Text);
                cmd.Parameters.AddWithValue("@41", tbBCI3Percent.Text);
                cmd.Parameters.AddWithValue("@42", _tbCI2.Text);
                cmd.Parameters.AddWithValue("@43", _tbCI2Percent.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.ExecuteNonQuery();



                SqlCommand cmd2 = new SqlCommand(strSQL1, con);

                cmd2.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd2.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent2.Text);
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

                cmd3.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd3.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3", tbCHF3_3.Text);
                cmd3.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6", tbSF6_3.Text);
                cmd3.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3", tbBCI3_3.Text);
                cmd3.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2", _tbCI2_3.Text);
                cmd3.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent3.Text);

                cmd3.ExecuteNonQuery();




                SqlCommand cmd4 = new SqlCommand(strSQL1, con);

                cmd4.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
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
                cmd4.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewCHF3", tbCHF3_4.Text);
                cmd4.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewSF6", tbSF6_4.Text);
                cmd4.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewBCI3", tbBCI3_4.Text);
                cmd4.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent4.Text);
                cmd4.Parameters.AddWithValue("@NewCI2", _tbCI2_4.Text);
                cmd4.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent4.Text);

                cmd4.ExecuteNonQuery();





                SqlCommand cmd5 = new SqlCommand(strSQL1, con);

                cmd5.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
                cmd5.Parameters.AddWithValue("@NewstepName", tbStepName5.Text);
                cmd5.Parameters.AddWithValue("@NewTimeDependentStep", tbTimeDependentStep5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessTime", tbProcessTime5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessPressure", tbProcessPressure5.Text);
                cmd5.Parameters.AddWithValue("@NewProcessPressurePercent", tbProcessPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@NewAPCSetpointPosition", tbApcSetpointPosition5.Text);
                cmd5.Parameters.AddWithValue("@NewAPCMode", cmbApcMode5.Text);
                cmd5.Parameters.AddWithValue("@NewActivePressureSensor", cmbActivePressureSensor5.Text);
                cmd5.Parameters.AddWithValue("@NewSoursePower", tbSourcePower5.Text);
                cmd5.Parameters.AddWithValue("@NewSoursePowerPercent", tbSoursePowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseMUtunecapacitor", cmbSourceMUTuneCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseMUloadcapacitor", cmbSourceMULoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewSourseRFcontrolMode", cmbSourceRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenPower", tbPlatenPower5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenPowerpercent", tbPlatenPowerPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewplatenCapacitorAdjust", cmbPlatenCapacitorAdjust5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFTuningCapacitor", tbPlatenRFTuningCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFTuningCapacitorpercent", tbPlatenRFTuningCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFloadCapacitor", tbPlatenRFLoadCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFloadCapacitorpercent", tbPlatenRFLoadCapacitorPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewPlatenRFpaddingCapacitor", cmbPlatenRFPaddingCapacitor5.Text);
                cmd5.Parameters.AddWithValue("@NewplatenRFcontrolMode", cmbPlatenRFControlMode5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumpressure", tbHeliumPressure5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumpressurepercent", tbHeliumPressurePercent5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumFlowWarninglevel", tbHeliumFlowWarningLevel5.Text);
                cmd5.Parameters.AddWithValue("@NewHeliumFlowFaultlevel", tbHeliumFlowFaultLevel5.Text);
                cmd5.Parameters.AddWithValue("@NewGasLineConfig", cmbGasLineConfig5.Text);
                cmd5.Parameters.AddWithValue("@NewArgon", tbArgon5.Text);
                cmd5.Parameters.AddWithValue("@NewArgonpercent", tbArgonPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewNitrogen", tbNitrogen5.Text);
                cmd5.Parameters.AddWithValue("@NewNitrogenpercent", tbNitrogenPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen", tbOxygen5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygenpercent", tbOxygenPercent5.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen1", tbOxygen1_4.Text);
                cmd5.Parameters.AddWithValue("@NewOxygen1percent", tbOxygen1Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewCHF3", tbCHF3_5.Text);
                cmd5.Parameters.AddWithValue("@NewCHF3percent", tbCHF3Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewSF6", tbSF6_5.Text);
                cmd5.Parameters.AddWithValue("@NewSF6percent", tbSF6Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewBCI3", tbBCI3_5.Text);
                cmd5.Parameters.AddWithValue("@NewBCI3percent", tbBCI3Percent5.Text);
                cmd5.Parameters.AddWithValue("@NewCI2", _tbCI2_5.Text);
                cmd5.Parameters.AddWithValue("@NewCI2percent", _tbCI2Percent5.Text);

                cmd5.ExecuteNonQuery();




            }
          




            MessageBox.Show("Save successfully");
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
    }
}
