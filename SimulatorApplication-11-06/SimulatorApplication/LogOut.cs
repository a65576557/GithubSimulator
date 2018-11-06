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
    public partial class LogOut : Form
    {
        public Form1 form1 = new Form1();
        public LogOut()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.button1.Enabled = false;
            form1.btnVCH.Enabled = false;
            form1.btnAPM.Enabled = false;
            form1.btntm.Enabled = false;


            form1.button7.Enabled = false;
            form1.btnRecipe.Enabled = false;
            form1.btnEventLog.Enabled = false;
            form1.btnLogger.Enabled = false;
            form1.btnconfig.Enabled = false;

          //  form1.button3.Enabled = false;
          //  form1.button4.Enabled = false;
          //  form1.button5.Enabled = false;


            form1.btnLogIn.Tag = "LogIn";
            form1.lbllog.Text = "System: Monitor";
        }

        private void LogOut_Load(object sender, EventArgs e)
        {

        }
    }
}
