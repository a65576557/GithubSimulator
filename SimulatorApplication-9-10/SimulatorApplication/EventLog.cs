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
    public partial class EventLog : Form
    {
        public EventLog()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder scsb;

        List<string> date = new List<string>();
        List<string> eventlog = new List<string>();
        List<string> information = new List<string>();

        private void EventLog_Load(object sender, EventArgs e)
        {
            ListViewItem item;
            listView1.View = View.Details;
            listView1.Columns.Add("Date",170);
            listView1.Columns.Add("Event", 180);
            listView1.Columns.Add("Infomation", 350);

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();

            string strSQL = "select * from EventLog";

            SqlCommand cmd = new SqlCommand(strSQL, con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {



                date.Add(string.Format("{0:yyyy/MM/dd hh:mm:ss}", reader["Date"]));
                eventlog.Add(reader["Event"].ToString());
                information.Add(reader["Info"].ToString());


            }
            for (int i = 0; i < date.Count(); i++)
            {
                item = new ListViewItem(date[i]);
                item.SubItems.Add(eventlog[i]);
                item.SubItems.Add(information[i]);
                listView1.Items.Add(item);

            }


        }
    }
}
