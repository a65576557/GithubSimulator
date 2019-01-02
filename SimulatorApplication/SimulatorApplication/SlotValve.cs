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
    public partial class SlotValve : Form
    {
        public Form1 form1 = new Form1();
        public SlotValve()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "APM Slot Valve is closed")
            {
                form1.picSV.Visible = false;
                label1.Text = "APM Slot Valve is open";
                button1.Text = "Close";
            }
            else
            {
                form1.picSV.Visible = true;
                label1.Text = "APM Slot Valve is closed";
                button1.Text = "Open";
            }
        }

        private void SlotValve_Load(object sender, EventArgs e)
        {
            if (form1.picSV.Visible == true)
            {
                label1.Text = "APM Slot Valve is closed";
                
            }
            else
                label1.Text = "APM Slot Valve is open";

        }
    }
}
