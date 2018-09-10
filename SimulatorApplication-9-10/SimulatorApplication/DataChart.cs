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
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulatorApplication
{
    public partial class DataChart : Form
    {
        SqlConnectionStringBuilder scsb;
        List<DateTime> Sec = new List<DateTime>();
        List<string> ValueMinimum = new List<string>();
        List<string> ValueMaximum = new List<string>();
        List<string> ValueAverage = new List<string>();

        public DataChart()
        {
            InitializeComponent();
        }

        public static DateTime DateParse(string date)
        {
            date = date.Trim();
            if (!string.IsNullOrEmpty(date))
                return DateTime.Parse(date, new System.Globalization.CultureInfo("en-GB"));
            return new DateTime();
        }







        private void DataChart_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from valueselection where parameter = @Newparameter and stepname = @Newstepname";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@Newparameter", FullMVs.parameter);
            cmd.Parameters.AddWithValue("@Newstepname", FullMVs.stepnamevalue);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {


               // Sec.Add(DateTime.Now);
                ValueMinimum.Add(reader["Minimum"].ToString());
                ValueMaximum.Add(reader["Maximum"].ToString());
                ValueAverage.Add(reader["Average"].ToString());
                Sec.Add((DateTime)reader["ValueDate"]);
            }

            /*    con.Close();

                con.Open();

                ////////////////////////////////////////////////////////////////////////get modulerecipe starttime

                string strSQL1 = "select * from modulerecipe where stepname = @1 and Noofrecipe = @2";
                SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                cmd1.Parameters.AddWithValue("@1", FullMVs.stepnamevalue);
                cmd1.Parameters.AddWithValue("@2", FullMVs.noofwafervalue);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    Sec.Add(DateTime.Parse(reader1["starttime"].ToString()));

                }
                */
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            chart1.Series.Clear();
            Series series1 = new Series();



            series1.XValueType = ChartValueType.DateTime;

            series1.Color = Color.Blue;

            series1.LegendText = "Value";
            series1.BorderWidth = 1;

            series1.MarkerBorderWidth = 3;
            series1.MarkerSize = 5;


            series1.Font = new System.Drawing.Font("微軟正黑體", 9);

            series1.ChartType = SeriesChartType.Line;

            series1.MarkerStyle = MarkerStyle.Circle;


            series1.IsValueShownAsLabel = true;
            for (int i = 0; i < Sec.Count; i++)
            {

                series1.Points.AddXY(Sec[i], ValueAverage[i]);
                
            }

            this.chart1.Series.Add(series1);
            this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm:ss";

            con.Close();
            Sec.Clear();
            ValueAverage.Clear();

        }
    }
}
