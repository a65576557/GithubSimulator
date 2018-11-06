using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulatorApplication
{
    public partial class Form1 : Form
    {

        public static string datasource = @"HP-PC\SQLEXPRESS";


        bool taskwait = true;

        public List<string> NoOfwafer = new List<string>();







        public string str123;

        Thread t = new Thread(threadwait);

       public static Task taskTimer;                     // timer任務實體
        delegate void showTimeHandler();    // 顯示時間委派函式
      public static  ManualResetEvent pauseSignal;       // 控制任務 暫停或繼續
        int cnt = 0;                        // 計數器

        ManualResetEvent manu = new ManualResetEvent(false);

        static AutoResetEvent myResetEvent = new AutoResetEvent(false);


        bool FlagStop = false;

        ManualResetEvent MTestTdEvent = new ManualResetEvent(true);


        public bool ispauserobot = false;


        public bool iscancelrecipe = false;

        int Cumtm = 0;

        Task task1 = null;


        public static string chamberload;
        public static string form2Msg;
        public static string stepname;
        public static int StepSec;
        public string mySec1;
        public int Sec1;
        public DateTime StartTime = new DateTime();
        public DateTime Wafer2StartTime = new DateTime();
        public DateTime Wafer3StartTime = new DateTime();
        public DateTime Wafer4StartTime = new DateTime();
        public DateTime Wafer5StartTime = new DateTime();
        public DateTime Wafer6StartTime = new DateTime();
        public DateTime Wafer7StartTime = new DateTime();
        public DateTime Wafer8StartTime = new DateTime();
        public DateTime Wafer9StartTime = new DateTime();
        public DateTime Wafer10StartTime = new DateTime();
        public DateTime Wafer11StartTime = new DateTime();
        public DateTime Wafer12StartTime = new DateTime();
        public DateTime Wafer13StartTime = new DateTime();
        public DateTime Wafer14StartTime = new DateTime();
        public DateTime Wafer15StartTime = new DateTime();
        public DateTime Wafer16StartTime = new DateTime();
        public DateTime Wafer17StartTime = new DateTime();
        public DateTime Wafer18StartTime = new DateTime();
        public DateTime Wafer19StartTime = new DateTime();
        public DateTime Wafer20StartTime = new DateTime();
        public DateTime Wafer21StartTime = new DateTime();
        public DateTime Wafer22StartTime = new DateTime();
        public DateTime Wafer23StartTime = new DateTime();
        public DateTime Wafer24StartTime = new DateTime();
        public DateTime EndTime = new DateTime();
        public DateTime WaferTime = new DateTime();
        public DateTime StepStartTime = new DateTime();
        public DateTime StepEndTime = new DateTime();
        public List<DateTime> ListStepStartTime = new List<DateTime>();
        public List<DateTime> ListStepEndTime = new List<DateTime>();
        public string noofwafer;
        bool on_off = false;
        bool stop = false;
        bool isStopRobot = false;
        bool isintoaligner = true;
        int x;
        int y;
        
        //  ManualResetEvent manu = new ManualResetEvent(true);

        // private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        // private readonly PauseTokenSource _mPauseTokeSource = new PauseTokenSource();



        public Microsoft.VisualBasic.PowerPacks.ShapeContainer newcontainer;

        //   public Microsoft.VisualBasic.PowerPacks.ShapeContainer APMcontainer;

        //    public Microsoft.VisualBasic.PowerPacks.ShapeContainer robotupcontainer;

        //   public Microsoft.VisualBasic.PowerPacks.ShapeContainer robotintoAPMcontainer;



        AutoResetEvent manu1;
        string CI2;
        string BCI3;
        string SF6;
        string CHF3;
        string Oxygen;
        string Oxygen1;
        string Nitrogen;
        string Argon;
        public string strEvent = "insert into EventLog(Date,Event,Info) values(@1,@2,@3)";
        public delegate void LoadChamber1(object sender, EventArgs e);
        public LoadChamber1 loadchamber1;
        public delegate void LoadData();
        public LoadData loaddata;

        List<string> picname = new List<string>();
        //   ManualResetEvent pauseSignal;
        SqlConnectionStringBuilder scsb;
        List<string> strStepname1 = new List<string>();
        // LogIn login = new LogIn();



        public void analysis()
        {

        }




        public Form1()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Tag = "";

            btnLogIn.Tag = "LogIn";
           // button5.Image = Properties.Resources.pause2;

            button5.Image.Tag = "Pause";

            button4.Enabled = false;
            button5.Enabled = false;


            //   picendeffector.Width += 2;

            Control.CheckForIllegalCrossThreadCalls = false;
            t.Start();
            picWafer1.Visible = false;
            picWafer2.Visible = false;
            picWafer3.Visible = false;
            picWafer4.Visible = false;
            picWafer5.Visible = false;
            picWafer6.Visible = false;
            picWafer7.Visible = false;
            picWafer8.Visible = false;
            picWafer9.Visible = false;
            picWafer10.Visible = false;
            picWafer11.Visible = false;
            picWafer12.Visible = false;
            picWafer13.Visible = false;
            picWafer14.Visible = false;
            picWafer15.Visible = false;
            picWafer16.Visible = false;
            picWafer17.Visible = false;
            picWafer18.Visible = false;
            picWafer19.Visible = false;
            picWafer20.Visible = false;
            picWafer21.Visible = false;
            picWafer22.Visible = false;
            picWafer23.Visible = false;
            picWafer24.Visible = false;
            picWafer25.Visible = false;




            btnendeffector.Parent = picMain;

            btnendeffector.FlatStyle = FlatStyle.Flat;
            btnendeffector.FlatAppearance.BorderColor = TransparencyKey;
            btnendeffector.FlatAppearance.MouseOverBackColor = TransparencyKey;
            btnendeffector.FlatAppearance.MouseDownBackColor = TransparencyKey;

            // btnendeffector.Parent = picMain;

            lblData.Visible = true;
            lblnum.Visible = true;
            picwafer.Image.Tag = "wafer";
            // panelrobot.BackColor = Color.Transparent;
            // panelrobot.Parent = picMain;
            lblwaferup.BackColor = Color.LightBlue;

            // ovalShape2.Visible = false;
            lblwaferaligner.BackColor = Color.LightBlue;
            lblwaferright.BackColor = Color.LightBlue;

            newcontainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            //  APMcontainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            // robotupcontainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            // robotintoAPMcontainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();


            //    robotintoAPMcontainer.Parent = this;
            //    robotupcontainer.Parent = this;
            newcontainer.Parent = this;
            //   APMcontainer.Parent = this;

            //    ovalShapeAPM.Parent = robotintoAPMcontainer;
            ovalShape1.Parent = newcontainer;
            //    ovalShapeAPM.Parent = APMcontainer;
            //    ovalShapeUp.Parent = robotupcontainer;
            // lblProcess.ForeColor = Color.Black;
            lblProcess.Text = "Unknow";
            lblProcess.BringToFront();
            lblStepName.BringToFront();
            lblProcessStep.BringToFront();

            ovalShape1.BackColor = Color.LightBlue;
            lblwafer.BackColor = Color.LightBlue;
            lblwaferAPM.BackColor = Color.LightBlue;

            ovalShapeAPM.BackColor = Color.Blue;

            ovalShape1.BringToFront();
            ovalShapeAPM.BringToFront();

            lblwafer.Visible = false;

            //   lblwafer.BackColor = Color.White;
            lblwafer.Text = "";

            picMain.SendToBack();

            // ovalShape2.BringToFront();
            //  Chamber1 chamber1 = new Chamber1();
            // ovalShape1.BackColor = Color.Red;
            // picMain.SendToBack();
            // this.panel3.BackColor = Color.Transparent;
            //this.panel3.Parent = this.picMain;
            //panel3.BringToFront();
            Properties.Resources.No1_2_3.Tag = "1_2_3";


            lblLoad.Left -= 0;
            lbl123.Left -= 0;
            lblCassetteRecipename.Left -= 0;
            lblmTorr.Left -= 0;
            lblState.Left -= 0;

            lblLoad.Text = "Aborted";

            lblChamber.Tag = chamberload;
            //  picMain.Image = Properties.Resources.mainpic;
            picMain.Image = Properties.Resources.mainpicture;
            picMain.Image.Tag = "mainpicture";


            //picCassette.Image = imageList1.Images[0];
            // picCassette.Image = Image.FromFile(@"C: \Users\hp\Documents\Visual Studio 2015\Projects\SimulatorApplication\SimulatorApplication\image\cassette.png");
            picCassette.Image = Properties.Resources.cassette;
            picwafer.Image = Properties.Resources.wafer;
            picCassette.Image.Tag = "cassette";

            picChamber.Image = Properties.Resources.new_chamber;


            // lblState.Text = "Idle";
            // lblmTorr.Text = "760 Torr";
            lblCassette.Tag = "";

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            //       pauseSignal = new ManualResetEvent(false);


            if (button2.Tag.ToString() == "")
            {



                if (btnVCH.Text == "Control Mode: Automatic")

                {

                    if (lblProcess.Text == "Idle" && lbltm.Text == "Idle")

                    {


                        LotInformation lot = new LotInformation();
                        DialogResult dr = lot.ShowDialog();
                        scsb = new SqlConnectionStringBuilder();
                        scsb.DataSource = datasource;
                        scsb.InitialCatalog = "RecipeType";
                        scsb.IntegratedSecurity = true;
                        SqlConnection con = new SqlConnection(scsb.ToString());


                        if (dr == DialogResult.OK)
                        {
                            button3.Enabled = true;
                            button4.Enabled = true;
                            button5.Enabled = true;

                            iscancelrecipe = false;
                            if (ispauserobot == false)
                            {

                                //   pauseSignal = new ManualResetEvent(true);
                                //   taskTimer = new Task(timerCallback);
                                //  taskTimer.Start();
                                //    await taskTimer;


                                button2.Enabled = false;
                              //  button2.Tag = "robotStart";


                                con.Open();
                                string SQLnoofwafer = "select noofwafers from cassettewafer where cassetterecipename like @searchcassetterecipename";
                                SqlCommand cmdnoofwafer = new SqlCommand(SQLnoofwafer, con);
                                cmdnoofwafer.Parameters.AddWithValue("@searchcassetterecipename", form2Msg);
                                SqlDataReader readernoofwafer = cmdnoofwafer.ExecuteReader();
                                while (readernoofwafer.Read())
                                {
                                    NoOfwafer.Add(readernoofwafer["noofwafers"].ToString());

                                }
                                con.Close();
                                if (ispauserobot == false && picMain.Image.Tag.ToString() == "mainpicture"&&iscancelrecipe==false)
                                {
                                    await Task.Delay(1000);

                                    con.Open();

                                    SqlCommand cmdevent = new SqlCommand(strEvent, con);
                                    cmdevent.Parameters.AddWithValue("@1", DateTime.Now);
                                    cmdevent.Parameters.AddWithValue("@2", "Machine robot reversal");
                                    cmdevent.Parameters.AddWithValue("@3", "reverse the robot");

                                    cmdevent.ExecuteNonQuery();

                                    con.Close();

                                    picMain.Image = Properties.Resources.picrobotbotton;
                                    picMain.Image.Tag = "picrobotbotton";
                                }
                                if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotbotton" && iscancelrecipe == false)
                                {
                                    await Task.Delay(1000);
                                    /////////////////////////////////////////////////////////////////////////////////////開始掃描Wafers

                                    picMain.Image = Properties.Resources.picrobotanalysis;
                                    picMain.Image.Tag = "picrobotanalysis";

                                    lblLoad.Text = "Loading";
                                    lblLoad.BackColor = Color.LimeGreen;
                                    lblmTorr.BackColor = Color.LimeGreen;
                                    str123 = lot.getLotID();
                                    lbl123.Text = lot.getLotID();
                                    lbl123.BackColor = Color.LimeGreen;
                                    lblCassetteRecipename.Text = form2Msg;
                                    lblCassetteRecipename.BackColor = Color.LimeGreen;
                                    lblState.Text = "Starting";
                                    lblState.BackColor = Color.LimeGreen;
                                    label1.BackColor = Color.LimeGreen;
                                    //  label1.Text = "Analysising.....";
                                    // label1.Font = new Font("微軟正黑體", 10);

                                    await Task.Delay(1000);

                                    picmap.Visible = true;

                                    for (int i = 1; i <= 24; i++)
                                    {
                                        await Task.Delay(50);
                                        picmap.Top -= 13;
                                    }

                                    picmap.Visible = false;

                                    picmap.Top += 312;

                                    await Task.Delay(1000);

                                  picmap1.Visible = true;
                                    for (int j = 1; j <= 24; j++)
                                    {
                                        await Task.Delay(50);
                                      picmap1.Top += 13;
                                    }
                                   picmap1.Visible = false;
                                   picmap1.Top -= 312;
                                    await Task.Delay(1000);



                                }
                                if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotanalysis" && iscancelrecipe == false)
                                {
                                    await Task.Delay(1000);

                                    picMain.Image = Properties.Resources.picrobotbotton;
                                    label1.Text = "";
                                    picMain.Image.Tag = "picrobotbotton2";

                                    //    picwafer.Image = Properties.Resources.waferfull;
                                    //  picwafer.Image.Tag = "waferfull";

                                    foreach (string i in NoOfwafer)
                                    {
                                        if (i == "1")
                                        {

                                            //  picwafer.Image = Properties.Resources.waferA1full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;



                                            picWafer1.Visible = true;

                                        }

                                        else if (i == "2")
                                        {
                                            //    picwafer.Image = Properties.Resources.waferA2full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;


                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;

                                        }

                                        else if (i == "3")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA3full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;




                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                        }
                                        else if (i == "4")
                                        {
                                            //picwafer.Image = Properties.Resources.waferA4full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;



                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                        }
                                        else if (i == "5")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;




                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;
                                        }
                                        else if (i == "6")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA6full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;





                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;
                                            picWafer6.Visible = true;
                                        }
                                        else if (i == "7")
                                        {

                                            // picwafer.Image = Properties.Resources.waferA7full;

                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;




                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;
                                            picWafer6.Visible = true;
                                            picWafer7.Visible = true;
                                        }
                                        else if (i == "8")
                                        {

                                            // picwafer.Image = Properties.Resources.waferA8full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;




                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;
                                            picWafer6.Visible = true;
                                            picWafer7.Visible = true;
                                            picWafer8.Visible = true;

                                        }
                                        else if (i == "9")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA9full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;




                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;
                                            picWafer6.Visible = true;
                                            picWafer7.Visible = true;
                                            picWafer8.Visible = true;
                                            picWafer9.Visible = true;
                                        }
                                        else if (i == "10")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA10full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;





                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;
                                            picWafer6.Visible = true;
                                            picWafer7.Visible = true;
                                            picWafer8.Visible = true;
                                            picWafer9.Visible = true;
                                            picWafer10.Visible = true;


                                        }

                                    }


                                }

                                if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotbotton2" && iscancelrecipe == false)
                                {
                                    await Task.Delay(1000);

                                    // pictRobot.Visible = true;
                                    // picCassette.Image = Properties.Resources.cassette1;
                                    // picCassette.Height -= 150;
                                    // picCassette.Top += 150;
                                    lblCassette.BackColor = Color.Blue;
                                    lblCassette.Tag = "Blue";
                                    // lblCassette.Text = "Cassette";

                                }

                                if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotbotton2" && lblCassette.Tag.ToString() == "Blue" && iscancelrecipe == false)
                                {
                                    await Task.Delay(1000);

                                    //pictRobot.Image = Properties.Resources.new_robot;
                                    picMain.Image = Properties.Resources.mainpicture;
                                    picMain.Image.Tag = "mainpicture2";

                                }
                                //  await Task.Delay(1000);

                                //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                if (ispauserobot == false && picMain.Image.Tag.ToString() == "mainpicture2" && iscancelrecipe == false)
                                {
                                    await Task.Delay(1000);

                                    picMain.Image = Properties.Resources.picrobotintocassette;
                                    picMain.Image.Tag = "picrobotintocassette";
                                    picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                    picCassette.Width += 25;
                                    picCassette.Height += 220;
                                    picCassette.Top -= 205;
                                    picCassette.Image.Tag = "robot_into_cassetteA1";
                                    picCassette.Left += 5;
                                    label1.BackColor = Color.Blue;
                                    lblLoad.Text = "";
                                    lblLoad.BackColor = Color.Blue;
                                    lbl123.BackColor = Color.Blue;
                                    lblState.BackColor = Color.Blue;
                                    lblCassetteRecipename.BackColor = Color.Blue;
                                    lblmTorr.BackColor = Color.Blue;


                                    lblCassette.BackColor = Color.LimeGreen;
                                }


                                await Task.Delay(1000);

                                for (int i = 0; i < NoOfwafer.Count; i++)

                                {


                                    if (int.Parse(NoOfwafer[i]) >= 1)
                                    {
                                        /////////////////////////////////////////////////////////start WaferA1
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassette" && iscancelrecipe == false)
                                        {
                                            picCassette.Image = Properties.Resources.cassette;
                                            await Task.Delay(1000);
                                            if (NoOfwafer[i] == "1")
                                            {
                                                // picwafer.Image = Properties.Resources.wafer;
                                                // picwafer.Image.Tag = "wafer";
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "2")
                                            {
                                                //  picwafer.Image = Properties.Resources.wafermapA2;
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "3")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA3fullA1;
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "4")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA4fullA1;
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "5")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA5fullA1;
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "6")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA5fullA1;
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "7")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA5fullA1;
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "8")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA5fullA1;
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "9")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA5fullA1;
                                                picWafer1.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "10")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA5fullA1;
                                                picWafer1.Visible = false;
                                            }


                                            StartTime = DateTime.Now;


                                            con.Open();

                                            string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                            SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                            cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "1");
                                            cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                            cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                            cmdwaferselection.Parameters.AddWithValue("Logname", lbl123.Text);
                                            cmdwaferselection.ExecuteNonQuery();

                                            con.Close();












                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA1";
                                            // panel1.Visible = true;
                                            //  ovalShape1.Visible = true;
                                            lblwafer.Visible = true;
                                            lblwafer.Text = "A1";
                                            lblCassette.BackColor = Color.Blue;

                                            picCassette.Image = Properties.Resources.cassette3;

                                            // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                            picCassette.Height -= 220;
                                            picCassette.Width -= 25;
                                            picCassette.Top += 205;
                                            picCassette.Image.Tag = "cassette";
                                            picCassette.Left -= 5;
                                            //  await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette;
                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA1" && iscancelrecipe == false)
                                        {
                                            await Task.Delay(1000);



                                            // pictRobot.Image = Properties.Resources.robotleft_A1;
                                            //   picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag = "picrobotAlignerWaferA1";
                                            //  ovalShape1.Visible = true;
                                            // lblwafer.Visible = true;
                                            ovalShape1.Left += 70;
                                            ovalShape1.Top -= 85;
                                            lblwafer.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A1";
                                            lblwafer.Left += 70;
                                            lblwafer.Top -= 85;
                                            // panel1.Visible = false;



                                            //   await Task.Delay(2000);
                                            //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                            //  picMain.Image = Properties.Resources.robotleftA1opencentralize;
                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA1" && iscancelrecipe == false)
                                        {
                                            await Task.Delay(1000);






                                            // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                            //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                            picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                            picMain.Image.Tag = "picrobotintoAlignerWaferA1";
                                            lblCentralize.BackColor = Color.LimeGreen;
                                            ovalShape1.Left += 155;
                                            ovalShape1.Top += 0;
                                            lblwaferright.Visible = false;
                                            lblwaferaligner.Visible = true;
                                            lblwaferaligner.Text = "A1";
                                            lblwafer.Left += 155;
                                            lblwafer.Top += 0;

                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAlignerWaferA1" && iscancelrecipe == false)
                                        {
                                            ////////////////////////////////////////////////////////////////////////////////////
                                            await Task.Delay(2000);
                                            // pictRobot.Visible = true;
                                            // picCentralize.Image = Properties.Resources.centralize2;
                                            // picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag = "picrobotAlignerWaferA1-2";
                                            // ovalShape1.Visible = true;
                                            //picwafer.Visible = true;
                                            lblwaferaligner.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A1";
                                            ovalShape1.Left -= 155;
                                            ovalShape1.Top -= 0;
                                            lblwafer.Left -= 155;
                                            lblwafer.Top -= 0;
                                            lblCentralize.BackColor = Color.Blue;

                                            // await Task.Delay(2000);
                                            // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                            // picMain.Image = Properties.Resources.robotleftA1;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA1-2" && iscancelrecipe == false)
                                        {
                                            await Task.Delay(2000);

                                            //   picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;
                                            picMain.Image.Tag = "picrobotAPMWaferA1";
                                            lblwaferright.Visible = false;
                                            lblwaferup.Visible = true;
                                            lblwaferup.Text = "A1";
                                            ovalShape1.Left -= 82;
                                            ovalShape1.Top -= 76;
                                            lblwafer.Left -= 82;
                                            lblwafer.Top -= 76;



                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA1" && picSV.Visible == true && iscancelrecipe == false)
                                        {
                                            await Task.Delay(1000);

                                            // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                            // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                            picSV.Visible = false;  // open sv of chamber

                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA1" && picSV.Visible == false && iscancelrecipe == false)
                                        {
                                            await Task.Delay(1000);

                                            //pictRobot.Visible = false;
                                            //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            //  picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA1";
                                            // picChamber.Width += 140;
                                            //picChamber.Left -= 150;
                                            //picChamber.Height += 10;
                                            lblwaferup.Visible = false;
                                            lblwaferAPM.Visible = true;
                                            lblwaferAPM.Text = "A1";
                                            ovalShape1.Top -= 145;
                                            ovalShape1.Left += 3;
                                            lblwafer.Top -= 145;
                                            lblwafer.Left += 3;



                                            lblChamber.BackColor = Color.LimeGreen;

                                            chamberload = "LimeGreen";

                                            // loaddata();
                                            // loadchamber1( sender, e);
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA1" && iscancelrecipe == false)
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picwaferinAPM;
                                            picMain.Image.Tag = "picwaferinAPMA1";
                                            ovalShape1.Left -= 1;
                                            ovalShape1.Left += 1;
                                            //  picMain.SendToBack();
                                            // ovalShape1.BringToFront();
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;


                                            //  pictRobot.Visible = true;

                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA1" && picSV.Visible == false && iscancelrecipe == false)
                                        {
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                            picSV.Visible = true;

                                            ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA1 into Chamber
                                            Chamber1 chamber1 = new Chamber1();
                                            chamber1.ShowDialog();

                                           lblRecipe.BackColor = Color.LimeGreen;
                                           lblStepName.BackColor = Color.LimeGreen;

                                            lblnum.BackColor = Color.LimeGreen;

                                            lblData.BackColor = Color.LimeGreen;
                                            lblData.Text = "";
                                            label2.BackColor = Color.LimeGreen;

                                            lblProcess.Text = "Processing";
                                            lblProcess.BackColor = Color.LimeGreen;
                                            lblProcessStep.Text = "Process Step";
                                            lblProcessStep.BackColor = Color.LimeGreen;



                                            con.Open();
                                            string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                            SqlCommand cmd = new SqlCommand(strSQL, con);
                                            cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                            SqlDataReader reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {


                                                lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                            }

                                            con.Close();
                                            con.Open();
                                            string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                            SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                            cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                            SqlDataReader reader1 = cmd1.ExecuteReader();
                                            while (reader1.Read())
                                            {

                                                strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                            }

                                            con.Close();

                                            con.Open();
                                            string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                            SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                            cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                            cmd2.ExecuteNonQuery();



                                            for (int j = 0; j < strStepname1.Count(); j += 1)

                                            {

                                           //     await Task.Delay(1000);

                                                ListStepStartTime.Add(DateTime.Now);


                                                int count = j + 1;


                                                lblStepName.Text = strStepname1[j];
                                                lblnum.Text = "," + count + "/" + strStepname1.Count();


                                                con.Close();

                                                con.Open();
                                                string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                                SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                                cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                                SqlDataReader readerSec = cmdSec.ExecuteReader();


                                                while (readerSec.Read())
                                                {
                                                    mySec1 = readerSec["ProcessTime"].ToString();

                                                    Int32.TryParse(mySec1, out Sec1);

                                                }

                                                for (int k = 1; k <= Sec1; k++)
                                                {
                                                    lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                               //     await Task.Delay(1000);


                                                }
                                                ListStepEndTime.Add(DateTime.Now);

                                                con.Close();

                                                con.Open();

                                                string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,Logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                                SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                                cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                                cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "1");
                                                cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                                cmdmodulerecipe.ExecuteNonQuery();

                                                con.Close();
                                                //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                                con.Open();

                                                string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                                SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                                cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                                cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                                SqlDataReader reader2 = cmd3.ExecuteReader();

                                                while (reader2.Read())
                                                {
                                                    CI2 = reader2["CI2"].ToString();
                                                    BCI3 = reader2["BCI3"].ToString();
                                                    SF6 = reader2["SF6"].ToString();
                                                    CHF3 = reader2["CHF3"].ToString();
                                                    Oxygen = reader2["Oxygen"].ToString();
                                                    Oxygen1 = reader2["Oxygen1"].ToString();
                                                    Nitrogen = reader2["Nitrogen"].ToString();
                                                    Argon = reader2["Argon"].ToString();



                                                }

                                                con.Close();

                                                ///////////////////////////////////////////////////////////////////////////////////////////////////
                                                con.Open();
                                                //  Chamber1 chamber1 = new Chamber1();

                                                string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate,logid,NoOfRecipe) values(@11,@21,@31,@41,@51,@61,@71,@81,@91,@101),(@12,@22,@32,@42,@52,@62,@72,@82,@92,@102),(@13,@23,@33,@43,@53,@63,@73,@83,@93,@103)"
                                                    + ",(@14,@24,@34,@44,@54,@64,@74,@84,@94,@104),(@15,@25,@35,@45,@55,@65,@75,@85,@95,@105),(@16,@26,@36,@46,@56,@66,@76,@86,@96,@106),(@17,@27,@37,@47,@57,@67,@77,@87,@97,@107),(@18,@28,@38,@48,@58,@68,@78,@88,@98,@108)";
                                                SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                                cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                                cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                                cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                                cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                                cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                                cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                                cmdparameter.Parameters.AddWithValue("@21", CI2);
                                                cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@23", SF6);
                                                cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@28", Argon);
                                                cmdparameter.Parameters.AddWithValue("@31", CI2);
                                                cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@33", SF6);
                                                cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@38", Argon);
                                                cmdparameter.Parameters.AddWithValue("@41", CI2);
                                                cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@43", SF6);
                                                cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@48", Argon);
                                                cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@91", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@92", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@93", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@94", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@95", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@96", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@97", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@98", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@101", "1");
                                                cmdparameter.Parameters.AddWithValue("@102", "1");
                                                cmdparameter.Parameters.AddWithValue("@103", "1");
                                                cmdparameter.Parameters.AddWithValue("@104", "1");
                                                cmdparameter.Parameters.AddWithValue("@105", "1");
                                                cmdparameter.Parameters.AddWithValue("@106", "1");
                                                cmdparameter.Parameters.AddWithValue("@107", "1");
                                                cmdparameter.Parameters.AddWithValue("@108", "1");


                                                cmdparameter.ExecuteNonQuery();
                                                con.Close();

                                            }
                                            ///////////////////////////////////////////////


                                            strStepname1.Clear();
                                            ListStepStartTime.Clear();
                                            ListStepEndTime.Clear();

                                            // }





                                            picMain.Image.Tag = "A1finishChamber";

                                            /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "A1finishChamber" && picSV.Visible == true)
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picSV.Visible = false;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "A1finishChamber" && picSV.Visible == false)
                                        {
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA1-2";

                                            ovalShape1.Left += 1;
                                            ovalShape1.Left -= 1;
                                            picChamber.Width += 140;
                                            picChamber.Left -= 150;
                                            picChamber.Height += 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA1-2")
                                        {
                                            await Task.Delay(1000);
                                            label2.BackColor = Color.Blue;
                                            lblProcess.BackColor = Color.Blue;
                                            lblProcessStep.BackColor = Color.Blue;
                                            lblRecipe.BackColor = Color.Blue;
                                            lblStepName.BackColor = Color.Blue;
                                            lblData.BackColor = Color.Blue;
                                            lblnum.BackColor = Color.Blue;

                                            lblProcess.Text = "Idle";
                                            lblProcessStep.Text = "";
                                            lblRecipe.Text = "";
                                            lblStepName.Text = "";
                                            lblnum.Text = "";
                                            lblData.Text = "";


                                            // pictRobot.Visible = true;

                                            picChamber.Image = Properties.Resources.new_chamber1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;
                                            picMain.Image.Tag = "picrobotAPMWaferA1-2";
                                            lblwaferAPM.Visible = false;
                                            lblwaferup.Visible = true;
                                            lblwaferup.Text = "A1";
                                            ovalShape1.Top += 145;
                                            ovalShape1.Left -= 3;
                                            lblwafer.Top += 145;
                                            lblwafer.Left -= 3;

                                            lblChamber.BackColor = Color.Blue;
                                            chamberload = "Blue";
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA1-2" && picSV.Visible == false)
                                        {
                                            await Task.Delay(2000);
                                            picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                            // picMain.Image = Properties.Resources.robotrightA1;
                                            picSV.Visible = true;

                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA1-2" && picSV.Visible == true)
                                        {
                                            await Task.Delay(2000);

                                            // pictRobot.Height += 20;

                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA1-2";
                                            lblwaferup.Visible = false;
                                            lblwafer.Visible = true;
                                            ovalShape1.Top += 162;
                                            lblwafer.Top += 162;
                                            ovalShape1.Left += 12;
                                            lblwafer.Left += 12;
                                            await Task.Delay(2000);

                                            await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                               // picMain.Image = Properties.Resources.robotgetwaferA1;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA1-2")
                                        {
                                            await Task.Delay(1000);

                                            lblCassette.BackColor = Color.LimeGreen;

                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "picrobotintocassette2";
                                            lblwafer.Visible = false;
                                            lblwafer.Visible = false;
                                            ovalShape1.Visible = false;
                                            picCassette.Height += 220;
                                            picCassette.Width += 25;
                                            picCassette.Top -= 205;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassette2")
                                        {
                                            await Task.Delay(2000);
                                            lblCassette.BackColor = Color.Blue;
                                            //  pictRobot.Visible = true;

                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image.Tag = "mainpicture3";
                                            picCassette.Image = Properties.Resources.cassette3;
                                            picCassette.Width -= 25;
                                            picCassette.Height -= 220;
                                            picCassette.Top += 205;
                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "mainpicture3")
                                        {
                                            await Task.Delay(2000);
                                            //  picMain.Image = Properties.Resources.mainpic;
                                            picCassette.Image = Properties.Resources.cassette;
                                            //   picwafer.Image = Properties.Resources.waferfull;
                                            if (NoOfwafer[i] == "1")
                                            {

                                                //   picwafer.Image = Properties.Resources.waferA1full;
                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;



                                                picWafer1.Visible = true;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;

                                            }
                                            if (NoOfwafer[i] == "2")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA2full;
                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;




                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                            }
                                            if (NoOfwafer[i] == "3")
                                            {
                                                //   picwafer.Image = Properties.Resources.waferA3full;

                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;



                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                            }
                                            if (NoOfwafer[i] == "4")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA4full;
                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;



                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                            }

                                            if (NoOfwafer[i] == "5")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA5full;

                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;



                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;
                                                picWafer5.Visible = true;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                            }


                                            //////////////////////////////////////////////////////////////////Save DataLog
                                            if (int.Parse(NoOfwafer[i]) == 1)
                                            {
                                                EndTime = DateTime.Now;


                                                con.Open();

                                                string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                                SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                                cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                                cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                                cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                                cmdinsertdatalog.ExecuteNonQuery();

                                                con.Close();


                                                lblState.Text = "Finished";

                                               

                                            }

                                            if (isStopRobot == true)
                                            {
                                                button2.Enabled = true;

                                                lblState.Text = "stopping";
                                            }

                                            picMain.Image.Tag = "finishWaferA1";
                                           

                                        }

                                        /////////////////////////////////////////////////////////finish waferA1
                                    }












                                    if (int.Parse(NoOfwafer[i]) >= 2)
                                    {
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishWaferA1"&&isStopRobot==false)
                                        {
                                            /////////////////////////////////////////////////////////start WaferA2
                                            lblState.Text = "starting";

                                            await Task.Delay(1000);
                                        

                                            //pictRobot.Image = Properties.Resources.new_robot;
                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image.Tag = "A2mainpicture";
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "A2mainpicture")
                                        {
                                            await Task.Delay(1000);

                                            //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                            // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                            await Task.Delay(1000);

                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "picrobotintocassetteA2";
                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                            picCassette.Width += 25;
                                            picCassette.Height += 220;
                                            picCassette.Top -= 205;
                                            picCassette.Image.Tag = "robot_into_cassetteA1";
                                            picCassette.Left += 5;
                                            label1.BackColor = Color.Blue;
                                            lblLoad.Text = "";
                                            lblLoad.BackColor = Color.Blue;
                                            lbl123.BackColor = Color.Blue;
                                            lblState.BackColor = Color.Blue;
                                            lblCassetteRecipename.BackColor = Color.Blue;
                                            lblmTorr.BackColor = Color.Blue;


                                            lblCassette.BackColor = Color.LimeGreen;
                                            await Task.Delay(1000);
                                            

                                            picCassette.Image = Properties.Resources.cassette;
                                            await Task.Delay(1000);

                                            if (NoOfwafer[i] == "1")
                                            {
                                                //  picwafer.Image = Properties.Resources.wafer;
                                                //picwafer.Image.Tag = "wafer";
                                                picWafer2.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "2")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA1full;

                                                picWafer2.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "3")
                                            {
                                                //   picwafer.Image = Properties.Resources.waferA3fullA2;
                                                picWafer2.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "4")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA4fullA2;
                                                picWafer2.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "5")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA5fullA2;
                                                picWafer2.Visible = false;
                                            }

                                            StartTime = DateTime.Now;


                                            con.Open();

                                            string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                            SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                            cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "2");
                                            cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                            cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                            cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);
                                            cmdwaferselection.ExecuteNonQuery();

                                            con.Close();

                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassetteA2")
                                        {
                                            await Task.Delay(1000);
                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA2";
                                            // panel1.Visible = true;
                                            //  ovalShape1.Visible = true;
                                            lblwafer.Visible = true;
                                            lblwafer.Text = "A2";
                                            lblCassette.BackColor = Color.Blue;

                                            picCassette.Image = Properties.Resources.cassette3;

                                            // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                            picCassette.Height -= 220;
                                            picCassette.Width -= 25;
                                            picCassette.Top += 205;
                                            picCassette.Image.Tag = "cassette";
                                            picCassette.Left -= 5;
                                            //  await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette;
                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA2")
                                        {
                                            await Task.Delay(1000);

                                            

                                            // pictRobot.Image = Properties.Resources.robotleft_A1;
                                            //   picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag = "picrobotAlignerWaferA2";
                                            //  ovalShape1.Visible = true;
                                            // lblwafer.Visible = true;
                                            ovalShape1.Left += 70;
                                            ovalShape1.Top -= 85;
                                            lblwafer.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A2";
                                            lblwafer.Left += 70;
                                            lblwafer.Top -= 85;
                                            // panel1.Visible = false;



                                            //   await Task.Delay(2000);
                                            //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                            //  picMain.Image = Properties.Resources.robotleftA1opencentralize;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA2")
                                        {
                                            await Task.Delay(2000);

                                            
                                            



                                            // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                            //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                            picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                            picMain.Image.Tag = "picrobotintoAlignerWaferA2";
                                            lblCentralize.BackColor = Color.LimeGreen;
                                            ovalShape1.Left += 155;
                                            ovalShape1.Top += 0;
                                            lblwaferright.Visible = false;
                                            lblwaferaligner.Visible = true;
                                            lblwaferaligner.Text = "A2";
                                            lblwafer.Left += 155;
                                            lblwafer.Top += 0;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAlignerWaferA2")
                                        {
                                            ////////////////////////////////////////////////////////////////////////////////////
                                            await Task.Delay(2000);
                                            // pictRobot.Visible = true;
                                            // picCentralize.Image = Properties.Resources.centralize2;
                                            // picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag = "picrobotAlignerWaferA2-2";
                                            // ovalShape1.Visible = true;
                                            //picwafer.Visible = true;
                                            lblwaferaligner.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A2";

                                            ovalShape1.Left -= 155;
                                            ovalShape1.Top -= 0;
                                            lblwafer.Left -= 155;
                                            lblwafer.Top -= 0;
                                            lblCentralize.BackColor = Color.Blue;

                                            // await Task.Delay(2000);
                                            // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                            // picMain.Image = Properties.Resources.robotleftA1;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA2-2")
                                        {
                                            await Task.Delay(2000);

                                            //   picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;
                                            picMain.Image.Tag = "picrobotAPMWaferA2";
                                            lblwaferright.Visible = false;
                                            lblwaferup.Visible = true;
                                            lblwaferup.Text = "A2";
                                            ovalShape1.Left -= 82;
                                            ovalShape1.Top -= 76;
                                            lblwafer.Left -= 82;
                                            lblwafer.Top -= 76;



                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA2" && picSV.Visible == true)
                                        {
                                            await Task.Delay(1000);

                                            // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                            // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                            picSV.Visible = false;  // open sv of chamber
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA2" && picSV.Visible == false)
                                        {
                                            await Task.Delay(1000);

                                            //pictRobot.Visible = false;
                                            //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            //  picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA2";
                                            // picChamber.Width += 140;
                                            //picChamber.Left -= 150;
                                            //picChamber.Height += 10;
                                            lblwaferup.Visible = false;
                                            lblwaferAPM.Visible = true;
                                            lblwaferAPM.Text = "A2";
                                            ovalShape1.Top -= 145;
                                            ovalShape1.Left += 3;
                                            lblwafer.Top -= 145;
                                            lblwafer.Left += 3;



                                            lblChamber.BackColor = Color.LimeGreen;

                                            chamberload = "LimeGreen";

                                            // loaddata();
                                            // loadchamber1( sender, e);
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA2")
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picwaferinAPM;
                                            picMain.Image.Tag = "picwaferinAPMA2";
                                            ovalShape1.Left -= 1;
                                            ovalShape1.Left += 1;
                                            //  picMain.SendToBack();
                                            // ovalShape1.BringToFront();
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;


                                            //  pictRobot.Visible = true;

                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA2" && picSV.Visible == false)
                                        {
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                            picSV.Visible = true;

                                            ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA2 into Chamber

                                            Chamber1 chamber1 = new Chamber1();
                                            chamber1.ShowDialog();

                                            lblRecipe.BackColor = Color.LimeGreen;
                                            lblStepName.BackColor = Color.LimeGreen;

                                            lblnum.BackColor = Color.LimeGreen;

                                            lblData.BackColor = Color.LimeGreen;
                                            lblData.Text = "";
                                            label2.BackColor = Color.LimeGreen;

                                            lblProcess.Text = "Processing";
                                            lblProcess.BackColor = Color.LimeGreen;
                                            lblProcessStep.Text = "Process Step";
                                            lblProcessStep.BackColor = Color.LimeGreen;



                                            con.Open();
                                            string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                            SqlCommand cmd = new SqlCommand(strSQL, con);
                                            cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                            SqlDataReader reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {

                                                lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                            }

                                            con.Close();
                                            con.Open();
                                            string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                            SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                            cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                            SqlDataReader reader1 = cmd1.ExecuteReader();
                                            while (reader1.Read())
                                            {

                                                strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                            }

                                            con.Close();

                                            con.Open();
                                            string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                            SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                            cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                            cmd2.ExecuteNonQuery();



                                            for (int j = 0; j < strStepname1.Count(); j += 1)

                                            {

                                               // await Task.Delay(1000);

                                                ListStepStartTime.Add(DateTime.Now);


                                                int count = j + 1;


                                                lblStepName.Text = strStepname1[j];
                                                lblnum.Text = "," + count + "/" + strStepname1.Count();


                                                con.Close();

                                                con.Open();
                                                string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                                SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                                cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                                SqlDataReader readerSec = cmdSec.ExecuteReader();


                                                while (readerSec.Read())
                                                {
                                                    mySec1 = readerSec["ProcessTime"].ToString();

                                                    Int32.TryParse(mySec1, out Sec1);

                                                }

                                                for (int k = 1; k <= Sec1; k++)
                                                {
                                                    lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                                //    await Task.Delay(1000);


                                                }
                                                ListStepEndTime.Add(DateTime.Now);

                                                con.Close();

                                                con.Open();

                                                string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,Logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                                SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                                cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                                cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "2");
                                                cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);
                                                cmdmodulerecipe.ExecuteNonQuery();

                                                con.Close();
                                                //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                                con.Open();

                                                string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                                SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                                cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                                cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                                SqlDataReader reader2 = cmd3.ExecuteReader();

                                                while (reader2.Read())
                                                {
                                                    CI2 = reader2["CI2"].ToString();
                                                    BCI3 = reader2["BCI3"].ToString();
                                                    SF6 = reader2["SF6"].ToString();
                                                    CHF3 = reader2["CHF3"].ToString();
                                                    Oxygen = reader2["Oxygen"].ToString();
                                                    Oxygen1 = reader2["Oxygen1"].ToString();
                                                    Nitrogen = reader2["Nitrogen"].ToString();
                                                    Argon = reader2["Argon"].ToString();



                                                }

                                                con.Close();

                                                ///////////////////////////////////////////////////////////////////////////////////////////////////
                                                con.Open();
                                             //   Chamber1 chamber1 = new Chamber1();

                                                string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate,logid,noofrecipe) values(@11,@21,@31,@41,@51,@61,@71,@81,@91,@101),(@12,@22,@32,@42,@52,@62,@72,@82,@92,@102),(@13,@23,@33,@43,@53,@63,@73,@83,@93,@103)"
                                                    + ",(@14,@24,@34,@44,@54,@64,@74,@84,@94,@104),(@15,@25,@35,@45,@55,@65,@75,@85,@95,@105),(@16,@26,@36,@46,@56,@66,@76,@86,@96,@106),(@17,@27,@37,@47,@57,@67,@77,@87,@97,@107),(@18,@28,@38,@48,@58,@68,@78,@88,@98,@108)";
                                                SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                                cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                                cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                                cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                                cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                                cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                                cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                                cmdparameter.Parameters.AddWithValue("@21", CI2);
                                                cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@23", SF6);
                                                cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@28", Argon);
                                                cmdparameter.Parameters.AddWithValue("@31", CI2);
                                                cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@33", SF6);
                                                cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@38", Argon);
                                                cmdparameter.Parameters.AddWithValue("@41", CI2);
                                                cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@43", SF6);
                                                cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@48", Argon);
                                                cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@91", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@92", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@93", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@94", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@95", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@96", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@97", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@98", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@101","2");
                                                cmdparameter.Parameters.AddWithValue("@102","2");
                                                cmdparameter.Parameters.AddWithValue("@103","2");
                                                cmdparameter.Parameters.AddWithValue("@104","2");
                                                cmdparameter.Parameters.AddWithValue("@105","2");
                                                cmdparameter.Parameters.AddWithValue("@106","2");
                                                cmdparameter.Parameters.AddWithValue("@107","2");
                                                cmdparameter.Parameters.AddWithValue("@108","2");
                                                cmdparameter.ExecuteNonQuery();
                                                con.Close();

                                            }
                                            ///////////////////////////////////////////////


                                            strStepname1.Clear();
                                            ListStepStartTime.Clear();
                                            ListStepEndTime.Clear();

                                            // }











                                            /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA2" && picSV.Visible == true)
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picSV.Visible = false;
                                            picMain.Image.Tag = "waferA2finishChamber";
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "waferA2finishChamber")
                                        {
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA2-2";
                                            ovalShape1.Left += 1;
                                            ovalShape1.Left -= 1;
                                            picChamber.Width += 140;
                                            picChamber.Left -= 150;
                                            picChamber.Height += 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA2-2")
                                        {
                                            await Task.Delay(1000);
                                            label2.BackColor = Color.Blue;
                                            lblProcess.BackColor = Color.Blue;
                                            lblProcessStep.BackColor = Color.Blue;
                                            lblRecipe.BackColor = Color.Blue;
                                            lblStepName.BackColor = Color.Blue;
                                            lblData.BackColor = Color.Blue;
                                            lblnum.BackColor = Color.Blue;

                                            lblProcess.Text = "Idle";
                                            lblProcessStep.Text = "";
                                            lblRecipe.Text = "";
                                            lblStepName.Text = "";
                                            lblnum.Text = "";
                                            lblData.Text = "";


                                            // pictRobot.Visible = true;

                                            picChamber.Image = Properties.Resources.new_chamber1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;
                                            picMain.Image.Tag = "picrobotAPMWaferA2-2";
                                            lblwaferAPM.Visible = false;
                                            lblwaferup.Visible = true;

                                            ovalShape1.Top += 145;
                                            ovalShape1.Left -= 3;
                                            lblwafer.Top += 145;
                                            lblwafer.Left -= 3;

                                            lblChamber.BackColor = Color.Blue;
                                            chamberload = "Blue";
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA2-2" && picSV.Visible == false)
                                        {
                                            await Task.Delay(2000);
                                            picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                            // picMain.Image = Properties.Resources.robotrightA1;
                                            picSV.Visible = true;


                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA2-2" && picSV.Visible == true)
                                        {
                                            await Task.Delay(2000);

                                            // pictRobot.Height += 20;

                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA2-2";
                                            lblwaferup.Visible = false;
                                            lblwafer.Visible = true;
                                            ovalShape1.Top += 162;
                                            lblwafer.Top += 162;
                                            ovalShape1.Left += 12;
                                            lblwafer.Left += 12;
                                            await Task.Delay(2000);

                                            await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                               // picMain.Image = Properties.Resources.robotgetwaferA1;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA2-2")
                                        {
                                            await Task.Delay(1000);

                                            lblCassette.BackColor = Color.LimeGreen;

                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "A2picrobotintocassette2";
                                            lblwafer.Visible = false;
                                            lblwafer.Visible = false;
                                            ovalShape1.Visible = false;
                                            picCassette.Height += 220;
                                            picCassette.Width += 25;
                                            picCassette.Top -= 205;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "A2picrobotintocassette2")
                                        {
                                            await Task.Delay(2000);
                                            lblCassette.BackColor = Color.Blue;
                                            //  pictRobot.Visible = true;

                                            picMain.Image = Properties.Resources.mainpicture;
                                            picCassette.Image = Properties.Resources.cassette3;
                                            picCassette.Width -= 25;
                                            picCassette.Height -= 220;
                                            picCassette.Top += 205;
                                            await Task.Delay(2000);
                                            //  picMain.Image = Properties.Resources.mainpic;
                                            picCassette.Image = Properties.Resources.cassette;
                                            //  picwafer.Image = Properties.Resources.waferfull;
                                            if (NoOfwafer[i] == "1")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA1full;
                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;

                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;

                                                picWafer1.Visible = true;
                                            }
                                            if (NoOfwafer[i] == "2")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA2full;
                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;


                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                            }
                                            if (NoOfwafer[i] == "3")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA3full;
                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;

                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;


                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                            }
                                            if (NoOfwafer[i] == "4")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA4full;
                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;

                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;


                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;
                                            }

                                            if (NoOfwafer[i] == "5")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA5full;
                                                picWafer1.Visible = false;
                                                picWafer2.Visible = false;
                                                picWafer3.Visible = false;
                                                picWafer4.Visible = false;
                                                picWafer5.Visible = false;
                                                picWafer6.Visible = false;
                                                picWafer7.Visible = false;
                                                picWafer8.Visible = false;
                                                picWafer9.Visible = false;
                                                picWafer10.Visible = false;
                                                picWafer11.Visible = false;
                                                picWafer12.Visible = false;
                                                picWafer13.Visible = false;
                                                picWafer14.Visible = false;
                                                picWafer15.Visible = false;
                                                picWafer16.Visible = false;
                                                picWafer17.Visible = false;
                                                picWafer18.Visible = false;
                                                picWafer19.Visible = false;
                                                picWafer20.Visible = false;
                                                picWafer21.Visible = false;
                                                picWafer22.Visible = false;
                                                picWafer23.Visible = false;
                                                picWafer24.Visible = false;
                                                picWafer25.Visible = false;

                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;


                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;
                                                picWafer5.Visible = true;
                                            }

                                            //////////////////////////////////////////////////////////////////Save DataLog
                                            if (int.Parse(NoOfwafer[i]) == 2)
                                            {
                                                EndTime = DateTime.Now;


                                                con.Open();

                                                string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                                SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                                cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                                cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                                cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                                cmdinsertdatalog.ExecuteNonQuery();

                                                con.Close();



                                                lblState.Text = "Finished";
                                              

                                               

                                            }

                                            if (isStopRobot == true)
                                            {
                                                button2.Enabled = true;
                                                lblState.Text = "Stopping";
                                            }
                                            picMain.Image.Tag = "finishWaferA2";
                                        }
                                        /////////////////////////////////////////////////////////finish waferA2
                                    }












                                    if (int.Parse(NoOfwafer[i]) >= 3)
                                    {
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishWaferA2"&&isStopRobot==false)
                                        {
                                            /////////////////////////////////////////////////////////start WaferA3

                                            await Task.Delay(1000);

                                            //pictRobot.Image = Properties.Resources.new_robot;
                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image.Tag = "A3mainpicture";
                                            await Task.Delay(1000);

                                            //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                            // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "A3mainpicture")
                                        {
                                            await Task.Delay(1000);

                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "picrobotintocassetteA3";
                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                            picCassette.Width += 25;
                                            picCassette.Height += 220;
                                            picCassette.Top -= 205;
                                            picCassette.Image.Tag = "robot_into_cassetteA1";
                                            picCassette.Left += 5;
                                            label1.BackColor = Color.Blue;
                                            lblLoad.Text = "";
                                            lblLoad.BackColor = Color.Blue;
                                            lbl123.BackColor = Color.Blue;
                                            lblState.BackColor = Color.Blue;
                                            lblCassetteRecipename.BackColor = Color.Blue;
                                            lblmTorr.BackColor = Color.Blue;


                                            lblCassette.BackColor = Color.LimeGreen;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassetteA3")
                                        {
                                            await Task.Delay(1000);




                                            picCassette.Image = Properties.Resources.cassette;
                                            await Task.Delay(1000);

                                            if (NoOfwafer[i] == "1")
                                            {
                                                // picwafer.Image = Properties.Resources.wafer;
                                                //  picwafer.Image.Tag = "wafer";
                                                picWafer3.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "2")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA1full;
                                                picWafer3.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "3")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA2full;
                                                picWafer3.Visible = false;

                                            }
                                            else if (NoOfwafer[i] == "4")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA4fullA3;
                                                picWafer3.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "5")
                                            {
                                                //   picwafer.Image = Properties.Resources.waferA5fullA3;
                                                picWafer3.Visible = false;
                                            }

                                            StartTime = DateTime.Now;


                                            con.Open();

                                            string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                            SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                            cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "3");
                                            cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                            cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                            cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);
                                            cmdwaferselection.ExecuteNonQuery();

                                            con.Close();




                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA3";
                                            // panel1.Visible = true;
                                            //  ovalShape1.Visible = true;
                                            lblwafer.Visible = true;
                                            lblwafer.Text = "A3";

                                            lblCassette.BackColor = Color.Blue;

                                            picCassette.Image = Properties.Resources.cassette3;

                                            // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                            picCassette.Height -= 220;
                                            picCassette.Width -= 25;
                                            picCassette.Top += 205;
                                            picCassette.Image.Tag = "cassette";
                                            picCassette.Left -= 5;
                                            //  await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette;
                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA3")
                                        {
                                            await Task.Delay(1000);



                                            // pictRobot.Image = Properties.Resources.robotleft_A1;
                                            //   picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag = "picrobotAlignerWaferA3";
                                            //  ovalShape1.Visible = true;
                                            // lblwafer.Visible = true;
                                            ovalShape1.Left += 70;
                                            ovalShape1.Top -= 85;
                                            lblwafer.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A3";
                                            lblwafer.Left += 70;
                                            lblwafer.Top -= 85;
                                            // panel1.Visible = false;



                                            //   await Task.Delay(2000);
                                            //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                            //  picMain.Image = Properties.Resources.robotleftA1opencentralize;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA3")
                                        {
                                            await Task.Delay(2000);






                                            // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                            //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                            picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                            picMain.Image.Tag = "picrobotintoAlignerWaferA3";
                                            lblCentralize.BackColor = Color.LimeGreen;
                                            ovalShape1.Left += 155;
                                            ovalShape1.Top += 0;
                                            lblwaferright.Visible = false;
                                            lblwaferaligner.Visible = true;
                                            lblwaferaligner.Text = "A3";
                                            lblwafer.Left += 155;
                                            lblwafer.Top += 0;


                                            ////////////////////////////////////////////////////////////////////////////////////
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAlignerWaferA3")
                                        {
                                            await Task.Delay(2000);
                                            // pictRobot.Visible = true;
                                            // picCentralize.Image = Properties.Resources.centralize2;
                                            // picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;

                                            picMain.Image.Tag = "picrobotAlignerWaferA3-2";
                                            // ovalShape1.Visible = true;
                                            //picwafer.Visible = true;
                                            lblwaferaligner.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A3";
                                            ovalShape1.Left -= 155;
                                            ovalShape1.Top -= 0;
                                            lblwafer.Left -= 155;
                                            lblwafer.Top -= 0;
                                            lblCentralize.BackColor = Color.Blue;

                                            // await Task.Delay(2000);
                                            // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                            // picMain.Image = Properties.Resources.robotleftA1;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA3-2")
                                        {
                                            await Task.Delay(2000);

                                            //   picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;
                                            picMain.Image.Tag = "picrobotAPMWaferA3";
                                            lblwaferright.Visible = false;
                                            lblwaferup.Visible = true;
                                            lblwaferup.Text = "A3";
                                            ovalShape1.Left -= 82;
                                            ovalShape1.Top -= 76;
                                            lblwafer.Left -= 82;
                                            lblwafer.Top -= 76;



                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA3" && picSV.Visible == true)
                                        {
                                            await Task.Delay(1000);

                                            // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                            // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                            picSV.Visible = false;  // open sv of chamber
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA3" && picSV.Visible == false)
                                        {
                                            await Task.Delay(1000);

                                            //pictRobot.Visible = false;
                                            //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            //  picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA3";
                                            // picChamber.Width += 140;
                                            //picChamber.Left -= 150;
                                            //picChamber.Height += 10;
                                            lblwaferup.Visible = false;
                                            lblwaferAPM.Visible = true;
                                            lblwaferAPM.Text = "A3";
                                            ovalShape1.Top -= 145;
                                            ovalShape1.Left += 3;
                                            lblwafer.Top -= 145;
                                            lblwafer.Left += 3;



                                            lblChamber.BackColor = Color.LimeGreen;

                                            chamberload = "LimeGreen";

                                            // loaddata();
                                            // loadchamber1( sender, e);
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA3")
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picwaferinAPM;
                                            picMain.Image.Tag = "picwaferinAPMA3";
                                            ovalShape1.Left -= 1;
                                            ovalShape1.Left += 1;
                                            //  picMain.SendToBack();
                                            // ovalShape1.BringToFront();
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;


                                            //  pictRobot.Visible = true;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA3" && picSV.Visible == false)
                                        {
                                            await Task.Delay(1000);
                                             
                                            picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                            picSV.Visible = true;

                                            ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA3 into Chamber

                                            Chamber1 chamber1 = new Chamber1();
                                            chamber1.ShowDialog();


                                            lblRecipe.BackColor = Color.LimeGreen;
                                            lblStepName.BackColor = Color.LimeGreen;

                                            lblnum.BackColor = Color.LimeGreen;

                                            lblData.BackColor = Color.LimeGreen;
                                            lblData.Text = "";
                                            label2.BackColor = Color.LimeGreen;

                                            lblProcess.Text = "Processing";
                                            lblProcess.BackColor = Color.LimeGreen;
                                            lblProcessStep.Text = "Process Step";
                                            lblProcessStep.BackColor = Color.LimeGreen;



                                            con.Open();
                                            string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                            SqlCommand cmd = new SqlCommand(strSQL, con);
                                            cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                            SqlDataReader reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {


                                                lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                            }

                                            con.Close();
                                            con.Open();
                                            string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                            SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                            cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                            SqlDataReader reader1 = cmd1.ExecuteReader();
                                            while (reader1.Read())
                                            {


                                                strStepname1.Add(string.Format("{0}", reader1["StepName"]));




                                            }

                                            con.Close();

                                            con.Open();
                                            string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                            SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                            cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                            cmd2.ExecuteNonQuery();



                                            for (int j = 0; j < strStepname1.Count(); j += 1)

                                            {

                                               // await Task.Delay(1000);

                                                ListStepStartTime.Add(DateTime.Now);


                                                int count = j + 1;


                                                lblStepName.Text = strStepname1[j];
                                                lblnum.Text = "," + count + "/" + strStepname1.Count();


                                                con.Close();

                                                con.Open();
                                                string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                                SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                                cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                                SqlDataReader readerSec = cmdSec.ExecuteReader();


                                                while (readerSec.Read())
                                                {
                                                    mySec1 = readerSec["ProcessTime"].ToString();

                                                    Int32.TryParse(mySec1, out Sec1);

                                                }

                                                for (int k = 1; k <= Sec1; k++)
                                                {
                                                    lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                               //     await Task.Delay(1000);


                                                }
                                                ListStepEndTime.Add(DateTime.Now);

                                                con.Close();

                                                con.Open();

                                                string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                                SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                                cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                                cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "3");
                                                cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                                cmdmodulerecipe.ExecuteNonQuery();

                                                con.Close();
                                                //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                                con.Open();

                                                string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                                SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                                cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                                cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                                SqlDataReader reader2 = cmd3.ExecuteReader();

                                                while (reader2.Read())
                                                {
                                                    CI2 = reader2["CI2"].ToString();
                                                    BCI3 = reader2["BCI3"].ToString();
                                                    SF6 = reader2["SF6"].ToString();
                                                    CHF3 = reader2["CHF3"].ToString();
                                                    Oxygen = reader2["Oxygen"].ToString();
                                                    Oxygen1 = reader2["Oxygen1"].ToString();
                                                    Nitrogen = reader2["Nitrogen"].ToString();
                                                    Argon = reader2["Argon"].ToString();



                                                }

                                                con.Close();

                                                ///////////////////////////////////////////////////////////////////////////////////////////////////
                                                con.Open();
                                              //  Chamber1 chamber1 = new Chamber1();

                                                string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate,logid) values(@11,@21,@31,@41,@51,@61,@71,@81,@91),(@12,@22,@32,@42,@52,@62,@72,@82,@92),(@13,@23,@33,@43,@53,@63,@73,@83,@93)"
                                                    + ",(@14,@24,@34,@44,@54,@64,@74,@84,@94),(@15,@25,@35,@45,@55,@65,@75,@85,@95),(@16,@26,@36,@46,@56,@66,@76,@86,@96),(@17,@27,@37,@47,@57,@67,@77,@87,@97),(@18,@28,@38,@48,@58,@68,@78,@88,@98)";
                                                SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                                cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                                cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                                cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                                cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                                cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                                cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                                cmdparameter.Parameters.AddWithValue("@21", CI2);
                                                cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@23", SF6);
                                                cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@28", Argon);
                                                cmdparameter.Parameters.AddWithValue("@31", CI2);
                                                cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@33", SF6);
                                                cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@38", Argon);
                                                cmdparameter.Parameters.AddWithValue("@41", CI2);
                                                cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@43", SF6);
                                                cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@48", Argon);
                                                cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@91", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@92", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@93", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@94", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@95", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@96", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@97", lbl123.Text);
                                                cmdparameter.Parameters.AddWithValue("@98", lbl123.Text);


                                                cmdparameter.ExecuteNonQuery();
                                                con.Close();

                                            }
                                            ///////////////////////////////////////////////


                                            strStepname1.Clear();
                                            ListStepStartTime.Clear();
                                            ListStepEndTime.Clear();

                                            // }











                                            /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA3" && picSV.Visible == true)
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picSV.Visible = false;
                                            picMain.Image.Tag = "A3finishChamber";
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "A3finishChamber")
                                        {
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA3-2";
                                            ovalShape1.Left += 1;
                                            ovalShape1.Left -= 1;
                                            picChamber.Width += 140;
                                            picChamber.Left -= 150;
                                            picChamber.Height += 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA3-2")
                                        {
                                            await Task.Delay(1000);
                                            label2.BackColor = Color.Blue;
                                            lblProcess.BackColor = Color.Blue;
                                            lblProcessStep.BackColor = Color.Blue;
                                            lblRecipe.BackColor = Color.Blue;
                                            lblStepName.BackColor = Color.Blue;
                                            lblData.BackColor = Color.Blue;
                                            lblnum.BackColor = Color.Blue;

                                            lblProcess.Text = "Idle";
                                            lblProcessStep.Text = "";
                                            lblRecipe.Text = "";
                                            lblStepName.Text = "";
                                            lblnum.Text = "";
                                            lblData.Text = "";


                                            // pictRobot.Visible = true;

                                            picChamber.Image = Properties.Resources.new_chamber1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;
                                            picMain.Image.Tag = "picrobotAPMWaferA3-2";
                                            lblwaferAPM.Visible = false;
                                            lblwaferup.Visible = true;
                                            ovalShape1.Top += 145;
                                            ovalShape1.Left -= 3;
                                            lblwafer.Top += 145;
                                            lblwafer.Left -= 3;

                                            lblChamber.BackColor = Color.Blue;
                                            chamberload = "Blue";
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA3-2" && picSV.Visible == false)
                                        {
                                            await Task.Delay(2000);
                                            picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                            // picMain.Image = Properties.Resources.robotrightA1;
                                            picSV.Visible = true;


                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA3-2" && picSV.Visible == true)
                                        {
                                            await Task.Delay(2000);

                                            // pictRobot.Height += 20;

                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA3-2";
                                            lblwaferup.Visible = false;
                                            lblwafer.Visible = true;
                                            ovalShape1.Top += 162;
                                            lblwafer.Top += 162;
                                            ovalShape1.Left += 12;
                                            lblwafer.Left += 12;

                                            await Task.Delay(2000);

                                            await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                               // picMain.Image = Properties.Resources.robotgetwaferA1;
                                            await Task.Delay(1000);

                                            lblCassette.BackColor = Color.LimeGreen;

                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA3-2")
                                        {
                                            await Task.Delay(1000);
                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "A3picrobotintocassette-2";
                                            lblwafer.Visible = false;
                                            lblwafer.Visible = false;
                                            ovalShape1.Visible = false;
                                            picCassette.Height += 220;
                                            picCassette.Width += 25;
                                            picCassette.Top -= 205;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "A3picrobotintocassette-2")
                                        {
                                            await Task.Delay(2000);
                                            lblCassette.BackColor = Color.Blue;
                                            //  pictRobot.Visible = true;

                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image.Tag = "A3mainpicture-2";
                                            picCassette.Image = Properties.Resources.cassette3;
                                            picCassette.Width -= 25;
                                            picCassette.Height -= 220;
                                            picCassette.Top += 205;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "A3mainpicture-2")
                                        {
                                            await Task.Delay(2000);
                                            //  picMain.Image = Properties.Resources.mainpic;
                                            picCassette.Image = Properties.Resources.cassette;
                                            // picwafer.Image = Properties.Resources.waferfull;
                                            if (NoOfwafer[i] == "1")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA1full;
                                                picWafer1.Visible = true;
                                            }
                                            if (NoOfwafer[i] == "2")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA2full;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                              
                                            }
                                            if (NoOfwafer[i] == "3")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA3full;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;

                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                                picWafer3.Image = Properties.Resources.picWaferGreen;
                                            }
                                            if (NoOfwafer[i] == "4")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA4full;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;

                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                                picWafer3.Image = Properties.Resources.picWaferGreen;

                                            }

                                            if (NoOfwafer[i] == "5")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA5full;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;
                                                picWafer5.Visible = true;

                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                                picWafer3.Image = Properties.Resources.picWaferGreen;
                                            }


                                            //////////////////////////////////////////////////////////////////Save DataLog
                                            if (int.Parse(NoOfwafer[i]) == 3)
                                            {
                                                EndTime = DateTime.Now;


                                                con.Open();

                                                string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                                SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                                cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                                cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                                cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                                cmdinsertdatalog.ExecuteNonQuery();

                                                con.Close();



                                                lblState.Text = "Finished";
                                               

                                            }

                                            if (isStopRobot == true)
                                            {
                                                button2.Enabled = true;
                                                lblState.Text = "Stopping";
                                            }
                                            picMain.Image.Tag = "finishWaferA3";
                                        }
                                        /////////////////////////////////////////////////////////finish waferA3
                                    }









                                      if (int.Parse(NoOfwafer[i]) >= 4)
                                      {
                                          /////////////////////////////////////////////////////////start WaferA4
                                          if(ispauserobot==false&&picMain.Image.Tag.ToString()=="finishWaferA3"&&isStopRobot==false)
                                          await Task.Delay(1000);

                                          //pictRobot.Image = Properties.Resources.new_robot;
                                          picMain.Image = Properties.Resources.mainpicture;
                                        picMain.Image.Tag = "mainpictureA4";
                                          await Task.Delay(1000);

                                        //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                        // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "mainpictureA4")
                                        {
                                            await Task.Delay(1000);

                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "picrobotintocassetteA4";
                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                            picCassette.Width += 25;
                                            picCassette.Height += 220;
                                            picCassette.Top -= 205;
                                            picCassette.Image.Tag = "robot_into_cassetteA1";
                                            picCassette.Left += 5;
                                            label1.BackColor = Color.Blue;
                                            lblLoad.Text = "";
                                            lblLoad.BackColor = Color.Blue;
                                            lbl123.BackColor = Color.Blue;
                                            lblState.BackColor = Color.Blue;
                                            lblCassetteRecipename.BackColor = Color.Blue;
                                            lblmTorr.BackColor = Color.Blue;


                                            lblCassette.BackColor = Color.LimeGreen;
                                            await Task.Delay(1000);




                                            picCassette.Image = Properties.Resources.cassette;

                                            await Task.Delay(1000);

                                            if (NoOfwafer[i] == "1")
                                            {
                                                //  picwafer.Image = Properties.Resources.wafer;
                                                //  picwafer.Image.Tag = "wafer";
                                                picWafer4.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "2")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA1full;
                                                picWafer4.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "3")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA2full;
                                                picWafer4.Visible = false;

                                            }
                                            else if (NoOfwafer[i] == "4")
                                            {
                                                //   picwafer.Image = Properties.Resources.waferA3full;
                                                picWafer4.Visible = false;
                                            }
                                            else if (NoOfwafer[i] == "5")
                                            {
                                                //   picwafer.Image = Properties.Resources.waferA5fullA4;
                                                picWafer4.Visible = false;
                                            }

                                            StartTime = DateTime.Now;


                                            con.Open();

                                            string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                            SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                            cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "4");
                                            cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                            cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                            cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);
                                            cmdwaferselection.ExecuteNonQuery();

                                            con.Close();





                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassetteA4")
                                        {

                                            await Task.Delay(1000);
                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA4";
                                            // panel1.Visible = true;
                                            //  ovalShape1.Visible = true;
                                            lblwafer.Visible = true;
                                            lblwafer.Text = "A4";

                                            lblCassette.BackColor = Color.Blue;

                                            picCassette.Image = Properties.Resources.cassette3;

                                            // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                            picCassette.Height -= 220;
                                            picCassette.Width -= 25;
                                            picCassette.Top += 205;
                                            picCassette.Image.Tag = "cassette";
                                            picCassette.Left -= 5;
                                            //  await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette;
                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA4")
                                        {
                                            await Task.Delay(1000);



                                            // pictRobot.Image = Properties.Resources.robotleft_A1;
                                            //   picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag= "picrobotAlignerWaferA4";
                                            //  ovalShape1.Visible = true;
                                            // lblwafer.Visible = true;
                                            ovalShape1.Left += 70;
                                            ovalShape1.Top -= 85;
                                            lblwafer.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A4";
                                            lblwafer.Left += 70;
                                            lblwafer.Top -= 85;
                                            // panel1.Visible = false;



                                            //   await Task.Delay(2000);
                                            //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                            //  picMain.Image = Properties.Resources.robotleftA1opencentralize;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA4")
                                        {
                                            await Task.Delay(2000);






                                            // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                            //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                            picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                            picMain.Image.Tag = "picrobotintoAlignerWaferA4";
                                            lblCentralize.BackColor = Color.LimeGreen;
                                            ovalShape1.Left += 155;
                                            ovalShape1.Top += 0;
                                            lblwaferright.Visible = false;
                                            lblwaferaligner.Visible = true;
                                            lblwaferaligner.Text = "A4";
                                            lblwafer.Left += 155;
                                            lblwafer.Top += 0;

                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAlignerWaferA4")
                                        {
                                            ////////////////////////////////////////////////////////////////////////////////////
                                            await Task.Delay(2000);
                                            // pictRobot.Visible = true;
                                            // picCentralize.Image = Properties.Resources.centralize2;
                                            // picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag = "picrobotAlignerWaferA4-2";
                                            // ovalShape1.Visible = true;
                                            //picwafer.Visible = true;
                                            lblwaferaligner.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A4";
                                            ovalShape1.Left -= 155;
                                            ovalShape1.Top -= 0;
                                            lblwafer.Left -= 155;
                                            lblwafer.Top -= 0;
                                            lblCentralize.BackColor = Color.Blue;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA4-2")
                                        {
                                            // await Task.Delay(2000);
                                            // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                            // picMain.Image = Properties.Resources.robotleftA1;
                                            await Task.Delay(2000);

                                            //   picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;
                                            picMain.Image.Tag = "picrobotAPMWaferA4";
                                            lblwaferright.Visible = false;
                                            lblwaferup.Visible = true;
                                            lblwaferup.Text = "A4";
                                            ovalShape1.Left -= 82;
                                            ovalShape1.Top -= 76;
                                            lblwafer.Left -= 82;
                                            lblwafer.Top -= 76;

                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA4")
                                        {

                                            await Task.Delay(1000);

                                            // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                            // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                            picSV.Visible = false;  // open sv of chamber
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA4" && picSV.Visible == false)
                                        {
                                            await Task.Delay(1000);

                                            //pictRobot.Visible = false;
                                            //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            //  picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA4";
                                            // picChamber.Width += 140;
                                            //picChamber.Left -= 150;
                                            //picChamber.Height += 10;
                                            lblwaferup.Visible = false;
                                            lblwaferAPM.Visible = true;
                                            lblwaferAPM.Text = "A4";
                                            ovalShape1.Top -= 145;
                                            ovalShape1.Left += 3;
                                            lblwafer.Top -= 145;
                                            lblwafer.Left += 3;



                                            lblChamber.BackColor = Color.LimeGreen;

                                            chamberload = "LimeGreen";

                                            // loaddata();
                                            // loadchamber1( sender, e);

                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA4")
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picwaferinAPM;


                                            picMain.Image.Tag = "picwaferinAPMA4";
                                            ovalShape1.Left -= 1;
                                            ovalShape1.Left += 1;
                                            //  picMain.SendToBack();
                                            // ovalShape1.BringToFront();
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;


                                            //  pictRobot.Visible = true;

                                        }
                                        if(ispauserobot==false&&picMain.Image.Tag.ToString()== "picwaferinAPMA4"&&picSV.Visible==false)
                                        { 
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                            picSV.Visible = true;

                                            //////////////////////////////////////////////////////////////////////////////////////////// ///////////WaferA4 into Chamber
                                            Chamber1 chamber1 = new Chamber1();
                                            chamber1.ShowDialog();

                                            lblRecipe.BackColor = Color.LimeGreen;
                                            lblStepName.BackColor = Color.LimeGreen;

                                            lblnum.BackColor = Color.LimeGreen;

                                            lblData.BackColor = Color.LimeGreen;
                                            lblData.Text = "";
                                            label2.BackColor = Color.LimeGreen;

                                            lblProcess.Text = "Processing";
                                            lblProcess.BackColor = Color.LimeGreen;
                                            lblProcessStep.Text = "Process Step";
                                            lblProcessStep.BackColor = Color.LimeGreen;



                                            con.Open();
                                            string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                            SqlCommand cmd = new SqlCommand(strSQL, con);
                                            cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                            SqlDataReader reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {

                                                lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                            }

                                            con.Close();
                                            con.Open();
                                            string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                            SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                            cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                            SqlDataReader reader1 = cmd1.ExecuteReader();
                                            while (reader1.Read())
                                            {

                                                strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                            }

                                            con.Close();

                                            con.Open();
                                            string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                            SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                            cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                            cmd2.ExecuteNonQuery();



                                            for (int j = 0; j < strStepname1.Count(); j += 1)

                                            {

                                              //  await Task.Delay(1000);

                                                ListStepStartTime.Add(DateTime.Now);


                                                int count = j + 1;


                                                lblStepName.Text = strStepname1[j];
                                                lblnum.Text = "," + count + "/" + strStepname1.Count();


                                                con.Close();

                                                con.Open();
                                                string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                                SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                                cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                                SqlDataReader readerSec = cmdSec.ExecuteReader();


                                                while (readerSec.Read())
                                                {
                                                    mySec1 = readerSec["ProcessTime"].ToString();

                                                    Int32.TryParse(mySec1, out Sec1);

                                                }

                                                for (int k = 1; k <= Sec1; k++)
                                                {
                                                    lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                                   // await Task.Delay(1000);


                                                }
                                                ListStepEndTime.Add(DateTime.Now);

                                                con.Close();

                                                con.Open();

                                                string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                                SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                                cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                                cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "4");
                                                cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                                cmdmodulerecipe.ExecuteNonQuery();

                                                con.Close();
                                                //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                                con.Open();

                                                string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                                SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                                cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                                cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                                SqlDataReader reader2 = cmd3.ExecuteReader();

                                                while (reader2.Read())
                                                {
                                                    CI2 = reader2["CI2"].ToString();
                                                    BCI3 = reader2["BCI3"].ToString();
                                                    SF6 = reader2["SF6"].ToString();
                                                    CHF3 = reader2["CHF3"].ToString();
                                                    Oxygen = reader2["Oxygen"].ToString();
                                                    Oxygen1 = reader2["Oxygen1"].ToString();
                                                    Nitrogen = reader2["Nitrogen"].ToString();
                                                    Argon = reader2["Argon"].ToString();



                                                }

                                                con.Close();

                                                ///////////////////////////////////////////////////////////////////////////////////////////////////
                                                con.Open();
                                              //  Chamber1 chamber1 = new Chamber1();

                                                string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate) values(@11,@21,@31,@41,@51,@61,@71,@81),(@12,@22,@32,@42,@52,@62,@72,@82),(@13,@23,@33,@43,@53,@63,@73,@83)"
                                                    + ",(@14,@24,@34,@44,@54,@64,@74,@84),(@15,@25,@35,@45,@55,@65,@75,@85),(@16,@26,@36,@46,@56,@66,@76,@86),(@17,@27,@37,@47,@57,@67,@77,@87),(@18,@28,@38,@48,@58,@68,@78,@88)";
                                                SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                                cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                                cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                                cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                                cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                                cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                                cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                                cmdparameter.Parameters.AddWithValue("@21", CI2);
                                                cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@23", SF6);
                                                cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@28", Argon);
                                                cmdparameter.Parameters.AddWithValue("@31", CI2);
                                                cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@33", SF6);
                                                cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@38", Argon);
                                                cmdparameter.Parameters.AddWithValue("@41", CI2);
                                                cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@43", SF6);
                                                cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@48", Argon);
                                                cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);


                                                cmdparameter.ExecuteNonQuery();
                                                con.Close();

                                            }
                                            ///////////////////////////////////////////////


                                            strStepname1.Clear();
                                            ListStepStartTime.Clear();
                                            ListStepEndTime.Clear();

                                            // }

                                            




                                            picMain.Image.Tag = "finishchamberA4";




                                            /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                        }


                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishchamberA4" && picSV.Visible==true)
                                        {

                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picSV.Visible = false;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishchamberA4" && picSV.Visible == false)
                                        {
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA4-2";
                                           
                                            ovalShape1.Left += 1;
                                            ovalShape1.Left -= 1;
                                            picChamber.Width += 140;
                                            picChamber.Left -= 150;
                                            picChamber.Height += 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA4-2")
                                        {
                                            await Task.Delay(1000);
                                            label2.BackColor = Color.Blue;
                                            lblProcess.BackColor = Color.Blue;
                                            lblProcessStep.BackColor = Color.Blue;
                                            lblRecipe.BackColor = Color.Blue;
                                            lblStepName.BackColor = Color.Blue;
                                            lblData.BackColor = Color.Blue;
                                            lblnum.BackColor = Color.Blue;

                                            lblProcess.Text = "Idle";
                                            lblProcessStep.Text = "";
                                            lblRecipe.Text = "";
                                            lblStepName.Text = "";
                                            lblnum.Text = "";
                                            lblData.Text = "";


                                            // pictRobot.Visible = true;

                                            picChamber.Image = Properties.Resources.new_chamber1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;

                                            picMain.Image.Tag = "picrobotAPMWaferA4-2";

                                            lblwaferAPM.Visible = false;
                                            lblwaferup.Visible = true;

                                            ovalShape1.Top += 145;
                                            ovalShape1.Left -= 3;
                                            lblwafer.Top += 145;
                                            lblwafer.Left -= 3;

                                            lblChamber.BackColor = Color.Blue;
                                            chamberload = "Blue";
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA4-2" && picSV.Visible == false)
                                        {
                                            await Task.Delay(2000);
                                            picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                            // picMain.Image = Properties.Resources.robotrightA1;
                                            picSV.Visible = true;


                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA4-2" && picSV.Visible == true)
                                        {
                                            await Task.Delay(2000);

                                            // pictRobot.Height += 20;

                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA4-2";
                                            lblwaferup.Visible = false;
                                            lblwafer.Visible = true;
                                            ovalShape1.Top += 162;
                                            lblwafer.Top += 162;
                                            ovalShape1.Left += 12;
                                            lblwafer.Left += 12;
                                            await Task.Delay(2000);

                                            await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                               // picMain.Image = Properties.Resources.robotgetwaferA1;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA4-2")
                                        {
                                            await Task.Delay(1000);

                                            lblCassette.BackColor = Color.LimeGreen;

                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "picrobotintocassettA4-2";
                                            lblwafer.Visible = false;
                                            lblwafer.Visible = false;
                                            ovalShape1.Visible = false;
                                            picCassette.Height += 220;
                                            picCassette.Width += 25;
                                            picCassette.Top -= 205;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassettA4-2")
                                        {
                                            await Task.Delay(2000);
                                            lblCassette.BackColor = Color.Blue;
                                            //  pictRobot.Visible = true;

                                            picMain.Image = Properties.Resources.mainpicture;
                                            picCassette.Image = Properties.Resources.cassette3;
                                            picCassette.Width -= 25;
                                            picCassette.Height -= 220;
                                            picCassette.Top += 205;
                                            await Task.Delay(2000);
                                            //  picMain.Image = Properties.Resources.mainpic;
                                            picCassette.Image = Properties.Resources.cassette;
                                            // picwafer.Image = Properties.Resources.waferfull;
                                            if (NoOfwafer[i] == "1")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA1full;
                                                picWafer1.Visible = true;
                                            }
                                            if (NoOfwafer[i] == "2")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA2full;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                            }
                                            if (NoOfwafer[i] == "3")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA3full;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                            }
                                            if (NoOfwafer[i] == "4")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA4full;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;
                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                                picWafer3.Image = Properties.Resources.picWaferGreen;
                                                picWafer4.Image = Properties.Resources.picWaferGreen;
                                            }

                                            if (NoOfwafer[i] == "5")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA5full;
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;
                                                picWafer5.Visible = true;
                                            }

                                            //////////////////////////////////////////////////////////////////Save DataLog
                                            if (int.Parse(NoOfwafer[i]) == 4)
                                            {
                                                EndTime = DateTime.Now;


                                                con.Open();

                                                string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                                SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                                cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                                cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                                cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                                cmdinsertdatalog.ExecuteNonQuery();

                                                con.Close();

                                                lblState.Text = "Finished";

                                                

                                            }
                                            picMain.Image.Tag = "finishwaferA4";
                                            if (isStopRobot == true)
                                            {
                                                button2.Enabled = true;
                                                lblState.Text = "Stopping";
                                            }

                                           
                                        }
                                          /////////////////////////////////////////////////////////finish waferA4
                                      }













                                    if (int.Parse(NoOfwafer[i]) >= 5)
                                    {
                                        /////////////////////////////////////////////////////////start WaferA5

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishwaferA4" && isStopRobot == false)
                                        {
                                            await Task.Delay(1000);

                                            //pictRobot.Image = Properties.Resources.new_robot;
                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image.Tag = "mainpictureA5";

                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "mainpictureA5")
                                        {
                                            await Task.Delay(1000);

                                            //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                            // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                            await Task.Delay(1000);

                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "picrobotintocassetteA5";
                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                            picCassette.Width += 25;
                                            picCassette.Height += 220;
                                            picCassette.Top -= 205;
                                            picCassette.Image.Tag = "robot_into_cassetteA1";
                                            picCassette.Left += 5;
                                            label1.BackColor = Color.Blue;
                                            lblLoad.Text = "";
                                            lblLoad.BackColor = Color.Blue;
                                            lbl123.BackColor = Color.Blue;
                                            lblState.BackColor = Color.Blue;
                                            lblCassetteRecipename.BackColor = Color.Blue;
                                            lblmTorr.BackColor = Color.Blue;


                                            lblCassette.BackColor = Color.LimeGreen;
                                            await Task.Delay(1000);


                                            picCassette.Image = Properties.Resources.cassette;
                                            await Task.Delay(1000);

                                            if (NoOfwafer[i] == "1")
                                            {
                                                // picwafer.Image = Properties.Resources.wafer;
                                                //  picwafer.Image.Tag = "wafer";
                                                picWafer5.Visible = true;
                                            }
                                            else if (NoOfwafer[i] == "2")
                                            {
                                                //  picwafer.Image = Properties.Resources.waferA1full;
                                                picWafer5.Visible = true;
                                            }
                                            else if (NoOfwafer[i] == "3")
                                            {
                                                //   picwafer.Image = Properties.Resources.waferA2full;
                                                picWafer5.Visible = true;

                                            }
                                            else if (NoOfwafer[i] == "4")
                                            {
                                                //   picwafer.Image = Properties.Resources.waferA3full;
                                                picWafer5.Visible = true;
                                            }
                                            else if (NoOfwafer[i] == "5")
                                            {
                                                // picwafer.Image = Properties.Resources.waferA4full;
                                                picWafer5.Visible = true;
                                            }

                                            StartTime = DateTime.Now;


                                            con.Open();

                                            string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                            SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                            cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "5");
                                            cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                            cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                            cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);
                                            cmdwaferselection.ExecuteNonQuery();

                                            con.Close();


                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassetteA5")
                                        { 
                                        await Task.Delay(1000);

                                        picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA5";                                       // panel1.Visible = true;
                                        //  ovalShape1.Visible = true;
                                        lblwafer.Visible = true;
                                        lblwafer.Text = "A5";

                                        lblCassette.BackColor = Color.Blue;

                                        picCassette.Image = Properties.Resources.cassette3;

                                        // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                        picCassette.Height -= 220;
                                        picCassette.Width -= 25;
                                        picCassette.Top += 205;
                                        picCassette.Image.Tag = "cassette";
                                        picCassette.Left -= 5;
                                        //  await Task.Delay(1000);
                                        picCassette.Image = Properties.Resources.cassette;
                                        // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                    }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA5")
                                        {
                                            await Task.Delay(1000);



                                            // pictRobot.Image = Properties.Resources.robotleft_A1;
                                            //   picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag = "picrobotAlignerWaferA5";
                                            //  ovalShape1.Visible = true;
                                            // lblwafer.Visible = true;
                                            ovalShape1.Left += 70;
                                            ovalShape1.Top -= 85;
                                            lblwafer.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A5";
                                            lblwafer.Left += 70;
                                            lblwafer.Top -= 85;
                                            // panel1.Visible = false;



                                            //   await Task.Delay(2000);
                                            //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                            //  picMain.Image = Properties.Resources.robotleftA1opencentralize;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA5")
                                        {
                                            await Task.Delay(2000);






                                            // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                            //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                            picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                            picMain.Image.Tag = "picrobotintoAlignerWaferA5";
                                            lblCentralize.BackColor = Color.LimeGreen;
                                            ovalShape1.Left += 155;
                                            ovalShape1.Top += 0;
                                            lblwaferright.Visible = false;
                                            lblwaferaligner.Visible = true;
                                            lblwaferaligner.Text = "A5";
                                            lblwafer.Left += 155;
                                            lblwafer.Top += 0;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAlignerWaferA5")
                                        {
                                            ////////////////////////////////////////////////////////////////////////////////////
                                            await Task.Delay(2000);
                                            // pictRobot.Visible = true;
                                            // picCentralize.Image = Properties.Resources.centralize2;
                                            // picMain.Image = Properties.Resources.picrobotcentralized;
                                            picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                            picMain.Image.Tag = "picrobotAlignerWaferA5-2";
                                            // ovalShape1.Visible = true;
                                            //picwafer.Visible = true;
                                            lblwaferaligner.Visible = false;
                                            lblwaferright.Visible = true;
                                            lblwaferright.Text = "A5";
                                            ovalShape1.Left -= 155;
                                            ovalShape1.Top -= 0;
                                            lblwafer.Left -= 155;
                                            lblwafer.Top -= 0;
                                            lblCentralize.BackColor = Color.Blue;

                                            // await Task.Delay(2000);
                                            // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                            // picMain.Image = Properties.Resources.robotleftA1;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA5-2")
                                        {
                                            await Task.Delay(2000);

                                            //   picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;
                                            picMain.Image.Tag = "picrobotAPMWaferA5";
                                            lblwaferright.Visible = false;
                                            lblwaferup.Visible = true;
                                            lblwaferup.Text = "A5";
                                            ovalShape1.Left -= 82;
                                            ovalShape1.Top -= 76;
                                            lblwafer.Left -= 82;
                                            lblwafer.Top -= 76;



                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA5" && picSV.Visible == true)
                                        {
                                            await Task.Delay(1000);

                                            // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                            // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                            picSV.Visible = false;  // open sv of chamber
                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA5" && picSV.Visible == false)
                                        {
                                            await Task.Delay(1000);

                                            //pictRobot.Visible = false;
                                            //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            //  picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA5";
                                            // picChamber.Width += 140;
                                            //picChamber.Left -= 150;
                                            //picChamber.Height += 10;
                                            lblwaferup.Visible = false;
                                            lblwaferAPM.Visible = true;
                                            lblwaferAPM.Text = "A5";
                                            ovalShape1.Top -= 145;
                                            ovalShape1.Left += 3;
                                            lblwafer.Top -= 145;
                                            lblwafer.Left += 3;



                                            lblChamber.BackColor = Color.LimeGreen;

                                            chamberload = "LimeGreen";

                                            // loaddata();
                                            // loadchamber1( sender, e);
                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA5")
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            
                                            //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picwaferinAPM;
                                            picMain.Image.Tag = "picwaferinAPMA5";
                                            ovalShape1.Left -= 1;
                                            ovalShape1.Left += 1;
                                            //  picMain.SendToBack();
                                            // ovalShape1.BringToFront();
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;


                                            //  pictRobot.Visible = true;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA5")
                                        {
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                            picSV.Visible = true;

                                            ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA5 into Chamber


                                            lblRecipe.BackColor = Color.LimeGreen;
                                            lblStepName.BackColor = Color.LimeGreen;

                                            lblnum.BackColor = Color.LimeGreen;

                                            lblData.BackColor = Color.LimeGreen;
                                            lblData.Text = "";
                                            label2.BackColor = Color.LimeGreen;

                                            lblProcess.Text = "Processing";
                                            lblProcess.BackColor = Color.LimeGreen;
                                            lblProcessStep.Text = "Process Step";
                                            lblProcessStep.BackColor = Color.LimeGreen;



                                            con.Open();
                                            string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                            SqlCommand cmd = new SqlCommand(strSQL, con);
                                            cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                            SqlDataReader reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {

                                                lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                            }

                                            con.Close();
                                            con.Open();
                                            string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                            SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                            cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                            SqlDataReader reader1 = cmd1.ExecuteReader();
                                            while (reader1.Read())
                                            {

                                                strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                            }

                                            con.Close();

                                            con.Open();
                                            string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                            SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                            cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                            cmd2.ExecuteNonQuery();



                                            for (int j = 0; j < strStepname1.Count(); j += 1)

                                            {

                                                await Task.Delay(1000);

                                                ListStepStartTime.Add(DateTime.Now);


                                                int count = j + 1;


                                                lblStepName.Text = strStepname1[j];
                                                lblnum.Text = "," + count + "/" + strStepname1.Count();


                                                con.Close();

                                                con.Open();
                                                string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                                SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                                cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                                SqlDataReader readerSec = cmdSec.ExecuteReader();


                                                while (readerSec.Read())
                                                {
                                                    mySec1 = readerSec["ProcessTime"].ToString();

                                                    Int32.TryParse(mySec1, out Sec1);

                                                }

                                                for (int k = 1; k <= Sec1; k++)
                                                {
                                                    lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                                    await Task.Delay(1000);


                                                }
                                                ListStepEndTime.Add(DateTime.Now);

                                                con.Close();

                                                con.Open();

                                                string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                                SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                                cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                                cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                                cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "5");
                                                cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                                cmdmodulerecipe.ExecuteNonQuery();

                                                con.Close();
                                                //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                                con.Open();

                                                string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                                SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                                cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                                cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                                SqlDataReader reader2 = cmd3.ExecuteReader();

                                                while (reader2.Read())
                                                {
                                                    CI2 = reader2["CI2"].ToString();
                                                    BCI3 = reader2["BCI3"].ToString();
                                                    SF6 = reader2["SF6"].ToString();
                                                    CHF3 = reader2["CHF3"].ToString();
                                                    Oxygen = reader2["Oxygen"].ToString();
                                                    Oxygen1 = reader2["Oxygen1"].ToString();
                                                    Nitrogen = reader2["Nitrogen"].ToString();
                                                    Argon = reader2["Argon"].ToString();



                                                }

                                                con.Close();

                                                ///////////////////////////////////////////////////////////////////////////////////////////////////
                                                con.Open();
                                                Chamber1 chamber1 = new Chamber1();

                                                string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate) values(@11,@21,@31,@41,@51,@61,@71,@81),(@12,@22,@32,@42,@52,@62,@72,@82),(@13,@23,@33,@43,@53,@63,@73,@83)"
                                                    + ",(@14,@24,@34,@44,@54,@64,@74,@84),(@15,@25,@35,@45,@55,@65,@75,@85),(@16,@26,@36,@46,@56,@66,@76,@86),(@17,@27,@37,@47,@57,@67,@77,@87),(@18,@28,@38,@48,@58,@68,@78,@88)";
                                                SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                                cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                                cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                                cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                                cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                                cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                                cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                                cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                                cmdparameter.Parameters.AddWithValue("@21", CI2);
                                                cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@23", SF6);
                                                cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@28", Argon);
                                                cmdparameter.Parameters.AddWithValue("@31", CI2);
                                                cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@33", SF6);
                                                cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@38", Argon);
                                                cmdparameter.Parameters.AddWithValue("@41", CI2);
                                                cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                                cmdparameter.Parameters.AddWithValue("@43", SF6);
                                                cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                                cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                                cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                                cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                                cmdparameter.Parameters.AddWithValue("@48", Argon);
                                                cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                                cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                                cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                                cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                                cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);


                                                cmdparameter.ExecuteNonQuery();
                                                con.Close();

                                            }
                                            ///////////////////////////////////////////////


                                            strStepname1.Clear();
                                            ListStepStartTime.Clear();
                                            ListStepEndTime.Clear();

                                            // }











                                            /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                            await Task.Delay(1000);


                                            picMain.Image.Tag = "finishchamberA5";

                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishchamberA5" && picSV.Visible == true)
                                        {
                                            await Task.Delay(1000);
                                            picChamber.Image = Properties.Resources.ChamberWithA1;
                                            //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                            picSV.Visible = false;
                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishchamberA5" && picSV.Visible == true)
                                        {
                                            await Task.Delay(1000);

                                            picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                            picMain.Image = Properties.Resources.picrobotintochamber;
                                            picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                            picMain.Image.Tag = "picrobotintoAPMWaferA5-2";
                                            ovalShape1.Left += 1;
                                            ovalShape1.Left -= 1;
                                            picChamber.Width += 140;
                                            picChamber.Left -= 150;
                                            picChamber.Height += 10;
                                        }

                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA5-2")
                                        {
                                            await Task.Delay(1000);
                                            label2.BackColor = Color.Blue;
                                            lblProcess.BackColor = Color.Blue;
                                            lblProcessStep.BackColor = Color.Blue;
                                            lblRecipe.BackColor = Color.Blue;
                                            lblStepName.BackColor = Color.Blue;
                                            lblData.BackColor = Color.Blue;
                                            lblnum.BackColor = Color.Blue;

                                            lblProcess.Text = "idle";
                                            lblProcessStep.Text = "";
                                            lblRecipe.Text = "";
                                            lblStepName.Text = "";
                                            lblnum.Text = "";
                                            lblData.Text = "";


                                            // pictRobot.Visible = true;

                                            picChamber.Image = Properties.Resources.new_chamber1;
                                            picMain.Image = Properties.Resources.picrobotbotton;
                                            picMain.Image = Properties.Resources.picrobotAPMWafer;

                                            picMain.Image.Tag = "picrobotAPMWaferA5-2";
                                            lblwaferAPM.Visible = false;
                                            lblwaferup.Visible = true;

                                            ovalShape1.Top += 145;
                                            ovalShape1.Left -= 3;
                                            lblwafer.Top += 145;
                                            lblwafer.Left -= 3;

                                            lblChamber.BackColor = Color.Blue;
                                            chamberload = "Blue";
                                            picChamber.Width -= 140;
                                            picChamber.Left += 150;
                                            picChamber.Height -= 10;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA5-2" && picSV.Visible == false)
                                        {
                                            await Task.Delay(2000);
                                            picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                            // picMain.Image = Properties.Resources.robotrightA1;
                                            picSV.Visible = true;

                                        }

                                        if (ispauserobot==false&&picMain.Image.Tag.ToString()== "picrobotAPMWaferA5-2" && picSV.Visible == true)
                                        {
                                            await Task.Delay(2000);

                                            // pictRobot.Height += 20;

                                            // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                            picMain.Image = Properties.Resources.mainpicture;
                                            picMain.Image = Properties.Resources.picrobotArmWafer;
                                            picMain.Image.Tag = "picrobotArmWaferA5-2";
                                            lblwaferup.Visible = false;
                                            lblwafer.Visible = true;
                                            ovalShape1.Top += 162;
                                            lblwafer.Top += 162;
                                            ovalShape1.Left += 12;
                                            lblwafer.Left += 12;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA5-2")
                                        {
                                            await Task.Delay(2000);

                                            await Task.Delay(1000);
                                            picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                               // picMain.Image = Properties.Resources.robotgetwaferA1;
                                            await Task.Delay(1000);

                                            lblCassette.BackColor = Color.LimeGreen;

                                            picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                            picMain.Image = Properties.Resources.picrobotintocassette;
                                            picMain.Image.Tag = "picrobotintocassetteA5-2";
                                            lblwafer.Visible = false;
                                            lblwafer.Visible = false;
                                            ovalShape1.Visible = false;
                                            picCassette.Height += 220;
                                            picCassette.Width += 25;
                                            picCassette.Top -= 205;
                                        }
                                        if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassetteA5-2")
                                        {
                                            await Task.Delay(2000);
                                            lblCassette.BackColor = Color.Blue;
                                            //  pictRobot.Visible = true;

                                            picMain.Image = Properties.Resources.mainpicture;
                                            picCassette.Image = Properties.Resources.cassette3;
                                            picCassette.Width -= 25;
                                            picCassette.Height -= 220;
                                            picCassette.Top += 205;
                                            await Task.Delay(2000);
                                            //  picMain.Image = Properties.Resources.mainpic;
                                            picCassette.Image = Properties.Resources.cassette;
                                            // picwafer.Image = Properties.Resources.waferfull;
                                            if (NoOfwafer[i] == "1")
                                            {
                                                picwafer.Image = Properties.Resources.waferA1full;
                                            }
                                            if (NoOfwafer[i] == "2")
                                            {
                                                picwafer.Image = Properties.Resources.waferA2full;
                                            }
                                            if (NoOfwafer[i] == "3")
                                            {
                                                picwafer.Image = Properties.Resources.waferA3full;
                                            }
                                            if (NoOfwafer[i] == "4")
                                            {
                                                picwafer.Image = Properties.Resources.waferA4full;
                                            }

                                            if (NoOfwafer[i] == "3")
                                            {
                                                picWafer1.Visible = true;
                                                picWafer2.Visible = true;
                                                picWafer3.Visible = true;
                                                picWafer4.Visible = true;
                                                picWafer5.Visible = true;

                                                picWafer5.Image = Properties.Resources.picWaferGreen;
                                                picWafer2.Image = Properties.Resources.picWaferGreen;
                                                picWafer1.Image = Properties.Resources.picWaferGreen;
                                                picWafer3.Image = Properties.Resources.picWaferGreen;
                                                picWafer4.Image = Properties.Resources.picWaferGreen;
                                            }

                                            //////////////////////////////////////////////////////////////////Save DataLog
                                            if (int.Parse(NoOfwafer[i]) == 5)
                                            {
                                                EndTime = DateTime.Now;


                                                con.Open();

                                                string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                                SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                                cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                                cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                                cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                                cmdinsertdatalog.ExecuteNonQuery();

                                                con.Close();

                                                /////////////////////////////////////////////////////////finish waferA5
                                                lblState.Text = "Finished";
                                            }
                                            picMain.Image.Tag = "finishwaferA5";

                                        }
                                      }


                                      /*

                                      if (int.Parse(NoOfwafer[i]) >= 6)
                                      {
                                          /////////////////////////////////////////////////////////start WaferA6

                                          picCassette.Image = Properties.Resources.cassette;
                                          await Task.Delay(1000);

                                          if (NoOfwafer[i] == "1")
                                          {
                                              picwafer.Image = Properties.Resources.wafer;
                                              picwafer.Image.Tag = "wafer";
                                          }
                                          else if (NoOfwafer[i] == "2")
                                          {
                                              picwafer.Image = Properties.Resources.waferA1full;
                                          }
                                          else if (NoOfwafer[i] == "3")
                                          {
                                              picwafer.Image = Properties.Resources.waferA2full;

                                          }
                                          else if (NoOfwafer[i] == "4")
                                          {
                                              picwafer.Image = Properties.Resources.waferA3full;
                                          }
                                          else if (NoOfwafer[i] == "5")
                                          {
                                              picwafer.Image = Properties.Resources.waferA4full;
                                          }
                                          else if (NoOfwafer[i] == "6")
                                          {
                                              picwafer.Image = Properties.Resources.waferA5full;

                                          }
                                          StartTime = DateTime.Now;


                                          con.Open();

                                          string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                          SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                          cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "6");
                                          cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                          cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                          cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);

                                          cmdwaferselection.ExecuteNonQuery();

                                          con.Close();









                                          await Task.Delay(1000);

                                          //pictRobot.Image = Properties.Resources.new_robot;
                                          picMain.Image = Properties.Resources.mainpicture;
                                          await Task.Delay(1000);

                                          //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                          // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                          await Task.Delay(1000);

                                          picMain.Image = Properties.Resources.picrobotintocassette;
                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                          picCassette.Width += 25;
                                          picCassette.Height += 220;
                                          picCassette.Top -= 205;
                                          picCassette.Image.Tag = "robot_into_cassetteA1";
                                          picCassette.Left += 5;
                                          label1.BackColor = Color.Blue;
                                          lblLoad.Text = "";
                                          lblLoad.BackColor = Color.Blue;
                                          lbl123.BackColor = Color.Blue;
                                          lblState.BackColor = Color.Blue;
                                          lblCassetteRecipename.BackColor = Color.Blue;
                                          lblmTorr.BackColor = Color.Blue;


                                          lblCassette.BackColor = Color.LimeGreen;
                                          await Task.Delay(1000);

                                          //  pictRobot.Visible = true;

                                          //  picMain.Image = Properties.Resources.mainpicture;
                                          picMain.Image = Properties.Resources.picrobotArmWafer;
                                          // panel1.Visible = true;
                                          //  ovalShape1.Visible = true;
                                          lblwafer.Visible = true;
                                          lblwafer.Text = "A5";

                                          lblCassette.BackColor = Color.Blue;

                                          picCassette.Image = Properties.Resources.cassette3;

                                          // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                          picCassette.Height -= 220;
                                          picCassette.Width -= 25;
                                          picCassette.Top += 205;
                                          picCassette.Image.Tag = "cassette";
                                          picCassette.Left -= 5;
                                          //  await Task.Delay(1000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                          await Task.Delay(1000);



                                          // pictRobot.Image = Properties.Resources.robotleft_A1;
                                          //   picMain.Image = Properties.Resources.picrobotcentralized;
                                          picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                          //  ovalShape1.Visible = true;
                                          // lblwafer.Visible = true;
                                          ovalShape1.Left += 70;
                                          ovalShape1.Top -= 85;
                                          lblwafer.Visible = false;
                                          lblwaferright.Visible = true;
                                          lblwaferright.Text = "A5";
                                          lblwafer.Left += 70;
                                          lblwafer.Top -= 85;
                                          // panel1.Visible = false;



                                          //   await Task.Delay(2000);
                                          //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                          //  picMain.Image = Properties.Resources.robotleftA1opencentralize;

                                          await Task.Delay(2000);






                                          // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                          //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                          picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                          lblCentralize.BackColor = Color.LimeGreen;
                                          ovalShape1.Left += 155;
                                          ovalShape1.Top += 0;
                                          lblwaferright.Visible = false;
                                          lblwaferaligner.Visible = true;
                                          lblwaferaligner.Text = "A6";
                                          lblwafer.Left += 155;
                                          lblwafer.Top += 0;


                                          ////////////////////////////////////////////////////////////////////////////////////
                                          await Task.Delay(2000);
                                          // pictRobot.Visible = true;
                                          // picCentralize.Image = Properties.Resources.centralize2;
                                          // picMain.Image = Properties.Resources.picrobotcentralized;
                                          picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                          // ovalShape1.Visible = true;
                                          //picwafer.Visible = true;
                                          lblwaferaligner.Visible = false;
                                          lblwaferright.Visible = true;
                                          lblwaferright.Text = "A6";
                                          ovalShape1.Left -= 155;
                                          ovalShape1.Top -= 0;
                                          lblwafer.Left -= 155;
                                          lblwafer.Top -= 0;
                                          lblCentralize.BackColor = Color.Blue;

                                          // await Task.Delay(2000);
                                          // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                          // picMain.Image = Properties.Resources.robotleftA1;
                                          await Task.Delay(2000);

                                          //   picMain.Image = Properties.Resources.picrobotbotton;
                                          picMain.Image = Properties.Resources.picrobotAPMWafer;
                                          lblwaferright.Visible = false;
                                          lblwaferup.Visible = true;
                                          lblwaferup.Text = "A6";
                                          ovalShape1.Left -= 82;
                                          ovalShape1.Top -= 76;
                                          lblwafer.Left -= 82;
                                          lblwafer.Top -= 76;





                                          await Task.Delay(1000);

                                          // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                          // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                          picSV.Visible = false;  // open sv of chamber

                                          await Task.Delay(1000);

                                          //pictRobot.Visible = false;
                                          //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                          //  picMain.Image = Properties.Resources.picrobotintochamber;
                                          picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                          // picChamber.Width += 140;
                                          //picChamber.Left -= 150;
                                          //picChamber.Height += 10;
                                          lblwaferup.Visible = false;
                                          lblwaferAPM.Visible = true;
                                          lblwaferAPM.Text = "A6";
                                          ovalShape1.Top -= 145;
                                          ovalShape1.Left += 3;
                                          lblwafer.Top -= 145;
                                          lblwafer.Left += 3;



                                          lblChamber.BackColor = Color.LimeGreen;

                                          chamberload = "LimeGreen";

                                          // loaddata();
                                          // loadchamber1( sender, e);
                                          await Task.Delay(1000);
                                          picChamber.Image = Properties.Resources.ChamberWithA1;
                                          //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                          picMain.Image = Properties.Resources.picrobotbotton;
                                          picMain.Image = Properties.Resources.picwaferinAPM;
                                          ovalShape1.Left -= 1;
                                          ovalShape1.Left += 1;
                                          //  picMain.SendToBack();
                                          // ovalShape1.BringToFront();
                                          picChamber.Width -= 140;
                                          picChamber.Left += 150;
                                          picChamber.Height -= 10;


                                          //  pictRobot.Visible = true;


                                          await Task.Delay(1000);

                                          picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                          //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                          picSV.Visible = true;

                                          ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA5 into Chamber


                                          lblRecipe.BackColor = Color.LimeGreen;
                                          lblStepName.BackColor = Color.LimeGreen;

                                          lblnum.BackColor = Color.LimeGreen;

                                          lblData.BackColor = Color.LimeGreen;
                                          lblData.Text = "";
                                          label2.BackColor = Color.LimeGreen;

                                          lblProcess.Text = "Processing";
                                          lblProcess.BackColor = Color.LimeGreen;
                                          lblProcessStep.Text = "Process Step";
                                          lblProcessStep.BackColor = Color.LimeGreen;



                                          con.Open();
                                          string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                          SqlCommand cmd = new SqlCommand(strSQL, con);
                                          cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                          SqlDataReader reader = cmd.ExecuteReader();
                                          while (reader.Read())
                                          {

                                              lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                          }

                                          con.Close();
                                          con.Open();
                                          string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                          SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                          cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                          SqlDataReader reader1 = cmd1.ExecuteReader();
                                          while (reader1.Read())
                                          {

                                              strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                          }

                                          con.Close();

                                          con.Open();
                                          string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                          SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                          cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                          cmd2.ExecuteNonQuery();



                                          for (int j = 0; j < strStepname1.Count(); j += 1)

                                          {

                                              await Task.Delay(1000);

                                              ListStepStartTime.Add(DateTime.Now);


                                              int count = j + 1;


                                              lblStepName.Text = strStepname1[j];
                                              lblnum.Text = "," + count + "/" + strStepname1.Count();


                                              con.Close();

                                              con.Open();
                                              string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                              SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                              cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                              SqlDataReader readerSec = cmdSec.ExecuteReader();


                                              while (readerSec.Read())
                                              {
                                                  mySec1 = readerSec["ProcessTime"].ToString();

                                                  Int32.TryParse(mySec1, out Sec1);

                                              }

                                              for (int k = 1; k <= Sec1; k++)
                                              {
                                                  lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                                  await Task.Delay(1000);


                                              }
                                              ListStepEndTime.Add(DateTime.Now);

                                              con.Close();

                                              con.Open();

                                              string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                              SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                              cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                              cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "6");
                                              cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                              cmdmodulerecipe.ExecuteNonQuery();

                                              con.Close();
                                              //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                              con.Open();

                                              string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                              SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                              cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                              cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                              SqlDataReader reader2 = cmd3.ExecuteReader();

                                              while (reader2.Read())
                                              {
                                                  CI2 = reader2["CI2"].ToString();
                                                  BCI3 = reader2["BCI3"].ToString();
                                                  SF6 = reader2["SF6"].ToString();
                                                  CHF3 = reader2["CHF3"].ToString();
                                                  Oxygen = reader2["Oxygen"].ToString();
                                                  Oxygen1 = reader2["Oxygen1"].ToString();
                                                  Nitrogen = reader2["Nitrogen"].ToString();
                                                  Argon = reader2["Argon"].ToString();



                                              }

                                              con.Close();

                                              ///////////////////////////////////////////////////////////////////////////////////////////////////
                                              con.Open();
                                              Chamber1 chamber1 = new Chamber1();

                                              string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                                  + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                              SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                              cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                              cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                              cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                              cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                              cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                              cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                              cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                              cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                              cmdparameter.Parameters.AddWithValue("@21", CI2);
                                              cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                              cmdparameter.Parameters.AddWithValue("@23", SF6);
                                              cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                              cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                              cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                              cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                              cmdparameter.Parameters.AddWithValue("@28", Argon);
                                              cmdparameter.Parameters.AddWithValue("@31", CI2);
                                              cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                              cmdparameter.Parameters.AddWithValue("@33", SF6);
                                              cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                              cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                              cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                              cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                              cmdparameter.Parameters.AddWithValue("@38", Argon);
                                              cmdparameter.Parameters.AddWithValue("@41", CI2);
                                              cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                              cmdparameter.Parameters.AddWithValue("@43", SF6);
                                              cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                              cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                              cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                              cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                              cmdparameter.Parameters.AddWithValue("@48", Argon);
                                              cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                              cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                              cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                              cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                              cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                              cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                              cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                              cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                              cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                              cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                              cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                              cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                              cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                              cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                              cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                              cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                              cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                              cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                              cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                              cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                              cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                              cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                              cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                              cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);


                                              cmdparameter.ExecuteNonQuery();
                                              con.Close();

                                          }
                                          ///////////////////////////////////////////////


                                          strStepname1.Clear();
                                          ListStepStartTime.Clear();
                                          ListStepEndTime.Clear();

                                          // }











                                          /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                          await Task.Delay(1000);
                                          picChamber.Image = Properties.Resources.ChamberWithA1;
                                          //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                          picSV.Visible = false;
                                          await Task.Delay(1000);

                                          picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                          picMain.Image = Properties.Resources.picrobotintochamber;
                                          picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                          ovalShape1.Left += 1;
                                          ovalShape1.Left -= 1;
                                          picChamber.Width += 140;
                                          picChamber.Left -= 150;
                                          picChamber.Height += 10;
                                          await Task.Delay(1000);
                                          label2.BackColor = Color.Blue;
                                          lblProcess.BackColor = Color.Blue;
                                          lblProcessStep.BackColor = Color.Blue;
                                          lblRecipe.BackColor = Color.Blue;
                                          lblStepName.BackColor = Color.Blue;
                                          lblData.BackColor = Color.Blue;
                                          lblnum.BackColor = Color.Blue;

                                          lblProcess.Text = "Aborted";
                                          lblProcessStep.Text = "";
                                          lblRecipe.Text = "";
                                          lblStepName.Text = "";
                                          lblnum.Text = "";
                                          lblData.Text = "???????????";


                                          // pictRobot.Visible = true;

                                          picChamber.Image = Properties.Resources.new_chamber1;
                                          picMain.Image = Properties.Resources.picrobotbotton;
                                          picMain.Image = Properties.Resources.picrobotAPMWafer;
                                          lblwaferAPM.Visible = false;
                                          lblwaferup.Visible = true;

                                          ovalShape1.Top += 145;
                                          ovalShape1.Left -= 3;
                                          lblwafer.Top += 145;
                                          lblwafer.Left -= 3;

                                          lblChamber.BackColor = Color.Blue;
                                          chamberload = "Blue";
                                          picChamber.Width -= 140;
                                          picChamber.Left += 150;
                                          picChamber.Height -= 10;
                                          await Task.Delay(2000);
                                          picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                          // picMain.Image = Properties.Resources.robotrightA1;
                                          picSV.Visible = true;




                                          await Task.Delay(2000);

                                          // pictRobot.Height += 20;

                                          // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                          picMain.Image = Properties.Resources.mainpicture;
                                          picMain.Image = Properties.Resources.picrobotArmWafer;
                                          lblwaferup.Visible = false;
                                          lblwafer.Visible = true;
                                          ovalShape1.Top += 162;
                                          lblwafer.Top += 162;
                                          ovalShape1.Left += 12;
                                          lblwafer.Left += 12;
                                          await Task.Delay(2000);

                                          await Task.Delay(1000);
                                          picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                             // picMain.Image = Properties.Resources.robotgetwaferA1;
                                          await Task.Delay(1000);

                                          lblCassette.BackColor = Color.LimeGreen;

                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picMain.Image = Properties.Resources.picrobotintocassette;
                                          lblwafer.Visible = false;
                                          lblwafer.Visible = false;
                                          ovalShape1.Visible = false;
                                          picCassette.Height += 220;
                                          picCassette.Width += 25;
                                          picCassette.Top -= 205;
                                          await Task.Delay(2000);
                                          lblCassette.BackColor = Color.Blue;
                                          //  pictRobot.Visible = true;

                                          picMain.Image = Properties.Resources.mainpicture;
                                          picCassette.Image = Properties.Resources.cassette3;
                                          picCassette.Width -= 25;
                                          picCassette.Height -= 220;
                                          picCassette.Top += 205;
                                          await Task.Delay(2000);
                                          //  picMain.Image = Properties.Resources.mainpic;
                                          picCassette.Image = Properties.Resources.cassette;
                                          // picwafer.Image = Properties.Resources.waferfull;
                                          if (NoOfwafer[i] == "1")
                                          {
                                              picwafer.Image = Properties.Resources.waferA1full;
                                          }
                                          if (NoOfwafer[i] == "2")
                                          {
                                              picwafer.Image = Properties.Resources.waferA2full;
                                          }
                                          if (NoOfwafer[i] == "3")
                                          {
                                              picwafer.Image = Properties.Resources.waferA3full;
                                          }
                                          if (NoOfwafer[i] == "4")
                                          {
                                              picwafer.Image = Properties.Resources.waferA4full;
                                          }

                                          if (NoOfwafer[i] == "5")
                                          {
                                              picwafer.Image = Properties.Resources.waferA5full;
                                          }
                                          if (NoOfwafer[i] == "6")
                                          {
                                              picwafer.Image = Properties.Resources.waferA6full;
                                          }

                                          //////////////////////////////////////////////////////////////////Save DataLog
                                          if (int.Parse(NoOfwafer[i]) == 6)
                                          {
                                              EndTime = DateTime.Now;


                                              con.Open();

                                              string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                              SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                              cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                              cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                              cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                              cmdinsertdatalog.ExecuteNonQuery();

                                              con.Close();

                                              /////////////////////////////////////////////////////////finish waferA5
                                          }

                                          //////////////////////////////////////////////////////////////////////////finish waferA6
                                      }
                                      if (int.Parse(NoOfwafer[i]) >= 7)
                                      {
                                          //////////////////////////////////////////////////////////////////////////start waferA7
                                          await Task.Delay(2000);

                                          picCassette.Image = Properties.Resources.cassette1;
                                          await Task.Delay(2000);
                                          Wafer7StartTime = DateTime.Now;
                                          scsb = new SqlConnectionStringBuilder();
                                          scsb.DataSource = @"HP-PC\SQLEXPRESS";
                                          scsb.InitialCatalog = "RecipeType";
                                          scsb.IntegratedSecurity = true;
                                          SqlConnection con6 = new SqlConnection(scsb.ToString());
                                          con6.Open();

                                          string wafer7strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName) values(@NoOfWafer,@StartTime,@CassetteRecipeName)";
                                          SqlCommand wafer7cmdwaferselection = new SqlCommand(wafer7strWaferSelection, con6);
                                          wafer7cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "7");
                                          wafer7cmdwaferselection.Parameters.AddWithValue("@StartTime", Wafer7StartTime);
                                          wafer7cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                          wafer7cmdwaferselection.ExecuteNonQuery();

                                          con6.Close();




                                          // lblCassette.BackColor = Color.LimeGreen;

                                          lblCassette.BackColor = Color.LimeGreen;
                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picCassette.Height += 150;
                                          picCassette.Top -= 150;
                                          await Task.Delay(2000);
                                          picwafer.Image = Properties.Resources.waferA7;
                                          await Task.Delay(2000);
                                          // WaferTime = DateTime.Now;
                                          lblCassette.BackColor = Color.Blue;

                                          picCassette.Image = Properties.Resources.cassette1;
                                          picCassette.Height -= 150;
                                          picCassette.Top += 150;
                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          await Task.Delay(2000);

                                          await Task.Delay(2000);

                                          await Task.Delay(2000);

                                          lblCentralize.BackColor = Color.LimeGreen;

                                          // picCentralize.Height += 100;

                                          await Task.Delay(2000);

                                          lblCentralize.BackColor = Color.Blue;

                                          //picCentralize.Height -= 100;

                                          await Task.Delay(2000);


                                          await Task.Delay(2000);

                                          picChamber.Image = Properties.Resources.new_chamber1;

                                          await Task.Delay(2000);


                                          picChamber.Image = Properties.Resources.robot_into_chamberA7;
                                          picChamber.Width += 100;
                                          picChamber.Left -= 150;
                                          lblChamber.BackColor = Color.LimeGreen;

                                          chamberload = "LimeGreen";
                                          //////////////////////////////////////////////////////////////////////////////////waferA7 into chamber
                                          WaferTime = DateTime.Now;
                                          lblRecipe.BackColor = Color.LimeGreen;
                                          lblStepName.BackColor = Color.LimeGreen;
                                          lblnum.BackColor = Color.LimeGreen;
                                          lblData.BackColor = Color.LimeGreen;
                                          lblData.Text = "";
                                          label2.BackColor = Color.LimeGreen;
                                          lblProcess.Text = "Processing";
                                          lblProcess.BackColor = Color.LimeGreen;
                                          lblProcessStep.Text = "Process Step";
                                          lblProcessStep.BackColor = Color.LimeGreen;

                                          con6.Open();
                                          string wafer7strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                          SqlCommand wafer7cmd = new SqlCommand(wafer7strSQL, con6);
                                          wafer7cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                          SqlDataReader wafer7reader = wafer7cmd.ExecuteReader();
                                          while (wafer7reader.Read())
                                          {

                                              lblRecipe.Text = string.Format("{0}", wafer7reader["WaferRecipe"]);



                                          }

                                          con6.Close();
                                          con6.Open();
                                          string wafer7strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                          SqlCommand wafer7cmd1 = new SqlCommand(wafer7strSQL1, con6);
                                          wafer7cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                          SqlDataReader wafer7reader1 = wafer7cmd1.ExecuteReader();
                                          while (wafer7reader1.Read())
                                          {

                                              strStepname1.Add(string.Format("{0}", wafer7reader1["StepName"]));


                                          }

                                          con6.Close();
                                          con6.Open();
                                          string wafer7strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                          SqlCommand wafer7cmd2 = new SqlCommand(wafer7strSQL2, con6);
                                          wafer7cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          //SqlDataReader reader2 = cmd2.ExecuteReader();
                                          wafer7cmd2.ExecuteNonQuery();

                                          // while (reader2.Read())
                                          // {
                                          //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                                          // int row = strStepname.Count();
                                          for (int a7 = 0; a7 < strStepname1.Count(); a7 += 1)
                                          {
                                              await Task.Delay(1000);
                                              ListStepStartTime.Add(DateTime.Now);
                                              int count = a7 + 1;
                                              // await Task.Delay(2000);
                                              lblStepName.Text = strStepname1[a7];
                                              lblnum.Text = "," + count + "/" + strStepname1.Count();
                                              // lblnum.Text = "," + count + "/" + strStepname.Count();
                                              //  await Task.Delay(2000);

                                              con6.Close();

                                              con6.Open();
                                              string wafer7strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                              SqlCommand wafer7cmdSec = new SqlCommand(wafer7strSQLStepSec, con6);
                                              wafer7cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                              SqlDataReader wafer7readerSec = wafer7cmdSec.ExecuteReader();


                                              while (wafer7readerSec.Read())
                                              {
                                                  mySec1 = wafer7readerSec["ProcessTime"].ToString();
                                                  // lblSec.Text = string.Format("{0}", readerSec["ProcessPressure"]);
                                                  Int32.TryParse(mySec1, out Sec1);

                                              }

                                              for (int j = 1; j <= Sec1; j++)
                                              {
                                                  lblData.Text = j.ToString() + "/" + mySec1.ToString() + " Sec";
                                                  await Task.Delay(1000);


                                              }
                                              ListStepEndTime.Add(DateTime.Now);

                                              con6.Close();


                                              con6.Open();

                                              string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe)";

                                              SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con6);

                                              cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                              cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[a7]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[a7]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[a7]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "7");

                                              cmdmodulerecipe.ExecuteNonQuery();

                                              con6.Close();
                                              ///////////////////////////////////////////////////////get parameter value

                                              con6.Open();

                                              string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                              SqlCommand cmd3 = new SqlCommand(strSQL3, con6);
                                              cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                              cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                              SqlDataReader reader2 = cmd3.ExecuteReader();

                                              while (reader2.Read())
                                              {
                                                  CI2 = reader2["CI2"].ToString();
                                                  BCI3 = reader2["BCI3"].ToString();
                                                  SF6 = reader2["SF6"].ToString();
                                                  CHF3 = reader2["CHF3"].ToString();
                                                  Oxygen = reader2["Oxygen"].ToString();
                                                  Oxygen1 = reader2["Oxygen1"].ToString();
                                                  Nitrogen = reader2["Nitrogen"].ToString();
                                                  Argon = reader2["Argon"].ToString();



                                              }

                                              con6.Close();


                                              ////////////////////////////////////////////////
                                              con6.Open();
                                              Chamber1 chamber1 = new Chamber1();

                                              string wafer7strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                                  + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                              SqlCommand wafer2cmdparameter = new SqlCommand(wafer7strParameter, con6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                              wafer2cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                              wafer2cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                              wafer2cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                              wafer2cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                              wafer2cmdparameter.Parameters.AddWithValue("@21", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@23", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@28", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@31", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@33", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@38", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@41", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@43", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@48", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@71", strStepname1[a7]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@72", strStepname1[a7]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@73", strStepname1[a7]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@74", strStepname1[a7]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@75", strStepname1[a7]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@76", strStepname1[a7]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@77", strStepname1[a7]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@78", strStepname1[a7]);


                                              wafer2cmdparameter.ExecuteNonQuery();
                                              con6.Close();








                                          }


                                          strStepname1.Clear();
                                          ListStepStartTime.Clear();
                                          ListStepEndTime.Clear();

                                          /////////////////////////////////////////////////////////////////

                                          await Task.Delay(2000);

                                          label2.BackColor = Color.Blue;
                                          lblProcess.BackColor = Color.Blue;
                                          lblProcessStep.BackColor = Color.Blue;
                                          lblRecipe.BackColor = Color.Blue;
                                          lblStepName.BackColor = Color.Blue;
                                          lblData.BackColor = Color.Blue;
                                          lblnum.BackColor = Color.Blue;

                                          lblProcess.Text = "Aborted";
                                          lblProcessStep.Text = "";
                                          lblRecipe.Text = "";
                                          lblStepName.Text = "";
                                          lblnum.Text = "";
                                          lblData.Text = "???????????";



                                          picChamber.Image = Properties.Resources.new_chamber1;
                                          lblChamber.BackColor = Color.Blue;
                                          chamberload = "Blue";
                                          picChamber.Width -= 100;
                                          picChamber.Left += 150;
                                          await Task.Delay(2000);
                                          picChamber.Image = Properties.Resources.new_chamber;





                                          await Task.Delay(2000);



                                          await Task.Delay(2000);

                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette1;
                                          await Task.Delay(2000);

                                          lblCassette.BackColor = Color.LimeGreen;

                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picCassette.Height += 150;
                                          picCassette.Top -= 150;
                                          await Task.Delay(2000);
                                          lblCassette.BackColor = Color.Blue;

                                          picCassette.Image = Properties.Resources.cassette1;
                                          picCassette.Height -= 150;
                                          picCassette.Top += 150;
                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          picwafer.Image = Properties.Resources.waferfull;

                                          //////////////////////////////////////////////////////////////////Save DataLog
                                          EndTime = DateTime.Now;
                                          con6.Close();
                                          if (int.Parse(NoOfwafer[i]) == 7)
                                          {
                                              con6.Open();

                                              string wafer2strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                              SqlCommand wafer2cmdinsertdatalog = new SqlCommand(wafer2strinsertdatalog, con6);

                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                              wafer2cmdinsertdatalog.ExecuteNonQuery();

                                              con6.Close();


                                          }




                                          //////////////////////////////////////////////////////////////////////////finish waferA7


                                      }
                                      if (int.Parse(NoOfwafer[i]) >= 8)
                                      {

                                          //////////////////////////////////////////////////////////////////////////start waferA8
                                          await Task.Delay(2000);

                                          picCassette.Image = Properties.Resources.cassette1;
                                          await Task.Delay(2000);
                                          Wafer8StartTime = DateTime.Now;
                                          scsb = new SqlConnectionStringBuilder();
                                          scsb.DataSource = @"HP-PC\SQLEXPRESS";
                                          scsb.InitialCatalog = "RecipeType";
                                          scsb.IntegratedSecurity = true;
                                          SqlConnection con7 = new SqlConnection(scsb.ToString());
                                          con7.Open();

                                          string wafer8strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName) values(@NoOfWafer,@StartTime,@CassetteRecipeName)";
                                          SqlCommand wafer8cmdwaferselection = new SqlCommand(wafer8strWaferSelection, con7);
                                          wafer8cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "8");
                                          wafer8cmdwaferselection.Parameters.AddWithValue("@StartTime", Wafer8StartTime);
                                          wafer8cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                          wafer8cmdwaferselection.ExecuteNonQuery();

                                          con7.Close();




                                          // lblCassette.BackColor = Color.LimeGreen;

                                          lblCassette.BackColor = Color.LimeGreen;
                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picCassette.Height += 150;
                                          picCassette.Top -= 150;
                                          await Task.Delay(2000);
                                          picwafer.Image = Properties.Resources.waferA8;
                                          await Task.Delay(2000);
                                          // WaferTime = DateTime.Now;
                                          lblCassette.BackColor = Color.Blue;


                                          picCassette.Image = Properties.Resources.cassette1;
                                          picCassette.Height -= 150;
                                          picCassette.Top += 150;
                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          await Task.Delay(2000);

                                          await Task.Delay(2000);


                                          lblCentralize.BackColor = Color.LimeGreen;

                                          await Task.Delay(2000);


                                          lblCentralize.BackColor = Color.Blue;

                                          //picCentralize.Height -= 100;

                                          await Task.Delay(2000);

                                          await Task.Delay(2000);

                                          picChamber.Image = Properties.Resources.new_chamber1;

                                          await Task.Delay(2000);


                                          picChamber.Image = Properties.Resources.robot_into_chamberA8;
                                          picChamber.Width += 100;
                                          picChamber.Left -= 150;
                                          lblChamber.BackColor = Color.LimeGreen;

                                          chamberload = "LimeGreen";
                                          //////////////////////////////////////////////////////////////////////////////////wafer2 into chamber
                                          WaferTime = DateTime.Now;
                                          lblRecipe.BackColor = Color.LimeGreen;
                                          lblStepName.BackColor = Color.LimeGreen;
                                          lblnum.BackColor = Color.LimeGreen;
                                          lblData.BackColor = Color.LimeGreen;
                                          lblData.Text = "";
                                          label2.BackColor = Color.LimeGreen;
                                          lblProcess.Text = "Processing";
                                          lblProcess.BackColor = Color.LimeGreen;
                                          lblProcessStep.Text = "Process Step";
                                          lblProcessStep.BackColor = Color.LimeGreen;

                                          con7.Open();
                                          string wafer8strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                          SqlCommand wafer8cmd = new SqlCommand(wafer8strSQL, con7);
                                          wafer8cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                          SqlDataReader wafer8reader = wafer8cmd.ExecuteReader();
                                          while (wafer8reader.Read())
                                          {

                                              lblRecipe.Text = string.Format("{0}", wafer8reader["WaferRecipe"]);



                                          }

                                          con7.Close();
                                          con7.Open();
                                          string wafer8strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                          SqlCommand wafer8cmd1 = new SqlCommand(wafer8strSQL1, con7);
                                          wafer8cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                          SqlDataReader wafer8reader1 = wafer8cmd1.ExecuteReader();
                                          while (wafer8reader1.Read())
                                          {

                                              strStepname1.Add(string.Format("{0}", wafer8reader1["StepName"]));


                                          }

                                          con7.Close();
                                          con7.Open();
                                          string wafer8strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                          SqlCommand wafer8cmd2 = new SqlCommand(wafer8strSQL2, con7);
                                          wafer8cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          //SqlDataReader reader2 = cmd2.ExecuteReader();
                                          wafer8cmd2.ExecuteNonQuery();

                                          // while (reader2.Read())
                                          // {
                                          //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                                          // int row = strStepname.Count();
                                          for (int a8 = 0; a8 < strStepname1.Count(); a8 += 1)
                                          {
                                              await Task.Delay(1000);
                                              ListStepStartTime.Add(DateTime.Now);
                                              int count = i + a8;
                                              // await Task.Delay(2000);
                                              lblStepName.Text = strStepname1[a8];
                                              lblnum.Text = "," + count + "/" + strStepname1.Count();
                                              // lblnum.Text = "," + count + "/" + strStepname.Count();
                                              //  await Task.Delay(2000);

                                              con7.Close();

                                              con7.Open();
                                              string wafer8strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                              SqlCommand wafer8cmdSec = new SqlCommand(wafer8strSQLStepSec, con7);
                                              wafer8cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                              SqlDataReader wafer8readerSec = wafer8cmdSec.ExecuteReader();


                                              while (wafer8readerSec.Read())
                                              {
                                                  mySec1 = wafer8readerSec["ProcessTime"].ToString();
                                                  // lblSec.Text = string.Format("{0}", readerSec["ProcessPressure"]);
                                                  Int32.TryParse(mySec1, out Sec1);

                                              }

                                              for (int j = 1; j <= Sec1; j++)
                                              {
                                                  lblData.Text = j.ToString() + "/" + mySec1.ToString() + " Sec";
                                                  await Task.Delay(1000);


                                              }
                                              ListStepEndTime.Add(DateTime.Now);

                                              con7.Close();


                                              con7.Open();

                                              string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe)";

                                              SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con7);

                                              cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                              cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[a8]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[a8]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[a8]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "8");

                                              cmdmodulerecipe.ExecuteNonQuery();

                                              con7.Close();
                                              ///////////////////////////////////////////////////////get parameter value

                                              con7.Open();

                                              string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                              SqlCommand cmd3 = new SqlCommand(strSQL3, con7);
                                              cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                              cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                              SqlDataReader reader2 = cmd3.ExecuteReader();

                                              while (reader2.Read())
                                              {
                                                  CI2 = reader2["CI2"].ToString();
                                                  BCI3 = reader2["BCI3"].ToString();
                                                  SF6 = reader2["SF6"].ToString();
                                                  CHF3 = reader2["CHF3"].ToString();
                                                  Oxygen = reader2["Oxygen"].ToString();
                                                  Oxygen1 = reader2["Oxygen1"].ToString();
                                                  Nitrogen = reader2["Nitrogen"].ToString();
                                                  Argon = reader2["Argon"].ToString();



                                              }

                                              con7.Close();


                                              ////////////////////////////////////////////////
                                              con7.Open();
                                              Chamber1 chamber1 = new Chamber1();

                                              string wafer8strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                                  + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                              SqlCommand wafer2cmdparameter = new SqlCommand(wafer8strParameter, con7);
                                              wafer2cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                              wafer2cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                              wafer2cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                              wafer2cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                              wafer2cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                              wafer2cmdparameter.Parameters.AddWithValue("@21", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@23", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@28", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@31", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@33", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@38", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@41", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@43", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@48", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@71", strStepname1[a8]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@72", strStepname1[a8]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@73", strStepname1[a8]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@74", strStepname1[a8]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@75", strStepname1[a8]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@76", strStepname1[a8]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@77", strStepname1[a8]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@78", strStepname1[a8]);


                                              wafer2cmdparameter.ExecuteNonQuery();
                                              con7.Close();








                                          }


                                          strStepname1.Clear();
                                          ListStepStartTime.Clear();
                                          ListStepEndTime.Clear();

                                          /////////////////////////////////////////////////////////////////

                                          await Task.Delay(2000);

                                          label2.BackColor = Color.Blue;
                                          lblProcess.BackColor = Color.Blue;
                                          lblProcessStep.BackColor = Color.Blue;
                                          lblRecipe.BackColor = Color.Blue;
                                          lblStepName.BackColor = Color.Blue;
                                          lblData.BackColor = Color.Blue;
                                          lblnum.BackColor = Color.Blue;

                                          lblProcess.Text = "Aborted";
                                          lblProcessStep.Text = "";
                                          lblRecipe.Text = "";
                                          lblStepName.Text = "";
                                          lblnum.Text = "";
                                          lblData.Text = "???????????";


                                          picChamber.Image = Properties.Resources.new_chamber1;
                                          lblChamber.BackColor = Color.Blue;
                                          chamberload = "Blue";
                                          picChamber.Width -= 100;
                                          picChamber.Left += 150;
                                          await Task.Delay(2000);
                                          picChamber.Image = Properties.Resources.new_chamber;





                                          await Task.Delay(2000);

                                          await Task.Delay(2000);

                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette1;
                                          await Task.Delay(2000);

                                          lblCassette.BackColor = Color.LimeGreen;

                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picCassette.Height += 150;
                                          picCassette.Top -= 150;
                                          await Task.Delay(2000);
                                          lblCassette.BackColor = Color.Blue;

                                          picCassette.Image = Properties.Resources.cassette1;
                                          picCassette.Height -= 150;
                                          picCassette.Top += 150;
                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          picwafer.Image = Properties.Resources.waferfull;

                                          //////////////////////////////////////////////////////////////////Save DataLog
                                          EndTime = DateTime.Now;
                                          con7.Close();
                                          if (int.Parse(NoOfwafer[i]) == 8)
                                          {
                                              con7.Open();

                                              string wafer2strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                              SqlCommand wafer2cmdinsertdatalog = new SqlCommand(wafer2strinsertdatalog, con7);

                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                              wafer2cmdinsertdatalog.ExecuteNonQuery();

                                              con7.Close();



                                          }



                                          //////////////////////////////////////////////////////////////////////////finish waferA8

                                      }
                                      if (int.Parse(NoOfwafer[i]) >= 9)
                                      {

                                          //////////////////////////////////////////////////////////////////////////start waferA9
                                          await Task.Delay(2000);

                                          picCassette.Image = Properties.Resources.cassette1;
                                          await Task.Delay(2000);
                                          Wafer9StartTime = DateTime.Now;
                                          scsb = new SqlConnectionStringBuilder();
                                          scsb.DataSource = @"HP-PC\SQLEXPRESS";
                                          scsb.InitialCatalog = "RecipeType";
                                          scsb.IntegratedSecurity = true;
                                          SqlConnection con8 = new SqlConnection(scsb.ToString());
                                          con8.Open();

                                          string wafer9strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName) values(@NoOfWafer,@StartTime,@CassetteRecipeName)";
                                          SqlCommand wafer9cmdwaferselection = new SqlCommand(wafer9strWaferSelection, con8);
                                          wafer9cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "9");
                                          wafer9cmdwaferselection.Parameters.AddWithValue("@StartTime", Wafer9StartTime);
                                          wafer9cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                          wafer9cmdwaferselection.ExecuteNonQuery();

                                          con8.Close();




                                          // lblCassette.BackColor = Color.LimeGreen;

                                          lblCassette.BackColor = Color.LimeGreen;
                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picCassette.Height += 150;
                                          picCassette.Top -= 150;
                                          await Task.Delay(2000);
                                          picwafer.Image = Properties.Resources.waferA9;
                                          await Task.Delay(2000);
                                          // WaferTime = DateTime.Now;
                                          lblCassette.BackColor = Color.Blue;

                                          picCassette.Image = Properties.Resources.cassette1;
                                          picCassette.Height -= 150;
                                          picCassette.Top += 150;
                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          await Task.Delay(2000);

                                          await Task.Delay(2000);

                                          await Task.Delay(2000);

                                          lblCentralize.BackColor = Color.LimeGreen;


                                          //picCentralize.Height -= 100;


                                          await Task.Delay(2000);

                                          picChamber.Image = Properties.Resources.new_chamber1;

                                          await Task.Delay(2000);


                                          picChamber.Image = Properties.Resources.robot_into_chamberA9;
                                          picChamber.Width += 100;
                                          picChamber.Left -= 150;
                                          lblChamber.BackColor = Color.LimeGreen;

                                          chamberload = "LimeGreen";
                                          //////////////////////////////////////////////////////////////////////////////////waferA9 into chamber
                                          WaferTime = DateTime.Now;
                                          lblRecipe.BackColor = Color.LimeGreen;
                                          lblStepName.BackColor = Color.LimeGreen;
                                          lblnum.BackColor = Color.LimeGreen;
                                          lblData.BackColor = Color.LimeGreen;
                                          lblData.Text = "";
                                          label2.BackColor = Color.LimeGreen;
                                          lblProcess.Text = "Processing";
                                          lblProcess.BackColor = Color.LimeGreen;
                                          lblProcessStep.Text = "Process Step";
                                          lblProcessStep.BackColor = Color.LimeGreen;

                                          con8.Open();
                                          string wafer9strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                          SqlCommand wafer9cmd = new SqlCommand(wafer9strSQL, con8);
                                          wafer9cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                          SqlDataReader wafer9reader = wafer9cmd.ExecuteReader();
                                          while (wafer9reader.Read())
                                          {

                                              lblRecipe.Text = string.Format("{0}", wafer9reader["WaferRecipe"]);



                                          }

                                          con8.Close();
                                          con8.Open();
                                          string wafer9strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                          SqlCommand wafer9cmd1 = new SqlCommand(wafer9strSQL1, con8);
                                          wafer9cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                          SqlDataReader wafer9reader1 = wafer9cmd1.ExecuteReader();
                                          while (wafer9reader1.Read())
                                          {

                                              strStepname1.Add(string.Format("{0}", wafer9reader1["StepName"]));


                                          }

                                          con8.Close();
                                          con8.Open();
                                          string wafer9strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                          SqlCommand wafer9cmd2 = new SqlCommand(wafer9strSQL2, con8);
                                          wafer9cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          //SqlDataReader reader2 = cmd2.ExecuteReader();
                                          wafer9cmd2.ExecuteNonQuery();

                                          // while (reader2.Read())
                                          // {
                                          //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                                          // int row = strStepname.Count();
                                          for (int a9 = 0; a9 < strStepname1.Count(); a9 += 1)
                                          {
                                              await Task.Delay(1000);
                                              ListStepStartTime.Add(DateTime.Now);
                                              int count = a9 + 1;
                                              // await Task.Delay(2000);
                                              lblStepName.Text = strStepname1[a9];
                                              lblnum.Text = "," + count + "/" + strStepname1.Count();
                                              // lblnum.Text = "," + count + "/" + strStepname.Count();
                                              //  await Task.Delay(2000);

                                              con8.Close();

                                              con8.Open();
                                              string wafer9strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                              SqlCommand wafer9cmdSec = new SqlCommand(wafer9strSQLStepSec, con8);
                                              wafer9cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                              SqlDataReader wafer9readerSec = wafer9cmdSec.ExecuteReader();


                                              while (wafer9readerSec.Read())
                                              {
                                                  mySec1 = wafer9readerSec["ProcessTime"].ToString();
                                                  // lblSec.Text = string.Format("{0}", readerSec["ProcessPressure"]);
                                                  Int32.TryParse(mySec1, out Sec1);

                                              }

                                              for (int j = 1; j <= Sec1; j++)
                                              {
                                                  lblData.Text = j.ToString() + "/" + mySec1.ToString() + " Sec";
                                                  await Task.Delay(1000);


                                              }
                                              ListStepEndTime.Add(DateTime.Now);

                                              con8.Close();


                                              con8.Open();

                                              string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe)";

                                              SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con8);

                                              cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                              cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[a9]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[a9]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[a9]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "9");

                                              cmdmodulerecipe.ExecuteNonQuery();

                                              con8.Close();
                                              ///////////////////////////////////////////////////////get parameter value

                                              con8.Open();

                                              string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                              SqlCommand cmd3 = new SqlCommand(strSQL3, con8);
                                              cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                              cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                              SqlDataReader reader2 = cmd3.ExecuteReader();

                                              while (reader2.Read())
                                              {
                                                  CI2 = reader2["CI2"].ToString();
                                                  BCI3 = reader2["BCI3"].ToString();
                                                  SF6 = reader2["SF6"].ToString();
                                                  CHF3 = reader2["CHF3"].ToString();
                                                  Oxygen = reader2["Oxygen"].ToString();
                                                  Oxygen1 = reader2["Oxygen1"].ToString();
                                                  Nitrogen = reader2["Nitrogen"].ToString();
                                                  Argon = reader2["Argon"].ToString();



                                              }

                                              con8.Close();


                                              ////////////////////////////////////////////////
                                              con8.Open();
                                              Chamber1 chamber1 = new Chamber1();

                                              string wafer9strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                                  + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                              SqlCommand wafer2cmdparameter = new SqlCommand(wafer9strParameter, con8);
                                              wafer2cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                              wafer2cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                              wafer2cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                              wafer2cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                              wafer2cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                              wafer2cmdparameter.Parameters.AddWithValue("@21", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@23", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@28", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@31", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@33", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@38", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@41", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@43", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@48", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@71", strStepname1[a9]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@72", strStepname1[a9]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@73", strStepname1[a9]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@74", strStepname1[a9]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@75", strStepname1[a9]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@76", strStepname1[a9]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@77", strStepname1[a9]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@78", strStepname1[a9]);


                                              wafer2cmdparameter.ExecuteNonQuery();
                                              con8.Close();








                                          }


                                          strStepname1.Clear();
                                          ListStepStartTime.Clear();
                                          ListStepEndTime.Clear();

                                          /////////////////////////////////////////////////////////////////

                                          await Task.Delay(2000);

                                          label2.BackColor = Color.Blue;
                                          lblProcess.BackColor = Color.Blue;
                                          lblProcessStep.BackColor = Color.Blue;
                                          lblRecipe.BackColor = Color.Blue;
                                          lblStepName.BackColor = Color.Blue;
                                          lblData.BackColor = Color.Blue;
                                          lblnum.BackColor = Color.Blue;

                                          lblProcess.Text = "Aborted";
                                          lblProcessStep.Text = "";
                                          lblRecipe.Text = "";
                                          lblStepName.Text = "";
                                          lblnum.Text = "";
                                          lblData.Text = "???????????";



                                          picChamber.Image = Properties.Resources.new_chamber1;
                                          lblChamber.BackColor = Color.Blue;
                                          chamberload = "Blue";
                                          picChamber.Width -= 100;
                                          picChamber.Left += 150;
                                          await Task.Delay(2000);
                                          picChamber.Image = Properties.Resources.new_chamber;





                                          await Task.Delay(2000);


                                          await Task.Delay(2000);

                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette1;
                                          await Task.Delay(2000);

                                          lblCassette.BackColor = Color.LimeGreen;

                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picCassette.Height += 150;
                                          picCassette.Top -= 150;
                                          await Task.Delay(2000);
                                          lblCassette.BackColor = Color.Blue;

                                          picCassette.Image = Properties.Resources.cassette1;
                                          picCassette.Height -= 150;
                                          picCassette.Top += 150;
                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          picwafer.Image = Properties.Resources.waferfull;

                                          //////////////////////////////////////////////////////////////////Save DataLog
                                          EndTime = DateTime.Now;
                                          con8.Close();
                                          if (int.Parse(NoOfwafer[i]) == 9)
                                          {
                                              con8.Open();

                                              string wafer2strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                              SqlCommand wafer2cmdinsertdatalog = new SqlCommand(wafer2strinsertdatalog, con8);

                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                              wafer2cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                              wafer2cmdinsertdatalog.ExecuteNonQuery();

                                              con8.Close();

                                          }

                                          //////////////////////////////////////////////////////////////////////////finish waferA9

                                      }
                                      if (int.Parse(NoOfwafer[i]) >= 10)
                                      {

                                          //////////////////////////////////////////////////////////////////////////start waferA10


                                          await Task.Delay(2000);

                                          picCassette.Image = Properties.Resources.cassette1;
                                          await Task.Delay(2000);
                                          Wafer10StartTime = DateTime.Now;
                                          scsb = new SqlConnectionStringBuilder();
                                          scsb.DataSource = @"HP-PC\SQLEXPRESS";
                                          scsb.InitialCatalog = "RecipeType";
                                          scsb.IntegratedSecurity = true;
                                          SqlConnection con9 = new SqlConnection(scsb.ToString());
                                          con9.Open();

                                          string wafer10strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName) values(@NoOfWafer,@StartTime,@CassetteRecipeName)";
                                          SqlCommand wafer10cmdwaferselection = new SqlCommand(wafer10strWaferSelection, con9);
                                          wafer10cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "10");
                                          wafer10cmdwaferselection.Parameters.AddWithValue("@StartTime", Wafer10StartTime);
                                          wafer10cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                          wafer10cmdwaferselection.ExecuteNonQuery();

                                          con9.Close();




                                          // lblCassette.BackColor = Color.LimeGreen;

                                          lblCassette.BackColor = Color.LimeGreen;
                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picCassette.Height += 150;
                                          picCassette.Top -= 150;
                                          await Task.Delay(2000);
                                          picwafer.Image = Properties.Resources.waferA10;
                                          await Task.Delay(2000);
                                          // WaferTime = DateTime.Now;
                                          lblCassette.BackColor = Color.Blue;


                                          picCassette.Image = Properties.Resources.cassette1;
                                          picCassette.Height -= 150;
                                          picCassette.Top += 150;
                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          await Task.Delay(2000);


                                          await Task.Delay(2000);

                                          lblCentralize.BackColor = Color.LimeGreen;


                                          await Task.Delay(2000);

                                          lblCentralize.BackColor = Color.Blue;

                                          //picCentralize.Height -= 100;



                                          await Task.Delay(2000);

                                          picChamber.Image = Properties.Resources.new_chamber1;

                                          await Task.Delay(2000);

                                          picChamber.Image = Properties.Resources.robot_into_chamberA10;
                                          picChamber.Width += 100;
                                          picChamber.Left -= 150;
                                          lblChamber.BackColor = Color.LimeGreen;

                                          chamberload = "LimeGreen";
                                          //////////////////////////////////////////////////////////////////////////////////waferA10 into chamber
                                          WaferTime = DateTime.Now;
                                          lblRecipe.BackColor = Color.LimeGreen;
                                          lblStepName.BackColor = Color.LimeGreen;
                                          lblnum.BackColor = Color.LimeGreen;
                                          lblData.BackColor = Color.LimeGreen;
                                          lblData.Text = "";
                                          label2.BackColor = Color.LimeGreen;
                                          lblProcess.Text = "Processing";
                                          lblProcess.BackColor = Color.LimeGreen;
                                          lblProcessStep.Text = "Process Step";
                                          lblProcessStep.BackColor = Color.LimeGreen;

                                          con9.Open();
                                          string wafer10strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                          SqlCommand wafer10cmd = new SqlCommand(wafer10strSQL, con9);
                                          wafer10cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                          SqlDataReader wafer10reader = wafer10cmd.ExecuteReader();
                                          while (wafer10reader.Read())
                                          {

                                              lblRecipe.Text = string.Format("{0}", wafer10reader["WaferRecipe"]);



                                          }

                                          con9.Close();
                                          con9.Open();
                                          string wafer10strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                          SqlCommand wafer10cmd1 = new SqlCommand(wafer10strSQL1, con9);
                                          wafer10cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                          SqlDataReader wafer10reader1 = wafer10cmd1.ExecuteReader();
                                          while (wafer10reader1.Read())
                                          {

                                              strStepname1.Add(string.Format("{0}", wafer10reader1["StepName"]));


                                          }

                                          con9.Close();
                                          con9.Open();
                                          string wafer10strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                          SqlCommand wafer10cmd2 = new SqlCommand(wafer10strSQL2, con9);
                                          wafer10cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          //SqlDataReader reader2 = cmd2.ExecuteReader();
                                          wafer10cmd2.ExecuteNonQuery();

                                          // while (reader2.Read())
                                          // {
                                          //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                                          // int row = strStepname.Count();
                                          for (int a10 = 0; a10 < strStepname1.Count(); a10 += 1)
                                          {
                                              await Task.Delay(1000);
                                              ListStepStartTime.Add(DateTime.Now);
                                              int count = a10 + 1;
                                              // await Task.Delay(2000);
                                              lblStepName.Text = strStepname1[a10];
                                              lblnum.Text = "," + count + "/" + strStepname1.Count();
                                              // lblnum.Text = "," + count + "/" + strStepname.Count();
                                              //  await Task.Delay(2000);

                                              con9.Close();

                                              con9.Open();
                                              string wafer10strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                              SqlCommand wafer10cmdSec = new SqlCommand(wafer10strSQLStepSec, con9);
                                              wafer10cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                              SqlDataReader wafer10readerSec = wafer10cmdSec.ExecuteReader();


                                              while (wafer10readerSec.Read())
                                              {
                                                  mySec1 = wafer10readerSec["ProcessTime"].ToString();
                                                  // lblSec.Text = string.Format("{0}", readerSec["ProcessPressure"]);
                                                  Int32.TryParse(mySec1, out Sec1);

                                              }

                                              for (int j = 1; j <= Sec1; j++)
                                              {
                                                  lblData.Text = j.ToString() + "/" + mySec1.ToString() + " Sec";
                                                  await Task.Delay(1000);


                                              }
                                              ListStepEndTime.Add(DateTime.Now);

                                              con9.Close();


                                              con9.Open();

                                              string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe)";

                                              SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con9);

                                              cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                              cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[a10]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[a10]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[a10]);
                                              cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "10");

                                              cmdmodulerecipe.ExecuteNonQuery();

                                              con9.Close();
                                              ///////////////////////////////////////////////////////get parameter value

                                              con9.Open();

                                              string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                              SqlCommand cmd3 = new SqlCommand(strSQL3, con9);
                                              cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                              cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                              SqlDataReader reader2 = cmd3.ExecuteReader();

                                              while (reader2.Read())
                                              {
                                                  CI2 = reader2["CI2"].ToString();
                                                  BCI3 = reader2["BCI3"].ToString();
                                                  SF6 = reader2["SF6"].ToString();
                                                  CHF3 = reader2["CHF3"].ToString();
                                                  Oxygen = reader2["Oxygen"].ToString();
                                                  Oxygen1 = reader2["Oxygen1"].ToString();
                                                  Nitrogen = reader2["Nitrogen"].ToString();
                                                  Argon = reader2["Argon"].ToString();



                                              }

                                              con9.Close();


                                              ////////////////////////////////////////////////
                                              con9.Open();
                                              Chamber1 chamber1 = new Chamber1();

                                              string wafer10strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                                  + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                              SqlCommand wafer2cmdparameter = new SqlCommand(wafer10strParameter, con9);
                                              wafer2cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                              wafer2cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                              wafer2cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                              wafer2cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                              wafer2cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                              wafer2cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                              wafer2cmdparameter.Parameters.AddWithValue("@21", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@23", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@28", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@31", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@33", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@38", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@41", CI2);
                                              wafer2cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@43", SF6);
                                              wafer2cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                              wafer2cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                              wafer2cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                              wafer2cmdparameter.Parameters.AddWithValue("@48", Argon);
                                              wafer2cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                              wafer2cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                              wafer2cmdparameter.Parameters.AddWithValue("@71", strStepname1[a10]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@72", strStepname1[a10]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@73", strStepname1[a10]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@74", strStepname1[a10]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@75", strStepname1[a10]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@76", strStepname1[a10]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@77", strStepname1[a10]);
                                              wafer2cmdparameter.Parameters.AddWithValue("@78", strStepname1[a10]);


                                              wafer2cmdparameter.ExecuteNonQuery();
                                              con9.Close();








                                          }


                                          strStepname1.Clear();
                                          ListStepStartTime.Clear();
                                          ListStepEndTime.Clear();

                                          /////////////////////////////////////////////////////////////////

                                          await Task.Delay(2000);

                                          label2.BackColor = Color.Blue;
                                          lblProcess.BackColor = Color.Blue;
                                          lblProcessStep.BackColor = Color.Blue;
                                          lblRecipe.BackColor = Color.Blue;
                                          lblStepName.BackColor = Color.Blue;
                                          lblData.BackColor = Color.Blue;
                                          lblnum.BackColor = Color.Blue;

                                          lblProcess.Text = "Aborted";
                                          lblProcessStep.Text = "";
                                          lblRecipe.Text = "";
                                          lblStepName.Text = "";
                                          lblnum.Text = "";
                                          lblData.Text = "???????????";



                                          picChamber.Image = Properties.Resources.new_chamber1;
                                          lblChamber.BackColor = Color.Blue;
                                          chamberload = "Blue";
                                          picChamber.Width -= 100;
                                          picChamber.Left += 150;
                                          await Task.Delay(2000);
                                          picChamber.Image = Properties.Resources.new_chamber;





                                          await Task.Delay(2000);

                                          await Task.Delay(2000);

                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette1;
                                          await Task.Delay(2000);

                                          lblCassette.BackColor = Color.LimeGreen;

                                          picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                          picCassette.Height += 150;
                                          picCassette.Top -= 150;
                                          await Task.Delay(2000);
                                          lblCassette.BackColor = Color.Blue;

                                          picCassette.Image = Properties.Resources.cassette1;
                                          picCassette.Height -= 150;
                                          picCassette.Top += 150;
                                          await Task.Delay(2000);
                                          picCassette.Image = Properties.Resources.cassette;
                                          picwafer.Image = Properties.Resources.waferfull;

                                          //////////////////////////////////////////////////////////////////Save DataLog
                                          if (int.Parse(NoOfwafer[i]) == 10)
                                          {
                                              EndTime = DateTime.Now;
                                              con9.Close();

                                              con9.Open();

                                              string wafer10strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                              SqlCommand wafer10cmdinsertdatalog = new SqlCommand(wafer10strinsertdatalog, con9);

                                              wafer10cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                              wafer10cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                              wafer10cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                              wafer10cmdinsertdatalog.ExecuteNonQuery();

                                              con9.Close();
                                          }
                                          //////////////////////////////////////////////////////////////////////////finish waferA10




                                      }






                                  }











                                  ////////////////////////////////////////////////////////////////////////////////////////////////////start WaferA1

                                  ////////////////////////////////////////////////////////////////////////////////////////////////finish waferA1
                                  /////////////////////////////////////////////////////////////////////////////////////////////////start waferA2


                                  //////////////////////////////////////////////////////////////////////////////A2 finish

                                  //////////////////////////////////////////////////////////////////////////////start A3


                                  /////////////////////////////////////////////////////////////////////////////////////////waferA3 finish 

                                  ////////////////////////////////////////////////////////////////////////////////////////start waferA4








                                  ///////////////////////////////////////////////////////////////////////////////////////////waferA4 finish

                                  ////////////////////////////////////////////////////////////////////////////////////////////////start waferA5




                                  ///////////////////////////////////////////////////////////////////////////////////////////////////////waferA5 finish

                                  ////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA6





                                  //////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA6 finish

                                  //////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA7







                                  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA7 finisg

                                  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA8












                                  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA8 finish

                                  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA9






                                  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA9 finish


                                  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA10





                                  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA10 finish
                                  */
                                }
                            }
                            if(ispauserobot==true)

                            {
                                button3.Enabled = false;
                                button4.Enabled = false;
                                button5.Enabled = false;

                                return;

                           }
                            if(isStopRobot==true)
                            {

                               

                                return;
                                    
                                    }

                            if (iscancelrecipe == true)
                            {

                               
                                picMain.Image = Properties.Resources.mainpicture;

                                button3.Enabled = false;
                                button4.Enabled = false;
                                button5.Enabled = false;

                                lblwafer.Visible = false;
                                lblwaferup.Visible = false;
                                lblwaferaligner.Visible = false;
                                lblwaferright.Visible = false;
                                lblwaferAPM.Visible = false;

                                lblState.Text = "";
                                lblnum.Text = "";
                                lblStepName.Text = "";
                                lblRecipe.Text = "";
                                lblProcessStep.Text = "";
                                lblProcess.Text = "idle";

                                button2.Enabled = true;
                                button2.Tag = "";

                                picmap.Visible = false;
                                picmap1.Visible = false;
                                lbl123.Text = "";
                                lblCassetteRecipename.Text = "";

                                picWafer1.Visible = false;
                                picWafer2.Visible = false;
                                picWafer3.Visible = false;
                                picWafer4.Visible = false;
                                picWafer5.Visible = false;
                                picWafer6.Visible = false;
                                picWafer7.Visible = false;
                                picWafer8.Visible = false;
                                picWafer9.Visible = false;
                                picWafer10.Visible = false;
                                picWafer11.Visible = false;
                                picWafer12.Visible = false;
                                picWafer13.Visible = false;
                                picWafer14.Visible = false;
                                picWafer15.Visible = false;
                                picWafer16.Visible = false;
                                picWafer17.Visible = false;
                                picWafer18.Visible = false;
                                picWafer19.Visible = false;
                                picWafer20.Visible = false;
                                picWafer21.Visible = false;
                                picWafer22.Visible = false;
                                picWafer23.Visible = false;
                                picWafer24.Visible = false;
                                picWafer25.Visible = false;


                                lblProcess.Text = "Idle"; 
                                    lbltm.Text = "Idle";

                                //   lblLoad.Text = "Aborted";
                                lblLoad.Text = "Selected recipe:" + form2Msg;
                                picMain.Image.Tag = "mainpicture";

                                return;
                            }



                        }
                    }

                    else
                    {

                        MessageBox.Show("APM and TM are not idle");
                    }


                }
                else
                {
                    MessageBox.Show("Transport not in Automatic");

                }
            }
            if (button2.Tag.ToString() == "robotPause")
            {

                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;



                PauseAndStopRobot resumerobot = new PauseAndStopRobot();
                resumerobot.label1.Text = "Do you want to resume the recipe?";
                DialogResult dr = resumerobot.ShowDialog();

                if (dr == DialogResult.OK)

                {

                    scsb = new SqlConnectionStringBuilder();
                    scsb.DataSource = datasource;
                    scsb.InitialCatalog = "RecipeType";
                    scsb.IntegratedSecurity = true;
                    SqlConnection con = new SqlConnection(scsb.ToString());

                    con.Open();

                    SqlCommand cmdeventlog = new SqlCommand(strEvent,con);

                    cmdeventlog.Parameters.AddWithValue("@1",DateTime.Now);
                    cmdeventlog.Parameters.AddWithValue("@2", "Resume robot");
                    cmdeventlog.Parameters.AddWithValue("@3", "Resume robot");

                    cmdeventlog.ExecuteNonQuery();

                    con.Close();

                    ispauserobot = false;

                    isStopRobot = false;


                    restartrobot();

                    button2.Enabled = false;
                }
            }
            if(button2.Tag.ToString()== "robotRestart")
            {

                PauseAndStopRobot restartrobot1 = new PauseAndStopRobot();
                restartrobot1.label1.Text = "Do you want to restart the recipe?";
                DialogResult dr = restartrobot1.ShowDialog();

                

                if (dr == DialogResult.OK)

                {
                    scsb = new SqlConnectionStringBuilder();
                    scsb.DataSource = datasource;
                    scsb.InitialCatalog = "RecipeType";
                    scsb.IntegratedSecurity = true;
                    SqlConnection con = new SqlConnection(scsb.ToString());

                    con.Open();

                    SqlCommand cmdeventlog = new SqlCommand(strEvent, con);

                    cmdeventlog.Parameters.AddWithValue("@1", DateTime.Now);
                    cmdeventlog.Parameters.AddWithValue("@2", "Restart robot");
                    cmdeventlog.Parameters.AddWithValue("@3", "Restart robot");

                    cmdeventlog.ExecuteNonQuery();

                    con.Close();






                    ispauserobot = false;

                    isStopRobot = false;


                    restartrobot();

                    button2.Enabled = false;
                }




            }

        }



        private async void restartrobot()
        {
            //       pauseSignal = new ManualResetEvent(false);






            if (btnVCH.Text == "Control Mode: Automatic")

            {

                if (lblProcess.Text == "Idle" && lbltm.Text == "Idle")

                {


                   // LotInformation lot = new LotInformation();
                   // DialogResult dr = lot.ShowDialog();
                    scsb = new SqlConnectionStringBuilder();
                    scsb.DataSource = datasource;
                    scsb.InitialCatalog = "RecipeType";
                    scsb.IntegratedSecurity = true;
                    SqlConnection con = new SqlConnection(scsb.ToString());


                   // if (dr == DialogResult.OK)
                   // {

                        if (ispauserobot == false)
                        {

                            //   pauseSignal = new ManualResetEvent(true);
                            //   taskTimer = new Task(timerCallback);
                            //  taskTimer.Start();
                            //    await taskTimer;





                            con.Open();
                            string SQLnoofwafer = "select noofwafers from cassettewafer where cassetterecipename like @searchcassetterecipename";
                            SqlCommand cmdnoofwafer = new SqlCommand(SQLnoofwafer, con);
                            cmdnoofwafer.Parameters.AddWithValue("@searchcassetterecipename", form2Msg);
                            SqlDataReader readernoofwafer = cmdnoofwafer.ExecuteReader();
                            while (readernoofwafer.Read())
                            {
                                NoOfwafer.Add(readernoofwafer["noofwafers"].ToString());

                            }
                            con.Close();
                            if (ispauserobot == false && picMain.Image.Tag.ToString() == "mainpicture")
                            {
                                await Task.Delay(1000);

                                con.Open();

                                SqlCommand cmdevent = new SqlCommand(strEvent, con);
                                cmdevent.Parameters.AddWithValue("@1", DateTime.Now);
                                cmdevent.Parameters.AddWithValue("@2", "Machine robot reversal");
                                cmdevent.Parameters.AddWithValue("@3", "reverse the robot");

                                cmdevent.ExecuteNonQuery();

                                con.Close();

                                picMain.Image = Properties.Resources.picrobotbotton;
                                picMain.Image.Tag = "picrobotbotton";
                            }
                            if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotbotton")
                            {
                                await Task.Delay(1000);
                                /////////////////////////////////////////////////////////////////////////////////////開始掃描Wafers

                                picMain.Image = Properties.Resources.picrobotanalysis;
                                picMain.Image.Tag = "picrobotanalysis";

                                lblLoad.Text = "Loading";
                                lblLoad.BackColor = Color.LimeGreen;
                                lblmTorr.BackColor = Color.LimeGreen;
                            lbl123.Text = str123;
                                lbl123.BackColor = Color.LimeGreen;
                                lblCassetteRecipename.Text = form2Msg;
                                lblCassetteRecipename.BackColor = Color.LimeGreen;
                                lblState.Text = "Starting";
                                lblState.BackColor = Color.LimeGreen;
                                label1.BackColor = Color.LimeGreen;
                                //  label1.Text = "Analysising.....";
                                // label1.Font = new Font("微軟正黑體", 10);
                            }
                            if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotanalysis")
                            {
                                await Task.Delay(1000);

                                picMain.Image = Properties.Resources.picrobotbotton;
                                label1.Text = "";
                                picMain.Image.Tag = "picrobotbotton2";

                                //    picwafer.Image = Properties.Resources.waferfull;
                                //  picwafer.Image.Tag = "waferfull";

                                foreach (string i in NoOfwafer)
                                {
                                    if (i == "1")
                                    {

                                        //  picwafer.Image = Properties.Resources.waferA1full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;



                                        picWafer1.Visible = true;

                                    }

                                    else if (i == "2")
                                    {
                                        //    picwafer.Image = Properties.Resources.waferA2full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;


                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;

                                    }

                                    else if (i == "3")
                                    {
                                        // picwafer.Image = Properties.Resources.waferA3full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;




                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;
                                        picWafer3.Visible = true;
                                    }
                                    else if (i == "4")
                                    {
                                        //picwafer.Image = Properties.Resources.waferA4full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;



                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;
                                        picWafer3.Visible = true;
                                        picWafer4.Visible = true;
                                    }
                                    else if (i == "5")
                                    {
                                        // picwafer.Image = Properties.Resources.waferA5full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;




                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;
                                        picWafer3.Visible = true;
                                        picWafer4.Visible = true;
                                        picWafer5.Visible = true;
                                    }
                                    else if (i == "6")
                                    {
                                        //  picwafer.Image = Properties.Resources.waferA6full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;





                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;
                                        picWafer3.Visible = true;
                                        picWafer4.Visible = true;
                                        picWafer5.Visible = true;
                                        picWafer6.Visible = true;
                                    }
                                    else if (i == "7")
                                    {

                                        // picwafer.Image = Properties.Resources.waferA7full;

                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;




                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;
                                        picWafer3.Visible = true;
                                        picWafer4.Visible = true;
                                        picWafer5.Visible = true;
                                        picWafer6.Visible = true;
                                        picWafer7.Visible = true;
                                    }
                                    else if (i == "8")
                                    {

                                        // picwafer.Image = Properties.Resources.waferA8full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;




                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;
                                        picWafer3.Visible = true;
                                        picWafer4.Visible = true;
                                        picWafer5.Visible = true;
                                        picWafer6.Visible = true;
                                        picWafer7.Visible = true;
                                        picWafer8.Visible = true;

                                    }
                                    else if (i == "9")
                                    {
                                        //  picwafer.Image = Properties.Resources.waferA9full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;




                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;
                                        picWafer3.Visible = true;
                                        picWafer4.Visible = true;
                                        picWafer5.Visible = true;
                                        picWafer6.Visible = true;
                                        picWafer7.Visible = true;
                                        picWafer8.Visible = true;
                                        picWafer9.Visible = true;
                                    }
                                    else if (i == "10")
                                    {
                                        // picwafer.Image = Properties.Resources.waferA10full;
                                        picWafer1.Visible = false;
                                        picWafer2.Visible = false;
                                        picWafer3.Visible = false;
                                        picWafer4.Visible = false;
                                        picWafer5.Visible = false;
                                        picWafer6.Visible = false;
                                        picWafer7.Visible = false;
                                        picWafer8.Visible = false;
                                        picWafer9.Visible = false;
                                        picWafer10.Visible = false;
                                        picWafer11.Visible = false;
                                        picWafer12.Visible = false;
                                        picWafer13.Visible = false;
                                        picWafer14.Visible = false;
                                        picWafer15.Visible = false;
                                        picWafer16.Visible = false;
                                        picWafer17.Visible = false;
                                        picWafer18.Visible = false;
                                        picWafer19.Visible = false;
                                        picWafer20.Visible = false;
                                        picWafer21.Visible = false;
                                        picWafer22.Visible = false;
                                        picWafer23.Visible = false;
                                        picWafer24.Visible = false;
                                        picWafer25.Visible = false;





                                        picWafer1.Visible = true;
                                        picWafer2.Visible = true;
                                        picWafer3.Visible = true;
                                        picWafer4.Visible = true;
                                        picWafer5.Visible = true;
                                        picWafer6.Visible = true;
                                        picWafer7.Visible = true;
                                        picWafer8.Visible = true;
                                        picWafer9.Visible = true;
                                        picWafer10.Visible = true;


                                    }

                                }


                            }

                            if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotbotton2")
                            {
                                await Task.Delay(1000);


                                // pictRobot.Visible = true;
                                // picCassette.Image = Properties.Resources.cassette1;
                                // picCassette.Height -= 150;
                                // picCassette.Top += 150;
                                lblCassette.BackColor = Color.Blue;
                                lblCassette.Tag = "Blue";
                                // lblCassette.Text = "Cassette";

                            }

                            if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotbotton2" && lblCassette.Tag.ToString() == "Blue")
                            {
                                await Task.Delay(1000);

                                //pictRobot.Image = Properties.Resources.new_robot;
                                picMain.Image = Properties.Resources.mainpicture;
                                picMain.Image.Tag = "mainpicture2";
                            }
                            //  await Task.Delay(1000);

                            //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                            // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                            if (ispauserobot == false && picMain.Image.Tag.ToString() == "mainpicture2")
                            {
                                await Task.Delay(1000);

                                picMain.Image = Properties.Resources.picrobotintocassette;
                                picMain.Image.Tag = "picrobotintocassette";
                                picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                picCassette.Width += 25;
                                picCassette.Height += 220;
                                picCassette.Top -= 205;
                                picCassette.Image.Tag = "robot_into_cassetteA1";
                                picCassette.Left += 5;
                                label1.BackColor = Color.Blue;
                                lblLoad.Text = "";
                                lblLoad.BackColor = Color.Blue;
                                lbl123.BackColor = Color.Blue;
                                lblState.BackColor = Color.Blue;
                                lblCassetteRecipename.BackColor = Color.Blue;
                                lblmTorr.BackColor = Color.Blue;


                                lblCassette.BackColor = Color.LimeGreen;
                            }


                            await Task.Delay(1000);

                            for (int i = 0; i < NoOfwafer.Count; i++)

                            {


                                if (int.Parse(NoOfwafer[i]) >= 1)
                                {
                                    /////////////////////////////////////////////////////////start WaferA1
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassette")
                                    {
                                        picCassette.Image = Properties.Resources.cassette;
                                        await Task.Delay(1000);
                                        if (NoOfwafer[i] == "1")
                                        {
                                            // picwafer.Image = Properties.Resources.wafer;
                                            // picwafer.Image.Tag = "wafer";
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "2")
                                        {
                                            //  picwafer.Image = Properties.Resources.wafermapA2;
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "3")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA3fullA1;
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "4")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA4fullA1;
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "5")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5fullA1;
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "6")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5fullA1;
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "7")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5fullA1;
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "8")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5fullA1;
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "9")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5fullA1;
                                            picWafer1.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "10")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5fullA1;
                                            picWafer1.Visible = false;
                                        }


                                        StartTime = DateTime.Now;


                                        con.Open();

                                        string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                        SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                        cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "1");
                                        cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                        cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                        cmdwaferselection.Parameters.AddWithValue("Logname", lbl123.Text);
                                        cmdwaferselection.ExecuteNonQuery();

                                        con.Close();












                                        picMain.Image = Properties.Resources.picrobotArmWafer;
                                        picMain.Image.Tag = "picrobotArmWaferA1";
                                        // panel1.Visible = true;
                                        //  ovalShape1.Visible = true;
                                        lblwafer.Visible = true;
                                        lblwafer.Text = "A1";
                                        lblCassette.BackColor = Color.Blue;

                                        picCassette.Image = Properties.Resources.cassette3;

                                        // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                        picCassette.Height -= 220;
                                        picCassette.Width -= 25;
                                        picCassette.Top += 205;
                                        picCassette.Image.Tag = "cassette";
                                        picCassette.Left -= 5;
                                        //  await Task.Delay(1000);
                                        picCassette.Image = Properties.Resources.cassette;
                                        // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA1")
                                    {
                                        await Task.Delay(1000);



                                        // pictRobot.Image = Properties.Resources.robotleft_A1;
                                        //   picMain.Image = Properties.Resources.picrobotcentralized;
                                        picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                        picMain.Image.Tag = "picrobotAlignerWaferA1";
                                        //  ovalShape1.Visible = true;
                                        // lblwafer.Visible = true;
                                        ovalShape1.Left += 70;
                                        ovalShape1.Top -= 85;
                                        lblwafer.Visible = false;
                                        lblwaferright.Visible = true;
                                        lblwaferright.Text = "A1";
                                        lblwafer.Left += 70;
                                        lblwafer.Top -= 85;
                                        // panel1.Visible = false;



                                        //   await Task.Delay(2000);
                                        //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                        //  picMain.Image = Properties.Resources.robotleftA1opencentralize;
                                    }

                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA1")
                                    {
                                        await Task.Delay(1000);






                                        // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                        //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                        picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                        picMain.Image.Tag = "picrobotintoAlignerWaferA1";
                                        lblCentralize.BackColor = Color.LimeGreen;
                                        ovalShape1.Left += 155;
                                        ovalShape1.Top += 0;
                                        lblwaferright.Visible = false;
                                        lblwaferaligner.Visible = true;
                                        lblwaferaligner.Text = "A1";
                                        lblwafer.Left += 155;
                                        lblwafer.Top += 0;

                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAlignerWaferA1")
                                    {
                                        ////////////////////////////////////////////////////////////////////////////////////
                                        await Task.Delay(2000);
                                        // pictRobot.Visible = true;
                                        // picCentralize.Image = Properties.Resources.centralize2;
                                        // picMain.Image = Properties.Resources.picrobotcentralized;
                                        picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                        picMain.Image.Tag = "picrobotAlignerWaferA1-2";
                                        // ovalShape1.Visible = true;
                                        //picwafer.Visible = true;
                                        lblwaferaligner.Visible = false;
                                        lblwaferright.Visible = true;
                                        lblwaferright.Text = "A1";
                                        ovalShape1.Left -= 155;
                                        ovalShape1.Top -= 0;
                                        lblwafer.Left -= 155;
                                        lblwafer.Top -= 0;
                                        lblCentralize.BackColor = Color.Blue;

                                        // await Task.Delay(2000);
                                        // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                        // picMain.Image = Properties.Resources.robotleftA1;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA1-2")
                                    {
                                        await Task.Delay(2000);

                                        //   picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picrobotAPMWafer;
                                        picMain.Image.Tag = "picrobotAPMWaferA1";
                                        lblwaferright.Visible = false;
                                        lblwaferup.Visible = true;
                                        lblwaferup.Text = "A1";
                                        ovalShape1.Left -= 82;
                                        ovalShape1.Top -= 76;
                                        lblwafer.Left -= 82;
                                        lblwafer.Top -= 76;



                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA1" && picSV.Visible == true)
                                    {
                                        await Task.Delay(1000);

                                        // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                        // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                        picSV.Visible = false;  // open sv of chamber

                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA1" && picSV.Visible == false)
                                    {
                                        await Task.Delay(1000);

                                        //pictRobot.Visible = false;
                                        //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                        //  picMain.Image = Properties.Resources.picrobotintochamber;
                                        picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                        picMain.Image.Tag = "picrobotintoAPMWaferA1";
                                        // picChamber.Width += 140;
                                        //picChamber.Left -= 150;
                                        //picChamber.Height += 10;
                                        lblwaferup.Visible = false;
                                        lblwaferAPM.Visible = true;
                                        lblwaferAPM.Text = "A1";
                                        ovalShape1.Top -= 145;
                                        ovalShape1.Left += 3;
                                        lblwafer.Top -= 145;
                                        lblwafer.Left += 3;



                                        lblChamber.BackColor = Color.LimeGreen;

                                        chamberload = "LimeGreen";

                                        // loaddata();
                                        // loadchamber1( sender, e);
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA1")
                                    {
                                        await Task.Delay(1000);
                                        picChamber.Image = Properties.Resources.ChamberWithA1;
                                        //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                        picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picwaferinAPM;
                                        picMain.Image.Tag = "picwaferinAPMA1";
                                        ovalShape1.Left -= 1;
                                        ovalShape1.Left += 1;
                                        //  picMain.SendToBack();
                                        // ovalShape1.BringToFront();
                                        picChamber.Width -= 140;
                                        picChamber.Left += 150;
                                        picChamber.Height -= 10;


                                        //  pictRobot.Visible = true;

                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA1" && picSV.Visible == false)
                                    {
                                        await Task.Delay(1000);

                                        picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                        //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                        picSV.Visible = true;

                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA1 into Chamber
                                        Chamber1 chamber1 = new Chamber1();
                                        chamber1.ShowDialog();

                                        lblRecipe.BackColor = Color.LimeGreen;
                                        lblStepName.BackColor = Color.LimeGreen;

                                        lblnum.BackColor = Color.LimeGreen;

                                        lblData.BackColor = Color.LimeGreen;
                                        lblData.Text = "";
                                        label2.BackColor = Color.LimeGreen;

                                        lblProcess.Text = "Processing";
                                        lblProcess.BackColor = Color.LimeGreen;
                                        lblProcessStep.Text = "Process Step";
                                        lblProcessStep.BackColor = Color.LimeGreen;



                                        con.Open();
                                        string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                        SqlCommand cmd = new SqlCommand(strSQL, con);
                                        cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        while (reader.Read())
                                        {


                                            lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                        }

                                        con.Close();
                                        con.Open();
                                        string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                        SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                        cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                        SqlDataReader reader1 = cmd1.ExecuteReader();
                                        while (reader1.Read())
                                        {

                                            strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                        }

                                        con.Close();

                                        con.Open();
                                        string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                        SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                        cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                        cmd2.ExecuteNonQuery();



                                        for (int j = 0; j < strStepname1.Count(); j += 1)

                                        {

                                            //await Task.Delay(1000);

                                            ListStepStartTime.Add(DateTime.Now);


                                            int count = j + 1;


                                            lblStepName.Text = strStepname1[j];
                                            lblnum.Text = "," + count + "/" + strStepname1.Count();


                                            con.Close();

                                            con.Open();
                                            string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                            SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                            cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                            SqlDataReader readerSec = cmdSec.ExecuteReader();


                                            while (readerSec.Read())
                                            {
                                                mySec1 = readerSec["ProcessTime"].ToString();

                                                Int32.TryParse(mySec1, out Sec1);

                                            }

                                            for (int k = 1; k <= Sec1; k++)
                                            {
                                                lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                              //  await Task.Delay(1000);


                                            }
                                            ListStepEndTime.Add(DateTime.Now);

                                            con.Close();

                                            con.Open();

                                            string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,Logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                            SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                            cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                            cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "1");
                                            cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                            cmdmodulerecipe.ExecuteNonQuery();

                                            con.Close();
                                            //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                            con.Open();

                                            string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                            SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                            cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                            cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                            SqlDataReader reader2 = cmd3.ExecuteReader();

                                            while (reader2.Read())
                                            {
                                                CI2 = reader2["CI2"].ToString();
                                                BCI3 = reader2["BCI3"].ToString();
                                                SF6 = reader2["SF6"].ToString();
                                                CHF3 = reader2["CHF3"].ToString();
                                                Oxygen = reader2["Oxygen"].ToString();
                                                Oxygen1 = reader2["Oxygen1"].ToString();
                                                Nitrogen = reader2["Nitrogen"].ToString();
                                                Argon = reader2["Argon"].ToString();



                                            }

                                            con.Close();

                                            ///////////////////////////////////////////////////////////////////////////////////////////////////
                                            con.Open();
                                            //  Chamber1 chamber1 = new Chamber1();

                                            string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate,logid) values(@11,@21,@31,@41,@51,@61,@71,@81,@91),(@12,@22,@32,@42,@52,@62,@72,@82,@92),(@13,@23,@33,@43,@53,@63,@73,@83,@93)"
                                                + ",(@14,@24,@34,@44,@54,@64,@74,@84,@94),(@15,@25,@35,@45,@55,@65,@75,@85,@95),(@16,@26,@36,@46,@56,@66,@76,@86,@96),(@17,@27,@37,@47,@57,@67,@77,@87,@97),(@18,@28,@38,@48,@58,@68,@78,@88,@98)";
                                            SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                            cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                            cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                            cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                            cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                            cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                            cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                            cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                            cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                            cmdparameter.Parameters.AddWithValue("@21", CI2);
                                            cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@23", SF6);
                                            cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@28", Argon);
                                            cmdparameter.Parameters.AddWithValue("@31", CI2);
                                            cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@33", SF6);
                                            cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@38", Argon);
                                            cmdparameter.Parameters.AddWithValue("@41", CI2);
                                            cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@43", SF6);
                                            cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@48", Argon);
                                            cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@91", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@92", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@93", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@94", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@95", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@96", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@97", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@98", lbl123.Text);


                                            cmdparameter.ExecuteNonQuery();
                                            con.Close();

                                        }
                                        ///////////////////////////////////////////////


                                        strStepname1.Clear();
                                        ListStepStartTime.Clear();
                                        ListStepEndTime.Clear();

                                        // }





                                        picMain.Image.Tag = "A1finishChamber";

                                        /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "A1finishChamber" && picSV.Visible == true)
                                    {
                                        await Task.Delay(1000);
                                        picChamber.Image = Properties.Resources.ChamberWithA1;
                                        //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                        picSV.Visible = false;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "A1finishChamber" && picSV.Visible == false)
                                    {
                                        await Task.Delay(1000);

                                        picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                        picMain.Image = Properties.Resources.picrobotintochamber;
                                        picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                        picMain.Image.Tag = "picrobotintoAPMWaferA1-2";

                                        ovalShape1.Left += 1;
                                        ovalShape1.Left -= 1;
                                        picChamber.Width += 140;
                                        picChamber.Left -= 150;
                                        picChamber.Height += 10;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA1-2")
                                    {
                                        await Task.Delay(1000);
                                        label2.BackColor = Color.Blue;
                                        lblProcess.BackColor = Color.Blue;
                                        lblProcessStep.BackColor = Color.Blue;
                                        lblRecipe.BackColor = Color.Blue;
                                        lblStepName.BackColor = Color.Blue;
                                        lblData.BackColor = Color.Blue;
                                        lblnum.BackColor = Color.Blue;

                                        lblProcess.Text = "Idle";
                                        lblProcessStep.Text = "";
                                        lblRecipe.Text = "";
                                        lblStepName.Text = "";
                                        lblnum.Text = "";
                                        lblData.Text = "";


                                        // pictRobot.Visible = true;

                                        picChamber.Image = Properties.Resources.new_chamber1;
                                        picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picrobotAPMWafer;
                                        picMain.Image.Tag = "picrobotAPMWaferA1-2";
                                        lblwaferAPM.Visible = false;
                                        lblwaferup.Visible = true;
                                        lblwaferup.Text = "A1";
                                        ovalShape1.Top += 145;
                                        ovalShape1.Left -= 3;
                                        lblwafer.Top += 145;
                                        lblwafer.Left -= 3;

                                        lblChamber.BackColor = Color.Blue;
                                        chamberload = "Blue";
                                        picChamber.Width -= 140;
                                        picChamber.Left += 150;
                                        picChamber.Height -= 10;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA1-2" && picSV.Visible == false)
                                    {
                                        await Task.Delay(2000);
                                        picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                        // picMain.Image = Properties.Resources.robotrightA1;
                                        picSV.Visible = true;

                                    }

                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA1-2" && picSV.Visible == true)
                                    {
                                        await Task.Delay(2000);

                                        // pictRobot.Height += 20;

                                        // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                        picMain.Image = Properties.Resources.mainpicture;
                                        picMain.Image = Properties.Resources.picrobotArmWafer;
                                        picMain.Image.Tag = "picrobotArmWaferA1-2";
                                        lblwaferup.Visible = false;
                                        lblwafer.Visible = true;
                                        ovalShape1.Top += 162;
                                        lblwafer.Top += 162;
                                        ovalShape1.Left += 12;
                                        lblwafer.Left += 12;
                                        await Task.Delay(2000);

                                        await Task.Delay(1000);
                                        picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                           // picMain.Image = Properties.Resources.robotgetwaferA1;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA1-2")
                                    {
                                        await Task.Delay(1000);

                                        lblCassette.BackColor = Color.LimeGreen;

                                        picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                        picMain.Image = Properties.Resources.picrobotintocassette;
                                        picMain.Image.Tag = "picrobotintocassette2";
                                        lblwafer.Visible = false;
                                        lblwafer.Visible = false;
                                        ovalShape1.Visible = false;
                                        picCassette.Height += 220;
                                        picCassette.Width += 25;
                                        picCassette.Top -= 205;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassette2")
                                    {
                                        await Task.Delay(2000);
                                        lblCassette.BackColor = Color.Blue;
                                        //  pictRobot.Visible = true;

                                        picMain.Image = Properties.Resources.mainpicture;
                                        picMain.Image.Tag = "mainpicture3";
                                        picCassette.Image = Properties.Resources.cassette3;
                                        picCassette.Width -= 25;
                                        picCassette.Height -= 220;
                                        picCassette.Top += 205;
                                    }

                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "mainpicture3")
                                    {
                                        await Task.Delay(2000);
                                        //  picMain.Image = Properties.Resources.mainpic;
                                        picCassette.Image = Properties.Resources.cassette;
                                        //   picwafer.Image = Properties.Resources.waferfull;
                                        if (NoOfwafer[i] == "1")
                                        {
                                            //   picwafer.Image = Properties.Resources.waferA1full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;



                                            picWafer1.Visible = true;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;

                                        }
                                        if (NoOfwafer[i] == "2")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA2full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;




                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;
                                        }
                                        if (NoOfwafer[i] == "3")
                                        {
                                            //   picwafer.Image = Properties.Resources.waferA3full;

                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;



                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;
                                        }
                                        if (NoOfwafer[i] == "4")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA4full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;



                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;
                                        }

                                        if (NoOfwafer[i] == "5")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA5full;

                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;



                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;
                                        }


                                        //////////////////////////////////////////////////////////////////Save DataLog
                                        if (int.Parse(NoOfwafer[i]) == 1)
                                        {
                                            EndTime = DateTime.Now;


                                            con.Open();

                                            string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                            SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                            cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                            cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                            cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                            cmdinsertdatalog.ExecuteNonQuery();

                                            con.Close();


                                            lblState.Text = "Finished";

                                        }



                                        picMain.Image.Tag = "finishWaferA1";
                                    if (isStopRobot == true)
                                    {
                                        button2.Enabled = true;

                                        lblState.Text = "Stopping";

                                    }

                                    }

                                    /////////////////////////////////////////////////////////finish waferA1
                                }












                                if (int.Parse(NoOfwafer[i]) >= 2)
                                {
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishWaferA1"&&isStopRobot==false)
                                    {
                                        /////////////////////////////////////////////////////////start WaferA2
                                        await Task.Delay(1000);

                                        //pictRobot.Image = Properties.Resources.new_robot;
                                        picMain.Image = Properties.Resources.mainpicture;
                                        picMain.Image.Tag = "A2mainpicture";
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "A2mainpicture")
                                    {
                                        await Task.Delay(1000);

                                        //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                        // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                        await Task.Delay(1000);

                                        picMain.Image = Properties.Resources.picrobotintocassette;
                                        picMain.Image.Tag = "picrobotintocassetteA2";
                                        picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                        picCassette.Width += 25;
                                        picCassette.Height += 220;
                                        picCassette.Top -= 205;
                                        picCassette.Image.Tag = "robot_into_cassetteA1";
                                        picCassette.Left += 5;
                                        label1.BackColor = Color.Blue;
                                        lblLoad.Text = "";
                                        lblLoad.BackColor = Color.Blue;
                                        lbl123.BackColor = Color.Blue;
                                        lblState.BackColor = Color.Blue;
                                        lblCassetteRecipename.BackColor = Color.Blue;
                                        lblmTorr.BackColor = Color.Blue;


                                        lblCassette.BackColor = Color.LimeGreen;
                                        await Task.Delay(1000);


                                        picCassette.Image = Properties.Resources.cassette;
                                        await Task.Delay(1000);

                                        if (NoOfwafer[i] == "1")
                                        {
                                            //  picwafer.Image = Properties.Resources.wafer;
                                            //picwafer.Image.Tag = "wafer";
                                            picWafer2.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "2")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA1full;

                                            picWafer2.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "3")
                                        {
                                            //   picwafer.Image = Properties.Resources.waferA3fullA2;
                                            picWafer2.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "4")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA4fullA2;
                                            picWafer2.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "5")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5fullA2;
                                            picWafer2.Visible = false;
                                        }

                                        StartTime = DateTime.Now;


                                        con.Open();

                                        string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                        SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                        cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "2");
                                        cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                        cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                        cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);
                                        cmdwaferselection.ExecuteNonQuery();

                                        con.Close();

                                    }

                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassetteA2")
                                    {
                                        await Task.Delay(1000);
                                        picMain.Image = Properties.Resources.picrobotArmWafer;
                                        picMain.Image.Tag = "picrobotArmWaferA2";
                                        // panel1.Visible = true;
                                        //  ovalShape1.Visible = true;
                                        lblwafer.Visible = true;
                                        lblwafer.Text = "A2";
                                        lblCassette.BackColor = Color.Blue;

                                        picCassette.Image = Properties.Resources.cassette3;

                                        // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                        picCassette.Height -= 220;
                                        picCassette.Width -= 25;
                                        picCassette.Top += 205;
                                        picCassette.Image.Tag = "cassette";
                                        picCassette.Left -= 5;
                                        //  await Task.Delay(1000);
                                        picCassette.Image = Properties.Resources.cassette;
                                        // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA2")
                                    {
                                        await Task.Delay(1000);



                                        // pictRobot.Image = Properties.Resources.robotleft_A1;
                                        //   picMain.Image = Properties.Resources.picrobotcentralized;
                                        picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                        picMain.Image.Tag = "picrobotAlignerWaferA2";
                                        //  ovalShape1.Visible = true;
                                        // lblwafer.Visible = true;
                                        ovalShape1.Left += 70;
                                        ovalShape1.Top -= 85;
                                        lblwafer.Visible = false;
                                        lblwaferright.Visible = true;
                                        lblwaferright.Text = "A2";
                                        lblwafer.Left += 70;
                                        lblwafer.Top -= 85;
                                        // panel1.Visible = false;



                                        //   await Task.Delay(2000);
                                        //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                        //  picMain.Image = Properties.Resources.robotleftA1opencentralize;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA2")
                                    {
                                        await Task.Delay(2000);






                                        // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                        //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                        picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                        picMain.Image.Tag = "picrobotintoAlignerWaferA2";
                                        lblCentralize.BackColor = Color.LimeGreen;
                                        ovalShape1.Left += 155;
                                        ovalShape1.Top += 0;
                                        lblwaferright.Visible = false;
                                        lblwaferaligner.Visible = true;
                                        lblwaferaligner.Text = "A2";
                                        lblwafer.Left += 155;
                                        lblwafer.Top += 0;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAlignerWaferA2")
                                    {
                                        ////////////////////////////////////////////////////////////////////////////////////
                                        await Task.Delay(2000);
                                        // pictRobot.Visible = true;
                                        // picCentralize.Image = Properties.Resources.centralize2;
                                        // picMain.Image = Properties.Resources.picrobotcentralized;
                                        picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                        picMain.Image.Tag = "picrobotAlignerWaferA2-2";
                                        // ovalShape1.Visible = true;
                                        //picwafer.Visible = true;
                                        lblwaferaligner.Visible = false;
                                        lblwaferright.Visible = true;
                                        lblwaferright.Text = "A2";

                                        ovalShape1.Left -= 155;
                                        ovalShape1.Top -= 0;
                                        lblwafer.Left -= 155;
                                        lblwafer.Top -= 0;
                                        lblCentralize.BackColor = Color.Blue;

                                        // await Task.Delay(2000);
                                        // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                        // picMain.Image = Properties.Resources.robotleftA1;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA2-2")
                                    {
                                        await Task.Delay(2000);

                                        //   picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picrobotAPMWafer;
                                        picMain.Image.Tag = "picrobotAPMWaferA2";
                                        lblwaferright.Visible = false;
                                        lblwaferup.Visible = true;
                                        lblwaferup.Text = "A2";
                                        ovalShape1.Left -= 82;
                                        ovalShape1.Top -= 76;
                                        lblwafer.Left -= 82;
                                        lblwafer.Top -= 76;



                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA2" && picSV.Visible == true)
                                    {
                                        await Task.Delay(1000);

                                        // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                        // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                        picSV.Visible = false;  // open sv of chamber
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA2" && picSV.Visible == false)
                                    {
                                        await Task.Delay(1000);

                                        //pictRobot.Visible = false;
                                        //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                        //  picMain.Image = Properties.Resources.picrobotintochamber;
                                        picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                        picMain.Image.Tag = "picrobotintoAPMWaferA2";
                                        // picChamber.Width += 140;
                                        //picChamber.Left -= 150;
                                        //picChamber.Height += 10;
                                        lblwaferup.Visible = false;
                                        lblwaferAPM.Visible = true;
                                        lblwaferAPM.Text = "A2";
                                        ovalShape1.Top -= 145;
                                        ovalShape1.Left += 3;
                                        lblwafer.Top -= 145;
                                        lblwafer.Left += 3;



                                        lblChamber.BackColor = Color.LimeGreen;

                                        chamberload = "LimeGreen";

                                        // loaddata();
                                        // loadchamber1( sender, e);
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA2")
                                    {
                                        await Task.Delay(1000);
                                        picChamber.Image = Properties.Resources.ChamberWithA1;
                                        //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                        picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picwaferinAPM;
                                        picMain.Image.Tag = "picwaferinAPMA2";
                                        ovalShape1.Left -= 1;
                                        ovalShape1.Left += 1;
                                        //  picMain.SendToBack();
                                        // ovalShape1.BringToFront();
                                        picChamber.Width -= 140;
                                        picChamber.Left += 150;
                                        picChamber.Height -= 10;


                                        //  pictRobot.Visible = true;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA2" && picSV.Visible == false)
                                    {
                                        await Task.Delay(1000);

                                        picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                        //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                        picSV.Visible = true;

                                    ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA2 into Chamber

                                    Chamber1 chamber1 = new Chamber1();
                                    chamber1.ShowDialog();


                                        lblRecipe.BackColor = Color.LimeGreen;
                                        lblStepName.BackColor = Color.LimeGreen;

                                        lblnum.BackColor = Color.LimeGreen;

                                        lblData.BackColor = Color.LimeGreen;
                                        lblData.Text = "";
                                        label2.BackColor = Color.LimeGreen;

                                        lblProcess.Text = "Processing";
                                        lblProcess.BackColor = Color.LimeGreen;
                                        lblProcessStep.Text = "Process Step";
                                        lblProcessStep.BackColor = Color.LimeGreen;



                                        con.Open();
                                        string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                        SqlCommand cmd = new SqlCommand(strSQL, con);
                                        cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        while (reader.Read())
                                        {

                                            lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                        }

                                        con.Close();
                                        con.Open();
                                        string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                        SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                        cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                        SqlDataReader reader1 = cmd1.ExecuteReader();
                                        while (reader1.Read())
                                        {

                                            strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                        }

                                        con.Close();

                                        con.Open();
                                        string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                        SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                        cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                        cmd2.ExecuteNonQuery();



                                        for (int j = 0; j < strStepname1.Count(); j += 1)

                                        {

                                          //  await Task.Delay(1000);

                                            ListStepStartTime.Add(DateTime.Now);


                                            int count = j + 1;


                                            lblStepName.Text = strStepname1[j];
                                            lblnum.Text = "," + count + "/" + strStepname1.Count();


                                            con.Close();

                                            con.Open();
                                            string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                            SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                            cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                            SqlDataReader readerSec = cmdSec.ExecuteReader();


                                            while (readerSec.Read())
                                            {
                                                mySec1 = readerSec["ProcessTime"].ToString();

                                                Int32.TryParse(mySec1, out Sec1);

                                            }

                                            for (int k = 1; k <= Sec1; k++)
                                            {
                                                lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                              //  await Task.Delay(1000);


                                            }
                                            ListStepEndTime.Add(DateTime.Now);

                                            con.Close();

                                            con.Open();

                                            string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,Logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                            SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                            cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                            cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "2");
                                            cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);
                                            cmdmodulerecipe.ExecuteNonQuery();

                                            con.Close();
                                            //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                            con.Open();

                                            string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                            SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                            cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                            cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                            SqlDataReader reader2 = cmd3.ExecuteReader();

                                            while (reader2.Read())
                                            {
                                                CI2 = reader2["CI2"].ToString();
                                                BCI3 = reader2["BCI3"].ToString();
                                                SF6 = reader2["SF6"].ToString();
                                                CHF3 = reader2["CHF3"].ToString();
                                                Oxygen = reader2["Oxygen"].ToString();
                                                Oxygen1 = reader2["Oxygen1"].ToString();
                                                Nitrogen = reader2["Nitrogen"].ToString();
                                                Argon = reader2["Argon"].ToString();



                                            }

                                            con.Close();

                                            ///////////////////////////////////////////////////////////////////////////////////////////////////
                                            con.Open();
                                         //   Chamber1 chamber1 = new Chamber1();

                                            string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate,logid) values(@11,@21,@31,@41,@51,@61,@71,@81,@91),(@12,@22,@32,@42,@52,@62,@72,@82,@92),(@13,@23,@33,@43,@53,@63,@73,@83,@93)"
                                                + ",(@14,@24,@34,@44,@54,@64,@74,@84,@94),(@15,@25,@35,@45,@55,@65,@75,@85,@95),(@16,@26,@36,@46,@56,@66,@76,@86,@96),(@17,@27,@37,@47,@57,@67,@77,@87,@97),(@18,@28,@38,@48,@58,@68,@78,@88,@98)";
                                            SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                            cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                            cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                            cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                            cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                            cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                            cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                            cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                            cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                            cmdparameter.Parameters.AddWithValue("@21", CI2);
                                            cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@23", SF6);
                                            cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@28", Argon);
                                            cmdparameter.Parameters.AddWithValue("@31", CI2);
                                            cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@33", SF6);
                                            cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@38", Argon);
                                            cmdparameter.Parameters.AddWithValue("@41", CI2);
                                            cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@43", SF6);
                                            cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@48", Argon);
                                            cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@91", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@92", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@93", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@94", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@95", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@96", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@97", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@98", lbl123.Text);
                                            cmdparameter.ExecuteNonQuery();
                                            con.Close();

                                        }
                                        ///////////////////////////////////////////////


                                        strStepname1.Clear();
                                        ListStepStartTime.Clear();
                                        ListStepEndTime.Clear();

                                        // }











                                        /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA2" && picSV.Visible == true)
                                    {
                                        await Task.Delay(1000);
                                        picChamber.Image = Properties.Resources.ChamberWithA1;
                                        //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                        picSV.Visible = false;
                                        picMain.Image.Tag = "waferA2finishChamber";
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "waferA2finishChamber")
                                    {
                                        await Task.Delay(1000);

                                        picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                        picMain.Image = Properties.Resources.picrobotintochamber;
                                        picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                        picMain.Image.Tag = "picrobotintoAPMWaferA2-2";
                                        ovalShape1.Left += 1;
                                        ovalShape1.Left -= 1;
                                        picChamber.Width += 140;
                                        picChamber.Left -= 150;
                                        picChamber.Height += 10;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA2-2")
                                    {
                                        await Task.Delay(1000);
                                        label2.BackColor = Color.Blue;
                                        lblProcess.BackColor = Color.Blue;
                                        lblProcessStep.BackColor = Color.Blue;
                                        lblRecipe.BackColor = Color.Blue;
                                        lblStepName.BackColor = Color.Blue;
                                        lblData.BackColor = Color.Blue;
                                        lblnum.BackColor = Color.Blue;

                                        lblProcess.Text = "Idle";
                                        lblProcessStep.Text = "";
                                        lblRecipe.Text = "";
                                        lblStepName.Text = "";
                                        lblnum.Text = "";
                                        lblData.Text = "";


                                        // pictRobot.Visible = true;

                                        picChamber.Image = Properties.Resources.new_chamber1;
                                        picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picrobotAPMWafer;
                                        picMain.Image.Tag = "picrobotAPMWaferA2-2";
                                        lblwaferAPM.Visible = false;
                                        lblwaferup.Visible = true;

                                        ovalShape1.Top += 145;
                                        ovalShape1.Left -= 3;
                                        lblwafer.Top += 145;
                                        lblwafer.Left -= 3;

                                        lblChamber.BackColor = Color.Blue;
                                        chamberload = "Blue";
                                        picChamber.Width -= 140;
                                        picChamber.Left += 150;
                                        picChamber.Height -= 10;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA2-2" && picSV.Visible == false)
                                    {
                                        await Task.Delay(2000);
                                        picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                        // picMain.Image = Properties.Resources.robotrightA1;
                                        picSV.Visible = true;


                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA2-2" && picSV.Visible == true)
                                    {
                                        await Task.Delay(2000);

                                        // pictRobot.Height += 20;

                                        // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                        picMain.Image = Properties.Resources.mainpicture;
                                        picMain.Image = Properties.Resources.picrobotArmWafer;
                                        picMain.Image.Tag = "picrobotArmWaferA2-2";
                                        lblwaferup.Visible = false;
                                        lblwafer.Visible = true;
                                        ovalShape1.Top += 162;
                                        lblwafer.Top += 162;
                                        ovalShape1.Left += 12;
                                        lblwafer.Left += 12;
                                        await Task.Delay(2000);

                                        await Task.Delay(1000);
                                        picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                           // picMain.Image = Properties.Resources.robotgetwaferA1;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA2-2")
                                    {
                                        await Task.Delay(1000);

                                        lblCassette.BackColor = Color.LimeGreen;

                                        picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                        picMain.Image = Properties.Resources.picrobotintocassette;
                                        picMain.Image.Tag = "A2picrobotintocassette2";
                                        lblwafer.Visible = false;
                                        lblwafer.Visible = false;
                                        ovalShape1.Visible = false;
                                        picCassette.Height += 220;
                                        picCassette.Width += 25;
                                        picCassette.Top -= 205;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "A2picrobotintocassette2")
                                    {
                                        await Task.Delay(2000);
                                        lblCassette.BackColor = Color.Blue;
                                        //  pictRobot.Visible = true;

                                        picMain.Image = Properties.Resources.mainpicture;
                                        picCassette.Image = Properties.Resources.cassette3;
                                        picCassette.Width -= 25;
                                        picCassette.Height -= 220;
                                        picCassette.Top += 205;
                                        await Task.Delay(2000);
                                        //  picMain.Image = Properties.Resources.mainpic;
                                        picCassette.Image = Properties.Resources.cassette;
                                        //  picwafer.Image = Properties.Resources.waferfull;
                                        if (NoOfwafer[i] == "1")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA1full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;

                                            picWafer2.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;

                                            picWafer1.Visible = true;
                                        }
                                        if (NoOfwafer[i] == "2")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA2full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;


                                            picWafer2.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                        }
                                        if (NoOfwafer[i] == "3")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA3full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;

                                            picWafer2.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;


                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                        }
                                        if (NoOfwafer[i] == "4")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA4full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;

                                            picWafer2.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;


                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                        }

                                        if (NoOfwafer[i] == "5")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA5full;
                                            picWafer1.Visible = false;
                                            picWafer2.Visible = false;
                                            picWafer3.Visible = false;
                                            picWafer4.Visible = false;
                                            picWafer5.Visible = false;
                                            picWafer6.Visible = false;
                                            picWafer7.Visible = false;
                                            picWafer8.Visible = false;
                                            picWafer9.Visible = false;
                                            picWafer10.Visible = false;
                                            picWafer11.Visible = false;
                                            picWafer12.Visible = false;
                                            picWafer13.Visible = false;
                                            picWafer14.Visible = false;
                                            picWafer15.Visible = false;
                                            picWafer16.Visible = false;
                                            picWafer17.Visible = false;
                                            picWafer18.Visible = false;
                                            picWafer19.Visible = false;
                                            picWafer20.Visible = false;
                                            picWafer21.Visible = false;
                                            picWafer22.Visible = false;
                                            picWafer23.Visible = false;
                                            picWafer24.Visible = false;
                                            picWafer25.Visible = false;

                                            picWafer2.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;


                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;
                                        }

                                        //////////////////////////////////////////////////////////////////Save DataLog
                                        if (int.Parse(NoOfwafer[i]) == 2)
                                        {
                                            EndTime = DateTime.Now;


                                            con.Open();

                                            string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                            SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                            cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                            cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                            cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                            cmdinsertdatalog.ExecuteNonQuery();

                                            con.Close();



                                            lblState.Text = "Finished";
                                            

                                        }


                                    picMain.Image.Tag = "finishWaferA2";
                                }
                                /////////////////////////////////////////////////////////finish waferA2
                            }












                                if (int.Parse(NoOfwafer[i]) >= 3)
                                {
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "finishWaferA2")
                                    {
                                        /////////////////////////////////////////////////////////start WaferA3

                                        await Task.Delay(1000);

                                        //pictRobot.Image = Properties.Resources.new_robot;
                                        picMain.Image = Properties.Resources.mainpicture;
                                        picMain.Image.Tag = "A3mainpicture";
                                        await Task.Delay(1000);

                                        //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                        // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "A3mainpicture")
                                    {
                                        await Task.Delay(1000);

                                        picMain.Image = Properties.Resources.picrobotintocassette;
                                        picMain.Image.Tag = "picrobotintocassetteA3";
                                        picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                        picCassette.Width += 25;
                                        picCassette.Height += 220;
                                        picCassette.Top -= 205;
                                        picCassette.Image.Tag = "robot_into_cassetteA1";
                                        picCassette.Left += 5;
                                        label1.BackColor = Color.Blue;
                                        lblLoad.Text = "";
                                        lblLoad.BackColor = Color.Blue;
                                        lbl123.BackColor = Color.Blue;
                                        lblState.BackColor = Color.Blue;
                                        lblCassetteRecipename.BackColor = Color.Blue;
                                        lblmTorr.BackColor = Color.Blue;


                                        lblCassette.BackColor = Color.LimeGreen;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintocassetteA3")
                                    {
                                        await Task.Delay(1000);




                                        picCassette.Image = Properties.Resources.cassette;
                                        await Task.Delay(1000);

                                        if (NoOfwafer[i] == "1")
                                        {
                                            // picwafer.Image = Properties.Resources.wafer;
                                            //  picwafer.Image.Tag = "wafer";
                                            picWafer3.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "2")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA1full;
                                            picWafer3.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "3")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA2full;
                                            picWafer3.Visible = false;

                                        }
                                        else if (NoOfwafer[i] == "4")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA4fullA3;
                                            picWafer3.Visible = false;
                                        }
                                        else if (NoOfwafer[i] == "5")
                                        {
                                            //   picwafer.Image = Properties.Resources.waferA5fullA3;
                                            picWafer3.Visible = false;
                                        }

                                        StartTime = DateTime.Now;


                                        con.Open();

                                        string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                        SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                        cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "3");
                                        cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                        cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                        cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);
                                        cmdwaferselection.ExecuteNonQuery();

                                        con.Close();




                                        picMain.Image = Properties.Resources.picrobotArmWafer;
                                        picMain.Image.Tag = "picrobotArmWaferA3";
                                        // panel1.Visible = true;
                                        //  ovalShape1.Visible = true;
                                        lblwafer.Visible = true;
                                        lblwafer.Text = "A3";

                                        lblCassette.BackColor = Color.Blue;

                                        picCassette.Image = Properties.Resources.cassette3;

                                        // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                        picCassette.Height -= 220;
                                        picCassette.Width -= 25;
                                        picCassette.Top += 205;
                                        picCassette.Image.Tag = "cassette";
                                        picCassette.Left -= 5;
                                        //  await Task.Delay(1000);
                                        picCassette.Image = Properties.Resources.cassette;
                                        // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA3")
                                    {
                                        await Task.Delay(1000);



                                        // pictRobot.Image = Properties.Resources.robotleft_A1;
                                        //   picMain.Image = Properties.Resources.picrobotcentralized;
                                        picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                        picMain.Image.Tag = "picrobotAlignerWaferA3";
                                        //  ovalShape1.Visible = true;
                                        // lblwafer.Visible = true;
                                        ovalShape1.Left += 70;
                                        ovalShape1.Top -= 85;
                                        lblwafer.Visible = false;
                                        lblwaferright.Visible = true;
                                        lblwaferright.Text = "A3";
                                        lblwafer.Left += 70;
                                        lblwafer.Top -= 85;
                                        // panel1.Visible = false;



                                        //   await Task.Delay(2000);
                                        //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                        //  picMain.Image = Properties.Resources.robotleftA1opencentralize;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA3")
                                    {
                                        await Task.Delay(2000);






                                        // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                        //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                        picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                        picMain.Image.Tag = "picrobotintoAlignerWaferA3";
                                        lblCentralize.BackColor = Color.LimeGreen;
                                        ovalShape1.Left += 155;
                                        ovalShape1.Top += 0;
                                        lblwaferright.Visible = false;
                                        lblwaferaligner.Visible = true;
                                        lblwaferaligner.Text = "A3";
                                        lblwafer.Left += 155;
                                        lblwafer.Top += 0;


                                        ////////////////////////////////////////////////////////////////////////////////////
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAlignerWaferA3")
                                    {
                                        await Task.Delay(2000);
                                        // pictRobot.Visible = true;
                                        // picCentralize.Image = Properties.Resources.centralize2;
                                        // picMain.Image = Properties.Resources.picrobotcentralized;
                                        picMain.Image = Properties.Resources.picrobotAlignerWafer;

                                        picMain.Image.Tag = "picrobotAlignerWaferA3-2";
                                        // ovalShape1.Visible = true;
                                        //picwafer.Visible = true;
                                        lblwaferaligner.Visible = false;
                                        lblwaferright.Visible = true;
                                        lblwaferright.Text = "A3";
                                        ovalShape1.Left -= 155;
                                        ovalShape1.Top -= 0;
                                        lblwafer.Left -= 155;
                                        lblwafer.Top -= 0;
                                        lblCentralize.BackColor = Color.Blue;

                                        // await Task.Delay(2000);
                                        // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                        // picMain.Image = Properties.Resources.robotleftA1;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAlignerWaferA3-2")
                                    {
                                        await Task.Delay(2000);

                                        //   picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picrobotAPMWafer;
                                        picMain.Image.Tag = "picrobotAPMWaferA3";
                                        lblwaferright.Visible = false;
                                        lblwaferup.Visible = true;
                                        lblwaferup.Text = "A3";
                                        ovalShape1.Left -= 82;
                                        ovalShape1.Top -= 76;
                                        lblwafer.Left -= 82;
                                        lblwafer.Top -= 76;



                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA3" && picSV.Visible == true)
                                    {
                                        await Task.Delay(1000);

                                        // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                        // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                        picSV.Visible = false;  // open sv of chamber
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA3" && picSV.Visible == false)
                                    {
                                        await Task.Delay(1000);

                                        //pictRobot.Visible = false;
                                        //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                        //  picMain.Image = Properties.Resources.picrobotintochamber;
                                        picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                        picMain.Image.Tag = "picrobotintoAPMWaferA3";
                                        // picChamber.Width += 140;
                                        //picChamber.Left -= 150;
                                        //picChamber.Height += 10;
                                        lblwaferup.Visible = false;
                                        lblwaferAPM.Visible = true;
                                        lblwaferAPM.Text = "A3";
                                        ovalShape1.Top -= 145;
                                        ovalShape1.Left += 3;
                                        lblwafer.Top -= 145;
                                        lblwafer.Left += 3;



                                        lblChamber.BackColor = Color.LimeGreen;

                                        chamberload = "LimeGreen";

                                        // loaddata();
                                        // loadchamber1( sender, e);
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA3")
                                    {
                                        await Task.Delay(1000);
                                        picChamber.Image = Properties.Resources.ChamberWithA1;
                                        //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                        picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picwaferinAPM;
                                        picMain.Image.Tag = "picwaferinAPMA3";
                                        ovalShape1.Left -= 1;
                                        ovalShape1.Left += 1;
                                        //  picMain.SendToBack();
                                        // ovalShape1.BringToFront();
                                        picChamber.Width -= 140;
                                        picChamber.Left += 150;
                                        picChamber.Height -= 10;


                                        //  pictRobot.Visible = true;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA3" && picSV.Visible == false)
                                    {
                                        await Task.Delay(1000);

                                        picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                        //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                        picSV.Visible = true;

                                    ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA3 into Chamber

                                    Chamber1 chamber1 = new Chamber1();
                                    chamber1.ShowDialog();


                                        lblRecipe.BackColor = Color.LimeGreen;
                                        lblStepName.BackColor = Color.LimeGreen;

                                        lblnum.BackColor = Color.LimeGreen;

                                        lblData.BackColor = Color.LimeGreen;
                                        lblData.Text = "";
                                        label2.BackColor = Color.LimeGreen;

                                        lblProcess.Text = "Processing";
                                        lblProcess.BackColor = Color.LimeGreen;
                                        lblProcessStep.Text = "Process Step";
                                        lblProcessStep.BackColor = Color.LimeGreen;



                                        con.Open();
                                        string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                        SqlCommand cmd = new SqlCommand(strSQL, con);
                                        cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        while (reader.Read())
                                        {


                                            lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                        }

                                        con.Close();
                                        con.Open();
                                        string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                        SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                        cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                        SqlDataReader reader1 = cmd1.ExecuteReader();
                                        while (reader1.Read())
                                        {


                                            strStepname1.Add(string.Format("{0}", reader1["StepName"]));




                                        }

                                        con.Close();

                                        con.Open();
                                        string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                        SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                        cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                        cmd2.ExecuteNonQuery();



                                        for (int j = 0; j < strStepname1.Count(); j += 1)

                                        {

                                          //  await Task.Delay(1000);

                                            ListStepStartTime.Add(DateTime.Now);


                                            int count = j + 1;


                                            lblStepName.Text = strStepname1[j];
                                            lblnum.Text = "," + count + "/" + strStepname1.Count();


                                            con.Close();

                                            con.Open();
                                            string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                            SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                            cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                            SqlDataReader readerSec = cmdSec.ExecuteReader();


                                            while (readerSec.Read())
                                            {
                                                mySec1 = readerSec["ProcessTime"].ToString();

                                                Int32.TryParse(mySec1, out Sec1);

                                            }

                                            for (int k = 1; k <= Sec1; k++)
                                            {
                                                lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                             //   await Task.Delay(1000);


                                            }
                                            ListStepEndTime.Add(DateTime.Now);

                                            con.Close();

                                            con.Open();

                                            string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                            SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                            cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                            cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                            cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "3");
                                            cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                            cmdmodulerecipe.ExecuteNonQuery();

                                            con.Close();
                                            //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                            con.Open();

                                            string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                            SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                            cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                            cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                            SqlDataReader reader2 = cmd3.ExecuteReader();

                                            while (reader2.Read())
                                            {
                                                CI2 = reader2["CI2"].ToString();
                                                BCI3 = reader2["BCI3"].ToString();
                                                SF6 = reader2["SF6"].ToString();
                                                CHF3 = reader2["CHF3"].ToString();
                                                Oxygen = reader2["Oxygen"].ToString();
                                                Oxygen1 = reader2["Oxygen1"].ToString();
                                                Nitrogen = reader2["Nitrogen"].ToString();
                                                Argon = reader2["Argon"].ToString();



                                            }

                                            con.Close();

                                            ///////////////////////////////////////////////////////////////////////////////////////////////////
                                            con.Open();
                                          //  Chamber1 chamber1 = new Chamber1();

                                            string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate,logid) values(@11,@21,@31,@41,@51,@61,@71,@81,@91),(@12,@22,@32,@42,@52,@62,@72,@82,@92),(@13,@23,@33,@43,@53,@63,@73,@83,@93)"
                                                + ",(@14,@24,@34,@44,@54,@64,@74,@84,@94),(@15,@25,@35,@45,@55,@65,@75,@85,@95),(@16,@26,@36,@46,@56,@66,@76,@86,@96),(@17,@27,@37,@47,@57,@67,@77,@87,@97),(@18,@28,@38,@48,@58,@68,@78,@88,@98)";
                                            SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                            cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                            cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                            cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                            cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                            cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                            cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                            cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                            cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                            cmdparameter.Parameters.AddWithValue("@21", CI2);
                                            cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@23", SF6);
                                            cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@28", Argon);
                                            cmdparameter.Parameters.AddWithValue("@31", CI2);
                                            cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@33", SF6);
                                            cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@38", Argon);
                                            cmdparameter.Parameters.AddWithValue("@41", CI2);
                                            cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                            cmdparameter.Parameters.AddWithValue("@43", SF6);
                                            cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                            cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                            cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                            cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                            cmdparameter.Parameters.AddWithValue("@48", Argon);
                                            cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                            cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                            cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                            cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);
                                            cmdparameter.Parameters.AddWithValue("@91", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@92", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@93", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@94", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@95", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@96", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@97", lbl123.Text);
                                            cmdparameter.Parameters.AddWithValue("@98", lbl123.Text);


                                            cmdparameter.ExecuteNonQuery();
                                            con.Close();

                                        }
                                        ///////////////////////////////////////////////


                                        strStepname1.Clear();
                                        ListStepStartTime.Clear();
                                        ListStepEndTime.Clear();

                                        // }











                                        /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                    }

                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picwaferinAPMA3" && picSV.Visible == true)
                                    {
                                        await Task.Delay(1000);
                                        picChamber.Image = Properties.Resources.ChamberWithA1;
                                        //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                        picSV.Visible = false;
                                        picMain.Image.Tag = "A3finishChamber";
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "A3finishChamber")
                                    {
                                        await Task.Delay(1000);

                                        picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                        picMain.Image = Properties.Resources.picrobotintochamber;
                                        picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                        picMain.Image.Tag = "picrobotintoAPMWaferA3-2";
                                        ovalShape1.Left += 1;
                                        ovalShape1.Left -= 1;
                                        picChamber.Width += 140;
                                        picChamber.Left -= 150;
                                        picChamber.Height += 10;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotintoAPMWaferA3-2")
                                    {
                                        await Task.Delay(1000);
                                        label2.BackColor = Color.Blue;
                                        lblProcess.BackColor = Color.Blue;
                                        lblProcessStep.BackColor = Color.Blue;
                                        lblRecipe.BackColor = Color.Blue;
                                        lblStepName.BackColor = Color.Blue;
                                        lblData.BackColor = Color.Blue;
                                        lblnum.BackColor = Color.Blue;

                                        lblProcess.Text = "Idle";
                                        lblProcessStep.Text = "";
                                        lblRecipe.Text = "";
                                        lblStepName.Text = "";
                                        lblnum.Text = "";
                                        lblData.Text = "";


                                        // pictRobot.Visible = true;

                                        picChamber.Image = Properties.Resources.new_chamber1;
                                        picMain.Image = Properties.Resources.picrobotbotton;
                                        picMain.Image = Properties.Resources.picrobotAPMWafer;
                                        picMain.Image.Tag = "picrobotAPMWaferA3-2";
                                        lblwaferAPM.Visible = false;
                                        lblwaferup.Visible = true;
                                        ovalShape1.Top += 145;
                                        ovalShape1.Left -= 3;
                                        lblwafer.Top += 145;
                                        lblwafer.Left -= 3;

                                        lblChamber.BackColor = Color.Blue;
                                        chamberload = "Blue";
                                        picChamber.Width -= 140;
                                        picChamber.Left += 150;
                                        picChamber.Height -= 10;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA3-2" && picSV.Visible == false)
                                    {
                                        await Task.Delay(2000);
                                        picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                        // picMain.Image = Properties.Resources.robotrightA1;
                                        picSV.Visible = true;


                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotAPMWaferA3-2" && picSV.Visible == true)
                                    {
                                        await Task.Delay(2000);

                                        // pictRobot.Height += 20;

                                        // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                        picMain.Image = Properties.Resources.mainpicture;
                                        picMain.Image = Properties.Resources.picrobotArmWafer;
                                        picMain.Image.Tag = "picrobotArmWaferA3-2";
                                        lblwaferup.Visible = false;
                                        lblwafer.Visible = true;
                                        ovalShape1.Top += 162;
                                        lblwafer.Top += 162;
                                        ovalShape1.Left += 12;
                                        lblwafer.Left += 12;

                                        await Task.Delay(2000);

                                        await Task.Delay(1000);
                                        picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                           // picMain.Image = Properties.Resources.robotgetwaferA1;
                                        await Task.Delay(1000);

                                        lblCassette.BackColor = Color.LimeGreen;

                                        picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "picrobotArmWaferA3-2")
                                    {
                                        await Task.Delay(1000);
                                        picMain.Image = Properties.Resources.picrobotintocassette;
                                        picMain.Image.Tag = "A3picrobotintocassette-2";
                                        lblwafer.Visible = false;
                                        lblwafer.Visible = false;
                                        ovalShape1.Visible = false;
                                        picCassette.Height += 220;
                                        picCassette.Width += 25;
                                        picCassette.Top -= 205;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "A3picrobotintocassette-2")
                                    {
                                        await Task.Delay(2000);
                                        lblCassette.BackColor = Color.Blue;
                                        //  pictRobot.Visible = true;

                                        picMain.Image = Properties.Resources.mainpicture;
                                        picMain.Image.Tag = "A3mainpicture-2";
                                        picCassette.Image = Properties.Resources.cassette3;
                                        picCassette.Width -= 25;
                                        picCassette.Height -= 220;
                                        picCassette.Top += 205;
                                    }
                                    if (ispauserobot == false && picMain.Image.Tag.ToString() == "A3mainpicture-2")
                                    {
                                        await Task.Delay(2000);
                                        //  picMain.Image = Properties.Resources.mainpic;
                                        picCassette.Image = Properties.Resources.cassette;
                                        // picwafer.Image = Properties.Resources.waferfull;
                                        if (NoOfwafer[i] == "1")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA1full;
                                            picWafer1.Visible = true;
                                        }
                                        if (NoOfwafer[i] == "2")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA2full;
                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                        }
                                        if (NoOfwafer[i] == "3")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA3full;
                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;

                                            picWafer2.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;
                                            picWafer3.Image = Properties.Resources.picWaferGreen;
                                        }
                                        if (NoOfwafer[i] == "4")
                                        {
                                            //  picwafer.Image = Properties.Resources.waferA4full;
                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;

                                            picWafer2.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;
                                            picWafer3.Image = Properties.Resources.picWaferGreen;

                                        }

                                        if (NoOfwafer[i] == "5")
                                        {
                                            // picwafer.Image = Properties.Resources.waferA5full;
                                            picWafer1.Visible = true;
                                            picWafer2.Visible = true;
                                            picWafer3.Visible = true;
                                            picWafer4.Visible = true;
                                            picWafer5.Visible = true;

                                            picWafer2.Image = Properties.Resources.picWaferGreen;
                                            picWafer1.Image = Properties.Resources.picWaferGreen;
                                            picWafer3.Image = Properties.Resources.picWaferGreen;
                                        }


                                        //////////////////////////////////////////////////////////////////Save DataLog
                                        if (int.Parse(NoOfwafer[i]) == 3)
                                        {
                                            EndTime = DateTime.Now;


                                            con.Open();

                                            string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                            SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                            cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                            cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                            cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                            cmdinsertdatalog.ExecuteNonQuery();

                                            con.Close();



                                            lblState.Text = "Finished";
                                        }
                                    if (isStopRobot == true)
                                    {
                                        button2.Enabled = true;
                                        lblState.Text = "Stopping";

                                    }
                                        picMain.Image.Tag = "finishWaferA3";
                                    }
                                    /////////////////////////////////////////////////////////finish waferA3
                                }









                                /*  if (int.Parse(NoOfwafer[i]) >= 4)
                                  {
                                      /////////////////////////////////////////////////////////start WaferA4
                                    //  if(ispauserobot==false&&picMain.Image.Tag.ToString()=="finishWaferA3")
                                      await Task.Delay(1000);

                                      //pictRobot.Image = Properties.Resources.new_robot;
                                      picMain.Image = Properties.Resources.mainpicture;
                                      await Task.Delay(1000);

                                      //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                      // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                      await Task.Delay(1000);

                                      picMain.Image = Properties.Resources.picrobotintocassette;
                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                      picCassette.Width += 25;
                                      picCassette.Height += 220;
                                      picCassette.Top -= 205;
                                      picCassette.Image.Tag = "robot_into_cassetteA1";
                                      picCassette.Left += 5;
                                      label1.BackColor = Color.Blue;
                                      lblLoad.Text = "";
                                      lblLoad.BackColor = Color.Blue;
                                      lbl123.BackColor = Color.Blue;
                                      lblState.BackColor = Color.Blue;
                                      lblCassetteRecipename.BackColor = Color.Blue;
                                      lblmTorr.BackColor = Color.Blue;


                                      lblCassette.BackColor = Color.LimeGreen;
                                      await Task.Delay(1000);




                                      picCassette.Image = Properties.Resources.cassette;
                                      await Task.Delay(1000);

                                      if (NoOfwafer[i] == "1")
                                      {
                                          //  picwafer.Image = Properties.Resources.wafer;
                                          //  picwafer.Image.Tag = "wafer";
                                          picWafer4.Visible = false;
                                      }
                                      else if (NoOfwafer[i] == "2")
                                      {
                                          // picwafer.Image = Properties.Resources.waferA1full;
                                          picWafer4.Visible = false;
                                      }
                                      else if (NoOfwafer[i] == "3")
                                      {
                                          // picwafer.Image = Properties.Resources.waferA2full;
                                          picWafer4.Visible = false;

                                      }
                                      else if (NoOfwafer[i] == "4")
                                      {
                                          //   picwafer.Image = Properties.Resources.waferA3full;
                                          picWafer4.Visible = false;
                                      }
                                      else if (NoOfwafer[i] == "5")
                                      {
                                          //   picwafer.Image = Properties.Resources.waferA5fullA4;
                                          picWafer4.Visible = false;
                                      }

                                      StartTime = DateTime.Now;


                                      con.Open();

                                      string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                      SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                      cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "4");
                                      cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                      cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                      cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);
                                      cmdwaferselection.ExecuteNonQuery();

                                      con.Close();








                                      picMain.Image = Properties.Resources.picrobotArmWafer;
                                      // panel1.Visible = true;
                                      //  ovalShape1.Visible = true;
                                      lblwafer.Visible = true;
                                      lblwafer.Text = "A4";

                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette3;

                                      // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                      picCassette.Height -= 220;
                                      picCassette.Width -= 25;
                                      picCassette.Top += 205;
                                      picCassette.Image.Tag = "cassette";
                                      picCassette.Left -= 5;
                                      //  await Task.Delay(1000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                      await Task.Delay(1000);



                                      // pictRobot.Image = Properties.Resources.robotleft_A1;
                                      //   picMain.Image = Properties.Resources.picrobotcentralized;
                                      picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                      //  ovalShape1.Visible = true;
                                      // lblwafer.Visible = true;
                                      ovalShape1.Left += 70;
                                      ovalShape1.Top -= 85;
                                      lblwafer.Visible = false;
                                      lblwaferright.Visible = true;
                                      lblwaferright.Text = "A4";
                                      lblwafer.Left += 70;
                                      lblwafer.Top -= 85;
                                      // panel1.Visible = false;



                                      //   await Task.Delay(2000);
                                      //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                      //  picMain.Image = Properties.Resources.robotleftA1opencentralize;

                                      await Task.Delay(2000);






                                      // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                      //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                      picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                      lblCentralize.BackColor = Color.LimeGreen;
                                      ovalShape1.Left += 155;
                                      ovalShape1.Top += 0;
                                      lblwaferright.Visible = false;
                                      lblwaferaligner.Visible = true;
                                      lblwaferaligner.Text = "A4";
                                      lblwafer.Left += 155;
                                      lblwafer.Top += 0;


                                      ////////////////////////////////////////////////////////////////////////////////////
                                      await Task.Delay(2000);
                                      // pictRobot.Visible = true;
                                      // picCentralize.Image = Properties.Resources.centralize2;
                                      // picMain.Image = Properties.Resources.picrobotcentralized;
                                      picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                      // ovalShape1.Visible = true;
                                      //picwafer.Visible = true;
                                      lblwaferaligner.Visible = false;
                                      lblwaferright.Visible = true;
                                      lblwaferright.Text = "A4";
                                      ovalShape1.Left -= 155;
                                      ovalShape1.Top -= 0;
                                      lblwafer.Left -= 155;
                                      lblwafer.Top -= 0;
                                      lblCentralize.BackColor = Color.Blue;

                                      // await Task.Delay(2000);
                                      // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                      // picMain.Image = Properties.Resources.robotleftA1;
                                      await Task.Delay(2000);

                                      //   picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picrobotAPMWafer;
                                      lblwaferright.Visible = false;
                                      lblwaferup.Visible = true;
                                      lblwaferup.Text = "A4";
                                      ovalShape1.Left -= 82;
                                      ovalShape1.Top -= 76;
                                      lblwafer.Left -= 82;
                                      lblwafer.Top -= 76;





                                      await Task.Delay(1000);

                                      // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                      // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                      picSV.Visible = false;  // open sv of chamber

                                      await Task.Delay(1000);

                                      //pictRobot.Visible = false;
                                      //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                      //  picMain.Image = Properties.Resources.picrobotintochamber;
                                      picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                      // picChamber.Width += 140;
                                      //picChamber.Left -= 150;
                                      //picChamber.Height += 10;
                                      lblwaferup.Visible = false;
                                      lblwaferAPM.Visible = true;
                                      lblwaferAPM.Text = "A4";
                                      ovalShape1.Top -= 145;
                                      ovalShape1.Left += 3;
                                      lblwafer.Top -= 145;
                                      lblwafer.Left += 3;



                                      lblChamber.BackColor = Color.LimeGreen;

                                      chamberload = "LimeGreen";

                                      // loaddata();
                                      // loadchamber1( sender, e);
                                      await Task.Delay(1000);
                                      picChamber.Image = Properties.Resources.ChamberWithA1;
                                      //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                      picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picwaferinAPM;
                                      ovalShape1.Left -= 1;
                                      ovalShape1.Left += 1;
                                      //  picMain.SendToBack();
                                      // ovalShape1.BringToFront();
                                      picChamber.Width -= 140;
                                      picChamber.Left += 150;
                                      picChamber.Height -= 10;


                                      //  pictRobot.Visible = true;


                                      await Task.Delay(1000);

                                      picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                      //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                      picSV.Visible = true;

                                      //////////////////////////////////////////////////////////////////////////////////////////// ///////////WaferA4 into Chamber


                                      lblRecipe.BackColor = Color.LimeGreen;
                                      lblStepName.BackColor = Color.LimeGreen;

                                      lblnum.BackColor = Color.LimeGreen;

                                      lblData.BackColor = Color.LimeGreen;
                                      lblData.Text = "";
                                      label2.BackColor = Color.LimeGreen;

                                      lblProcess.Text = "Processing";
                                      lblProcess.BackColor = Color.LimeGreen;
                                      lblProcessStep.Text = "Process Step";
                                      lblProcessStep.BackColor = Color.LimeGreen;



                                      con.Open();
                                      string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                      SqlCommand cmd = new SqlCommand(strSQL, con);
                                      cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                      SqlDataReader reader = cmd.ExecuteReader();
                                      while (reader.Read())
                                      {

                                          lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                      }

                                      con.Close();
                                      con.Open();
                                      string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                      SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                      cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                      SqlDataReader reader1 = cmd1.ExecuteReader();
                                      while (reader1.Read())
                                      {

                                          strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                      }

                                      con.Close();

                                      con.Open();
                                      string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                      SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                      cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                      cmd2.ExecuteNonQuery();



                                      for (int j = 0; j < strStepname1.Count(); j += 1)

                                      {

                                          await Task.Delay(1000);

                                          ListStepStartTime.Add(DateTime.Now);


                                          int count = j + 1;


                                          lblStepName.Text = strStepname1[j];
                                          lblnum.Text = "," + count + "/" + strStepname1.Count();


                                          con.Close();

                                          con.Open();
                                          string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                          SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                          cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                          SqlDataReader readerSec = cmdSec.ExecuteReader();


                                          while (readerSec.Read())
                                          {
                                              mySec1 = readerSec["ProcessTime"].ToString();

                                              Int32.TryParse(mySec1, out Sec1);

                                          }

                                          for (int k = 1; k <= Sec1; k++)
                                          {
                                              lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                              await Task.Delay(1000);


                                          }
                                          ListStepEndTime.Add(DateTime.Now);

                                          con.Close();

                                          con.Open();

                                          string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                          SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                          cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                          cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "4");
                                          cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                          cmdmodulerecipe.ExecuteNonQuery();

                                          con.Close();
                                          //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                          con.Open();

                                          string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                          SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                          cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                          cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          SqlDataReader reader2 = cmd3.ExecuteReader();

                                          while (reader2.Read())
                                          {
                                              CI2 = reader2["CI2"].ToString();
                                              BCI3 = reader2["BCI3"].ToString();
                                              SF6 = reader2["SF6"].ToString();
                                              CHF3 = reader2["CHF3"].ToString();
                                              Oxygen = reader2["Oxygen"].ToString();
                                              Oxygen1 = reader2["Oxygen1"].ToString();
                                              Nitrogen = reader2["Nitrogen"].ToString();
                                              Argon = reader2["Argon"].ToString();



                                          }

                                          con.Close();

                                          ///////////////////////////////////////////////////////////////////////////////////////////////////
                                          con.Open();
                                          Chamber1 chamber1 = new Chamber1();

                                          string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate) values(@11,@21,@31,@41,@51,@61,@71,@81),(@12,@22,@32,@42,@52,@62,@72,@82),(@13,@23,@33,@43,@53,@63,@73,@83)"
                                              + ",(@14,@24,@34,@44,@54,@64,@74,@84),(@15,@25,@35,@45,@55,@65,@75,@85),(@16,@26,@36,@46,@56,@66,@76,@86),(@17,@27,@37,@47,@57,@67,@77,@87),(@18,@28,@38,@48,@58,@68,@78,@88)";
                                          SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                          cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                          cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                          cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                          cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                          cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                          cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                          cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                          cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                          cmdparameter.Parameters.AddWithValue("@21", CI2);
                                          cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@23", SF6);
                                          cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@28", Argon);
                                          cmdparameter.Parameters.AddWithValue("@31", CI2);
                                          cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@33", SF6);
                                          cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@38", Argon);
                                          cmdparameter.Parameters.AddWithValue("@41", CI2);
                                          cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@43", SF6);
                                          cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@48", Argon);
                                          cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);


                                          cmdparameter.ExecuteNonQuery();
                                          con.Close();

                                      }
                                      ///////////////////////////////////////////////


                                      strStepname1.Clear();
                                      ListStepStartTime.Clear();
                                      ListStepEndTime.Clear();

                                      // }











                                      /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                      await Task.Delay(1000);
                                      picChamber.Image = Properties.Resources.ChamberWithA1;
                                      //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                      picSV.Visible = false;
                                      await Task.Delay(1000);

                                      picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                      picMain.Image = Properties.Resources.picrobotintochamber;
                                      picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                      ovalShape1.Left += 1;
                                      ovalShape1.Left -= 1;
                                      picChamber.Width += 140;
                                      picChamber.Left -= 150;
                                      picChamber.Height += 10;
                                      await Task.Delay(1000);
                                      label2.BackColor = Color.Blue;
                                      lblProcess.BackColor = Color.Blue;
                                      lblProcessStep.BackColor = Color.Blue;
                                      lblRecipe.BackColor = Color.Blue;
                                      lblStepName.BackColor = Color.Blue;
                                      lblData.BackColor = Color.Blue;
                                      lblnum.BackColor = Color.Blue;

                                      lblProcess.Text = "Idle";
                                      lblProcessStep.Text = "";
                                      lblRecipe.Text = "";
                                      lblStepName.Text = "";
                                      lblnum.Text = "";
                                      lblData.Text = "";


                                      // pictRobot.Visible = true;

                                      picChamber.Image = Properties.Resources.new_chamber1;
                                      picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picrobotAPMWafer;
                                      lblwaferAPM.Visible = false;
                                      lblwaferup.Visible = true;

                                      ovalShape1.Top += 145;
                                      ovalShape1.Left -= 3;
                                      lblwafer.Top += 145;
                                      lblwafer.Left -= 3;

                                      lblChamber.BackColor = Color.Blue;
                                      chamberload = "Blue";
                                      picChamber.Width -= 140;
                                      picChamber.Left += 150;
                                      picChamber.Height -= 10;
                                      await Task.Delay(2000);
                                      picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                      // picMain.Image = Properties.Resources.robotrightA1;
                                      picSV.Visible = true;




                                      await Task.Delay(2000);

                                      // pictRobot.Height += 20;

                                      // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                      picMain.Image = Properties.Resources.mainpicture;
                                      picMain.Image = Properties.Resources.picrobotArmWafer;
                                      lblwaferup.Visible = false;
                                      lblwafer.Visible = true;
                                      ovalShape1.Top += 162;
                                      lblwafer.Top += 162;
                                      ovalShape1.Left += 12;
                                      lblwafer.Left += 12;
                                      await Task.Delay(2000);

                                      await Task.Delay(1000);
                                      picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                         // picMain.Image = Properties.Resources.robotgetwaferA1;
                                      await Task.Delay(1000);

                                      lblCassette.BackColor = Color.LimeGreen;

                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picMain.Image = Properties.Resources.picrobotintocassette;
                                      lblwafer.Visible = false;
                                      lblwafer.Visible = false;
                                      ovalShape1.Visible = false;
                                      picCassette.Height += 220;
                                      picCassette.Width += 25;
                                      picCassette.Top -= 205;
                                      await Task.Delay(2000);
                                      lblCassette.BackColor = Color.Blue;
                                      //  pictRobot.Visible = true;

                                      picMain.Image = Properties.Resources.mainpicture;
                                      picCassette.Image = Properties.Resources.cassette3;
                                      picCassette.Width -= 25;
                                      picCassette.Height -= 220;
                                      picCassette.Top += 205;
                                      await Task.Delay(2000);
                                      //  picMain.Image = Properties.Resources.mainpic;
                                      picCassette.Image = Properties.Resources.cassette;
                                      // picwafer.Image = Properties.Resources.waferfull;
                                      if (NoOfwafer[i] == "1")
                                      {
                                          //  picwafer.Image = Properties.Resources.waferA1full;
                                          picWafer1.Visible = true;
                                      }
                                      if (NoOfwafer[i] == "2")
                                      {
                                          //  picwafer.Image = Properties.Resources.waferA2full;
                                          picWafer1.Visible = true;
                                          picWafer2.Visible = true;
                                      }
                                      if (NoOfwafer[i] == "3")
                                      {
                                          //  picwafer.Image = Properties.Resources.waferA3full;
                                          picWafer1.Visible = true;
                                          picWafer2.Visible = true;
                                          picWafer3.Visible = true;
                                      }
                                      if (NoOfwafer[i] == "4")
                                      {
                                          // picwafer.Image = Properties.Resources.waferA4full;
                                          picWafer1.Visible = true;
                                          picWafer2.Visible = true;
                                          picWafer3.Visible = true;
                                          picWafer4.Visible = true;
                                          picWafer2.Image = Properties.Resources.picWaferGreen;
                                          picWafer1.Image = Properties.Resources.picWaferGreen;
                                          picWafer3.Image = Properties.Resources.picWaferGreen;
                                          picWafer4.Image = Properties.Resources.picWaferGreen;
                                      }

                                      if (NoOfwafer[i] == "5")
                                      {
                                          //  picwafer.Image = Properties.Resources.waferA5full;
                                          picWafer1.Visible = true;
                                          picWafer2.Visible = true;
                                          picWafer3.Visible = true;
                                          picWafer4.Visible = true;
                                          picWafer5.Visible = true;
                                      }

                                      //////////////////////////////////////////////////////////////////Save DataLog
                                      if (int.Parse(NoOfwafer[i]) == 4)
                                      {
                                          EndTime = DateTime.Now;


                                          con.Open();

                                          string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                          SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                          cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                          cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                          cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                          cmdinsertdatalog.ExecuteNonQuery();

                                          con.Close();

                                          lblState.Text = "Finished";

                                      }
                                      /////////////////////////////////////////////////////////finish waferA4
                                  }













                                  if (int.Parse(NoOfwafer[i]) >= 5)
                                  {
                                      /////////////////////////////////////////////////////////start WaferA5

                                      await Task.Delay(1000);

                                      //pictRobot.Image = Properties.Resources.new_robot;
                                      picMain.Image = Properties.Resources.mainpicture;
                                      await Task.Delay(1000);

                                      //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                      // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                      await Task.Delay(1000);

                                      picMain.Image = Properties.Resources.picrobotintocassette;
                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                      picCassette.Width += 25;
                                      picCassette.Height += 220;
                                      picCassette.Top -= 205;
                                      picCassette.Image.Tag = "robot_into_cassetteA1";
                                      picCassette.Left += 5;
                                      label1.BackColor = Color.Blue;
                                      lblLoad.Text = "";
                                      lblLoad.BackColor = Color.Blue;
                                      lbl123.BackColor = Color.Blue;
                                      lblState.BackColor = Color.Blue;
                                      lblCassetteRecipename.BackColor = Color.Blue;
                                      lblmTorr.BackColor = Color.Blue;


                                      lblCassette.BackColor = Color.LimeGreen;
                                      await Task.Delay(1000);


                                      picCassette.Image = Properties.Resources.cassette;
                                      await Task.Delay(1000);

                                      if (NoOfwafer[i] == "1")
                                      {
                                          // picwafer.Image = Properties.Resources.wafer;
                                          //  picwafer.Image.Tag = "wafer";
                                          picWafer5.Visible = true;
                                      }
                                      else if (NoOfwafer[i] == "2")
                                      {
                                          //  picwafer.Image = Properties.Resources.waferA1full;
                                          picWafer5.Visible = true;
                                      }
                                      else if (NoOfwafer[i] == "3")
                                      {
                                          //   picwafer.Image = Properties.Resources.waferA2full;
                                          picWafer5.Visible = true;

                                      }
                                      else if (NoOfwafer[i] == "4")
                                      {
                                          //   picwafer.Image = Properties.Resources.waferA3full;
                                          picWafer5.Visible = true;
                                      }
                                      else if (NoOfwafer[i] == "5")
                                      {
                                          // picwafer.Image = Properties.Resources.waferA4full;
                                          picWafer5.Visible = true;
                                      }

                                      StartTime = DateTime.Now;


                                      con.Open();

                                      string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                      SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                      cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "5");
                                      cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                      cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                      cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);
                                      cmdwaferselection.ExecuteNonQuery();

                                      con.Close();




                                      picMain.Image = Properties.Resources.picrobotArmWafer;
                                      // panel1.Visible = true;
                                      //  ovalShape1.Visible = true;
                                      lblwafer.Visible = true;
                                      lblwafer.Text = "A5";

                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette3;

                                      // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                      picCassette.Height -= 220;
                                      picCassette.Width -= 25;
                                      picCassette.Top += 205;
                                      picCassette.Image.Tag = "cassette";
                                      picCassette.Left -= 5;
                                      //  await Task.Delay(1000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                      await Task.Delay(1000);



                                      // pictRobot.Image = Properties.Resources.robotleft_A1;
                                      //   picMain.Image = Properties.Resources.picrobotcentralized;
                                      picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                      //  ovalShape1.Visible = true;
                                      // lblwafer.Visible = true;
                                      ovalShape1.Left += 70;
                                      ovalShape1.Top -= 85;
                                      lblwafer.Visible = false;
                                      lblwaferright.Visible = true;
                                      lblwaferright.Text = "A5";
                                      lblwafer.Left += 70;
                                      lblwafer.Top -= 85;
                                      // panel1.Visible = false;



                                      //   await Task.Delay(2000);
                                      //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                      //  picMain.Image = Properties.Resources.robotleftA1opencentralize;

                                      await Task.Delay(2000);






                                      // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                      //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                      picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                      lblCentralize.BackColor = Color.LimeGreen;
                                      ovalShape1.Left += 155;
                                      ovalShape1.Top += 0;
                                      lblwaferright.Visible = false;
                                      lblwaferaligner.Visible = true;
                                      lblwaferaligner.Text = "A5";
                                      lblwafer.Left += 155;
                                      lblwafer.Top += 0;


                                      ////////////////////////////////////////////////////////////////////////////////////
                                      await Task.Delay(2000);
                                      // pictRobot.Visible = true;
                                      // picCentralize.Image = Properties.Resources.centralize2;
                                      // picMain.Image = Properties.Resources.picrobotcentralized;
                                      picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                      // ovalShape1.Visible = true;
                                      //picwafer.Visible = true;
                                      lblwaferaligner.Visible = false;
                                      lblwaferright.Visible = true;
                                      lblwaferright.Text = "A5";
                                      ovalShape1.Left -= 155;
                                      ovalShape1.Top -= 0;
                                      lblwafer.Left -= 155;
                                      lblwafer.Top -= 0;
                                      lblCentralize.BackColor = Color.Blue;

                                      // await Task.Delay(2000);
                                      // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                      // picMain.Image = Properties.Resources.robotleftA1;
                                      await Task.Delay(2000);

                                      //   picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picrobotAPMWafer;
                                      lblwaferright.Visible = false;
                                      lblwaferup.Visible = true;
                                      lblwaferup.Text = "A5";
                                      ovalShape1.Left -= 82;
                                      ovalShape1.Top -= 76;
                                      lblwafer.Left -= 82;
                                      lblwafer.Top -= 76;





                                      await Task.Delay(1000);

                                      // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                      // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                      picSV.Visible = false;  // open sv of chamber

                                      await Task.Delay(1000);

                                      //pictRobot.Visible = false;
                                      //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                      //  picMain.Image = Properties.Resources.picrobotintochamber;
                                      picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                      // picChamber.Width += 140;
                                      //picChamber.Left -= 150;
                                      //picChamber.Height += 10;
                                      lblwaferup.Visible = false;
                                      lblwaferAPM.Visible = true;
                                      lblwaferAPM.Text = "A5";
                                      ovalShape1.Top -= 145;
                                      ovalShape1.Left += 3;
                                      lblwafer.Top -= 145;
                                      lblwafer.Left += 3;



                                      lblChamber.BackColor = Color.LimeGreen;

                                      chamberload = "LimeGreen";

                                      // loaddata();
                                      // loadchamber1( sender, e);
                                      await Task.Delay(1000);
                                      picChamber.Image = Properties.Resources.ChamberWithA1;
                                      //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                      picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picwaferinAPM;
                                      ovalShape1.Left -= 1;
                                      ovalShape1.Left += 1;
                                      //  picMain.SendToBack();
                                      // ovalShape1.BringToFront();
                                      picChamber.Width -= 140;
                                      picChamber.Left += 150;
                                      picChamber.Height -= 10;


                                      //  pictRobot.Visible = true;


                                      await Task.Delay(1000);

                                      picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                      //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                      picSV.Visible = true;

                                      ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA5 into Chamber


                                      lblRecipe.BackColor = Color.LimeGreen;
                                      lblStepName.BackColor = Color.LimeGreen;

                                      lblnum.BackColor = Color.LimeGreen;

                                      lblData.BackColor = Color.LimeGreen;
                                      lblData.Text = "";
                                      label2.BackColor = Color.LimeGreen;

                                      lblProcess.Text = "Processing";
                                      lblProcess.BackColor = Color.LimeGreen;
                                      lblProcessStep.Text = "Process Step";
                                      lblProcessStep.BackColor = Color.LimeGreen;



                                      con.Open();
                                      string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                      SqlCommand cmd = new SqlCommand(strSQL, con);
                                      cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                      SqlDataReader reader = cmd.ExecuteReader();
                                      while (reader.Read())
                                      {

                                          lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                      }

                                      con.Close();
                                      con.Open();
                                      string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                      SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                      cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                      SqlDataReader reader1 = cmd1.ExecuteReader();
                                      while (reader1.Read())
                                      {

                                          strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                      }

                                      con.Close();

                                      con.Open();
                                      string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                      SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                      cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                      cmd2.ExecuteNonQuery();



                                      for (int j = 0; j < strStepname1.Count(); j += 1)

                                      {

                                          await Task.Delay(1000);

                                          ListStepStartTime.Add(DateTime.Now);


                                          int count = j + 1;


                                          lblStepName.Text = strStepname1[j];
                                          lblnum.Text = "," + count + "/" + strStepname1.Count();


                                          con.Close();

                                          con.Open();
                                          string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                          SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                          cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                          SqlDataReader readerSec = cmdSec.ExecuteReader();


                                          while (readerSec.Read())
                                          {
                                              mySec1 = readerSec["ProcessTime"].ToString();

                                              Int32.TryParse(mySec1, out Sec1);

                                          }

                                          for (int k = 1; k <= Sec1; k++)
                                          {
                                              lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                              await Task.Delay(1000);


                                          }
                                          ListStepEndTime.Add(DateTime.Now);

                                          con.Close();

                                          con.Open();

                                          string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                          SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                          cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                          cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "5");
                                          cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                          cmdmodulerecipe.ExecuteNonQuery();

                                          con.Close();
                                          //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                          con.Open();

                                          string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                          SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                          cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                          cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          SqlDataReader reader2 = cmd3.ExecuteReader();

                                          while (reader2.Read())
                                          {
                                              CI2 = reader2["CI2"].ToString();
                                              BCI3 = reader2["BCI3"].ToString();
                                              SF6 = reader2["SF6"].ToString();
                                              CHF3 = reader2["CHF3"].ToString();
                                              Oxygen = reader2["Oxygen"].ToString();
                                              Oxygen1 = reader2["Oxygen1"].ToString();
                                              Nitrogen = reader2["Nitrogen"].ToString();
                                              Argon = reader2["Argon"].ToString();



                                          }

                                          con.Close();

                                          ///////////////////////////////////////////////////////////////////////////////////////////////////
                                          con.Open();
                                          Chamber1 chamber1 = new Chamber1();

                                          string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname,valuedate) values(@11,@21,@31,@41,@51,@61,@71,@81),(@12,@22,@32,@42,@52,@62,@72,@82),(@13,@23,@33,@43,@53,@63,@73,@83)"
                                              + ",(@14,@24,@34,@44,@54,@64,@74,@84),(@15,@25,@35,@45,@55,@65,@75,@85),(@16,@26,@36,@46,@56,@66,@76,@86),(@17,@27,@37,@47,@57,@67,@77,@87),(@18,@28,@38,@48,@58,@68,@78,@88)";
                                          SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                          cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                          cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                          cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                          cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                          cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                          cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                          cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                          cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                          cmdparameter.Parameters.AddWithValue("@21", CI2);
                                          cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@23", SF6);
                                          cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@28", Argon);
                                          cmdparameter.Parameters.AddWithValue("@31", CI2);
                                          cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@33", SF6);
                                          cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@38", Argon);
                                          cmdparameter.Parameters.AddWithValue("@41", CI2);
                                          cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@43", SF6);
                                          cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@48", Argon);
                                          cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@81", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@82", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@83", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@84", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@85", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@86", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@87", DateTime.Now);
                                          cmdparameter.Parameters.AddWithValue("@88", DateTime.Now);


                                          cmdparameter.ExecuteNonQuery();
                                          con.Close();

                                      }
                                      ///////////////////////////////////////////////


                                      strStepname1.Clear();
                                      ListStepStartTime.Clear();
                                      ListStepEndTime.Clear();

                                      // }











                                      /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                      await Task.Delay(1000);
                                      picChamber.Image = Properties.Resources.ChamberWithA1;
                                      //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                      picSV.Visible = false;
                                      await Task.Delay(1000);

                                      picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                      picMain.Image = Properties.Resources.picrobotintochamber;
                                      picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                      ovalShape1.Left += 1;
                                      ovalShape1.Left -= 1;
                                      picChamber.Width += 140;
                                      picChamber.Left -= 150;
                                      picChamber.Height += 10;
                                      await Task.Delay(1000);
                                      label2.BackColor = Color.Blue;
                                      lblProcess.BackColor = Color.Blue;
                                      lblProcessStep.BackColor = Color.Blue;
                                      lblRecipe.BackColor = Color.Blue;
                                      lblStepName.BackColor = Color.Blue;
                                      lblData.BackColor = Color.Blue;
                                      lblnum.BackColor = Color.Blue;

                                      lblProcess.Text = "idle";
                                      lblProcessStep.Text = "";
                                      lblRecipe.Text = "";
                                      lblStepName.Text = "";
                                      lblnum.Text = "";
                                      lblData.Text = "";


                                      // pictRobot.Visible = true;

                                      picChamber.Image = Properties.Resources.new_chamber1;
                                      picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picrobotAPMWafer;
                                      lblwaferAPM.Visible = false;
                                      lblwaferup.Visible = true;

                                      ovalShape1.Top += 145;
                                      ovalShape1.Left -= 3;
                                      lblwafer.Top += 145;
                                      lblwafer.Left -= 3;

                                      lblChamber.BackColor = Color.Blue;
                                      chamberload = "Blue";
                                      picChamber.Width -= 140;
                                      picChamber.Left += 150;
                                      picChamber.Height -= 10;
                                      await Task.Delay(2000);
                                      picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                      // picMain.Image = Properties.Resources.robotrightA1;
                                      picSV.Visible = true;




                                      await Task.Delay(2000);

                                      // pictRobot.Height += 20;

                                      // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                      picMain.Image = Properties.Resources.mainpicture;
                                      picMain.Image = Properties.Resources.picrobotArmWafer;
                                      lblwaferup.Visible = false;
                                      lblwafer.Visible = true;
                                      ovalShape1.Top += 162;
                                      lblwafer.Top += 162;
                                      ovalShape1.Left += 12;
                                      lblwafer.Left += 12;
                                      await Task.Delay(2000);

                                      await Task.Delay(1000);
                                      picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                         // picMain.Image = Properties.Resources.robotgetwaferA1;
                                      await Task.Delay(1000);

                                      lblCassette.BackColor = Color.LimeGreen;

                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picMain.Image = Properties.Resources.picrobotintocassette;
                                      lblwafer.Visible = false;
                                      lblwafer.Visible = false;
                                      ovalShape1.Visible = false;
                                      picCassette.Height += 220;
                                      picCassette.Width += 25;
                                      picCassette.Top -= 205;
                                      await Task.Delay(2000);
                                      lblCassette.BackColor = Color.Blue;
                                      //  pictRobot.Visible = true;

                                      picMain.Image = Properties.Resources.mainpicture;
                                      picCassette.Image = Properties.Resources.cassette3;
                                      picCassette.Width -= 25;
                                      picCassette.Height -= 220;
                                      picCassette.Top += 205;
                                      await Task.Delay(2000);
                                      //  picMain.Image = Properties.Resources.mainpic;
                                      picCassette.Image = Properties.Resources.cassette;
                                      // picwafer.Image = Properties.Resources.waferfull;
                                      if (NoOfwafer[i] == "1")
                                      {
                                          picwafer.Image = Properties.Resources.waferA1full;
                                      }
                                      if (NoOfwafer[i] == "2")
                                      {
                                          picwafer.Image = Properties.Resources.waferA2full;
                                      }
                                      if (NoOfwafer[i] == "3")
                                      {
                                          picwafer.Image = Properties.Resources.waferA3full;
                                      }
                                      if (NoOfwafer[i] == "4")
                                      {
                                          picwafer.Image = Properties.Resources.waferA4full;
                                      }

                                      if (NoOfwafer[i] == "3")
                                      {
                                          picWafer1.Visible = true;
                                          picWafer2.Visible = true;
                                          picWafer3.Visible = true;
                                          picWafer4.Visible = true;
                                          picWafer5.Visible = true;

                                          picWafer5.Image = Properties.Resources.picWaferGreen;
                                          picWafer2.Image = Properties.Resources.picWaferGreen;
                                          picWafer1.Image = Properties.Resources.picWaferGreen;
                                          picWafer3.Image = Properties.Resources.picWaferGreen;
                                          picWafer4.Image = Properties.Resources.picWaferGreen;
                                      }

                                      //////////////////////////////////////////////////////////////////Save DataLog
                                      if (int.Parse(NoOfwafer[i]) == 5)
                                      {
                                          EndTime = DateTime.Now;


                                          con.Open();

                                          string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                          SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                          cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                          cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                          cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                          cmdinsertdatalog.ExecuteNonQuery();

                                          con.Close();

                                          /////////////////////////////////////////////////////////finish waferA5
                                          lblState.Text = "Finished";
                                      }
                                  }
                                  if (int.Parse(NoOfwafer[i]) >= 6)
                                  {
                                      /////////////////////////////////////////////////////////start WaferA6

                                      picCassette.Image = Properties.Resources.cassette;
                                      await Task.Delay(1000);

                                      if (NoOfwafer[i] == "1")
                                      {
                                          picwafer.Image = Properties.Resources.wafer;
                                          picwafer.Image.Tag = "wafer";
                                      }
                                      else if (NoOfwafer[i] == "2")
                                      {
                                          picwafer.Image = Properties.Resources.waferA1full;
                                      }
                                      else if (NoOfwafer[i] == "3")
                                      {
                                          picwafer.Image = Properties.Resources.waferA2full;

                                      }
                                      else if (NoOfwafer[i] == "4")
                                      {
                                          picwafer.Image = Properties.Resources.waferA3full;
                                      }
                                      else if (NoOfwafer[i] == "5")
                                      {
                                          picwafer.Image = Properties.Resources.waferA4full;
                                      }
                                      else if (NoOfwafer[i] == "6")
                                      {
                                          picwafer.Image = Properties.Resources.waferA5full;

                                      }
                                      StartTime = DateTime.Now;


                                      con.Open();

                                      string strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName,Logname) values(@NoOfWafer,@StartTime,@CassetteRecipeName,@Logname)";
                                      SqlCommand cmdwaferselection = new SqlCommand(strWaferSelection, con);
                                      cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "6");
                                      cmdwaferselection.Parameters.AddWithValue("@StartTime", StartTime);
                                      cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                      cmdwaferselection.Parameters.AddWithValue("@Logname", lbl123.Text);

                                      cmdwaferselection.ExecuteNonQuery();

                                      con.Close();









                                      await Task.Delay(1000);

                                      //pictRobot.Image = Properties.Resources.new_robot;
                                      picMain.Image = Properties.Resources.mainpicture;
                                      await Task.Delay(1000);

                                      //   picCassette.Image = Properties.Resources.cassette3;//open cassette
                                      // picMain.Image = Properties.Resources.mainpicCassetteopen;  
                                      await Task.Delay(1000);

                                      picMain.Image = Properties.Resources.picrobotintocassette;
                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;

                                      picCassette.Width += 25;
                                      picCassette.Height += 220;
                                      picCassette.Top -= 205;
                                      picCassette.Image.Tag = "robot_into_cassetteA1";
                                      picCassette.Left += 5;
                                      label1.BackColor = Color.Blue;
                                      lblLoad.Text = "";
                                      lblLoad.BackColor = Color.Blue;
                                      lbl123.BackColor = Color.Blue;
                                      lblState.BackColor = Color.Blue;
                                      lblCassetteRecipename.BackColor = Color.Blue;
                                      lblmTorr.BackColor = Color.Blue;


                                      lblCassette.BackColor = Color.LimeGreen;
                                      await Task.Delay(1000);

                                      //  pictRobot.Visible = true;

                                      //  picMain.Image = Properties.Resources.mainpicture;
                                      picMain.Image = Properties.Resources.picrobotArmWafer;
                                      // panel1.Visible = true;
                                      //  ovalShape1.Visible = true;
                                      lblwafer.Visible = true;
                                      lblwafer.Text = "A5";

                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette3;

                                      // picMain.Image = Properties.Resources.mainpicCassetteopen;
                                      picCassette.Height -= 220;
                                      picCassette.Width -= 25;
                                      picCassette.Top += 205;
                                      picCassette.Image.Tag = "cassette";
                                      picCassette.Left -= 5;
                                      //  await Task.Delay(1000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                      await Task.Delay(1000);



                                      // pictRobot.Image = Properties.Resources.robotleft_A1;
                                      //   picMain.Image = Properties.Resources.picrobotcentralized;
                                      picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                      //  ovalShape1.Visible = true;
                                      // lblwafer.Visible = true;
                                      ovalShape1.Left += 70;
                                      ovalShape1.Top -= 85;
                                      lblwafer.Visible = false;
                                      lblwaferright.Visible = true;
                                      lblwaferright.Text = "A5";
                                      lblwafer.Left += 70;
                                      lblwafer.Top -= 85;
                                      // panel1.Visible = false;



                                      //   await Task.Delay(2000);
                                      //  picCentralize.Image = Properties.Resources.centralize2;//open centralize
                                      //  picMain.Image = Properties.Resources.robotleftA1opencentralize;

                                      await Task.Delay(2000);






                                      // picCentralize.Image = Properties.Resources.robot_into_centralizeA1;

                                      //  picMain.Image = Properties.Resources.picrobotintocentralized;
                                      picMain.Image = Properties.Resources.picrobotintoAlignerWafer;
                                      lblCentralize.BackColor = Color.LimeGreen;
                                      ovalShape1.Left += 155;
                                      ovalShape1.Top += 0;
                                      lblwaferright.Visible = false;
                                      lblwaferaligner.Visible = true;
                                      lblwaferaligner.Text = "A6";
                                      lblwafer.Left += 155;
                                      lblwafer.Top += 0;


                                      ////////////////////////////////////////////////////////////////////////////////////
                                      await Task.Delay(2000);
                                      // pictRobot.Visible = true;
                                      // picCentralize.Image = Properties.Resources.centralize2;
                                      // picMain.Image = Properties.Resources.picrobotcentralized;
                                      picMain.Image = Properties.Resources.picrobotAlignerWafer;
                                      // ovalShape1.Visible = true;
                                      //picwafer.Visible = true;
                                      lblwaferaligner.Visible = false;
                                      lblwaferright.Visible = true;
                                      lblwaferright.Text = "A6";
                                      ovalShape1.Left -= 155;
                                      ovalShape1.Top -= 0;
                                      lblwafer.Left -= 155;
                                      lblwafer.Top -= 0;
                                      lblCentralize.BackColor = Color.Blue;

                                      // await Task.Delay(2000);
                                      // picCentralize.Image = Properties.Resources.centralize;//close centralize
                                      // picMain.Image = Properties.Resources.robotleftA1;
                                      await Task.Delay(2000);

                                      //   picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picrobotAPMWafer;
                                      lblwaferright.Visible = false;
                                      lblwaferup.Visible = true;
                                      lblwaferup.Text = "A6";
                                      ovalShape1.Left -= 82;
                                      ovalShape1.Top -= 76;
                                      lblwafer.Left -= 82;
                                      lblwafer.Top -= 76;





                                      await Task.Delay(1000);

                                      // picChamber.Image = Properties.Resources.new_chamber1;//open chamber
                                      // picMain.Image = Properties.Resources.robotrightA1openchamber;
                                      picSV.Visible = false;  // open sv of chamber

                                      await Task.Delay(1000);

                                      //pictRobot.Visible = false;
                                      //picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                      //  picMain.Image = Properties.Resources.picrobotintochamber;
                                      picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                      // picChamber.Width += 140;
                                      //picChamber.Left -= 150;
                                      //picChamber.Height += 10;
                                      lblwaferup.Visible = false;
                                      lblwaferAPM.Visible = true;
                                      lblwaferAPM.Text = "A6";
                                      ovalShape1.Top -= 145;
                                      ovalShape1.Left += 3;
                                      lblwafer.Top -= 145;
                                      lblwafer.Left += 3;



                                      lblChamber.BackColor = Color.LimeGreen;

                                      chamberload = "LimeGreen";

                                      // loaddata();
                                      // loadchamber1( sender, e);
                                      await Task.Delay(1000);
                                      picChamber.Image = Properties.Resources.ChamberWithA1;
                                      //   picMain.Image = Properties.Resources.robotintochamberwithA1;
                                      picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picwaferinAPM;
                                      ovalShape1.Left -= 1;
                                      ovalShape1.Left += 1;
                                      //  picMain.SendToBack();
                                      // ovalShape1.BringToFront();
                                      picChamber.Width -= 140;
                                      picChamber.Left += 150;
                                      picChamber.Height -= 10;


                                      //  pictRobot.Visible = true;


                                      await Task.Delay(1000);

                                      picChamber.Image = Properties.Resources.ChamberWithA1Close;
                                      //picMain.Image = Properties.Resources.robotintochamberwithA1close;
                                      picSV.Visible = true;

                                      ///////////////////////////////////////////////////////////////////////////////////////////////////////WaferA5 into Chamber


                                      lblRecipe.BackColor = Color.LimeGreen;
                                      lblStepName.BackColor = Color.LimeGreen;

                                      lblnum.BackColor = Color.LimeGreen;

                                      lblData.BackColor = Color.LimeGreen;
                                      lblData.Text = "";
                                      label2.BackColor = Color.LimeGreen;

                                      lblProcess.Text = "Processing";
                                      lblProcess.BackColor = Color.LimeGreen;
                                      lblProcessStep.Text = "Process Step";
                                      lblProcessStep.BackColor = Color.LimeGreen;



                                      con.Open();
                                      string strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                      SqlCommand cmd = new SqlCommand(strSQL, con);
                                      cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                      SqlDataReader reader = cmd.ExecuteReader();
                                      while (reader.Read())
                                      {

                                          lblRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);



                                      }

                                      con.Close();
                                      con.Open();
                                      string strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                      SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                                      cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                      SqlDataReader reader1 = cmd1.ExecuteReader();
                                      while (reader1.Read())
                                      {

                                          strStepname1.Add(string.Format("{0}", reader1["StepName"]));


                                      }

                                      con.Close();

                                      con.Open();
                                      string strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                      SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                                      cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);

                                      cmd2.ExecuteNonQuery();



                                      for (int j = 0; j < strStepname1.Count(); j += 1)

                                      {

                                          await Task.Delay(1000);

                                          ListStepStartTime.Add(DateTime.Now);


                                          int count = j + 1;


                                          lblStepName.Text = strStepname1[j];
                                          lblnum.Text = "," + count + "/" + strStepname1.Count();


                                          con.Close();

                                          con.Open();
                                          string strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                          SqlCommand cmdSec = new SqlCommand(strSQLStepSec, con);
                                          cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                          SqlDataReader readerSec = cmdSec.ExecuteReader();


                                          while (readerSec.Read())
                                          {
                                              mySec1 = readerSec["ProcessTime"].ToString();

                                              Int32.TryParse(mySec1, out Sec1);

                                          }

                                          for (int k = 1; k <= Sec1; k++)
                                          {
                                              lblData.Text = k.ToString() + "/" + mySec1.ToString() + " Sec";
                                              await Task.Delay(1000);


                                          }
                                          ListStepEndTime.Add(DateTime.Now);

                                          con.Close();

                                          con.Open();

                                          string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe,logname) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe,@Logname)";

                                          SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con);

                                          cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                          cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[j]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "6");
                                          cmdmodulerecipe.Parameters.AddWithValue("@Logname", lbl123.Text);

                                          cmdmodulerecipe.ExecuteNonQuery();

                                          con.Close();
                                          //////////////////////////////////////////////////////////////////////////////////////////////////////get parameter value

                                          con.Open();

                                          string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                          SqlCommand cmd3 = new SqlCommand(strSQL3, con);
                                          cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                          cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          SqlDataReader reader2 = cmd3.ExecuteReader();

                                          while (reader2.Read())
                                          {
                                              CI2 = reader2["CI2"].ToString();
                                              BCI3 = reader2["BCI3"].ToString();
                                              SF6 = reader2["SF6"].ToString();
                                              CHF3 = reader2["CHF3"].ToString();
                                              Oxygen = reader2["Oxygen"].ToString();
                                              Oxygen1 = reader2["Oxygen1"].ToString();
                                              Nitrogen = reader2["Nitrogen"].ToString();
                                              Argon = reader2["Argon"].ToString();



                                          }

                                          con.Close();

                                          ///////////////////////////////////////////////////////////////////////////////////////////////////
                                          con.Open();
                                          Chamber1 chamber1 = new Chamber1();

                                          string strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                              + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                          SqlCommand cmdparameter = new SqlCommand(strParameter, con);
                                          cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                          cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                          cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                          cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                          cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                          cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                          cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                          cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                          cmdparameter.Parameters.AddWithValue("@21", CI2);
                                          cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@23", SF6);
                                          cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@28", Argon);
                                          cmdparameter.Parameters.AddWithValue("@31", CI2);
                                          cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@33", SF6);
                                          cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@38", Argon);
                                          cmdparameter.Parameters.AddWithValue("@41", CI2);
                                          cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                          cmdparameter.Parameters.AddWithValue("@43", SF6);
                                          cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                          cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                          cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                          cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                          cmdparameter.Parameters.AddWithValue("@48", Argon);
                                          cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                          cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                          cmdparameter.Parameters.AddWithValue("@71", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@72", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@73", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@74", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@75", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@76", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@77", strStepname1[j]);
                                          cmdparameter.Parameters.AddWithValue("@78", strStepname1[j]);


                                          cmdparameter.ExecuteNonQuery();
                                          con.Close();

                                      }
                                      ///////////////////////////////////////////////


                                      strStepname1.Clear();
                                      ListStepStartTime.Clear();
                                      ListStepEndTime.Clear();

                                      // }











                                      /////////////////////////////////////////////////////////////////////////////////////////////////// 
                                      await Task.Delay(1000);
                                      picChamber.Image = Properties.Resources.ChamberWithA1;
                                      //picMain.Image = Properties.Resources.robotintochamberwithA1;
                                      picSV.Visible = false;
                                      await Task.Delay(1000);

                                      picChamber.Image = Properties.Resources.robot_into_chamberA11;
                                      picMain.Image = Properties.Resources.picrobotintochamber;
                                      picMain.Image = Properties.Resources.picrobotintoAPMWafer;
                                      ovalShape1.Left += 1;
                                      ovalShape1.Left -= 1;
                                      picChamber.Width += 140;
                                      picChamber.Left -= 150;
                                      picChamber.Height += 10;
                                      await Task.Delay(1000);
                                      label2.BackColor = Color.Blue;
                                      lblProcess.BackColor = Color.Blue;
                                      lblProcessStep.BackColor = Color.Blue;
                                      lblRecipe.BackColor = Color.Blue;
                                      lblStepName.BackColor = Color.Blue;
                                      lblData.BackColor = Color.Blue;
                                      lblnum.BackColor = Color.Blue;

                                      lblProcess.Text = "Aborted";
                                      lblProcessStep.Text = "";
                                      lblRecipe.Text = "";
                                      lblStepName.Text = "";
                                      lblnum.Text = "";
                                      lblData.Text = "???????????";


                                      // pictRobot.Visible = true;

                                      picChamber.Image = Properties.Resources.new_chamber1;
                                      picMain.Image = Properties.Resources.picrobotbotton;
                                      picMain.Image = Properties.Resources.picrobotAPMWafer;
                                      lblwaferAPM.Visible = false;
                                      lblwaferup.Visible = true;

                                      ovalShape1.Top += 145;
                                      ovalShape1.Left -= 3;
                                      lblwafer.Top += 145;
                                      lblwafer.Left -= 3;

                                      lblChamber.BackColor = Color.Blue;
                                      chamberload = "Blue";
                                      picChamber.Width -= 140;
                                      picChamber.Left += 150;
                                      picChamber.Height -= 10;
                                      await Task.Delay(2000);
                                      picChamber.Image = Properties.Resources.new_chamber;//close chamber

                                      // picMain.Image = Properties.Resources.robotrightA1;
                                      picSV.Visible = true;




                                      await Task.Delay(2000);

                                      // pictRobot.Height += 20;

                                      // picMain.Image = Properties.Resources.robotgetwaferA1cassetteclose;
                                      picMain.Image = Properties.Resources.mainpicture;
                                      picMain.Image = Properties.Resources.picrobotArmWafer;
                                      lblwaferup.Visible = false;
                                      lblwafer.Visible = true;
                                      ovalShape1.Top += 162;
                                      lblwafer.Top += 162;
                                      ovalShape1.Left += 12;
                                      lblwafer.Left += 12;
                                      await Task.Delay(2000);

                                      await Task.Delay(1000);
                                      picCassette.Image = Properties.Resources.cassette3;//open cassette
                                                                                         // picMain.Image = Properties.Resources.robotgetwaferA1;
                                      await Task.Delay(1000);

                                      lblCassette.BackColor = Color.LimeGreen;

                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picMain.Image = Properties.Resources.picrobotintocassette;
                                      lblwafer.Visible = false;
                                      lblwafer.Visible = false;
                                      ovalShape1.Visible = false;
                                      picCassette.Height += 220;
                                      picCassette.Width += 25;
                                      picCassette.Top -= 205;
                                      await Task.Delay(2000);
                                      lblCassette.BackColor = Color.Blue;
                                      //  pictRobot.Visible = true;

                                      picMain.Image = Properties.Resources.mainpicture;
                                      picCassette.Image = Properties.Resources.cassette3;
                                      picCassette.Width -= 25;
                                      picCassette.Height -= 220;
                                      picCassette.Top += 205;
                                      await Task.Delay(2000);
                                      //  picMain.Image = Properties.Resources.mainpic;
                                      picCassette.Image = Properties.Resources.cassette;
                                      // picwafer.Image = Properties.Resources.waferfull;
                                      if (NoOfwafer[i] == "1")
                                      {
                                          picwafer.Image = Properties.Resources.waferA1full;
                                      }
                                      if (NoOfwafer[i] == "2")
                                      {
                                          picwafer.Image = Properties.Resources.waferA2full;
                                      }
                                      if (NoOfwafer[i] == "3")
                                      {
                                          picwafer.Image = Properties.Resources.waferA3full;
                                      }
                                      if (NoOfwafer[i] == "4")
                                      {
                                          picwafer.Image = Properties.Resources.waferA4full;
                                      }

                                      if (NoOfwafer[i] == "5")
                                      {
                                          picwafer.Image = Properties.Resources.waferA5full;
                                      }
                                      if (NoOfwafer[i] == "6")
                                      {
                                          picwafer.Image = Properties.Resources.waferA6full;
                                      }

                                      //////////////////////////////////////////////////////////////////Save DataLog
                                      if (int.Parse(NoOfwafer[i]) == 6)
                                      {
                                          EndTime = DateTime.Now;


                                          con.Open();

                                          string strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                          SqlCommand cmdinsertdatalog = new SqlCommand(strinsertdatalog, con);

                                          cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                          cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                          cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                          cmdinsertdatalog.ExecuteNonQuery();

                                          con.Close();

                                          /////////////////////////////////////////////////////////finish waferA5
                                      }

                                      //////////////////////////////////////////////////////////////////////////finish waferA6
                                  }
                                  if (int.Parse(NoOfwafer[i]) >= 7)
                                  {
                                      //////////////////////////////////////////////////////////////////////////start waferA7
                                      await Task.Delay(2000);

                                      picCassette.Image = Properties.Resources.cassette1;
                                      await Task.Delay(2000);
                                      Wafer7StartTime = DateTime.Now;
                                      scsb = new SqlConnectionStringBuilder();
                                      scsb.DataSource = @"HP-PC\SQLEXPRESS";
                                      scsb.InitialCatalog = "RecipeType";
                                      scsb.IntegratedSecurity = true;
                                      SqlConnection con6 = new SqlConnection(scsb.ToString());
                                      con6.Open();

                                      string wafer7strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName) values(@NoOfWafer,@StartTime,@CassetteRecipeName)";
                                      SqlCommand wafer7cmdwaferselection = new SqlCommand(wafer7strWaferSelection, con6);
                                      wafer7cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "7");
                                      wafer7cmdwaferselection.Parameters.AddWithValue("@StartTime", Wafer7StartTime);
                                      wafer7cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                      wafer7cmdwaferselection.ExecuteNonQuery();

                                      con6.Close();




                                      // lblCassette.BackColor = Color.LimeGreen;

                                      lblCassette.BackColor = Color.LimeGreen;
                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picCassette.Height += 150;
                                      picCassette.Top -= 150;
                                      await Task.Delay(2000);
                                      picwafer.Image = Properties.Resources.waferA7;
                                      await Task.Delay(2000);
                                      // WaferTime = DateTime.Now;
                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette1;
                                      picCassette.Height -= 150;
                                      picCassette.Top += 150;
                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      await Task.Delay(2000);

                                      await Task.Delay(2000);

                                      await Task.Delay(2000);

                                      lblCentralize.BackColor = Color.LimeGreen;

                                      // picCentralize.Height += 100;

                                      await Task.Delay(2000);

                                      lblCentralize.BackColor = Color.Blue;

                                      //picCentralize.Height -= 100;

                                      await Task.Delay(2000);


                                      await Task.Delay(2000);

                                      picChamber.Image = Properties.Resources.new_chamber1;

                                      await Task.Delay(2000);


                                      picChamber.Image = Properties.Resources.robot_into_chamberA7;
                                      picChamber.Width += 100;
                                      picChamber.Left -= 150;
                                      lblChamber.BackColor = Color.LimeGreen;

                                      chamberload = "LimeGreen";
                                      //////////////////////////////////////////////////////////////////////////////////waferA7 into chamber
                                      WaferTime = DateTime.Now;
                                      lblRecipe.BackColor = Color.LimeGreen;
                                      lblStepName.BackColor = Color.LimeGreen;
                                      lblnum.BackColor = Color.LimeGreen;
                                      lblData.BackColor = Color.LimeGreen;
                                      lblData.Text = "";
                                      label2.BackColor = Color.LimeGreen;
                                      lblProcess.Text = "Processing";
                                      lblProcess.BackColor = Color.LimeGreen;
                                      lblProcessStep.Text = "Process Step";
                                      lblProcessStep.BackColor = Color.LimeGreen;

                                      con6.Open();
                                      string wafer7strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                      SqlCommand wafer7cmd = new SqlCommand(wafer7strSQL, con6);
                                      wafer7cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                      SqlDataReader wafer7reader = wafer7cmd.ExecuteReader();
                                      while (wafer7reader.Read())
                                      {

                                          lblRecipe.Text = string.Format("{0}", wafer7reader["WaferRecipe"]);



                                      }

                                      con6.Close();
                                      con6.Open();
                                      string wafer7strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                      SqlCommand wafer7cmd1 = new SqlCommand(wafer7strSQL1, con6);
                                      wafer7cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                      SqlDataReader wafer7reader1 = wafer7cmd1.ExecuteReader();
                                      while (wafer7reader1.Read())
                                      {

                                          strStepname1.Add(string.Format("{0}", wafer7reader1["StepName"]));


                                      }

                                      con6.Close();
                                      con6.Open();
                                      string wafer7strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                      SqlCommand wafer7cmd2 = new SqlCommand(wafer7strSQL2, con6);
                                      wafer7cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                      //SqlDataReader reader2 = cmd2.ExecuteReader();
                                      wafer7cmd2.ExecuteNonQuery();

                                      // while (reader2.Read())
                                      // {
                                      //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                                      // int row = strStepname.Count();
                                      for (int a7 = 0; a7 < strStepname1.Count(); a7 += 1)
                                      {
                                          await Task.Delay(1000);
                                          ListStepStartTime.Add(DateTime.Now);
                                          int count = a7 + 1;
                                          // await Task.Delay(2000);
                                          lblStepName.Text = strStepname1[a7];
                                          lblnum.Text = "," + count + "/" + strStepname1.Count();
                                          // lblnum.Text = "," + count + "/" + strStepname.Count();
                                          //  await Task.Delay(2000);

                                          con6.Close();

                                          con6.Open();
                                          string wafer7strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                          SqlCommand wafer7cmdSec = new SqlCommand(wafer7strSQLStepSec, con6);
                                          wafer7cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                          SqlDataReader wafer7readerSec = wafer7cmdSec.ExecuteReader();


                                          while (wafer7readerSec.Read())
                                          {
                                              mySec1 = wafer7readerSec["ProcessTime"].ToString();
                                              // lblSec.Text = string.Format("{0}", readerSec["ProcessPressure"]);
                                              Int32.TryParse(mySec1, out Sec1);

                                          }

                                          for (int j = 1; j <= Sec1; j++)
                                          {
                                              lblData.Text = j.ToString() + "/" + mySec1.ToString() + " Sec";
                                              await Task.Delay(1000);


                                          }
                                          ListStepEndTime.Add(DateTime.Now);

                                          con6.Close();


                                          con6.Open();

                                          string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe)";

                                          SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con6);

                                          cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                          cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[a7]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[a7]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[a7]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "7");

                                          cmdmodulerecipe.ExecuteNonQuery();

                                          con6.Close();
                                          ///////////////////////////////////////////////////////get parameter value

                                          con6.Open();

                                          string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                          SqlCommand cmd3 = new SqlCommand(strSQL3, con6);
                                          cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                          cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          SqlDataReader reader2 = cmd3.ExecuteReader();

                                          while (reader2.Read())
                                          {
                                              CI2 = reader2["CI2"].ToString();
                                              BCI3 = reader2["BCI3"].ToString();
                                              SF6 = reader2["SF6"].ToString();
                                              CHF3 = reader2["CHF3"].ToString();
                                              Oxygen = reader2["Oxygen"].ToString();
                                              Oxygen1 = reader2["Oxygen1"].ToString();
                                              Nitrogen = reader2["Nitrogen"].ToString();
                                              Argon = reader2["Argon"].ToString();



                                          }

                                          con6.Close();


                                          ////////////////////////////////////////////////
                                          con6.Open();
                                          Chamber1 chamber1 = new Chamber1();

                                          string wafer7strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                              + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                          SqlCommand wafer2cmdparameter = new SqlCommand(wafer7strParameter, con6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                          wafer2cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                          wafer2cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                          wafer2cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                          wafer2cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                          wafer2cmdparameter.Parameters.AddWithValue("@21", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@23", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@28", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@31", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@33", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@38", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@41", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@43", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@48", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@71", strStepname1[a7]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@72", strStepname1[a7]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@73", strStepname1[a7]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@74", strStepname1[a7]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@75", strStepname1[a7]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@76", strStepname1[a7]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@77", strStepname1[a7]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@78", strStepname1[a7]);


                                          wafer2cmdparameter.ExecuteNonQuery();
                                          con6.Close();








                                      }


                                      strStepname1.Clear();
                                      ListStepStartTime.Clear();
                                      ListStepEndTime.Clear();

                                      /////////////////////////////////////////////////////////////////

                                      await Task.Delay(2000);

                                      label2.BackColor = Color.Blue;
                                      lblProcess.BackColor = Color.Blue;
                                      lblProcessStep.BackColor = Color.Blue;
                                      lblRecipe.BackColor = Color.Blue;
                                      lblStepName.BackColor = Color.Blue;
                                      lblData.BackColor = Color.Blue;
                                      lblnum.BackColor = Color.Blue;

                                      lblProcess.Text = "Aborted";
                                      lblProcessStep.Text = "";
                                      lblRecipe.Text = "";
                                      lblStepName.Text = "";
                                      lblnum.Text = "";
                                      lblData.Text = "???????????";



                                      picChamber.Image = Properties.Resources.new_chamber1;
                                      lblChamber.BackColor = Color.Blue;
                                      chamberload = "Blue";
                                      picChamber.Width -= 100;
                                      picChamber.Left += 150;
                                      await Task.Delay(2000);
                                      picChamber.Image = Properties.Resources.new_chamber;





                                      await Task.Delay(2000);



                                      await Task.Delay(2000);

                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette1;
                                      await Task.Delay(2000);

                                      lblCassette.BackColor = Color.LimeGreen;

                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picCassette.Height += 150;
                                      picCassette.Top -= 150;
                                      await Task.Delay(2000);
                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette1;
                                      picCassette.Height -= 150;
                                      picCassette.Top += 150;
                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      picwafer.Image = Properties.Resources.waferfull;

                                      //////////////////////////////////////////////////////////////////Save DataLog
                                      EndTime = DateTime.Now;
                                      con6.Close();
                                      if (int.Parse(NoOfwafer[i]) == 7)
                                      {
                                          con6.Open();

                                          string wafer2strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                          SqlCommand wafer2cmdinsertdatalog = new SqlCommand(wafer2strinsertdatalog, con6);

                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                          wafer2cmdinsertdatalog.ExecuteNonQuery();

                                          con6.Close();


                                      }




                                      //////////////////////////////////////////////////////////////////////////finish waferA7


                                  }
                                  if (int.Parse(NoOfwafer[i]) >= 8)
                                  {

                                      //////////////////////////////////////////////////////////////////////////start waferA8
                                      await Task.Delay(2000);

                                      picCassette.Image = Properties.Resources.cassette1;
                                      await Task.Delay(2000);
                                      Wafer8StartTime = DateTime.Now;
                                      scsb = new SqlConnectionStringBuilder();
                                      scsb.DataSource = @"HP-PC\SQLEXPRESS";
                                      scsb.InitialCatalog = "RecipeType";
                                      scsb.IntegratedSecurity = true;
                                      SqlConnection con7 = new SqlConnection(scsb.ToString());
                                      con7.Open();

                                      string wafer8strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName) values(@NoOfWafer,@StartTime,@CassetteRecipeName)";
                                      SqlCommand wafer8cmdwaferselection = new SqlCommand(wafer8strWaferSelection, con7);
                                      wafer8cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "8");
                                      wafer8cmdwaferselection.Parameters.AddWithValue("@StartTime", Wafer8StartTime);
                                      wafer8cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                      wafer8cmdwaferselection.ExecuteNonQuery();

                                      con7.Close();




                                      // lblCassette.BackColor = Color.LimeGreen;

                                      lblCassette.BackColor = Color.LimeGreen;
                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picCassette.Height += 150;
                                      picCassette.Top -= 150;
                                      await Task.Delay(2000);
                                      picwafer.Image = Properties.Resources.waferA8;
                                      await Task.Delay(2000);
                                      // WaferTime = DateTime.Now;
                                      lblCassette.BackColor = Color.Blue;


                                      picCassette.Image = Properties.Resources.cassette1;
                                      picCassette.Height -= 150;
                                      picCassette.Top += 150;
                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      await Task.Delay(2000);

                                      await Task.Delay(2000);


                                      lblCentralize.BackColor = Color.LimeGreen;

                                      await Task.Delay(2000);


                                      lblCentralize.BackColor = Color.Blue;

                                      //picCentralize.Height -= 100;

                                      await Task.Delay(2000);

                                      await Task.Delay(2000);

                                      picChamber.Image = Properties.Resources.new_chamber1;

                                      await Task.Delay(2000);


                                      picChamber.Image = Properties.Resources.robot_into_chamberA8;
                                      picChamber.Width += 100;
                                      picChamber.Left -= 150;
                                      lblChamber.BackColor = Color.LimeGreen;

                                      chamberload = "LimeGreen";
                                      //////////////////////////////////////////////////////////////////////////////////wafer2 into chamber
                                      WaferTime = DateTime.Now;
                                      lblRecipe.BackColor = Color.LimeGreen;
                                      lblStepName.BackColor = Color.LimeGreen;
                                      lblnum.BackColor = Color.LimeGreen;
                                      lblData.BackColor = Color.LimeGreen;
                                      lblData.Text = "";
                                      label2.BackColor = Color.LimeGreen;
                                      lblProcess.Text = "Processing";
                                      lblProcess.BackColor = Color.LimeGreen;
                                      lblProcessStep.Text = "Process Step";
                                      lblProcessStep.BackColor = Color.LimeGreen;

                                      con7.Open();
                                      string wafer8strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                      SqlCommand wafer8cmd = new SqlCommand(wafer8strSQL, con7);
                                      wafer8cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                      SqlDataReader wafer8reader = wafer8cmd.ExecuteReader();
                                      while (wafer8reader.Read())
                                      {

                                          lblRecipe.Text = string.Format("{0}", wafer8reader["WaferRecipe"]);



                                      }

                                      con7.Close();
                                      con7.Open();
                                      string wafer8strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                      SqlCommand wafer8cmd1 = new SqlCommand(wafer8strSQL1, con7);
                                      wafer8cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                      SqlDataReader wafer8reader1 = wafer8cmd1.ExecuteReader();
                                      while (wafer8reader1.Read())
                                      {

                                          strStepname1.Add(string.Format("{0}", wafer8reader1["StepName"]));


                                      }

                                      con7.Close();
                                      con7.Open();
                                      string wafer8strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                      SqlCommand wafer8cmd2 = new SqlCommand(wafer8strSQL2, con7);
                                      wafer8cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                      //SqlDataReader reader2 = cmd2.ExecuteReader();
                                      wafer8cmd2.ExecuteNonQuery();

                                      // while (reader2.Read())
                                      // {
                                      //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                                      // int row = strStepname.Count();
                                      for (int a8 = 0; a8 < strStepname1.Count(); a8 += 1)
                                      {
                                          await Task.Delay(1000);
                                          ListStepStartTime.Add(DateTime.Now);
                                          int count = i + a8;
                                          // await Task.Delay(2000);
                                          lblStepName.Text = strStepname1[a8];
                                          lblnum.Text = "," + count + "/" + strStepname1.Count();
                                          // lblnum.Text = "," + count + "/" + strStepname.Count();
                                          //  await Task.Delay(2000);

                                          con7.Close();

                                          con7.Open();
                                          string wafer8strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                          SqlCommand wafer8cmdSec = new SqlCommand(wafer8strSQLStepSec, con7);
                                          wafer8cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                          SqlDataReader wafer8readerSec = wafer8cmdSec.ExecuteReader();


                                          while (wafer8readerSec.Read())
                                          {
                                              mySec1 = wafer8readerSec["ProcessTime"].ToString();
                                              // lblSec.Text = string.Format("{0}", readerSec["ProcessPressure"]);
                                              Int32.TryParse(mySec1, out Sec1);

                                          }

                                          for (int j = 1; j <= Sec1; j++)
                                          {
                                              lblData.Text = j.ToString() + "/" + mySec1.ToString() + " Sec";
                                              await Task.Delay(1000);


                                          }
                                          ListStepEndTime.Add(DateTime.Now);

                                          con7.Close();


                                          con7.Open();

                                          string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe)";

                                          SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con7);

                                          cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                          cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[a8]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[a8]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[a8]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "8");

                                          cmdmodulerecipe.ExecuteNonQuery();

                                          con7.Close();
                                          ///////////////////////////////////////////////////////get parameter value

                                          con7.Open();

                                          string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                          SqlCommand cmd3 = new SqlCommand(strSQL3, con7);
                                          cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                          cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          SqlDataReader reader2 = cmd3.ExecuteReader();

                                          while (reader2.Read())
                                          {
                                              CI2 = reader2["CI2"].ToString();
                                              BCI3 = reader2["BCI3"].ToString();
                                              SF6 = reader2["SF6"].ToString();
                                              CHF3 = reader2["CHF3"].ToString();
                                              Oxygen = reader2["Oxygen"].ToString();
                                              Oxygen1 = reader2["Oxygen1"].ToString();
                                              Nitrogen = reader2["Nitrogen"].ToString();
                                              Argon = reader2["Argon"].ToString();



                                          }

                                          con7.Close();


                                          ////////////////////////////////////////////////
                                          con7.Open();
                                          Chamber1 chamber1 = new Chamber1();

                                          string wafer8strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                              + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                          SqlCommand wafer2cmdparameter = new SqlCommand(wafer8strParameter, con7);
                                          wafer2cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                          wafer2cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                          wafer2cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                          wafer2cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                          wafer2cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                          wafer2cmdparameter.Parameters.AddWithValue("@21", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@23", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@28", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@31", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@33", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@38", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@41", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@43", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@48", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@71", strStepname1[a8]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@72", strStepname1[a8]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@73", strStepname1[a8]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@74", strStepname1[a8]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@75", strStepname1[a8]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@76", strStepname1[a8]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@77", strStepname1[a8]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@78", strStepname1[a8]);


                                          wafer2cmdparameter.ExecuteNonQuery();
                                          con7.Close();








                                      }


                                      strStepname1.Clear();
                                      ListStepStartTime.Clear();
                                      ListStepEndTime.Clear();

                                      /////////////////////////////////////////////////////////////////

                                      await Task.Delay(2000);

                                      label2.BackColor = Color.Blue;
                                      lblProcess.BackColor = Color.Blue;
                                      lblProcessStep.BackColor = Color.Blue;
                                      lblRecipe.BackColor = Color.Blue;
                                      lblStepName.BackColor = Color.Blue;
                                      lblData.BackColor = Color.Blue;
                                      lblnum.BackColor = Color.Blue;

                                      lblProcess.Text = "Aborted";
                                      lblProcessStep.Text = "";
                                      lblRecipe.Text = "";
                                      lblStepName.Text = "";
                                      lblnum.Text = "";
                                      lblData.Text = "???????????";


                                      picChamber.Image = Properties.Resources.new_chamber1;
                                      lblChamber.BackColor = Color.Blue;
                                      chamberload = "Blue";
                                      picChamber.Width -= 100;
                                      picChamber.Left += 150;
                                      await Task.Delay(2000);
                                      picChamber.Image = Properties.Resources.new_chamber;





                                      await Task.Delay(2000);

                                      await Task.Delay(2000);

                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette1;
                                      await Task.Delay(2000);

                                      lblCassette.BackColor = Color.LimeGreen;

                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picCassette.Height += 150;
                                      picCassette.Top -= 150;
                                      await Task.Delay(2000);
                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette1;
                                      picCassette.Height -= 150;
                                      picCassette.Top += 150;
                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      picwafer.Image = Properties.Resources.waferfull;

                                      //////////////////////////////////////////////////////////////////Save DataLog
                                      EndTime = DateTime.Now;
                                      con7.Close();
                                      if (int.Parse(NoOfwafer[i]) == 8)
                                      {
                                          con7.Open();

                                          string wafer2strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                          SqlCommand wafer2cmdinsertdatalog = new SqlCommand(wafer2strinsertdatalog, con7);

                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                          wafer2cmdinsertdatalog.ExecuteNonQuery();

                                          con7.Close();



                                      }



                                      //////////////////////////////////////////////////////////////////////////finish waferA8

                                  }
                                  if (int.Parse(NoOfwafer[i]) >= 9)
                                  {

                                      //////////////////////////////////////////////////////////////////////////start waferA9
                                      await Task.Delay(2000);

                                      picCassette.Image = Properties.Resources.cassette1;
                                      await Task.Delay(2000);
                                      Wafer9StartTime = DateTime.Now;
                                      scsb = new SqlConnectionStringBuilder();
                                      scsb.DataSource = @"HP-PC\SQLEXPRESS";
                                      scsb.InitialCatalog = "RecipeType";
                                      scsb.IntegratedSecurity = true;
                                      SqlConnection con8 = new SqlConnection(scsb.ToString());
                                      con8.Open();

                                      string wafer9strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName) values(@NoOfWafer,@StartTime,@CassetteRecipeName)";
                                      SqlCommand wafer9cmdwaferselection = new SqlCommand(wafer9strWaferSelection, con8);
                                      wafer9cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "9");
                                      wafer9cmdwaferselection.Parameters.AddWithValue("@StartTime", Wafer9StartTime);
                                      wafer9cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                      wafer9cmdwaferselection.ExecuteNonQuery();

                                      con8.Close();




                                      // lblCassette.BackColor = Color.LimeGreen;

                                      lblCassette.BackColor = Color.LimeGreen;
                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picCassette.Height += 150;
                                      picCassette.Top -= 150;
                                      await Task.Delay(2000);
                                      picwafer.Image = Properties.Resources.waferA9;
                                      await Task.Delay(2000);
                                      // WaferTime = DateTime.Now;
                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette1;
                                      picCassette.Height -= 150;
                                      picCassette.Top += 150;
                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      await Task.Delay(2000);

                                      await Task.Delay(2000);

                                      await Task.Delay(2000);

                                      lblCentralize.BackColor = Color.LimeGreen;


                                      //picCentralize.Height -= 100;


                                      await Task.Delay(2000);

                                      picChamber.Image = Properties.Resources.new_chamber1;

                                      await Task.Delay(2000);


                                      picChamber.Image = Properties.Resources.robot_into_chamberA9;
                                      picChamber.Width += 100;
                                      picChamber.Left -= 150;
                                      lblChamber.BackColor = Color.LimeGreen;

                                      chamberload = "LimeGreen";
                                      //////////////////////////////////////////////////////////////////////////////////waferA9 into chamber
                                      WaferTime = DateTime.Now;
                                      lblRecipe.BackColor = Color.LimeGreen;
                                      lblStepName.BackColor = Color.LimeGreen;
                                      lblnum.BackColor = Color.LimeGreen;
                                      lblData.BackColor = Color.LimeGreen;
                                      lblData.Text = "";
                                      label2.BackColor = Color.LimeGreen;
                                      lblProcess.Text = "Processing";
                                      lblProcess.BackColor = Color.LimeGreen;
                                      lblProcessStep.Text = "Process Step";
                                      lblProcessStep.BackColor = Color.LimeGreen;

                                      con8.Open();
                                      string wafer9strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                      SqlCommand wafer9cmd = new SqlCommand(wafer9strSQL, con8);
                                      wafer9cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                      SqlDataReader wafer9reader = wafer9cmd.ExecuteReader();
                                      while (wafer9reader.Read())
                                      {

                                          lblRecipe.Text = string.Format("{0}", wafer9reader["WaferRecipe"]);



                                      }

                                      con8.Close();
                                      con8.Open();
                                      string wafer9strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                      SqlCommand wafer9cmd1 = new SqlCommand(wafer9strSQL1, con8);
                                      wafer9cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                      SqlDataReader wafer9reader1 = wafer9cmd1.ExecuteReader();
                                      while (wafer9reader1.Read())
                                      {

                                          strStepname1.Add(string.Format("{0}", wafer9reader1["StepName"]));


                                      }

                                      con8.Close();
                                      con8.Open();
                                      string wafer9strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                      SqlCommand wafer9cmd2 = new SqlCommand(wafer9strSQL2, con8);
                                      wafer9cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                      //SqlDataReader reader2 = cmd2.ExecuteReader();
                                      wafer9cmd2.ExecuteNonQuery();

                                      // while (reader2.Read())
                                      // {
                                      //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                                      // int row = strStepname.Count();
                                      for (int a9 = 0; a9 < strStepname1.Count(); a9 += 1)
                                      {
                                          await Task.Delay(1000);
                                          ListStepStartTime.Add(DateTime.Now);
                                          int count = a9 + 1;
                                          // await Task.Delay(2000);
                                          lblStepName.Text = strStepname1[a9];
                                          lblnum.Text = "," + count + "/" + strStepname1.Count();
                                          // lblnum.Text = "," + count + "/" + strStepname.Count();
                                          //  await Task.Delay(2000);

                                          con8.Close();

                                          con8.Open();
                                          string wafer9strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                          SqlCommand wafer9cmdSec = new SqlCommand(wafer9strSQLStepSec, con8);
                                          wafer9cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                          SqlDataReader wafer9readerSec = wafer9cmdSec.ExecuteReader();


                                          while (wafer9readerSec.Read())
                                          {
                                              mySec1 = wafer9readerSec["ProcessTime"].ToString();
                                              // lblSec.Text = string.Format("{0}", readerSec["ProcessPressure"]);
                                              Int32.TryParse(mySec1, out Sec1);

                                          }

                                          for (int j = 1; j <= Sec1; j++)
                                          {
                                              lblData.Text = j.ToString() + "/" + mySec1.ToString() + " Sec";
                                              await Task.Delay(1000);


                                          }
                                          ListStepEndTime.Add(DateTime.Now);

                                          con8.Close();


                                          con8.Open();

                                          string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe)";

                                          SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con8);

                                          cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                          cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[a9]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[a9]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[a9]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "9");

                                          cmdmodulerecipe.ExecuteNonQuery();

                                          con8.Close();
                                          ///////////////////////////////////////////////////////get parameter value

                                          con8.Open();

                                          string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                          SqlCommand cmd3 = new SqlCommand(strSQL3, con8);
                                          cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                          cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          SqlDataReader reader2 = cmd3.ExecuteReader();

                                          while (reader2.Read())
                                          {
                                              CI2 = reader2["CI2"].ToString();
                                              BCI3 = reader2["BCI3"].ToString();
                                              SF6 = reader2["SF6"].ToString();
                                              CHF3 = reader2["CHF3"].ToString();
                                              Oxygen = reader2["Oxygen"].ToString();
                                              Oxygen1 = reader2["Oxygen1"].ToString();
                                              Nitrogen = reader2["Nitrogen"].ToString();
                                              Argon = reader2["Argon"].ToString();



                                          }

                                          con8.Close();


                                          ////////////////////////////////////////////////
                                          con8.Open();
                                          Chamber1 chamber1 = new Chamber1();

                                          string wafer9strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                              + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                          SqlCommand wafer2cmdparameter = new SqlCommand(wafer9strParameter, con8);
                                          wafer2cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                          wafer2cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                          wafer2cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                          wafer2cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                          wafer2cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                          wafer2cmdparameter.Parameters.AddWithValue("@21", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@23", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@28", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@31", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@33", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@38", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@41", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@43", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@48", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@71", strStepname1[a9]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@72", strStepname1[a9]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@73", strStepname1[a9]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@74", strStepname1[a9]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@75", strStepname1[a9]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@76", strStepname1[a9]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@77", strStepname1[a9]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@78", strStepname1[a9]);


                                          wafer2cmdparameter.ExecuteNonQuery();
                                          con8.Close();








                                      }


                                      strStepname1.Clear();
                                      ListStepStartTime.Clear();
                                      ListStepEndTime.Clear();

                                      /////////////////////////////////////////////////////////////////

                                      await Task.Delay(2000);

                                      label2.BackColor = Color.Blue;
                                      lblProcess.BackColor = Color.Blue;
                                      lblProcessStep.BackColor = Color.Blue;
                                      lblRecipe.BackColor = Color.Blue;
                                      lblStepName.BackColor = Color.Blue;
                                      lblData.BackColor = Color.Blue;
                                      lblnum.BackColor = Color.Blue;

                                      lblProcess.Text = "Aborted";
                                      lblProcessStep.Text = "";
                                      lblRecipe.Text = "";
                                      lblStepName.Text = "";
                                      lblnum.Text = "";
                                      lblData.Text = "???????????";



                                      picChamber.Image = Properties.Resources.new_chamber1;
                                      lblChamber.BackColor = Color.Blue;
                                      chamberload = "Blue";
                                      picChamber.Width -= 100;
                                      picChamber.Left += 150;
                                      await Task.Delay(2000);
                                      picChamber.Image = Properties.Resources.new_chamber;





                                      await Task.Delay(2000);


                                      await Task.Delay(2000);

                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette1;
                                      await Task.Delay(2000);

                                      lblCassette.BackColor = Color.LimeGreen;

                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picCassette.Height += 150;
                                      picCassette.Top -= 150;
                                      await Task.Delay(2000);
                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette1;
                                      picCassette.Height -= 150;
                                      picCassette.Top += 150;
                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      picwafer.Image = Properties.Resources.waferfull;

                                      //////////////////////////////////////////////////////////////////Save DataLog
                                      EndTime = DateTime.Now;
                                      con8.Close();
                                      if (int.Parse(NoOfwafer[i]) == 9)
                                      {
                                          con8.Open();

                                          string wafer2strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                          SqlCommand wafer2cmdinsertdatalog = new SqlCommand(wafer2strinsertdatalog, con8);

                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                          wafer2cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                          wafer2cmdinsertdatalog.ExecuteNonQuery();

                                          con8.Close();

                                      }

                                      //////////////////////////////////////////////////////////////////////////finish waferA9

                                  }
                                  if (int.Parse(NoOfwafer[i]) >= 10)
                                  {

                                      //////////////////////////////////////////////////////////////////////////start waferA10


                                      await Task.Delay(2000);

                                      picCassette.Image = Properties.Resources.cassette1;
                                      await Task.Delay(2000);
                                      Wafer10StartTime = DateTime.Now;
                                      scsb = new SqlConnectionStringBuilder();
                                      scsb.DataSource = @"HP-PC\SQLEXPRESS";
                                      scsb.InitialCatalog = "RecipeType";
                                      scsb.IntegratedSecurity = true;
                                      SqlConnection con9 = new SqlConnection(scsb.ToString());
                                      con9.Open();

                                      string wafer10strWaferSelection = "insert into WaferSelection(NoOfWafers,StartTime,CassetteRecipeName) values(@NoOfWafer,@StartTime,@CassetteRecipeName)";
                                      SqlCommand wafer10cmdwaferselection = new SqlCommand(wafer10strWaferSelection, con9);
                                      wafer10cmdwaferselection.Parameters.AddWithValue("@NoOfWafer", "10");
                                      wafer10cmdwaferselection.Parameters.AddWithValue("@StartTime", Wafer10StartTime);
                                      wafer10cmdwaferselection.Parameters.AddWithValue("@CassetteRecipeName", form2Msg);
                                      wafer10cmdwaferselection.ExecuteNonQuery();

                                      con9.Close();




                                      // lblCassette.BackColor = Color.LimeGreen;

                                      lblCassette.BackColor = Color.LimeGreen;
                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picCassette.Height += 150;
                                      picCassette.Top -= 150;
                                      await Task.Delay(2000);
                                      picwafer.Image = Properties.Resources.waferA10;
                                      await Task.Delay(2000);
                                      // WaferTime = DateTime.Now;
                                      lblCassette.BackColor = Color.Blue;


                                      picCassette.Image = Properties.Resources.cassette1;
                                      picCassette.Height -= 150;
                                      picCassette.Top += 150;
                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      await Task.Delay(2000);


                                      await Task.Delay(2000);

                                      lblCentralize.BackColor = Color.LimeGreen;


                                      await Task.Delay(2000);

                                      lblCentralize.BackColor = Color.Blue;

                                      //picCentralize.Height -= 100;



                                      await Task.Delay(2000);

                                      picChamber.Image = Properties.Resources.new_chamber1;

                                      await Task.Delay(2000);

                                      picChamber.Image = Properties.Resources.robot_into_chamberA10;
                                      picChamber.Width += 100;
                                      picChamber.Left -= 150;
                                      lblChamber.BackColor = Color.LimeGreen;

                                      chamberload = "LimeGreen";
                                      //////////////////////////////////////////////////////////////////////////////////waferA10 into chamber
                                      WaferTime = DateTime.Now;
                                      lblRecipe.BackColor = Color.LimeGreen;
                                      lblStepName.BackColor = Color.LimeGreen;
                                      lblnum.BackColor = Color.LimeGreen;
                                      lblData.BackColor = Color.LimeGreen;
                                      lblData.Text = "";
                                      label2.BackColor = Color.LimeGreen;
                                      lblProcess.Text = "Processing";
                                      lblProcess.BackColor = Color.LimeGreen;
                                      lblProcessStep.Text = "Process Step";
                                      lblProcessStep.BackColor = Color.LimeGreen;

                                      con9.Open();
                                      string wafer10strSQL = "select WaferRecipe from CassetteWafer  where CassetterecipeName = @NewWaferRecipe";

                                      SqlCommand wafer10cmd = new SqlCommand(wafer10strSQL, con9);
                                      wafer10cmd.Parameters.AddWithValue("@NewWaferRecipe", Form1.form2Msg);
                                      SqlDataReader wafer10reader = wafer10cmd.ExecuteReader();
                                      while (wafer10reader.Read())
                                      {

                                          lblRecipe.Text = string.Format("{0}", wafer10reader["WaferRecipe"]);



                                      }

                                      con9.Close();
                                      con9.Open();
                                      string wafer10strSQL1 = "select stepname from newrecipe where recipename = @Myrecipename";

                                      SqlCommand wafer10cmd1 = new SqlCommand(wafer10strSQL1, con9);
                                      wafer10cmd1.Parameters.AddWithValue("@Myrecipename", lblRecipe.Text);
                                      SqlDataReader wafer10reader1 = wafer10cmd1.ExecuteReader();
                                      while (wafer10reader1.Read())
                                      {

                                          strStepname1.Add(string.Format("{0}", wafer10reader1["StepName"]));


                                      }

                                      con9.Close();
                                      con9.Open();
                                      string wafer10strSQL2 = "select StepName from newrecipe inner join CassetteWafer on newrecipe.recipename = cassettewafer.waferRecipe where cassettewafer.waferRecipe = @Newrecipename";
                                      SqlCommand wafer10cmd2 = new SqlCommand(wafer10strSQL2, con9);
                                      wafer10cmd2.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                      //SqlDataReader reader2 = cmd2.ExecuteReader();
                                      wafer10cmd2.ExecuteNonQuery();

                                      // while (reader2.Read())
                                      // {
                                      //strStepname.Add(string.Format("{0}", reader2["StepName"]));
                                      // int row = strStepname.Count();
                                      for (int a10 = 0; a10 < strStepname1.Count(); a10 += 1)
                                      {
                                          await Task.Delay(1000);
                                          ListStepStartTime.Add(DateTime.Now);
                                          int count = a10 + 1;
                                          // await Task.Delay(2000);
                                          lblStepName.Text = strStepname1[a10];
                                          lblnum.Text = "," + count + "/" + strStepname1.Count();
                                          // lblnum.Text = "," + count + "/" + strStepname.Count();
                                          //  await Task.Delay(2000);

                                          con9.Close();

                                          con9.Open();
                                          string wafer10strSQLStepSec = "select * from newrecipe where stepname = @NewSec";

                                          SqlCommand wafer10cmdSec = new SqlCommand(wafer10strSQLStepSec, con9);
                                          wafer10cmdSec.Parameters.AddWithValue("@NewSec", lblStepName.Text);

                                          SqlDataReader wafer10readerSec = wafer10cmdSec.ExecuteReader();


                                          while (wafer10readerSec.Read())
                                          {
                                              mySec1 = wafer10readerSec["ProcessTime"].ToString();
                                              // lblSec.Text = string.Format("{0}", readerSec["ProcessPressure"]);
                                              Int32.TryParse(mySec1, out Sec1);

                                          }

                                          for (int j = 1; j <= Sec1; j++)
                                          {
                                              lblData.Text = j.ToString() + "/" + mySec1.ToString() + " Sec";
                                              await Task.Delay(1000);


                                          }
                                          ListStepEndTime.Add(DateTime.Now);

                                          con9.Close();


                                          con9.Open();

                                          string strModuleRecipe = "insert into ModuleRecipe(RecipeName,StepName,StartTime,EndTime,noofrecipe) values(@recipename,@stepname,@starttime,@endtime,@noofrecipe)";

                                          SqlCommand cmdmodulerecipe = new SqlCommand(strModuleRecipe, con9);

                                          cmdmodulerecipe.Parameters.AddWithValue("@recipename", lblRecipe.Text);
                                          cmdmodulerecipe.Parameters.AddWithValue("@stepname", strStepname1[a10]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@starttime", ListStepStartTime[a10]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@endtime", ListStepEndTime[a10]);
                                          cmdmodulerecipe.Parameters.AddWithValue("@noofrecipe", "10");

                                          cmdmodulerecipe.ExecuteNonQuery();

                                          con9.Close();
                                          ///////////////////////////////////////////////////////get parameter value

                                          con9.Open();

                                          string strSQL3 = "select * from newrecipe where stepname = @Newstepname and recipename = @Newrecipename";

                                          SqlCommand cmd3 = new SqlCommand(strSQL3, con9);
                                          cmd3.Parameters.AddWithValue("@Newstepname", lblStepName.Text);
                                          cmd3.Parameters.AddWithValue("@Newrecipename", lblRecipe.Text);
                                          SqlDataReader reader2 = cmd3.ExecuteReader();

                                          while (reader2.Read())
                                          {
                                              CI2 = reader2["CI2"].ToString();
                                              BCI3 = reader2["BCI3"].ToString();
                                              SF6 = reader2["SF6"].ToString();
                                              CHF3 = reader2["CHF3"].ToString();
                                              Oxygen = reader2["Oxygen"].ToString();
                                              Oxygen1 = reader2["Oxygen1"].ToString();
                                              Nitrogen = reader2["Nitrogen"].ToString();
                                              Argon = reader2["Argon"].ToString();



                                          }

                                          con9.Close();


                                          ////////////////////////////////////////////////
                                          con9.Open();
                                          Chamber1 chamber1 = new Chamber1();

                                          string wafer10strParameter = "insert into valueselection(parameter,Minimum,Maximum,Average,Units,recipename,stepname) values(@11,@21,@31,@41,@51,@61,@71),(@12,@22,@32,@42,@52,@62,@72),(@13,@23,@33,@43,@53,@63,@73)"
                                              + ",(@14,@24,@34,@44,@54,@64,@74),(@15,@25,@35,@45,@55,@65,@75),(@16,@26,@36,@46,@56,@66,@76),(@17,@27,@37,@47,@57,@67,@77),(@18,@28,@38,@48,@58,@68,@78)";
                                          SqlCommand wafer2cmdparameter = new SqlCommand(wafer10strParameter, con9);
                                          wafer2cmdparameter.Parameters.AddWithValue("@11", "CI2");
                                          wafer2cmdparameter.Parameters.AddWithValue("@12", "BCI3");
                                          wafer2cmdparameter.Parameters.AddWithValue("@13", "SF6");
                                          wafer2cmdparameter.Parameters.AddWithValue("@14", "CHF3");
                                          wafer2cmdparameter.Parameters.AddWithValue("@15", "Oxygen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@16", "Oxygen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@17", "Nitrogen");
                                          wafer2cmdparameter.Parameters.AddWithValue("@18", "Argon");
                                          wafer2cmdparameter.Parameters.AddWithValue("@21", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@22", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@23", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@24", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@25", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@26", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@27", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@28", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@31", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@32", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@33", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@34", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@35", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@36", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@37", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@38", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@41", CI2);
                                          wafer2cmdparameter.Parameters.AddWithValue("@42", BCI3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@43", SF6);
                                          wafer2cmdparameter.Parameters.AddWithValue("@44", CHF3);
                                          wafer2cmdparameter.Parameters.AddWithValue("@45", Oxygen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@46", Oxygen1);
                                          wafer2cmdparameter.Parameters.AddWithValue("@47", Nitrogen);
                                          wafer2cmdparameter.Parameters.AddWithValue("@48", Argon);
                                          wafer2cmdparameter.Parameters.AddWithValue("@51", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@52", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@53", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@54", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@55", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@56", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@57", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@58", "sccm");
                                          wafer2cmdparameter.Parameters.AddWithValue("@61", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@62", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@63", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@64", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@65", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@66", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@67", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@68", lblRecipe.Text);
                                          wafer2cmdparameter.Parameters.AddWithValue("@71", strStepname1[a10]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@72", strStepname1[a10]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@73", strStepname1[a10]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@74", strStepname1[a10]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@75", strStepname1[a10]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@76", strStepname1[a10]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@77", strStepname1[a10]);
                                          wafer2cmdparameter.Parameters.AddWithValue("@78", strStepname1[a10]);


                                          wafer2cmdparameter.ExecuteNonQuery();
                                          con9.Close();








                                      }


                                      strStepname1.Clear();
                                      ListStepStartTime.Clear();
                                      ListStepEndTime.Clear();

                                      /////////////////////////////////////////////////////////////////

                                      await Task.Delay(2000);

                                      label2.BackColor = Color.Blue;
                                      lblProcess.BackColor = Color.Blue;
                                      lblProcessStep.BackColor = Color.Blue;
                                      lblRecipe.BackColor = Color.Blue;
                                      lblStepName.BackColor = Color.Blue;
                                      lblData.BackColor = Color.Blue;
                                      lblnum.BackColor = Color.Blue;

                                      lblProcess.Text = "Aborted";
                                      lblProcessStep.Text = "";
                                      lblRecipe.Text = "";
                                      lblStepName.Text = "";
                                      lblnum.Text = "";
                                      lblData.Text = "???????????";



                                      picChamber.Image = Properties.Resources.new_chamber1;
                                      lblChamber.BackColor = Color.Blue;
                                      chamberload = "Blue";
                                      picChamber.Width -= 100;
                                      picChamber.Left += 150;
                                      await Task.Delay(2000);
                                      picChamber.Image = Properties.Resources.new_chamber;





                                      await Task.Delay(2000);

                                      await Task.Delay(2000);

                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette1;
                                      await Task.Delay(2000);

                                      lblCassette.BackColor = Color.LimeGreen;

                                      picCassette.Image = Properties.Resources.robot_into_cassetteA1;
                                      picCassette.Height += 150;
                                      picCassette.Top -= 150;
                                      await Task.Delay(2000);
                                      lblCassette.BackColor = Color.Blue;

                                      picCassette.Image = Properties.Resources.cassette1;
                                      picCassette.Height -= 150;
                                      picCassette.Top += 150;
                                      await Task.Delay(2000);
                                      picCassette.Image = Properties.Resources.cassette;
                                      picwafer.Image = Properties.Resources.waferfull;

                                      //////////////////////////////////////////////////////////////////Save DataLog
                                      if (int.Parse(NoOfwafer[i]) == 10)
                                      {
                                          EndTime = DateTime.Now;
                                          con9.Close();

                                          con9.Open();

                                          string wafer10strinsertdatalog = "insert into DataLogger(logname,cassetterecipename,starttime) values(@1,@2,@3) ";
                                          SqlCommand wafer10cmdinsertdatalog = new SqlCommand(wafer10strinsertdatalog, con9);

                                          wafer10cmdinsertdatalog.Parameters.AddWithValue("@1", lbl123.Text);
                                          wafer10cmdinsertdatalog.Parameters.AddWithValue("@2", form2Msg);
                                          wafer10cmdinsertdatalog.Parameters.AddWithValue("@3", StartTime);

                                          wafer10cmdinsertdatalog.ExecuteNonQuery();

                                          con9.Close();
                                      }
                                      //////////////////////////////////////////////////////////////////////////finish waferA10




                                  }






                              }











                              ////////////////////////////////////////////////////////////////////////////////////////////////////start WaferA1

                              ////////////////////////////////////////////////////////////////////////////////////////////////finish waferA1
                              /////////////////////////////////////////////////////////////////////////////////////////////////start waferA2


                              //////////////////////////////////////////////////////////////////////////////A2 finish

                              //////////////////////////////////////////////////////////////////////////////start A3


                              /////////////////////////////////////////////////////////////////////////////////////////waferA3 finish 

                              ////////////////////////////////////////////////////////////////////////////////////////start waferA4








                              ///////////////////////////////////////////////////////////////////////////////////////////waferA4 finish

                              ////////////////////////////////////////////////////////////////////////////////////////////////start waferA5




                              ///////////////////////////////////////////////////////////////////////////////////////////////////////waferA5 finish

                              ////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA6





                              //////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA6 finish

                              //////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA7







                              ///////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA7 finisg

                              ///////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA8












                              ///////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA8 finish

                              ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA9






                              ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA9 finish


                              ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////start waferA10





                              ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////waferA10 finish
                              */
                            
                        }
                    }
                }

                else
                {

                    MessageBox.Show("APM and TM are not idle");
                }


            }
            else
            {
                MessageBox.Show("Transport not in Automatic");

            }


        }





        private void button3_Click(object sender, EventArgs e)
        {
            // pauseSignal = new ManualResetEvent(true);
            //pauseSignal.Reset();
            // manu.Set();
            //////////////////////////////////////////////////////////
            /*     button4.Enabled = true;
                 button3.Enabled = false;
                 stopandstart1.start();*/
            //  t.Resume();
            //      manu.Set();
            // pauseSignal.Set();
            // myResetEvent.Set();

            /*   FlagStop = !FlagStop;
               if (FlagStop == true)

               {

                   MTestTdEvent.Reset();

               }

               else

               {

                   MTestTdEvent.Set();

               }*/

            //  taskwait = false;
            // pauseSignal.Set();
            // MessageBox.Show("7777");
            // ispauserobot = false;
            //  button2_Click(sender, e);
            // restartrobot();


            /*    while (picMain.Image.Tag.ToString() != "finishWaferA1")
                {

                    stoptherobot();
                    if (picMain.Image.Tag.ToString() == "finishWaferA1")
                    {
                        break;
                    }

                }*/
            PauseAndStopRobot stoprobot = new PauseAndStopRobot();
            stoprobot.label1.Text = "Do you want to stop this recipe?";
            DialogResult dr = stoprobot.ShowDialog();

            if (dr == DialogResult.OK)
            {

                isStopRobot = true;

                //  button2.Enabled = true;
                button2.Tag = "robotRestart";

                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;

            }
        }

        private void stoptherobot()
        {

          


            if (picMain.Image.Tag.ToString() == "finishWaferA1" || picMain.Image.Tag.ToString() == "finishWaferA2" || picMain.Image.Tag.ToString() == "finishWaferA3" || picMain.Image.Tag.ToString() == "finishwaferA4")
            {
                ispauserobot = true;
                

            }


        }

        /*public async void 暫停() {



        }*/

        private void button1_Click(object sender, EventArgs e)
        {


            Form2 form2 = new Form2();
            DialogResult dr = form2.ShowDialog();
            if (dr == DialogResult.OK)
            {

                form2Msg = form2.GetMsg();
                button2.Enabled = true;

                lblLoad.Text = "Selected recipe:" + form2Msg;


            }



        }

        private void button7_Click(object sender, EventArgs e)
        {
            //tabControl1.Visible = false;



        }

        private void button8_Click(object sender, EventArgs e)
        {
            // tabControl1.Visible = false;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //tabControl1.Visible = false;
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {

            RecipeType rt = new RecipeType();
            rt.ShowDialog();
            rt.Dispose();



        }

        private void btni2L_Click(object sender, EventArgs e)
        {
            i2L019 i2L019 = new i2L019();
            i2L019.ShowDialog();




        }

        private void button9_Click_1(object sender, EventArgs e)
        {

            cassette cassette = new cassette();
            cassette.Show();




        }

        private void button10_Click(object sender, EventArgs e)
        {
            Chamber1 chamber1 = new Chamber1();
            chamber1.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Centralize centralize = new Centralize();
            centralize.ShowDialog();

        }

        private void btnVCH_Click(object sender, EventArgs e)
        {


            StateControlOfVCH VCH = new StateControlOfVCH();

            VCH.form1 = this;


            DialogResult dr = VCH.ShowDialog();











        }

        private void btnLog_Click(object sender, EventArgs e)
        {

            DataLogger datalogger = new DataLogger();
            datalogger.ShowDialog();




        }

        class stopandstart
        {
            private bool stopornot = false;

            public void stop()
            {
                stopornot = true;
                while (stopornot)
                {


                    System.Threading.Thread.Sleep(100);
                    // Application.DoEvents();
                }

            }
            public void start()
            {
                stopornot = false;

            }

        }
        stopandstart stopandstart1 = new stopandstart();


        private  void button4_Click(object sender, EventArgs e)
        {
            //manu = new ManualResetEvent(false);
            //manu.WaitOne();
            //   manu.Reset();
            //  manu1 = new AutoResetEvent(false);
            //  manu1.WaitOne();
            // manu.Reset();
            // await Task.Delay();

            // manu.WaitOne();
            // manu.Reset();
            //////////////////////////////////////////////////////////////////////////////////////
            /* button4.Enabled = false;
             button3.Enabled = true;
             stopandstart1.stop();*/
            /////////////////////////////////////////////////////////////////////////////////////

            //  Application.DoEvents();


            /*       picMain.Image = Properties.Resources.mainpicture;
                ispauserobot = true;
                picMain.Image.Tag = "mainpicture";*/


            PauseAndStopRobot cancelrecipe = new PauseAndStopRobot();
            cancelrecipe.label1.Text = "Do you want to cancel this recipe?";
            DialogResult dr = cancelrecipe.ShowDialog();
            if (dr == DialogResult.OK)
            {
                iscancelrecipe = true;

            }


        }

        private void OvalShapeVisible(bool visible)
        {
            if (visible == true)
            {
                ovalShape1.Visible = true;
            }
            if (visible == false)
            {
                ovalShape1.Visible = false;
            }
        }


        private void btnRobotAction_Click(object sender, EventArgs e)
        {

            ActionArm actionArm = new ActionArm();
            actionArm.form1 = this;
            actionArm.ShowDialog();

            Rotate rotate = new Rotate();
            rotate.myform1 = this;
        }

        private void button11_Click(object sender, EventArgs e)
        {

            btnRobotAction.Visible = false;

            btnChamberValve.Visible = false;



        }

        private void btnChamberValve_Click(object sender, EventArgs e)
        {
            SlotValve slotValve = new SlotValve();
            slotValve.form1 = this;
            slotValve.ShowDialog();




        }

        private void btnCassetteControl_Click(object sender, EventArgs e)
        {
            if (picMain.Image.Tag.ToString() == "picrobotintocassette")


            {

                Wafer_Transfer_and_Flag_Operation wafer = new Wafer_Transfer_and_Flag_Operation();
                wafer.form1 = this;
                wafer.ShowDialog();

            }

            else
            {

                cassettemap cassettemap = new cassettemap();
                cassettemap.form1 = this;
                cassettemap.ShowDialog();


            }

        }

        private  void button5_Click(object sender, EventArgs e)
        {
            //  await Task.Delay(7000);
            //  t.Suspend();
            //   pauseSignal.Reset();
            //manu.WaitOne();
            //manu.Set();

            //  myResetEvent.WaitOne();
            //  MessageBox.Show("123");
            //  Monitor.Wait();


            //   MTestTdEvent.WaitOne();
            // MTestTdEvent.Reset();
            //  MTestTdEvent.Set();


            //  delayTask.Wait();
            // taskwait = true;





            /*
            if (button5.Image.Tag.ToString() == "Pause")
            {
                taskTimer = new Task(Tasktest);
                taskTimer.Start();

                pauseSignal.WaitOne();
                pauseSignal.Reset();

               

                button5.Image = Properties.Resources.play;
                button5.Image.Tag = "Play";
            }
            else
            {
                pauseSignal.Set();
                button5.Image = Properties.Resources.pause2;

                button5.Image.Tag = "Pause";

            }
            */
            PauseAndStopRobot pauserobot = new PauseAndStopRobot();
            pauserobot.label1.Text = "Do you want to pause this recipe?";

            DialogResult dr = pauserobot.ShowDialog();

            if (dr == DialogResult.OK)
            {

                scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = datasource;
                scsb.InitialCatalog = "RecipeType";
                scsb.IntegratedSecurity = true;
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();

                SqlCommand cmdeventlog = new SqlCommand(strEvent, con);

                cmdeventlog.Parameters.AddWithValue("@1", DateTime.Now);
                cmdeventlog.Parameters.AddWithValue("@2", "Machine robot stoped");
                cmdeventlog.Parameters.AddWithValue("@3", "Pause the robot");

                cmdeventlog.ExecuteNonQuery();

                con.Close();

                ispauserobot = true;

                button2.Enabled = true;
                button2.Tag = "robotPause";

                //pauseSignal.WaitOne();
            }
        }

        private void Tasktest()
        {
            //   MessageBox.Show("Test");
            // NewRecipe test = new NewRecipe();
            // test.ShowDialog();

            PauseTest pausetest = new PauseTest();
            pausetest.form1 = this;
            pausetest.ShowDialog();
         //   button5.Enabled = true;
        }


        private static void threadwait()
        {
            myResetEvent.WaitOne();

            MessageBox.Show("123");
        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnEventLog_Click(object sender, EventArgs e)
        {

            EventLog eventLog = new EventLog();
            eventLog.ShowDialog();




        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (btnLogIn.Tag.ToString() == "LogIn")
            {
                LogIn logIn = new LogIn();

                logIn.form1 = this;
                logIn.ShowDialog();
            }
            else if (btnLogIn.Tag.ToString() == "LogOut")
            {
                LogOut logOut = new LogOut();
                logOut.form1 = this;
                logOut.ShowDialog();

            }
        }

        private void btnCentralizeControl_Click(object sender, EventArgs e)
        {

        }

        private void picSV_Click(object sender, EventArgs e)
        {
            SlotValve slotValve = new SlotValve();
            slotValve.form1 = this;
            slotValve.ShowDialog();
        }

        private void btnrobot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("123");


        }

        private void picrobot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("123");
        }

        private void panelrobot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("123");
        }

        private void btnAPM_Click(object sender, EventArgs e)
        {

            APM apm = new APM();
            apm.form1 = this;
            apm.ShowDialog();


        }

        private void btntm_Click(object sender, EventArgs e)
        {
            TM tm = new TM();
            tm.form1 = this;
            tm.ShowDialog();


        }

        private void btnendeffector_Click(object sender, EventArgs e)
        {
            endeffector endeffector = new endeffector();
            //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
            endeffector.form1 = this;
            endeffector.ShowDialog();
            //  MessageBox.Show(endeffector.str);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void lblwafer_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("");

            endeffector endeffector = new endeffector();
            //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
            endeffector.form1 = this;
            endeffector.ShowDialog();
            //  MessageBox.Show(endeffector.str);



        }

        private void lblwaferAPM_Click(object sender, EventArgs e)
        {
            endeffector endeffector = new endeffector();
            //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
            endeffector.form1 = this;
            endeffector.ShowDialog();
            //  MessageBox.Show(endeffector.str);
        }

        private void picendeffector_Click(object sender, EventArgs e)
        {

            endeffector endeffector = new endeffector();
            //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
            endeffector.form1 = this;
            endeffector.ShowDialog();
            //  MessageBox.Show(endeffector.str);

        }

        private void btnChamberControl_Click(object sender, EventArgs e)
        {

        }

        private void picMain_Click(object sender, EventArgs e)
        {
            /* int x = Control.MousePosition.X;
             int y = Control.MousePosition.Y;



             if (x >= 736 && x <= 766 && y >= 561 && y <= 591)
             {
                 endeffector endeffector = new endeffector();
                 //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
                 endeffector.form1 = this;
                 endeffector.ShowDialog();
                 //  MessageBox.Show(endeffector.str);



             }*/




        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            /* x = e.Location.X;
              y = e.Location.Y;
              this.Invalidate();*/

            //  Point mousePoint = new Point(e.X, e.Y);


        }

        private void picMain_MouseMove(object sender, MouseEventArgs e)
        {
            /*  x = e.Location.X;
              y = e.Location.Y;
              this.Invalidate();*/
            x = e.X;
            y = e.Y;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (x >= 736 && x <= 766 && y >= 561 && y <= 591)
            {
                endeffector endeffector = new endeffector();
                //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
                endeffector.form1 = this;
                endeffector.ShowDialog();
                //  MessageBox.Show(endeffector.str);



            }

        }

        private void button6_Click_2(object sender, EventArgs e)
        {

        }

        private void picMain_MouseClick(object sender, MouseEventArgs e)
        {
            /* if (e.X > 736 && e.Y > 561)
             {
                 endeffector endeffector = new endeffector();
                 //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
                 endeffector.form1 = this;
                 endeffector.ShowDialog();
                 //  MessageBox.Show(endeffector.str);

             }*/




            if (e.X >= 70 && e.X <= 90 && e.Y >= 350 && e.Y <= 380)
            {
                endeffector endeffector = new endeffector();
                //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
                endeffector.form1 = this;
                endeffector.ShowDialog();
                //  MessageBox.Show(endeffector.str);

            }

            else if (e.X >= 70 && e.X <= 90 && e.Y >= 290 && e.Y <= 320)
            {
                ActionArm actionArm = new ActionArm();
                actionArm.form1 = this;
                actionArm.ShowDialog();

                Rotate rotate = new Rotate();
                rotate.myform1 = this;

            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            /*  Point p = e.Location;
              string X = p.X.ToString();
              string Y = p.Y.ToString();
              MessageBox.Show(p.ToString(), X + Y);*/
            if (e.X > 736 && e.Y > 561 && e.X < 746 && e.Y < 571)
            {
                endeffector endeffector = new endeffector();
                //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
                endeffector.form1 = this;
                endeffector.ShowDialog();
                //  MessageBox.Show(endeffector.str);

            }
        }

        private void lblwaferright_Click(object sender, EventArgs e)
        {
            endeffector endeffector = new endeffector();
            //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
            endeffector.form1 = this;
            endeffector.ShowDialog();
            //  MessageBox.Show(endeffector.str);
        }

        private void lblwaferup_Click(object sender, EventArgs e)
        {
            endeffector endeffector = new endeffector();
            //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
            endeffector.form1 = this;
            endeffector.ShowDialog();
            //  MessageBox.Show(endeffector.str);
        }

        private void lblwaferaligner_Click(object sender, EventArgs e)
        {
            endeffector endeffector = new endeffector();
            //  endeffector.ovalvisible = new endeffector.OvalVisible(OvalShapeVisible);
            endeffector.form1 = this;
            endeffector.ShowDialog();
            //  MessageBox.Show(endeffector.str);
        }
    }


}


