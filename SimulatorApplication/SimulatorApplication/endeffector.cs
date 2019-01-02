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
    public partial class endeffector : Form
    {
        public endeffector()
        {
            InitializeComponent();
        }

        public delegate void OvalVisible(bool visible);
        public OvalVisible ovalvisible;


        public Form1 form1 = new Form1();
    //    public ActionArm actionArm = new ActionArm();
        public string str;
        public static string no; /////////Destination No
        public string no1;//////////source No
        public string str1;
        bool visible = false;
        public static string straling;

        private void endeffector_Load(object sender, EventArgs e)
        {
           // form1.picwafer.Image.Tag = "wafer";
            // cmbalign.Text = "None";
            if (straling!=null)

            {
                cmbalign.Text = straling;
            }
            else
            {
                cmbalign.Text = "None";
            }
            radiomapwafer.Checked = true;
            radiononalign.Checked = true;
        }

        private void radioclearwafer_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void radiotransfer_CheckedChanged(object sender, EventArgs e)
        {
          //  radiowithalign.Visible = true;
           // radiononalign.Visible = true;
           



            if (form1.lblwafer.Visible == true||form1.lblwaferAPM.Visible==true||form1.lblwaferright.Visible==true||form1.lblwaferup.Visible==true||form1.lblwaferaligner.Visible==true)
            {
                tbSourceSlotno.Text = form1.lblwafer.Text.Remove(0, 1);
                tbDestinationSlotno.Text = form1.lblwafer.Text.Remove(0, 1);
                
            }
            



            if (form1.lblwafer.Visible == true)
            {
                cmbSource.Text = "Arm";
            }
            if (form1.lblwaferAPM.Visible == true)
            {
                cmbSource.Text = "APM";
            }
            if (form1.lblwaferaligner.Visible == true)
            {
                cmbSource.Text = "Aligner";
            }
               if (form1.picwafer.Image.Tag != null)
                {
                    for (int i = 1; i <= 25; i++)
                    {
                        string waferno;
                        waferno = i.ToString();
                        if (form1.picwafer.Image.Tag.ToString() == waferno)
                        {
                            cmbSource.Text = "CSA";
                        }
                        tbSourceSlotno.Text = form1.picwafer.Image.Tag.ToString();
                        tbDestinationSlotno.Text = form1.picwafer.Image.Tag.ToString();
                    }

                }
          
            
            /*    if (form1.picwafer.Image.Tag.ToString() != "wafer")
                {
                    cmbSource.Text = "CSA";
                    tbSourceSlotno.Text = form1.picwafer.Image.Tag.ToString();
                    tbDestinationSlotno.Text = form1.picwafer.Image.Tag.ToString();
                }*/
            

            radiomapwafer.Visible = false;
            radioclearwafer.Visible = false;
            cmbSource.Enabled = true;
            tbSourceSlotno.Enabled = true;
        }

        private void radiomapwafer_CheckedChanged(object sender, EventArgs e)
        {
          


        }

        private void radioamp_CheckedChanged(object sender, EventArgs e)
        {
            radiowithalign.Visible = false;
            radiononalign.Visible = false;

            tbDestinationSlotno.Text = "";
            tbSourceSlotno.Text = "";
            radiomapwafer.Visible = true;
            radioclearwafer.Visible = true;

            cmbSource.Enabled = false;
            tbSourceSlotno.Enabled = false;

        }

        private  void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            str1 = cmbSource.SelectedItem.ToString();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {

            if (radioamp.Checked == true && radiomapwafer.Checked == true)   ////////////////////////////////////// map wafer
            {
               

                if (str == "Arm")
                {
                    //form1.newcontainer.Visible = true;
                    //form1.ovalShape1.Parent.Parent;
                    form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                    form1.picMain.Image.Tag = "picrobotArmWafer";
                    no = tbDestinationSlotno.Text;
                  //  form1.ovalShape1.Visible = true;
                    form1.lblwafer.Visible = true;
                    form1.lblwafer.Text = "A" + no;
                    if (no == "1")
                    {
                        form1.picWafer1.Visible = false;
                    }
                    if (no == "2")
                    {
                        form1.picWafer2.Visible = false;
                    }



                    //  form1.ovalShapeAPM.Left += 0;
                    //  form1.ovalShapeAPM.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
                    // form1.ovalShapeAPM.SendToBack();
                    //   form1.ovalShapeAPM.Visible = false;
                    //  form1.lblwaferAPM.Visible = false;


                }

                if (str == "APM")
                {
                   
                  //  form1.APMcontainer.Visible = true;
                    no = tbDestinationSlotno.Text;
                    no1 = tbSourceSlotno.Text;
                    //  form1.ovalShape1.Parent.Parent = form1.picMain;
                    form1.picMain.Image = Properties.Resources.picwaferinAPMHome;
                    form1.picMain.Image.Tag = "picwaferinAPMHome";
                    //  form1.lblwafer.Visible = true;
                    //   form1.ovalShape1.Top -= 300;
                    //   form1.lblwafer.Top -= 300;
                    //   form1.ovalShape1.Left -= 7;
                    //    form1.lblwafer.Left -= 7;
                    form1.lblwaferAPM.Visible = true;
                   
                  //  form1.ovalShapeAPM.Visible = true;
                    //  form1.ovalShapeAPM.Parent.Parent = form1.picMain;
                  //  form1.ovalShapeAPM.BringToFront();
                   // form1.lblwaferAPM.Visible = true;
                    form1.lblwaferAPM.Text = "A" + no;
                    form1.lblwafer.Text = "A" + no;

                }
                if (str == "Aligner")
                {
                    no = tbDestinationSlotno.Text;
                    //  form1.ovalShape1.Visible = true;
                    //form1.lblwafer.Visible = true;
                    //form1.ovalShape1.Top -= 80;
                    //form1.lblwafer.Top -= 80;
                    //form1.ovalShape1.Left += 220;
                    //form1.lblwafer.Left += 220;
                    //form1.lblwafer.Text = "A" + no;
                    // form1.picMain.Image = Properties.Resources.
                    form1.picMain.Image = Properties.Resources.picrobotwaferinAlignerHome;
                    form1.picMain.Image.Tag = "picrobotwaferinAlignerHome";
                    form1.lblwaferaligner.Visible = true;
                    form1.lblwaferaligner.Text = "A" + no;
                    form1.lblwafer.Text = "A" + no;
                }
                if (str == "CSA")
                {
                   
                    no = tbDestinationSlotno.Text;
                    switch (no)
                    {
                        case "1":
                            form1.picwafer.Image = Properties.Resources.wafermapA1;
                            form1.picwafer.Image.Tag = "1";
                            form1.lblwafer.Text = "A" + "1";
                            break;

                        case "2":
                            form1.picwafer.Image = Properties.Resources.wafermapA2;
                            form1.picwafer.Image.Tag = "2";
                            form1.lblwafer.Text = "A" + "2";

                            break;

                        case "3":
                            form1.picwafer.Image = Properties.Resources.wafermapA3;
                            form1.picwafer.Image.Tag = "3";
                            form1.lblwafer.Text = "A" + "3";
                            break;
                        case "4":
                            form1.picwafer.Image = Properties.Resources.wafermapA4;
                            form1.picwafer.Image.Tag = "4";
                            form1.lblwafer.Text = "A" + "4";
                            break;
                        case "5":
                            form1.picwafer.Image = Properties.Resources.wafermapA5;
                            form1.picwafer.Image.Tag = "5";
                            form1.lblwafer.Text = "A" + "5";
                            break;
                        case "6":
                            form1.picwafer.Image = Properties.Resources.wafermapA6;
                            form1.picwafer.Image.Tag = "6";
                            form1.lblwafer.Text = "A" + "6";
                            break;
                        case "7":
                            form1.picwafer.Image = Properties.Resources.wafermapA7;
                            form1.picwafer.Image.Tag = "7";
                            form1.lblwafer.Text = "A" + "7";
                            break;
                        case "8":
                            form1.picwafer.Image = Properties.Resources.wafermapA8;
                            form1.picwafer.Image.Tag = "8";
                            form1.lblwafer.Text = "A" + "8";
                            break;
                        case "9":
                            form1.picwafer.Image = Properties.Resources.wafermapA9;
                            form1.picwafer.Image.Tag = "9";
                            form1.lblwafer.Text = "A" + "9";
                            break;
                        case "10":
                            form1.picwafer.Image = Properties.Resources.wafermapA10;
                            form1.picwafer.Image.Tag = "10";
                            form1.lblwafer.Text = "A" + "10";
                            break;
                        case "11":
                            form1.picwafer.Image = Properties.Resources.wafermapA11;
                            form1.picwafer.Image.Tag = "11";
                            form1.lblwafer.Text = "A" + "11";
                            break;
                        case "12":
                            form1.picwafer.Image = Properties.Resources.wafermapA12;
                            form1.picwafer.Image.Tag = "12";
                            form1.lblwafer.Text = "A" + "12";
                            break;
                        case "13":
                            form1.picwafer.Image = Properties.Resources.wafermapA13;
                            form1.picwafer.Image.Tag = "13";
                            form1.lblwafer.Text = "A" + "13";
                            break;
                        case "14":
                            form1.picwafer.Image = Properties.Resources.wafermapA14;
                            form1.picwafer.Image.Tag = "14";
                            form1.lblwafer.Text = "A" + "14";
                            break;
                        case "15":
                            form1.picwafer.Image = Properties.Resources.wafermapA15;
                            form1.picwafer.Image.Tag = "15";
                            form1.lblwafer.Text = "A" + "15";
                            break;
                        case "16":
                            form1.picwafer.Image = Properties.Resources.wafermapA16;
                            form1.picwafer.Image.Tag = "16";
                            form1.lblwafer.Text = "A" + "16";
                            break;
                        case "17":
                            form1.picwafer.Image = Properties.Resources.wafermapA17;
                            form1.picwafer.Image.Tag = "17";
                            form1.lblwafer.Text = "A" + "17";
                            break;
                        case "18":
                            form1.picwafer.Image = Properties.Resources.wafermapA18;
                            form1.picwafer.Image.Tag = "18";
                            form1.lblwafer.Text = "A" + "18";
                            break;
                        case "19":
                            form1.picwafer.Image = Properties.Resources.wafermapA19;
                            form1.picwafer.Image.Tag = "19";
                            form1.lblwafer.Text = "A" + "19";
                            break;
                        case "20":
                            form1.picwafer.Image = Properties.Resources.wafermapA20;
                            form1.picwafer.Image.Tag = "20";
                            form1.lblwafer.Text = "A" + "20";
                            break;
                        case "21":
                            form1.picwafer.Image = Properties.Resources.wafermapA21;
                            form1.picwafer.Image.Tag = "21";
                            form1.lblwafer.Text = "A" + "21";
                            break;
                        case "22":
                            form1.picwafer.Image = Properties.Resources.wafermapA22;
                            form1.picwafer.Image.Tag = "22";
                            form1.lblwafer.Text = "A" + "22";
                            break;
                        case "23":
                            form1.picwafer.Image = Properties.Resources.wafermapA23;
                            form1.picwafer.Image.Tag = "23";
                            form1.lblwafer.Text = "A" + "23";
                            break;
                        case "24":
                            form1.picwafer.Image = Properties.Resources.wafermapA24;
                            form1.picwafer.Image.Tag = "24";
                            form1.lblwafer.Text = "A" + "24";
                            break;
                        case "25":
                            form1.picwafer.Image = Properties.Resources.wafermapA25;
                            form1.picwafer.Image.Tag = "25";
                            form1.lblwafer.Text = "A" + "25";
                            break;
                    }

                }


            }

            else if (radiotransfer.Checked == true)
            {
                if (cmbalign.Text=="None")   ///////////////////////////////////not with align
                {

                    straling = "None";

                    if (str1 == "Arm") ////////////////////////////source Arm

                    {

                        if (str == "APM") ////////////////////////////////////////////destination APM

                        {

                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            await Task.Delay(1000);

                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                            form1.lblwafer.Visible = false;
                            //   form1.newcontainer.Top -= 150;
                            //  form1.lblwafer.Top -= 150;
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            //  form1.robotupcontainer.Visible = true;
                            //  form1.ovalShapeUp.Visible = true;
                            //  form1.ovalShapeUp.BackColor = Color.LightBlue;
                            form1.lblwaferup.BackColor = Color.LightBlue;
                            form1.lblwaferup.Text = "A" + no1;
                            form1.lblwaferup.Visible = true;
                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            //   form1.robotupcontainer.Visible = false;
                            form1.ovalShapeUp.Visible = false;
                            form1.lblwaferup.Visible = false;
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            //   form1.robotintoAPMcontainer.Visible = true;
                            //   form1.ovalShapeAPM.Visible = true;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no1;
                            await Task.Delay(1000);

                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            form1.picMain.Image.Tag = "picwaferinAPM";
                            //  form1.robotintoAPMcontainer.Visible = false;
                            // form1.robotintoAPMcontainer.Visible = true;
                            //form1.ovalShapeAPM.Visible = true;
                            form1.lblwaferAPM.Visible = true;
                            await Task.Delay(1000);
                            form1.picSV.Visible = true;



                            /*     await Task.Delay(1000);
                                 form1.picMain.Image = Properties.Resources.picrobotbotton;
                                 form1.ovalShape1.Top -= 150;
                                 form1.lblwafer.Top -= 150;
                                 form1.ovalShape1.Left -= 0;
                                 form1.lblwafer.Left -= 0;
                                 await Task.Delay(1000);
                                 form1.picSV.Visible = false;
                                 await Task.Delay(1000);
                                 form1.picMain.Image = Properties.Resources.picrobotintochamber;
                                 form1.ovalShape1.Top -= 150;
                                 form1.lblwafer.Top -= 150;
                                 form1.ovalShape1.Left -= 7;
                                 form1.lblwafer.Left -= 7;*/

                        }

                        else if (str == "Aligner")//////////////////////////////////////////////////destination Aligner
                        {


                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;

                           await Task.Delay(1000);
                            // form1.lblwafer.Text = "A" + no1;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            form1.lblwaferright.BackColor = Color.LightBlue;
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            //  form1.ovalShape1.Top -= 85;
                            //  form1.lblwafer.Top -= 85;
                            //   form1.ovalShape1.Left += 70;
                            //   form1.lblwafer.Left += 70;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.BackColor = Color.LightBlue;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            //form1.ovalShape1.Left += 150;
                            //form1.lblwafer.Left += 150;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                            form1.picMain.Image.Tag = "picrobotwaferinAligner";

                        }
                        else if (str == "CSA")//////////////////////////////////////////////////////////destination CSA
                        {

                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Visible = false;
                            await Task.Delay(1000);
                            switch (tbDestinationSlotno.Text)
                            {
                                case "1":
                                    form1.picwafer.Image = Properties.Resources.wafermapA1;
                                    form1.picwafer.Image.Tag = "1";
                                    form1.lblwafer.Text = "A" +"1";
                                    break;
                                case "2":
                                    form1.picwafer.Image = Properties.Resources.wafermapA2;
                                    form1.picwafer.Image.Tag = "2";
                                    form1.lblwafer.Text = "A" + "2";
                                    break;
                                case "3":
                                    form1.picwafer.Image = Properties.Resources.wafermapA3;
                                    form1.picwafer.Image.Tag = "3";
                                    form1.lblwafer.Text = "A" + "3";
                                    break;
                                case "4":
                                    form1.picwafer.Image = Properties.Resources.wafermapA4;
                                    form1.picwafer.Image.Tag = "4";
                                    form1.lblwafer.Text = "A" + "4";
                                    break;
                                case "5":
                                    form1.picwafer.Image = Properties.Resources.wafermapA5;
                                    form1.picwafer.Image.Tag = "5";
                                    form1.lblwafer.Text = "A" + "5";
                                    break;
                                case "6":
                                    form1.picwafer.Image = Properties.Resources.wafermapA6;
                                    form1.picwafer.Image.Tag = "6";
                                    form1.lblwafer.Text = "A" + "6";
                                    break;
                                case "7":
                                    form1.picwafer.Image = Properties.Resources.wafermapA7;
                                    form1.picwafer.Image.Tag = "7";
                                    form1.lblwafer.Text = "A" + "7";
                                    break;
                                case "8":
                                    form1.picwafer.Image = Properties.Resources.wafermapA8;
                                    form1.picwafer.Image.Tag = "8";
                                    form1.lblwafer.Text = "A" + "8";
                                    break;
                                case "9":
                                    form1.picwafer.Image = Properties.Resources.wafermapA9;
                                    form1.picwafer.Image.Tag = "9";
                                    form1.lblwafer.Text = "A" + "9";
                                    break;
                                case "10":
                                    form1.picwafer.Image = Properties.Resources.wafermapA10;
                                    form1.picwafer.Image.Tag = "10";
                                    form1.lblwafer.Text = "A" + "10";
                                    break;
                                case "11":
                                    form1.picwafer.Image = Properties.Resources.wafermapA11;
                                    form1.picwafer.Image.Tag = "11";
                                    form1.lblwafer.Text = "A" + "11";
                                    break;
                                case "12":
                                    form1.picwafer.Image = Properties.Resources.wafermapA12;
                                    form1.picwafer.Image.Tag = "12";
                                    form1.lblwafer.Text = "A" + "12";
                                    break;
                                case "13":
                                    form1.picwafer.Image = Properties.Resources.wafermapA13;
                                    form1.picwafer.Image.Tag = "13";
                                    form1.lblwafer.Text = "A" + "13";
                                    break;
                                case "14":
                                    form1.picwafer.Image = Properties.Resources.wafermapA14;
                                    form1.picwafer.Image.Tag = "14";
                                    form1.lblwafer.Text = "A" + "14";
                                    break;
                                case "15":
                                    form1.picwafer.Image = Properties.Resources.wafermapA15;
                                    form1.picwafer.Image.Tag = "15";
                                    form1.lblwafer.Text = "A" + "15";
                                    break;
                                case "16":
                                    form1.picwafer.Image = Properties.Resources.wafermapA16;
                                    form1.picwafer.Image.Tag = "16";
                                    form1.lblwafer.Text = "A" + "16";
                                    break;
                                case "17":
                                    form1.picwafer.Image = Properties.Resources.wafermapA17;
                                    form1.picwafer.Image.Tag = "17";
                                    form1.lblwafer.Text = "A" + "17";
                                    break;
                                case "18":
                                    form1.picwafer.Image = Properties.Resources.wafermapA18;
                                    form1.picwafer.Image.Tag = "18";
                                    form1.lblwafer.Text = "A" + "18";
                                    break;
                                case "19":
                                    form1.picwafer.Image = Properties.Resources.wafermapA19;
                                    form1.picwafer.Image.Tag = "19";
                                    form1.lblwafer.Text = "A" + "19";
                                    break;
                                case "20":
                                    form1.picwafer.Image = Properties.Resources.wafermapA20;
                                    form1.picwafer.Image.Tag = "20";
                                    form1.lblwafer.Text = "A" + "20";
                                    break;
                                case "21":
                                    form1.picwafer.Image = Properties.Resources.wafermapA21;
                                    form1.picwafer.Image.Tag = "21";
                                    form1.lblwafer.Text = "A" + "21";
                                    break;
                                case "22":
                                    form1.picwafer.Image = Properties.Resources.wafermapA22;
                                    form1.picwafer.Image.Tag = "22";
                                    form1.lblwafer.Text = "A" + "22";
                                    break;
                                case "23":
                                    form1.picwafer.Image = Properties.Resources.wafermapA23;
                                    form1.picwafer.Image.Tag = "23";
                                    form1.lblwafer.Text = "A" + "23";
                                    break;
                                case "24":
                                    form1.picwafer.Image = Properties.Resources.wafermapA24;
                                    form1.picwafer.Image.Tag = "24";
                                    form1.lblwafer.Text = "A" + "24";
                                    break;
                                case "25":
                                    form1.picwafer.Image = Properties.Resources.wafermapA25;
                                    form1.picwafer.Image.Tag = "25";
                                    form1.lblwafer.Text = "A" + "25";
                                    break;



                            }
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.picMain.Image.Tag = "mainpicture";

                        }
                    }
                    if (str1 == "APM")////////////////////////////////source APM
                    {

                        if (str == "Aligner")////////////////////////////destination Aligner
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferAPM.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picSV.Visible = true;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.picMain.Image.Tag = "picrobotwaferinAligner";

                        }
                        if (str == "Arm")////////////////////////////destination Arm
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferAPM.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picSV.Visible = true;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;

                        }
                        if (str == "CSA")////////////////////////////destination CSA
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;

                            await Task.Delay(1000);
                            form1.lblwaferAPM.Visible = false;
                            form1.lblwaferAPM.Text = "A" + no1;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                            form1.lblwaferup.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Visible = false;
                            await Task.Delay(1000);
                            switch (tbDestinationSlotno.Text)
                            {
                                case "1":
                                    form1.picwafer.Image = Properties.Resources.wafermapA1;
                                    form1.picwafer.Image.Tag = "1";
                                    form1.lblwafer.Text = "A" + "1";
                                    break;
                                case "2":
                                    form1.picwafer.Image = Properties.Resources.wafermapA2;
                                    form1.picwafer.Image.Tag = "2";
                                    form1.lblwafer.Text = "A" + "2";
                                    break;
                                case "3":
                                    form1.picwafer.Image = Properties.Resources.wafermapA3;
                                    form1.picwafer.Image.Tag = "3";
                                    form1.lblwafer.Text = "A" + "3";
                                    break;
                                case "4":
                                    form1.picwafer.Image = Properties.Resources.wafermapA4;
                                    form1.picwafer.Image.Tag = "4";
                                    form1.lblwafer.Text = "A" + "4";
                                    break;
                                case "5":
                                    form1.picwafer.Image = Properties.Resources.wafermapA5;
                                    form1.picwafer.Image.Tag = "5";
                                    form1.lblwafer.Text = "A" + "5";
                                    break;
                                case "6":
                                    form1.picwafer.Image = Properties.Resources.wafermapA6;
                                    form1.picwafer.Image.Tag = "6";
                                    form1.lblwafer.Text = "A" + "6";
                                    break;
                                case "7":
                                    form1.picwafer.Image = Properties.Resources.wafermapA7;
                                    form1.picwafer.Image.Tag = "7";
                                    form1.lblwafer.Text = "A" + "7";
                                    break;
                                case "8":
                                    form1.picwafer.Image = Properties.Resources.wafermapA8;
                                    form1.picwafer.Image.Tag = "8";
                                    form1.lblwafer.Text = "A" + "8";
                                    break;
                                case "9":
                                    form1.picwafer.Image = Properties.Resources.wafermapA9;
                                    form1.picwafer.Image.Tag = "9";
                                    form1.lblwafer.Text = "A" + "9";
                                    break;
                                case "10":
                                    form1.picwafer.Image = Properties.Resources.wafermapA10;
                                    form1.picwafer.Image.Tag = "10";
                                    form1.lblwafer.Text = "A" + "10";
                                    break;
                                case "11":
                                    form1.picwafer.Image = Properties.Resources.wafermapA11;
                                    form1.picwafer.Image.Tag = "11";
                                    form1.lblwafer.Text = "A" + "11";
                                    break;
                                case "12":
                                    form1.picwafer.Image = Properties.Resources.wafermapA12;
                                    form1.picwafer.Image.Tag = "12";
                                    form1.lblwafer.Text = "A" + "12";
                                    break;
                                case "13":
                                    form1.picwafer.Image = Properties.Resources.wafermapA13;
                                    form1.picwafer.Image.Tag = "13";
                                    form1.lblwafer.Text = "A" + "13";
                                    break;
                                case "14":
                                    form1.picwafer.Image = Properties.Resources.wafermapA14;
                                    form1.picwafer.Image.Tag = "14";
                                    form1.lblwafer.Text = "A" + "14";
                                    break;
                                case "15":
                                    form1.picwafer.Image = Properties.Resources.wafermapA15;
                                    form1.picwafer.Image.Tag = "15";
                                    form1.lblwafer.Text = "A" + "15";
                                    break;
                                case "16":
                                    form1.picwafer.Image = Properties.Resources.wafermapA16;
                                    form1.picwafer.Image.Tag = "16";
                                    form1.lblwafer.Text = "A" + "16";
                                    break;
                                case "17":
                                    form1.picwafer.Image = Properties.Resources.wafermapA17;
                                    form1.picwafer.Image.Tag = "17";
                                    form1.lblwafer.Text = "A" + "17";
                                    break;
                                case "18":
                                    form1.picwafer.Image = Properties.Resources.wafermapA18;
                                    form1.picwafer.Image.Tag = "18";
                                    form1.lblwafer.Text = "A" + "18";
                                    break;
                                case "19":
                                    form1.picwafer.Image = Properties.Resources.wafermapA19;
                                    form1.picwafer.Image.Tag = "19";
                                    form1.lblwafer.Text = "A" + "19";
                                    break;
                                case "20":
                                    form1.picwafer.Image = Properties.Resources.wafermapA20;
                                    form1.picwafer.Image.Tag = "20";
                                    form1.lblwafer.Text = "A" + "20";
                                    break;
                                case "21":
                                    form1.picwafer.Image = Properties.Resources.wafermapA21;
                                    form1.picwafer.Image.Tag = "21";
                                    form1.lblwafer.Text = "A" + "21";
                                    break;
                                case "22":
                                    form1.picwafer.Image = Properties.Resources.wafermapA22;
                                    form1.picwafer.Image.Tag = "22";
                                    form1.lblwafer.Text = "A" + "22";
                                    break;
                                case "23":
                                    form1.picwafer.Image = Properties.Resources.wafermapA23;
                                    form1.picwafer.Image.Tag = "23";
                                    form1.lblwafer.Text = "A" + "23";
                                    break;
                                case "24":
                                    form1.picwafer.Image = Properties.Resources.wafermapA24;
                                    form1.picwafer.Image.Tag = "24";
                                    form1.lblwafer.Text = "A" + "24";
                                    break;
                                case "25":
                                    form1.picwafer.Image = Properties.Resources.wafermapA25;
                                    form1.picwafer.Image.Tag = "25";
                                    form1.lblwafer.Text = "A" + "25";
                                    break;



                            }
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;

                        }



                    }
                    if (str1 == "CSA")//////////////////////source CSA
                    {
                        if (str == "APM")///////////////////////////////////////destination APM
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            //     form1.lblwafer.Visible = true;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Visible = false;
                            form1.lblwafer.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picwafer.Image = Properties.Resources.wafer;
                          //  form1.picwafer.Image.Tag = "wafer";
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            form1.picMain.Image.Tag = "picwaferinAPM";
                            await Task.Delay(1000);
                            form1.picSV.Visible = true;
                        }
                        if (str == "Aligner")////////////////////////////////////destination Aligner
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;

                            await Task.Delay(1000);

                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Text = "A" + no1;
                            await Task.Delay(1000);

                            form1.picwafer.Image = Properties.Resources.wafer;
                          //  form1.picwafer.Image.Tag = "wafer";
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.picMain.Image.Tag = "picrobotwaferinAligner";

                        }
                        if (str == "Arm")//////////////////////////distination Arm
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            await Task.Delay(1000);
                            form1.picwafer.Image = Properties.Resources.wafer;
                         //   form1.picwafer.Image.Tag = "wafer";
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                            form1.picMain.Image.Tag = "picrobotArmWafer";

                        }

                    }

                    if (str1=="Aligner")////////////////////////////////////source Aligner
                    {

                        if (str == "APM")/////////////////////////////////////destination APM
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferaligner.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            form1.picMain.Image.Tag = "picwaferinAPM";
                          await Task.Delay(1000);
                            form1.picSV.Visible = true;

                        }
                        if (str == "Arm")/////////////////////////////////////destination Arm
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferaligner.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.picMain.Image.Tag = "picrobotArmWafer";
                            form1.lblwaferright.Visible = false;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                            await Task.Delay(1000);

                        }

                        if (str == "CSA")/////////////////////////////////////destination CSA
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferaligner.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Visible = false;
                            await Task.Delay(1000);
                            switch (tbDestinationSlotno.Text)
                            {
                                case "1":
                                    form1.picwafer.Image = Properties.Resources.wafermapA1;
                                    form1.picwafer.Image.Tag = "1";
                                    form1.lblwafer.Text = "A" + "1";
                                    break;
                                case "2":
                                    form1.picwafer.Image = Properties.Resources.wafermapA2;
                                    form1.picwafer.Image.Tag = "2";
                                    form1.lblwafer.Text = "A" + "2";
                                    break;
                                case "3":
                                    form1.picwafer.Image = Properties.Resources.wafermapA3;
                                    form1.picwafer.Image.Tag = "3";
                                    form1.lblwafer.Text = "A" + "3";
                                    break;
                                case "4":
                                    form1.picwafer.Image = Properties.Resources.wafermapA4;
                                    form1.picwafer.Image.Tag = "4";
                                    form1.lblwafer.Text = "A" + "4";
                                    break;
                                case "5":
                                    form1.picwafer.Image = Properties.Resources.wafermapA5;
                                    form1.picwafer.Image.Tag = "5";
                                    form1.lblwafer.Text = "A" + "5";
                                    break;
                                case "6":
                                    form1.picwafer.Image = Properties.Resources.wafermapA6;
                                    form1.picwafer.Image.Tag = "6";
                                    form1.lblwafer.Text = "A" + "6";
                                    break;
                                case "7":
                                    form1.picwafer.Image = Properties.Resources.wafermapA7;
                                    form1.picwafer.Image.Tag = "7";
                                    form1.lblwafer.Text = "A" + "7";
                                    break;
                                case "8":
                                    form1.picwafer.Image = Properties.Resources.wafermapA8;
                                    form1.picwafer.Image.Tag = "8";
                                    form1.lblwafer.Text = "A" + "8";
                                    break;
                                case "9":
                                    form1.picwafer.Image = Properties.Resources.wafermapA9;
                                    form1.picwafer.Image.Tag = "9";
                                    form1.lblwafer.Text = "A" + "9";
                                    break;
                                case "10":
                                    form1.picwafer.Image = Properties.Resources.wafermapA10;
                                    form1.picwafer.Image.Tag = "10";
                                    form1.lblwafer.Text = "A" + "10";
                                    break;
                                case "11":
                                    form1.picwafer.Image = Properties.Resources.wafermapA11;
                                    form1.picwafer.Image.Tag = "11";
                                    form1.lblwafer.Text = "A" + "11";
                                    break;
                                case "12":
                                    form1.picwafer.Image = Properties.Resources.wafermapA12;
                                    form1.picwafer.Image.Tag = "12";
                                    form1.lblwafer.Text = "A" + "12";
                                    break;
                                case "13":
                                    form1.picwafer.Image = Properties.Resources.wafermapA13;
                                    form1.picwafer.Image.Tag = "13";
                                    form1.lblwafer.Text = "A" + "13";
                                    break;
                                case "14":
                                    form1.picwafer.Image = Properties.Resources.wafermapA14;
                                    form1.picwafer.Image.Tag = "14";
                                    form1.lblwafer.Text = "A" + "14";
                                    break;
                                case "15":
                                    form1.picwafer.Image = Properties.Resources.wafermapA15;
                                    form1.picwafer.Image.Tag = "15";
                                    form1.lblwafer.Text = "A" + "15";
                                    break;
                                case "16":
                                    form1.picwafer.Image = Properties.Resources.wafermapA16;
                                    form1.picwafer.Image.Tag = "16";
                                    form1.lblwafer.Text = "A" + "16";
                                    break;
                                case "17":
                                    form1.picwafer.Image = Properties.Resources.wafermapA17;
                                    form1.picwafer.Image.Tag = "17";
                                    form1.lblwafer.Text = "A" + "17";
                                    break;
                                case "18":
                                    form1.picwafer.Image = Properties.Resources.wafermapA18;
                                    form1.picwafer.Image.Tag = "18";
                                    form1.lblwafer.Text = "A" + "18";
                                    break;
                                case "19":
                                    form1.picwafer.Image = Properties.Resources.wafermapA19;
                                    form1.picwafer.Image.Tag = "19";
                                    form1.lblwafer.Text = "A" + "19";
                                    break;
                                case "20":
                                    form1.picwafer.Image = Properties.Resources.wafermapA20;
                                    form1.picwafer.Image.Tag = "20";
                                    form1.lblwafer.Text = "A" + "20";
                                    break;
                                case "21":
                                    form1.picwafer.Image = Properties.Resources.wafermapA21;
                                    form1.picwafer.Image.Tag = "21";
                                    form1.lblwafer.Text = "A" + "21";
                                    break;
                                case "22":
                                    form1.picwafer.Image = Properties.Resources.wafermapA22;
                                    form1.picwafer.Image.Tag = "22";
                                    form1.lblwafer.Text = "A" + "22";
                                    break;
                                case "23":
                                    form1.picwafer.Image = Properties.Resources.wafermapA23;
                                    form1.picwafer.Image.Tag = "23";
                                    form1.lblwafer.Text = "A" + "23";
                                    break;
                                case "24":
                                    form1.picwafer.Image = Properties.Resources.wafermapA24;
                                    form1.picwafer.Image.Tag = "24";
                                    form1.lblwafer.Text = "A" + "24";
                                    break;
                                case "25":
                                    form1.picwafer.Image = Properties.Resources.wafermapA25;
                                    form1.picwafer.Image.Tag = "25";
                                    form1.lblwafer.Text = "A" + "25";
                                    break;



                            }
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.picMain.Image.Tag = "mainpicture";
                        }

                    }

                }
               else if (cmbalign.Text == "With Align")  ////////////////////////////////////////////////////with align
                {
                    straling = "With Align";
                    if (str1=="Arm")/////////////////////////source Arm
                    {
                        if (str == "APM")////////////////////destination APM
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferaligner.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            form1.picMain.Image.Tag = "picwaferinAPM";
                            await Task.Delay(1000);
                            form1.picSV.Visible = true;
                        }
                        if (str == "CSA")///////////////////////////////////////////destination CSA
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Visible = false;
                            await Task.Delay(1000);
                            switch (tbDestinationSlotno.Text)
                            {
                                case "1":
                                    form1.picwafer.Image = Properties.Resources.wafermapA1;
                                    form1.picwafer.Image.Tag = "1";
                                    form1.lblwafer.Text = "A" + "1";
                                    break;
                                case "2":
                                    form1.picwafer.Image = Properties.Resources.wafermapA2;
                                    form1.picwafer.Image.Tag = "2";
                                    form1.lblwafer.Text = "A" + "2";
                                    break;
                                case "3":
                                    form1.picwafer.Image = Properties.Resources.wafermapA3;
                                    form1.picwafer.Image.Tag = "3";
                                    form1.lblwafer.Text = "A" + "3";
                                    break;
                                case "4":
                                    form1.picwafer.Image = Properties.Resources.wafermapA4;
                                    form1.picwafer.Image.Tag = "4";
                                    form1.lblwafer.Text = "A" + "4";
                                    break;
                                case "5":
                                    form1.picwafer.Image = Properties.Resources.wafermapA5;
                                    form1.picwafer.Image.Tag = "5";
                                    form1.lblwafer.Text = "A" + "5";
                                    break;
                                case "6":
                                    form1.picwafer.Image = Properties.Resources.wafermapA6;
                                    form1.picwafer.Image.Tag = "6";
                                    form1.lblwafer.Text = "A" + "6";
                                    break;
                                case "7":
                                    form1.picwafer.Image = Properties.Resources.wafermapA7;
                                    form1.picwafer.Image.Tag = "7";
                                    form1.lblwafer.Text = "A" + "7";
                                    break;
                                case "8":
                                    form1.picwafer.Image = Properties.Resources.wafermapA8;
                                    form1.picwafer.Image.Tag = "8";
                                    form1.lblwafer.Text = "A" + "8";
                                    break;
                                case "9":
                                    form1.picwafer.Image = Properties.Resources.wafermapA9;
                                    form1.picwafer.Image.Tag = "9";
                                    form1.lblwafer.Text = "A" + "9";
                                    break;
                                case "10":
                                    form1.picwafer.Image = Properties.Resources.wafermapA10;
                                    form1.picwafer.Image.Tag = "10";
                                    form1.lblwafer.Text = "A" + "10";
                                    break;
                                case "11":
                                    form1.picwafer.Image = Properties.Resources.wafermapA11;
                                    form1.picwafer.Image.Tag = "11";
                                    form1.lblwafer.Text = "A" + "11";
                                    break;
                                case "12":
                                    form1.picwafer.Image = Properties.Resources.wafermapA12;
                                    form1.picwafer.Image.Tag = "12";
                                    form1.lblwafer.Text = "A" + "12";
                                    break;
                                case "13":
                                    form1.picwafer.Image = Properties.Resources.wafermapA13;
                                    form1.picwafer.Image.Tag = "13";
                                    form1.lblwafer.Text = "A" + "13";
                                    break;
                                case "14":
                                    form1.picwafer.Image = Properties.Resources.wafermapA14;
                                    form1.picwafer.Image.Tag = "14";
                                    form1.lblwafer.Text = "A" + "14";
                                    break;
                                case "15":
                                    form1.picwafer.Image = Properties.Resources.wafermapA15;
                                    form1.picwafer.Image.Tag = "15";
                                    form1.lblwafer.Text = "A" + "15";
                                    break;
                                case "16":
                                    form1.picwafer.Image = Properties.Resources.wafermapA16;
                                    form1.picwafer.Image.Tag = "16";
                                    form1.lblwafer.Text = "A" + "16";
                                    break;
                                case "17":
                                    form1.picwafer.Image = Properties.Resources.wafermapA17;
                                    form1.picwafer.Image.Tag = "17";
                                    form1.lblwafer.Text = "A" + "17";
                                    break;
                                case "18":
                                    form1.picwafer.Image = Properties.Resources.wafermapA18;
                                    form1.picwafer.Image.Tag = "18";
                                    form1.lblwafer.Text = "A" + "18";
                                    break;
                                case "19":
                                    form1.picwafer.Image = Properties.Resources.wafermapA19;
                                    form1.picwafer.Image.Tag = "19";
                                    form1.lblwafer.Text = "A" + "19";
                                    break;
                                case "20":
                                    form1.picwafer.Image = Properties.Resources.wafermapA20;
                                    form1.picwafer.Image.Tag = "20";
                                    form1.lblwafer.Text = "A" + "20";
                                    break;
                                case "21":
                                    form1.picwafer.Image = Properties.Resources.wafermapA21;
                                    form1.picwafer.Image.Tag = "21";
                                    form1.lblwafer.Text = "A" + "21";
                                    break;
                                case "22":
                                    form1.picwafer.Image = Properties.Resources.wafermapA22;
                                    form1.picwafer.Image.Tag = "22";
                                    form1.lblwafer.Text = "A" + "22";
                                    break;
                                case "23":
                                    form1.picwafer.Image = Properties.Resources.wafermapA23;
                                    form1.picwafer.Image.Tag = "23";
                                    form1.lblwafer.Text = "A" + "23";
                                    break;
                                case "24":
                                    form1.picwafer.Image = Properties.Resources.wafermapA24;
                                    form1.picwafer.Image.Tag = "24";
                                    form1.lblwafer.Text = "A" + "24";
                                    break;
                                case "25":
                                    form1.picwafer.Image = Properties.Resources.wafermapA25;
                                    form1.picwafer.Image.Tag = "25";
                                    form1.lblwafer.Text = "A" + "25";
                                    break;



                            }
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.picMain.Image.Tag = "mainpicture";


                        }
                        if (str == "Aligner")///////////////////////////////////// destination Aligner
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;

                         await Task.Delay(1000);
                            // form1.lblwafer.Text = "A" + no1;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            form1.lblwaferright.BackColor = Color.LightBlue;
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            //  form1.ovalShape1.Top -= 85;
                            //  form1.lblwafer.Top -= 85;
                            //   form1.ovalShape1.Left += 70;
                            //   form1.lblwafer.Left += 70;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                            form1.lblwaferaligner.BackColor = Color.LightBlue;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            //form1.ovalShape1.Left += 150;
                            //form1.lblwafer.Left += 150;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                            form1.picMain.Image.Tag = "picrobotwaferinAligner";

                        }

                    }
                    if (str1 == "APM")///////////////////////////source APM
                    {
                        if (str == "Arm")//////////////////////////////////////////////destination Arm
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no1;

                          await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                            form1.lblwaferAPM.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            form1.lblwaferaligner.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                            form1.picMain.Image.Tag = "picrobotArmWafer";

                        }
                        if (str == "CSA")/////////////////////////////////////////////////destination CSA
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no1;

                           await Task.Delay(1000);
                         
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                         
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwafer.Text = "A" + no1;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no1;
                           await Task.Delay(1000);

                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                            form1.lblwaferAPM.Visible = false;
                            await Task.Delay(1000);
                            form1.picSV.Visible = true;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            form1.lblwaferaligner.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Visible = false;
                            await Task.Delay(1000);
                            switch (tbDestinationSlotno.Text)
                            {
                                case "1":
                                    form1.picwafer.Image = Properties.Resources.wafermapA1;
                                    form1.picwafer.Image.Tag = "1";
                                    form1.lblwafer.Text = "A" + "1";
                                    break;
                                case "2":
                                    form1.picwafer.Image = Properties.Resources.wafermapA2;
                                    form1.picwafer.Image.Tag = "2";
                                    form1.lblwafer.Text = "A" + "2";
                                    break;
                                case "3":
                                    form1.picwafer.Image = Properties.Resources.wafermapA3;
                                    form1.picwafer.Image.Tag = "3";
                                    form1.lblwafer.Text = "A" + "3";
                                    break;
                                case "4":
                                    form1.picwafer.Image = Properties.Resources.wafermapA4;
                                    form1.picwafer.Image.Tag = "4";
                                    form1.lblwafer.Text = "A" + "4";
                                    break;
                                case "5":
                                    form1.picwafer.Image = Properties.Resources.wafermapA5;
                                    form1.picwafer.Image.Tag = "5";
                                    form1.lblwafer.Text = "A" + "5";
                                    break;
                                case "6":
                                    form1.picwafer.Image = Properties.Resources.wafermapA6;
                                    form1.picwafer.Image.Tag = "6";
                                    form1.lblwafer.Text = "A" + "6";
                                    break;
                                case "7":
                                    form1.picwafer.Image = Properties.Resources.wafermapA7;
                                    form1.picwafer.Image.Tag = "7";
                                    form1.lblwafer.Text = "A" + "7";
                                    break;
                                case "8":
                                    form1.picwafer.Image = Properties.Resources.wafermapA8;
                                    form1.picwafer.Image.Tag = "8";
                                    form1.lblwafer.Text = "A" + "8";
                                    break;
                                case "9":
                                    form1.picwafer.Image = Properties.Resources.wafermapA9;
                                    form1.picwafer.Image.Tag = "9";
                                    form1.lblwafer.Text = "A" + "9";
                                    break;
                                case "10":
                                    form1.picwafer.Image = Properties.Resources.wafermapA10;
                                    form1.picwafer.Image.Tag = "10";
                                    form1.lblwafer.Text = "A" + "10";
                                    break;
                                case "11":
                                    form1.picwafer.Image = Properties.Resources.wafermapA11;
                                    form1.picwafer.Image.Tag = "11";
                                    form1.lblwafer.Text = "A" + "11";
                                    break;
                                case "12":
                                    form1.picwafer.Image = Properties.Resources.wafermapA12;
                                    form1.picwafer.Image.Tag = "12";
                                    form1.lblwafer.Text = "A" + "12";
                                    break;
                                case "13":
                                    form1.picwafer.Image = Properties.Resources.wafermapA13;
                                    form1.picwafer.Image.Tag = "13";
                                    form1.lblwafer.Text = "A" + "13";
                                    break;
                                case "14":
                                    form1.picwafer.Image = Properties.Resources.wafermapA14;
                                    form1.picwafer.Image.Tag = "14";
                                    form1.lblwafer.Text = "A" + "14";
                                    break;
                                case "15":
                                    form1.picwafer.Image = Properties.Resources.wafermapA15;
                                    form1.picwafer.Image.Tag = "15";
                                    form1.lblwafer.Text = "A" + "15";
                                    break;
                                case "16":
                                    form1.picwafer.Image = Properties.Resources.wafermapA16;
                                    form1.picwafer.Image.Tag = "16";
                                    form1.lblwafer.Text = "A" + "16";
                                    break;
                                case "17":
                                    form1.picwafer.Image = Properties.Resources.wafermapA17;
                                    form1.picwafer.Image.Tag = "17";
                                    form1.lblwafer.Text = "A" + "17";
                                    break;
                                case "18":
                                    form1.picwafer.Image = Properties.Resources.wafermapA18;
                                    form1.picwafer.Image.Tag = "18";
                                    form1.lblwafer.Text = "A" + "18";
                                    break;
                                case "19":
                                    form1.picwafer.Image = Properties.Resources.wafermapA19;
                                    form1.picwafer.Image.Tag = "19";
                                    form1.lblwafer.Text = "A" + "19";
                                    break;
                                case "20":
                                    form1.picwafer.Image = Properties.Resources.wafermapA20;
                                    form1.picwafer.Image.Tag = "20";
                                    form1.lblwafer.Text = "A" + "20";
                                    break;
                                case "21":
                                    form1.picwafer.Image = Properties.Resources.wafermapA21;
                                    form1.picwafer.Image.Tag = "21";
                                    form1.lblwafer.Text = "A" + "21";
                                    break;
                                case "22":
                                    form1.picwafer.Image = Properties.Resources.wafermapA22;
                                    form1.picwafer.Image.Tag = "22";
                                    form1.lblwafer.Text = "A" + "22";
                                    break;
                                case "23":
                                    form1.picwafer.Image = Properties.Resources.wafermapA23;
                                    form1.picwafer.Image.Tag = "23";
                                    form1.lblwafer.Text = "A" + "23";
                                    break;
                                case "24":
                                    form1.picwafer.Image = Properties.Resources.wafermapA24;
                                    form1.picwafer.Image.Tag = "24";
                                    form1.lblwafer.Text = "A" + "24";
                                    break;
                                case "25":
                                    form1.picwafer.Image = Properties.Resources.wafermapA25;
                                    form1.picwafer.Image.Tag = "25";
                                    form1.lblwafer.Text = "A" + "25";
                                    break;



                            }
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.picMain.Image.Tag = "mainpicture";
                        }

                        if (str == "Aligner")//////////////////////////////////////////////////////////destination Aligner
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferAPM.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picSV.Visible = true;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                           await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.picMain.Image.Tag = "picrobotwaferinAligner";


                        }


                    }
                    if (str1 == "CSA")//////////////////////////////source CSA
                    {
                        if (str == "APM")///////////////////////destination APM
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.lblwafer.Visible = false;
                            form1.lblwafer.Text = "A" + no;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;

                            await Task.Delay(1000);
                            form1.picwafer.Image = Properties.Resources.wafer;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferaligner.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no;

                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            form1.picMain.Image.Tag = "picwaferinAPM";
                            await Task.Delay(1000);
                            form1.picSV.Visible = true;


                        }
                        if (str == "Aligner")///////////////////////////////////////destination Aligner
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;

                            await Task.Delay(1000);

                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Text = "A" + no1;
                            await Task.Delay(1000);

                            form1.picwafer.Image = Properties.Resources.wafer;
                          //  form1.picwafer.Image.Tag = "wafer";
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;
                          await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.picMain.Image.Tag = "picrobotwaferinAligner";


                        }
                        if (str == "Arm")////////////////////////////////////////////////////////////destination Arm
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            await Task.Delay(1000);
                            form1.picwafer.Image = Properties.Resources.wafer;
                         //   form1.picwafer.Image.Tag = "wafer";
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no;
                            form1.picMain.Image.Tag = "picrobotArmWafer";


                        }


                    }


                    if (str1 == "Aligner")////////////////////////////////////source Aligner
                    {

                        if (str == "APM")/////////////////////////////////////destination APM
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferaligner.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.lblwaferup.Text = "A" + no;
                            await Task.Delay(1000);
                            form1.picSV.Visible = false;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwaferAPM.Visible = true;
                            form1.lblwaferAPM.Text = "A" + no;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;
                            form1.picMain.Image.Tag = "picwaferinAPM";
                            await Task.Delay(1000);
                            form1.picSV.Visible = true;

                        }
                        if (str == "Arm")/////////////////////////////////////destination Arm
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferaligner.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.picMain.Image.Tag = "picrobotArmWafer";
                            form1.lblwaferright.Visible = false;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no;
                            await Task.Delay(1000);

                        }

                        if (str == "CSA")/////////////////////////////////////destination CSA
                        {
                            no1 = tbSourceSlotno.Text;
                            no = tbDestinationSlotno.Text;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + no1;

                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferaligner.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + no1;
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.picrobotintocassette;
                            form1.lblwafer.Visible = false;
                            await Task.Delay(1000);
                            switch (tbDestinationSlotno.Text)
                            {
                                case "1":
                                    form1.picwafer.Image = Properties.Resources.wafermapA1;
                                    form1.picwafer.Image.Tag = "1";
                                    form1.lblwafer.Text = "A" + "1";
                                    break;
                                case "2":
                                    form1.picwafer.Image = Properties.Resources.wafermapA2;
                                    form1.picwafer.Image.Tag = "2";
                                    form1.lblwafer.Text = "A" + "2";
                                    break;
                                case "3":
                                    form1.picwafer.Image = Properties.Resources.wafermapA3;
                                    form1.picwafer.Image.Tag = "3";
                                    form1.lblwafer.Text = "A" + "3";
                                    break;
                                case "4":
                                    form1.picwafer.Image = Properties.Resources.wafermapA4;
                                    form1.picwafer.Image.Tag = "4";
                                    form1.lblwafer.Text = "A" + "4";
                                    break;
                                case "5":
                                    form1.picwafer.Image = Properties.Resources.wafermapA5;
                                    form1.picwafer.Image.Tag = "5";
                                    form1.lblwafer.Text = "A" + "5";
                                    break;
                                case "6":
                                    form1.picwafer.Image = Properties.Resources.wafermapA6;
                                    form1.picwafer.Image.Tag = "6";
                                    form1.lblwafer.Text = "A" + "6";
                                    break;
                                case "7":
                                    form1.picwafer.Image = Properties.Resources.wafermapA7;
                                    form1.picwafer.Image.Tag = "7";
                                    form1.lblwafer.Text = "A" + "7";
                                    break;
                                case "8":
                                    form1.picwafer.Image = Properties.Resources.wafermapA8;
                                    form1.picwafer.Image.Tag = "8";
                                    form1.lblwafer.Text = "A" + "8";
                                    break;
                                case "9":
                                    form1.picwafer.Image = Properties.Resources.wafermapA9;
                                    form1.picwafer.Image.Tag = "9";
                                    form1.lblwafer.Text = "A" + "9";
                                    break;
                                case "10":
                                    form1.picwafer.Image = Properties.Resources.wafermapA10;
                                    form1.picwafer.Image.Tag = "10";
                                    form1.lblwafer.Text = "A" + "10";
                                    break;
                                case "11":
                                    form1.picwafer.Image = Properties.Resources.wafermapA11;
                                    form1.picwafer.Image.Tag = "11";
                                    form1.lblwafer.Text = "A" + "11";
                                    break;
                                case "12":
                                    form1.picwafer.Image = Properties.Resources.wafermapA12;
                                    form1.picwafer.Image.Tag = "12";
                                    form1.lblwafer.Text = "A" + "12";
                                    break;
                                case "13":
                                    form1.picwafer.Image = Properties.Resources.wafermapA13;
                                    form1.picwafer.Image.Tag = "13";
                                    form1.lblwafer.Text = "A" + "13";
                                    break;
                                case "14":
                                    form1.picwafer.Image = Properties.Resources.wafermapA14;
                                    form1.picwafer.Image.Tag = "14";
                                    form1.lblwafer.Text = "A" + "14";
                                    break;
                                case "15":
                                    form1.picwafer.Image = Properties.Resources.wafermapA15;
                                    form1.picwafer.Image.Tag = "15";
                                    form1.lblwafer.Text = "A" + "15";
                                    break;
                                case "16":
                                    form1.picwafer.Image = Properties.Resources.wafermapA16;
                                    form1.picwafer.Image.Tag = "16";
                                    form1.lblwafer.Text = "A" + "16";
                                    break;
                                case "17":
                                    form1.picwafer.Image = Properties.Resources.wafermapA17;
                                    form1.picwafer.Image.Tag = "17";
                                    form1.lblwafer.Text = "A" + "17";
                                    break;
                                case "18":
                                    form1.picwafer.Image = Properties.Resources.wafermapA18;
                                    form1.picwafer.Image.Tag = "18";
                                    form1.lblwafer.Text = "A" + "18";
                                    break;
                                case "19":
                                    form1.picwafer.Image = Properties.Resources.wafermapA19;
                                    form1.picwafer.Image.Tag = "19";
                                    form1.lblwafer.Text = "A" + "19";
                                    break;
                                case "20":
                                    form1.picwafer.Image = Properties.Resources.wafermapA20;
                                    form1.picwafer.Image.Tag = "20";
                                    form1.lblwafer.Text = "A" + "20";
                                    break;
                                case "21":
                                    form1.picwafer.Image = Properties.Resources.wafermapA21;
                                    form1.picwafer.Image.Tag = "21";
                                    form1.lblwafer.Text = "A" + "21";
                                    break;
                                case "22":
                                    form1.picwafer.Image = Properties.Resources.wafermapA22;
                                    form1.picwafer.Image.Tag = "22";
                                    form1.lblwafer.Text = "A" + "22";
                                    break;
                                case "23":
                                    form1.picwafer.Image = Properties.Resources.wafermapA23;
                                    form1.picwafer.Image.Tag = "23";
                                    form1.lblwafer.Text = "A" + "23";
                                    break;
                                case "24":
                                    form1.picwafer.Image = Properties.Resources.wafermapA24;
                                    form1.picwafer.Image.Tag = "24";
                                    form1.lblwafer.Text = "A" + "24";
                                    break;
                                case "25":
                                    form1.picwafer.Image = Properties.Resources.wafermapA25;
                                    form1.picwafer.Image.Tag = "25";
                                    form1.lblwafer.Text = "A" + "25";
                                    break;



                            }
                            await Task.Delay(1000);
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.picMain.Image.Tag = "mainpicture";
                        }

                    }



                }


            }

            else if (radioclearwafer.Checked == true)
            {
                form1.lblwafer.Visible = false;
                form1.lblwaferup.Visible = false;
                form1.lblwaferAPM.Visible = false;
                form1.lblwaferright.Visible = false;

                form1.picwafer.Image = Properties.Resources.wafer;
              //  form1.picwafer.Image.Tag = "wafer";

                switch (form1.picMain.Image.Tag)
                {
                    case "picrobotArmWafer":
                        form1.picMain.Image = Properties.Resources.mainpicture;
                        

                        break;


                    default:
                        form1.picMain.Image = Properties.Resources.mainpicture;
                        break;
               
                        
                }
       
               

           //    form1.ovalShape1.Parent.Parent = form1.picMain;
               
             //   form1.ovalShapeAPM.Parent.Parent = form1.picMain;
            }


        }

        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = cmbDestination.SelectedItem.ToString();
        }
    }
}
