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
    public partial class Chamber : Form
    {
        public Chamber()
        {
            InitializeComponent();
        }

        private void Chamber_Load(object sender, EventArgs e)
        {

            
            btnPoint.Image = Properties.Resources.close;
            btnPoint.Image.Tag = "close";


            btnBypass.Image = Properties.Resources.close;

            btnBypass.Image.Tag = "close";


            btnAmmoniaPurge.Image = Properties.Resources.close;
            btnAmmoniaPurge.Image.Tag = "close";

            btnAmmoniaIn.Image = Properties.Resources.close;
            btnAmmoniaIn.Image.Tag = "close";

            btnAmmoniaOut.Image = Properties.Resources.close;
            btnAmmoniaOut.Image.Tag = "close";

            btnNitrogenPurge.Image = Properties.Resources.close;
            btnNitrogenPurge.Image.Tag = "close";

            btnNitrgenIn.Image = Properties.Resources.close;
            btnNitrgenIn.Image.Tag = "close";
            
            btnNitrogenOut.Image = Properties.Resources.close;
            btnNitrogenOut.Image.Tag = "close";

            btnNitrogen1Purge.Image = Properties.Resources.close;
            btnNitrogen1Purge.Image.Tag = "close";

            btnNitrogen1In.Image = Properties.Resources.close;
            btnNitrogen1In.Image.Tag = "close";

            btnNitrogen1Out.Image = Properties.Resources.close;
            btnNitrogen1Out.Image.Tag = "close";

            btnOxygenPurge.Image = Properties.Resources.close;
            btnOxygenPurge.Image.Tag = "close";

            btnOxygenIn.Image = Properties.Resources.close;
            btnOxygenIn.Image.Tag = "close";

            btnOxygenOut.Image = Properties.Resources.close;
            btnOxygenOut.Image.Tag = "close";

            btnN2Inlet.Image = Properties.Resources.close;
            btnN2Inlet.Image.Tag = "close";

            btnManifold.Image = Properties.Resources.close;
            btnManifold.Image.Tag = "close";
        }

        private void btnAmmoniaPurge_Click(object sender, EventArgs e)
        {

            switch (btnAmmoniaPurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Ammonia Valve Purge Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnAmmoniaPurge.Image = Properties.Resources.open;
                        btnAmmoniaPurge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Ammonia Valve Purge Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnAmmoniaPurge.Image = Properties.Resources.close;
                        btnAmmoniaPurge.Image.Tag = "close";

                    }


                    break;

                   
            }




        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            switch (btnPoint.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnPoint.Image = Properties.Resources.open;
                        btnPoint.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnPoint.Image = Properties.Resources.close;
                        btnPoint.Image.Tag = "close";

                    }


                    break;


            }


            


        }

        private void btnBypass_Click(object sender, EventArgs e)
        {
            switch (btnBypass.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Chamber bypass valve Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnBypass.Image = Properties.Resources.open;
                        btnBypass.Image.Tag = "open";


                    }

                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Chamber bypass valve Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnBypass.Image = Properties.Resources.close;
                       btnBypass.Image.Tag = "close";

                    }


                    break;




            }
            }

        private void btnAmmoniaIn_Click(object sender, EventArgs e)
        {
            switch (btnAmmoniaIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Ammonia Valve in is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnAmmoniaIn.Image = Properties.Resources.open;
                        btnAmmoniaIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Ammonia Valve in is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnAmmoniaIn.Image = Properties.Resources.close;
                        btnAmmoniaIn.Image.Tag = "close";

                    }


                    break;



                    
            }
        }

        private void btnAmmoniaOut_Click(object sender, EventArgs e)
        {
            switch (btnAmmoniaOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Ammonia Valve out is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnAmmoniaOut.Image = Properties.Resources.open;
                        btnAmmoniaOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Ammonia Valve out is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnAmmoniaOut.Image = Properties.Resources.close;
                        btnAmmoniaOut.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnNitrogenPurge_Click(object sender, EventArgs e)
        {
            switch (btnNitrogenPurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Nitrogen Valve Purge is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnNitrogenPurge.Image = Properties.Resources.open;
                        btnNitrogenPurge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Nitrogen Valve Purge is open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnNitrogenPurge.Image = Properties.Resources.close;
                        btnNitrogenPurge.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnNitrgenIn_Click(object sender, EventArgs e)
        {

            switch (btnNitrgenIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Nitrogen Valve in is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnNitrgenIn.Image = Properties.Resources.open;
                        btnNitrgenIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Nitrogen Valve in is open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnNitrgenIn.Image = Properties.Resources.close;
                        btnNitrgenIn.Image.Tag = "close";

                    }


                    break;




            }

        }

        private void btnNitrogenOut_Click(object sender, EventArgs e)
        {
            switch (btnNitrogenOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Nitrogen Valve out is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnNitrogenOut.Image = Properties.Resources.open;
                        btnNitrogenOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Nitrogen Valve out is open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnNitrogenOut.Image = Properties.Resources.close;
                        btnNitrogenOut.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnNitrogen1Purge_Click(object sender, EventArgs e)
        {
            switch (btnNitrogen1Purge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Nitrogen Valve Purge is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnNitrogen1Purge.Image = Properties.Resources.open;
                        btnNitrogen1Purge.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Nitrogen Valve Purge is open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnNitrogen1Purge.Image = Properties.Resources.close;
                        btnNitrogen1Purge.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnNitrogen1In_Click(object sender, EventArgs e)
        {
            switch (btnNitrogen1In.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Nitrogen Valve in is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnNitrogen1In.Image = Properties.Resources.open;
                        btnNitrogen1In.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Nitrogen Valve in is open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnNitrogen1In.Image = Properties.Resources.close;
                        btnNitrogen1In.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnNitrogen1Out_Click(object sender, EventArgs e)
        {
            switch (btnNitrogen1Out.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Nitrogen Valve out is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnNitrogen1Out.Image = Properties.Resources.open;
                        btnNitrogen1Out.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Nitrogen Valve out is open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnNitrogen1Out.Image = Properties.Resources.close;
                        btnNitrogen1Out.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnOxygenPurge_Click(object sender, EventArgs e)
        {
            switch (btnOxygenPurge.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Oxygen Valve Purge is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnOxygenPurge.Image = Properties.Resources.open;
                        btnOxygenPurge.Image.Tag = "open";

                        
                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve Purge is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygenPurge.Image = Properties.Resources.close;
                        btnOxygenPurge.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnOxygenIn_Click(object sender, EventArgs e)
        {
            switch (btnOxygenIn.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Oxygen Valve In is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnOxygenIn.Image = Properties.Resources.open;
                        btnOxygenIn.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve In is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygenIn.Image = Properties.Resources.close;
                        btnOxygenIn.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnOxygenOut_Click(object sender, EventArgs e)
        {
            switch (btnOxygenOut.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Oxygen Valve Out is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnOxygenOut.Image = Properties.Resources.open;
                        btnOxygenOut.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Oxygen Valve Out is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnOxygenOut.Image = Properties.Resources.close;
                        btnOxygenOut.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnN2Inlet_Click(object sender, EventArgs e)
        {
            switch (btnN2Inlet.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "N2 inlet Valve Is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnN2Inlet.Image = Properties.Resources.open;
                        btnN2Inlet.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "N2 inlet Valve Is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnN2Inlet.Image = Properties.Resources.close;
                        btnN2Inlet.Image.Tag = "close";

                    }


                    break;




            }
        }

        private void btnManifold_Click(object sender, EventArgs e)
        {
            switch (btnManifold.Image.Tag.ToString())
            {

                case "close":
                    Point point = new Point();
                    point.label1.Text = "Manifold isolation is Closed";
                    DialogResult dr = point.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        btnManifold.Image = Properties.Resources.open;
                        btnManifold.Image.Tag = "open";


                    }
                    break;
                case "open":
                    PointOpen pointopen = new PointOpen();
                    pointopen.label1.Text = "Manifold isolation is Open";
                    DialogResult dr1 = pointopen.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {

                        btnManifold.Image = Properties.Resources.close;
                        btnManifold.Image.Tag = "close";

                    }


                    break;




            }
        }
    }
}
