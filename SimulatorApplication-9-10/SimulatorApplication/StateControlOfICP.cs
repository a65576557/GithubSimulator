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
    public partial class StateControlOfICP : Form
    {
        public static string MsgManual;
        public static string MsgAutomatic;
        public StateControlOfICP()
        {
            InitializeComponent();
        }

        private void StateControlOfICP_Load(object sender, EventArgs e)
        {
            btnManual.Tag = MsgManual;
            btnAutomatic.Tag = MsgAutomatic;

            if (btnManual.Tag.ToString() == "false")
                lblState.Text = "The current state of VCH is manual, aborted";
            if (btnAutomatic.Tag.ToString() == "false")
                lblState.Text = "The current state of VCH is Automatic, aborted";




        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            btnManual.Enabled = false;
            btnManual.Tag = "false";
            MsgManual = btnManual.Tag.ToString();

            btnAutomatic.Enabled = true;

            btnAutomatic.Tag = "true";
            MsgAutomatic = btnAutomatic.Tag.ToString();
        }

        private void btnAutomatic_Click(object sender, EventArgs e)
        {
            btnAutomatic.Enabled = false;
            btnAutomatic.Tag = "false";
            MsgAutomatic = btnAutomatic.Tag.ToString();
            btnManual.Enabled = true;
            btnManual.Tag = "true";
            MsgManual = btnManual.Tag.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            btnManual.Tag = MsgManual;
            btnAutomatic.Tag = MsgAutomatic;
        }
    }
}
