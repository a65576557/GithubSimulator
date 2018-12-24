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
    public partial class ActionArm : Form
    {
        public Form1 form1 = new Form1();

       

        public ActionArm()
        {
            InitializeComponent();
        }

      public  string action;
        Wafer_Transfer_and_Flag_Operation wafer_Transfer_And_Flag_Operation = new Wafer_Transfer_and_Flag_Operation();
       

        private void ActionArm_Load(object sender, EventArgs e)
        {

           




        }

        private void listAction_SelectedIndexChanged(object sender, EventArgs e)
        {

            action = listAction.SelectedItem.ToString();

          


        }

        private async void  button1_Click(object sender, EventArgs e)
        {
            if (action == "Home")
            {


                if (form1.picMain.Image.Tag.ToString() == "picrobotintocentralized")
                {

                    await Task.Delay(1000);

                    form1.picMain.Image = Properties.Resources.picrobotcentralized;

                    await Task.Delay(1000);

                    form1.picMain.Image = Properties.Resources.mainpicture;
                    form1.picMain.Image.Tag = "mainpicture";
                }

                else if (form1.picMain.Image.Tag.ToString() == "picrobotintochamber")
                {
                    await Task.Delay(1000);

                    form1.picMain.Image = Properties.Resources.picrobotbotton;

                    await Task.Delay(1000);

                    form1.picMain.Image = Properties.Resources.mainpicture;
                    form1.picMain.Image.Tag = "mainpicture";

                }


                else if (form1.picMain.Image.Tag.ToString() == "picwaferinAPM")
                {
                    form1.picMain.Image = Properties.Resources.picwaferinAPMHome;

                }

                else
                {
                    form1.picMain.Image = Properties.Resources.mainpicture;
                    form1.picMain.Image.Tag = "mainpicture";
                }

            }
            if (action == "Rotate")
            {
                Rotate rotate = new Rotate();
                rotate.actionArm1 = this;
                rotate.ShowDialog();

                if (form1.picMain.Image.Tag.ToString() != "picrobotintocassette"&& form1.picMain.Image.Tag.ToString() != "picrobotintocentralized"&& form1.picMain.Image.Tag.ToString() != "picrobotintochamber")
                {
                    if (rotate.getmsg().ToString() == "Aligner")
                    {
                        if (form1.picMain.Image.Tag.ToString() == "picrobotArmWafer")
                        {
                            //  endeffector endeffector = new endeffector();
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferAPM.Visible = false;
                            form1.lblwaferright.Visible = true;
                            form1.lblwaferright.BackColor = Color.LightBlue;
                            form1.lblwaferright.Text = "A" + endeffector.no;
                            form1.picMain.Image.Tag = "picrobotAlignerWafer";
                        }
                        else if (form1.picMain.Image.Tag.ToString() == "picwaferinAPMHome")
                        {
                            form1.picMain.Image = Properties.Resources.picwaferinAPMHomeRight;
                            form1.picMain.Image.Tag = "picwaferinAPMHomeRight";

                        }
                        else if (form1.picMain.Image.Tag.ToString() == "picrobotwaferinAlignerHome")
                        {

                            form1.picMain.Image = Properties.Resources.picrobotwaferinAligner;
                            form1.picMain.Image.Tag = "picrobotwaferinAligner";
                        }

                        else if (form1.picMain.Image.Tag.ToString() == "picrobotAPMWafer")
                        {
                            form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                            form1.lblwaferAPM.Visible = false;
                            form1.lblwaferaligner.Visible = true;
                            form1.lblwaferaligner.Text = "A" + endeffector.no;
                            form1.picMain.Image.Tag = "picrobotAlignerWafer";
                        }


                        else
                        {
                            form1.picMain.Image = Properties.Resources.picrobotcentralized;
                            form1.picMain.Image.Tag = "picrobotcentralized";
                        }
                    }

                    if (rotate.getmsg().ToString() == "CSA")
                    {
                        if (form1.picMain.Image.Tag.ToString() == "picrobotAPMWafer")
                        {
                            form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                            form1.lblwaferup.Visible = false;
                            form1.lblwafer.Visible = true;
                            form1.picMain.Image.Tag = "picrobotArmWafer";
                            endeffector endeffector = new endeffector();
                            // endeffector.actionArm = this;
                            // endeffector.cmbSource.Text = "CSA";
                        }
                        else if (form1.picMain.Image.Tag.ToString() == "picrobotwaferinAligner")
                        {
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAlignerHome;

                            form1.picMain.Image.Tag = "picrobotwaferinAlignerHome";
                        }

                        else if (form1.picMain.Image.Tag.ToString() == "picrobotwaferinAlignerHomeup")
                        {
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAlignerHome;

                            form1.picMain.Image.Tag = "picrobotwaferinAlignerHome";

                        }
                        

                        else
                        {
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.picMain.Image.Tag = "mainpicture";
                        }
                    }
                    if (rotate.getmsg().ToString() == "APM")
                    {
                        if (form1.picMain.Image.Tag.ToString() == "picrobotAPMWafer")
                        {
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwafer.Visible = false;
                            form1.lblwaferup.Visible = true;


                        }
                        else if (form1.picMain.Image.Tag.ToString() == "picrobotwaferinAligner")
                        {
                            form1.picMain.Image = Properties.Resources.picrobotwaferinAlignerHomeup;
                            form1.picMain.Image.Tag = "picrobotwaferinAlignerHomeup";

                        }
                        else if (form1.picMain.Image.Tag.ToString() == "picrobotAlignerWafer")
                        {
                            form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                            form1.lblwaferright.Visible = false;
                            form1.lblwaferup.Visible = true;
                            form1.picMain.Image.Tag = "picrobotAPMWafer";

                        }
                        else if (form1.picMain.Image.Tag.ToString() == "picwaferinAPMHome")
                        {
                            form1.picMain.Image = Properties.Resources.picwaferinAPM;

                            form1.picMain.Image.Tag = "picwaferinAPM";
                            
                        }
             

                        else

                        {
                            form1.picMain.Image = Properties.Resources.picrobotbotton;
                            form1.picMain.Image.Tag = "picrobotbotton";
                        }
                    }


                    

                  
                }
                else
                {
                    MessageBox.Show("123");
                }
            }

            if (action == "Retract")
            {
                switch (form1.picMain.Image.Tag)
                {
                    case "picrobotintocassette":

                      /*  if (Wafer_Transfer_and_Flag_Operation.waferno == "1")
                        {
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.ovalShape1.Visible = true;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + Wafer_Transfer_and_Flag_Operation.waferno;
                        }
                       else if (Wafer_Transfer_and_Flag_Operation.waferno == "2")
                        {
                            form1.picMain.Image = Properties.Resources.mainpicture;
                            form1.ovalShape1.Visible = true;
                            form1.lblwafer.Visible = true;
                            form1.lblwafer.Text = "A" + Wafer_Transfer_and_Flag_Operation.waferno;
                        }*/


                        form1.picMain.Image = Properties.Resources.picrobotArmWafer;
                        form1.lblwafer.Visible = true;
                        form1.picMain.Image.Tag = "picrobotArmWafer";

                        break;

                    case "picrobotintocassette1":

                        form1.picMain.Image = Properties.Resources.mainpicture;

                        form1.picMain.Image.Tag = "mainpicture";

                        break;



                    case "picrobotintocentralized":
                        form1.picMain.Image = Properties.Resources.picrobotcentralized;
                        form1.picMain.Image.Tag = "picrobotcentralized";

                        break;

                    case "picrobotintochamber":
                        form1.picMain.Image = Properties.Resources.picrobotbotton;
                        form1.picMain.Image.Tag = "picrobotbotton";

                        break;

                    case "picrobotintoAPMWafer":
                        form1.picMain.Image = Properties.Resources.picrobotAPMWafer;
                        form1.lblwaferAPM.Visible = false;
                        form1.lblwaferup.Visible = true;
                        form1.picMain.Image.Tag = "picrobotAPMWafer";
                        break;

                    case "picrobotintoAlignerWafer":
                        form1.picMain.Image = Properties.Resources.picrobotAlignerWafer;
                        form1.lblwaferaligner.Visible = false;
                        form1.lblwaferright.Visible = true;
                        form1.picMain.Image.Tag = "picrobotAlignerWafe";
                        break;
                }


            }

            if (action == "Extend")
            {
                switch (form1.picMain.Image.Tag)
                {
                    case "mainpicture":
                        form1.picMain.Image = Properties.Resources.picrobotintocassette;
                        form1.picMain.Image.Tag = "picrobotintocassette1";

                        break;

                    case "picrobotcentralized":
                        form1.picMain.Image = Properties.Resources.picrobotintocentralized;
                        form1.picMain.Image.Tag = "picrobotintocentralized";

                        break;

                    case "picrobotbotton":
                        if (form1.picSV.Visible == false)
                        {
                            form1.picMain.Image = Properties.Resources.picrobotintochamber;
                            form1.picMain.Image.Tag = "picrobotintochamber";
                        }
                        else if (form1.picSV.Visible == true)
                        {
                            MessageBox.Show("SV is closed");

                        }

                        

                        break;
                    case "picwaferinAPM":
                        if (form1.picSV.Visible == false)
                        {
                            form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                            form1.picMain.Image.Tag = "picrobotintoAPMWafer";
                        }

                        else if (form1.picSV.Visible == true)
                        {
                            MessageBox.Show("SV is closed");
                        }

                        break;
                    case "picrobotwaferinAligner":
                        form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                        form1.lblwaferright.Visible = false;
                        form1.lblwaferaligner.Visible = true;
                        form1.picMain.Image.Tag = "picrobotintoAlignerWafer";
                        break;
                    case "picrobotArmWafer":
                     form1.picMain.Image=   Properties.Resources.picrobotintocassette;
                        form1.lblwafer.Visible = false;
                        form1.picMain.Image.Tag = "picrobotintocassette";
                        break;
                    case "picrobotAPMWafer":
                        form1.picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                        form1.lblwaferup.Visible = false;
                        form1.lblwaferAPM.Visible = true;
                        form1.picMain.Image.Tag = "picrobotintoAPMWafer";
                        break;
                    case "picrobotAlignerWafer":
                        form1.picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                        form1.lblwaferright.Visible = false;
                        form1.lblwaferaligner.Visible = true;
                        break;
                }



            }

            if (action == "Map")
            {
                await Task.Delay(1000);

                form1.picMain.Image = Properties.Resources.picrobotbotton;
                await Task.Delay(1000);
                form1.picMain.Image = Properties.Resources.picrobotanalysis;

                await Task.Delay(1000);
                form1.picmap.Visible = true;
                for (int i = 1; i <= 24; i++)
                {
                    await Task.Delay(20);
                    form1.picmap.Top -= 13;
                }
                form1.picmap.Visible = false;
                form1.picmap.Top += 312;
                await Task.Delay(1000);
                form1.picmap1.Visible = true;
                for (int j = 1; j <= 24; j++)
                {
                    await Task.Delay(20);
                    form1.picmap1.Top += 13;
                }
                form1.picmap1.Visible = false;
                form1.picmap1.Top -= 312;
                await Task.Delay(1000);
                form1.picWafer1.Visible = true;
                form1.picWafer2.Visible = true;
                form1.picWafer3.Visible = true;
                form1.picWafer4.Visible = true;
                form1.picWafer5.Visible = true;
                form1.picWafer6.Visible = true;
                form1.picWafer7.Visible = true;
                form1.picWafer8.Visible = true;
                form1.picWafer9.Visible = true;
                form1.picWafer10.Visible = true;
                form1.picWafer11.Visible = true;
                form1.picWafer12.Visible = true;
                form1.picWafer13.Visible = true;
                form1.picWafer14.Visible = true;
                form1.picWafer15.Visible = true;
                form1.picWafer16.Visible = true;
                form1.picWafer17.Visible = true;
                form1.picWafer18.Visible = true;
                form1.picWafer19.Visible = true;
                form1.picWafer20.Visible = true;
                form1.picWafer21.Visible = true;
                form1.picWafer22.Visible = true;
                form1.picWafer23.Visible = true;
                form1.picWafer24.Visible = true;
                form1.picWafer25.Visible = true;

                await Task.Delay(1000);
                form1.picMain.Image = Properties.Resources.picrobotbotton;
                await Task.Delay(1000);
                form1.picMain.Image = Properties.Resources.mainpicture;


            }
            if (action=="Go slot")
            {
                GoSlot goslot = new GoSlot();
                goslot.ShowDialog();


                if (goslot.SlotNo == "1")
                {
                    await Task.Delay(1000);
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;


                }
               

                if (goslot.SlotNo == "2")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;

                    await Task.Delay(1000);
                    form1.picmap.Top -= 13;
                    form1.picmap1.Top -= 13;
                        

                }
                
                if (goslot.SlotNo == "3")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 26;
                    form1.picmap1.Top -= 26;

                }
                if (goslot.SlotNo == "4")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 37;
                    form1.picmap1.Top -= 37;

                }
                if (goslot.SlotNo == "5")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 50;
                    form1.picmap1.Top -= 50;


                }
                if (goslot.SlotNo == "6")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 63;
                    form1.picmap1.Top -= 63;


                }
                if (goslot.SlotNo == "7")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 76;
                    form1.picmap1.Top -= 76;


                }

                if (goslot.SlotNo == "8")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 89;
                    form1.picmap1.Top -= 89;

                }
                if (goslot.SlotNo == "9")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 102;
                    form1.picmap1.Top -= 102;

                }
                if (goslot.SlotNo == "10")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 115;
                    form1.picmap1.Top -= 115;

                }
                if (goslot.SlotNo == "11")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 128;
                    form1.picmap1.Top -= 128;

                }
                if (goslot.SlotNo == "12")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 141;
                    form1.picmap1.Top -= 141;

                }
                if (goslot.SlotNo == "13")
                {
                    form1.picmap1.Top += 305;
                    form1.picmap.Visible = true;
                    form1.picmap1.Visible = true;
                    await Task.Delay(1000);
                    form1.picmap.Top -= 154;
                    form1.picmap1.Top -= 154;

                }



            }
        }
    }
}
