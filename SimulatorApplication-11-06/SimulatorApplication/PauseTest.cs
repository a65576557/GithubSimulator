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
    public partial class PauseTest : Form
    {

        public Form1 form1 = new Form1();


        public PauseTest()
        {
            InitializeComponent();
        }

        private void PauseTest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.pauseSignal.Set();

        }
    }
}
