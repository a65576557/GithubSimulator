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
    public partial class FullMVs : Form
    {
        SqlConnectionStringBuilder scsb;
        List<string> listrecipename = new List<string>();
        List<string> listStepName = new List<string>();
        List<string> listStarted = new List<string>();
        List<string> listEnded = new List<string>();
        List<string> listparameter = new List<string>();
        List<string> listminimum = new List<string>();
        List<string> listmaxmum = new List<string>();
        List<string> listaverage = new List<string>();
        List<string> listunits = new List<string>();
        List<string> listWaferNo = new List<string>();
        List<string> listwaferstarttime = new List<string>();

        public static string stepnamevalue;
        public static string recipenamevalue;
        public static string noofwafervalue;
        public static string modulerecipevalue;
        public static string minimum;
        public static string maximum;
        public static string average;
        public static string parameter;

        public string noofwafer;
       public ListViewItem itm;
        public ListViewItem itm2;
        public FullMVs()
        {
            InitializeComponent();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            DataChart datachart = new DataChart();
            datachart.ShowDialog();
            
        }

        private void FullMVs_Load(object sender, EventArgs e)
        {
            ModuleSelection.FullRowSelect = true;
            WaferSelection.FullRowSelect = true;
            ValueSelection.FullRowSelect = true;
           
            ListViewItem itm1;
            ModuleSelection.View = View.Details;
            WaferSelection.View = View.Details;
            ValueSelection.View = View.Details;
           // DateTime startdatetime;
          //  DateTime.TryParse(DataLogger.strRecipeName,out startdatetime);

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            ModuleSelection.Columns.Add("Module Recipe",130);
            ModuleSelection.Columns.Add("Step Name", 120);
            ModuleSelection.Columns.Add("Started", 210);
            ModuleSelection.Columns.Add("Ended", 210);

            WaferSelection.Columns.Add("Wafer No",120);
            WaferSelection.Columns.Add("Start Time",200);
                    
            ValueSelection.Columns.Add("Parameter",150);
            ValueSelection.Columns.Add("Minimum",150);
            ValueSelection.Columns.Add("Maximum",150);
            ValueSelection.Columns.Add("Average", 150);
            ValueSelection.Columns.Add("Units", 150);

          /*  string strModuleRecipe = "select * from ModuleRecipe inner join cassettewafer on Modulerecipe.recipename = cassettewafer.waferrecipe where cassettewafer.cassetterecipename = @recipename";

            SqlCommand cmd = new SqlCommand(strModuleRecipe, con);
            cmd.Parameters.AddWithValue("@recipename",DataLogger.strRecipeName);
            SqlDataReader reader = cmd.ExecuteReader();

         /*   while (reader.Read())
            {
                listrecipename.Add(reader["RecipeName"].ToString());
                listStepName.Add(reader["StepName"].ToString());
                listStarted.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", reader["StartTime"]));
                listEnded.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", reader["EndTime"]));

                            }
          /*  for (int i = 0; i < listStepName.Count; i++)
            {
                itm = new ListViewItem(listrecipename[i]);
                itm.SubItems.Add(listStepName[i]);
                itm.SubItems.Add(listStarted[i]);
                itm.SubItems.Add(listEnded[i]);
                 ModuleSelection.Items.Add(itm);

            }*/
            con.Close();
            con.Open();
            string strwaferselection = "select * from waferselection where cassetterecipename = @waferrecipe and Logname = @Logname";
            SqlCommand cmdwaferselection = new SqlCommand(strwaferselection,con);
            cmdwaferselection.Parameters.AddWithValue("@waferrecipe", DataLogger.strRecipeName);
            cmdwaferselection.Parameters.AddWithValue("@Logname", DataLogger.strLogname);
            SqlDataReader waferselectionreader = cmdwaferselection.ExecuteReader();
            while (waferselectionreader.Read())
            {
                listWaferNo.Add(waferselectionreader["noofwafers"].ToString());
                // listwaferstarttime.Add(waferselectionreader[""].ToString());
                listwaferstarttime.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", waferselectionreader["StartTime"]));
            }
            //   string strwaferstarttime = "select * from ";

            for (int i = 0; i < listWaferNo.Count; i++)
            {
                itm1 = new ListViewItem(listWaferNo[i]);
                itm1.SubItems.Add(listwaferstarttime[i]);

                WaferSelection.Items.Add(itm1);

            }




        }

        private void WaferSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            noofwafer = WaferSelection.SelectedItems[0].SubItems[0].Text; 

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSQL = "select * from modulerecipe  where noofrecipe = @1 and Logname = @Logname ";
            //MessageBox.Show(noofwafer);

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@1", noofwafer);
            cmd.Parameters.AddWithValue("@Logname", DataLogger.strLogname);
         //   cmd.Parameters.AddWithValue("@2", DataLogger.strLogname);
            SqlDataReader reader = cmd.ExecuteReader();
       //    if (ModuleSelection.Items.Count == 0)
            {
                ModuleSelection.Items.Clear();
                listrecipename.Clear();
                listStepName.Clear();
                listStarted.Clear();
                listEnded.Clear();


                while (reader.Read())
                {

                    listrecipename.Add(reader["RecipeName"].ToString());
                    listStepName.Add(reader["StepName"].ToString());
                    listStarted.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", reader["StartTime"]));
                    listEnded.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", reader["EndTime"]));
                }
                for (int i = 0; i < listStepName.Count; i++)
                {
                    itm = new ListViewItem(listrecipename[i]);
                    itm.SubItems.Add(listStepName[i]);
                    itm.SubItems.Add(listStarted[i]);
                    itm.SubItems.Add(listEnded[i]);
                    ModuleSelection.Items.Add(itm);

                }
                listrecipename.Clear();
                listStepName.Clear();
                listStarted.Clear();
                listEnded.Clear();
            }
         /*  else
            {
                ModuleSelection.Items.Clear();
                listrecipename.Clear();
                listStepName.Clear();
                listStarted.Clear();
                listEnded.Clear();
                while (reader.Read())
                {
                    listrecipename.Add(reader["RecipeName"].ToString());
                    listStepName.Add(reader["StepName"].ToString());
                    listStarted.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", reader["StartTime"]));
                    listEnded.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", reader["EndTime"]));
                }
                for (int i = 0; i < listStepName.Count; i++)
                {
                    itm = new ListViewItem(listrecipename[i]);
                    itm.SubItems.Add(listStepName[i]);
                    itm.SubItems.Add(listStarted[i]);
                    itm.SubItems.Add(listEnded[i]);
                    ModuleSelection.Items.Add(itm);

                }
                listrecipename.Clear();
                listStepName.Clear();
                listStarted.Clear();
                listEnded.Clear();


            }*/
        }

        private void ModuleSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
             stepnamevalue = ModuleSelection.SelectedItems[0].SubItems[1].Text;
            modulerecipevalue = ModuleSelection.SelectedItems[0].SubItems[0].Text;
            recipenamevalue = ModuleSelection.SelectedItems[0].SubItems[0].Text;
            noofwafervalue = WaferSelection.SelectedItems[0].SubItems[0].Text;

            //  MessageBox.Show(stepnamevalue);

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string Strsearchvalue = "select * from valueselection where stepname like @1 and recipename like @2 and noofrecipe like @3";
            SqlCommand cmd = new SqlCommand(Strsearchvalue, con);
            cmd.Parameters.AddWithValue("@1", stepnamevalue);
            cmd.Parameters.AddWithValue("@2", modulerecipevalue);
            cmd.Parameters.AddWithValue("@3", noofwafer);
            SqlDataReader reader = cmd.ExecuteReader();
            if (ValueSelection.Items.Count == 0)
            {
                while (reader.Read())

                {
                    listparameter.Add(reader["parameter"].ToString());
                    listminimum.Add(reader["Minimum"].ToString());
                    listmaxmum.Add(reader["Maximum"].ToString());
                    listaverage.Add(reader["average"].ToString());
                    listunits.Add(reader["units"].ToString());



                }
                for (int i = 0; i < listparameter.Count; i++)
                {
                    itm2 = new ListViewItem(listparameter[i]);
                    itm2.SubItems.Add(listminimum[i]);
                    itm2.SubItems.Add(listmaxmum[i]);
                    itm2.SubItems.Add(listaverage[i]);
                    itm2.SubItems.Add(listunits[i]);
                    ValueSelection.Items.Add(itm2);

                }
            }
            else {

                ValueSelection.Items.Clear();
                listparameter.Clear();
                listminimum.Clear();
                listmaxmum.Clear();
                listaverage.Clear();
                listunits.Clear();

                while (reader.Read())

                {


                    listparameter.Add(reader["parameter"].ToString());
                    listminimum.Add(reader["Minimum"].ToString());
                    listmaxmum.Add(reader["Maximum"].ToString());
                    listaverage.Add(reader["average"].ToString());
                    listunits.Add(reader["units"].ToString());



                }
                for (int i = 0; i < listparameter.Count; i++)
                {

                    itm2 = new ListViewItem(listparameter[i]);
                    itm2.SubItems.Add(listminimum[i]);
                    itm2.SubItems.Add(listmaxmum[i]);
                    itm2.SubItems.Add(listaverage[i]);
                    itm2.SubItems.Add(listunits[i]);
                    ValueSelection.Items.Add(itm2);

                }




            }

            listparameter.Clear();
            listminimum.Clear();
            listmaxmum.Clear();
            listaverage.Clear();
            listunits.Clear();
        }

        private void ValueSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameter = ValueSelection.SelectedItems[0].SubItems[0].Text;
            minimum = ValueSelection.SelectedItems[0].SubItems[1].Text;
            maximum = ValueSelection.SelectedItems[0].SubItems[2].Text;
            average = ValueSelection.SelectedItems[0].SubItems[3].Text;

           // MessageBox.Show(parameter + "+" + minimum + "+" + maximum + "+" + average);





        }
    }
}
