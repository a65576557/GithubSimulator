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
    public partial class Slotno : Form
    {
        private string msg;
        public Slotno()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            msg = textBox1.Text;


        }
        public string getmsg()
        {

            return msg ;
        }

        private void Slotno_Load(object sender, EventArgs e)
        {

        }
    }
}
