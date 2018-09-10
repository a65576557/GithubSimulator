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
    public partial class TM : Form
       
    {
       public Form1 form1 = new Form1();
        string button;
        public TM()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (button == "1")
            {
                form1.label4.BackColor = Color.LimeGreen;
                form1.lbltm.BackColor = Color.LimeGreen;
                form1.lbltm.Text = "going to idle";
                await Task.Delay(2000);
                form1.label4.BackColor = Color.Blue;
                form1.lbltm.BackColor = Color.Blue;
                form1.lbltm.Text = "Idle";

            }
        }

        private void btnidle_Click(object sender, EventArgs e)
        {
            button = "1";
        }

        private void TM_Load(object sender, EventArgs e)
        {

        }
    }
}
