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
    public partial class StateControlOfVCH : Form
    {
        public static string MsgManual;
        public static string MsgAutomatic;
        public StateControlOfVCH()
        {
            InitializeComponent();
        }
        public Form1 form1 = new Form1();
        private void StateControlOfVCH_Load(object sender, EventArgs e)
        {

            // btnManual.Enabled = false;
            btnManual.Tag = MsgManual;
            btnAutomatic.Tag = MsgAutomatic;

            if (btnManual.Tag.ToString() == "false")
                lblCurrentState.Text = "The current state of VCH is manual, aborted";
            if(btnAutomatic.Tag.ToString()=="false")
                lblCurrentState.Text = "The current state of VCH is Automatic, aborted";

        }

        private void button1_Click(object sender, EventArgs e)   
        {

            btnManual.Tag = MsgManual;
            btnAutomatic.Tag = MsgAutomatic;

            if (btnManual.Tag.ToString() == "false" && btnAutomatic.Tag.ToString() == "true")
            {
                form1.btnRobotAction.Visible = true;
                //  form1.btnChamberControl.Visible = true;
                form1.picMain.Enabled = true;
                form1.btnendeffector.Visible = true;

                form1.picSV.Enabled = true;

            //    form1.btnCentralizeControl.Visible = true;
               // form1.btnCassetteControl.Visible = true;
                form1.btnendeffector.Visible = true;

                form1.btnVCH.Text = "Control Mode: Manual";

            }

            else if (btnManual.Tag.ToString()=="true"&&btnAutomatic.Tag.ToString()=="false")
            {
                form1.btnendeffector.Visible = false;
                form1.picMain.Enabled = false;
                form1.btnRobotAction.Visible = false;
           //     form1.btnChamberControl.Visible = false;

                form1.picSV.Enabled = false;

            //    form1.btnCentralizeControl.Visible = false;
              //  form1.btnCassetteControl.Visible = false;

                form1.btnVCH.Text = "Control Mode: Automatic";

            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            btnManual.Enabled = false;
            btnManual.Tag = "false";
            MsgManual = btnManual.Tag.ToString();

            btnAutomatic.Enabled = true;
            
            btnAutomatic.Tag = "true";
            MsgAutomatic = btnAutomatic.Tag.ToString();

        /*    form1.btnRobotAction.Visible = true;
            form1.btnChamberControl.Visible = true;
           
            form1.picSV.Enabled = true;

            form1.btnCentralizeControl.Visible = true;
            form1.btnCassetteControl.Visible = true;

            form1.btnVCH.Text = "Control Mode: Manual";*/

        }

        private void btnAutomatic_Click(object sender, EventArgs e)
        {



            btnAutomatic.Enabled = false;
            btnAutomatic.Tag = "false";
            MsgAutomatic = btnAutomatic.Tag.ToString();
            btnManual.Enabled = true;
            btnManual.Tag = "true";
            MsgManual = btnManual.Tag.ToString();



        /*    form1.btnRobotAction.Visible = false;
            form1.btnChamberControl.Visible = false;

            form1.picSV.Enabled = false;

            form1.btnCentralizeControl.Visible = false;
            form1.btnCassetteControl.Visible = false;

            form1.btnVCH.Text = "Control Mode: Automatic";*/
        }
   
    }
}
