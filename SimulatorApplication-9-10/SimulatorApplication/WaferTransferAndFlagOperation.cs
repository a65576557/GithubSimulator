using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorApplication
{
    public partial class Wafer_Transfer_and_Flag_Operation : Form
    {
        public Wafer_Transfer_and_Flag_Operation()
        {
            InitializeComponent();
        }
        public static string waferno;
        public Form1 form1 = new Form1();
        private void btnMapWafer_Click(object sender, EventArgs e)
        {
            Slotno slotno = new Slotno();
            slotno.ShowDialog();
            waferno = slotno.getmsg();
            
        }
        public string strcombobox;

        private void Wafer_Transfer_and_Flag_Operation_Load(object sender, EventArgs e)
        {
            lblSourceStation.Text = "CSA";
           
            
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            MessageBox.Show(strcombobox);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strcombobox = comboBox1.SelectedItem.ToString();
        }
    }
}
