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
    public partial class DataLogger : Form
    {
        SqlConnectionStringBuilder scsb;
        List<string> logname = new List<string>();
        List<string> cassetterecipe = new List<string>();
        List<string> starttime = new List<string>();
        public static string strRecipeName;
        public static string strLogname;


        public DataLogger()
        {
            InitializeComponent();
        }



        private void DataLogger_Load(object sender, EventArgs e)
        {
            this.listView1.Clear();
            this.listView1.FullRowSelect = true;

          //  this.listView1.Items[0].Focused = true;
            //this.listView1.Items[0].Selected = true;

            

            listView1.View = View.Details;
            ListViewItem itm;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            listView1.Columns.Add("Log ID",150);
            listView1.Columns.Add("Cassette Recipe",150);
            listView1.Columns.Add("Start Time",200);
           
           


            string strSQL = "select * from DataLogger";
            SqlCommand cmd = new SqlCommand(strSQL,con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                logname.Add(reader["logname"].ToString());
              
               cassetterecipe.Add(reader["cassetterecipename"].ToString());
                starttime.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", reader["starttime"]));
                

            }
            
            for (int i = 0; i < logname.Count; i++)
            {
                itm = new ListViewItem(logname[i]);
                itm.SubItems.Add(cassetterecipe[i]);
                itm.SubItems.Add(starttime[i]);
                listView1.Items.Add(itm);
                
            }
            
           
        }

        private void btnMVs_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].SubItems[1].Text.Length > 0)
            {
                strRecipeName = listView1.SelectedItems[0].SubItems[1].Text;
                strLogname = listView1.SelectedItems[0].SubItems[0].Text;
            }
            else

                MessageBox.Show("please select item");

            if (strRecipeName.Length != 0)

            {
                FullMVs datachart = new FullMVs();
                datachart.ShowDialog();
            }
            else
                MessageBox.Show("please select item");
            }


        }
    }


