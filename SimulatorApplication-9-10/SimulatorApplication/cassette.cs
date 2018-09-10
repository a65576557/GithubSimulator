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
    public partial class cassette : Form
    {
        public cassette()
        {
            InitializeComponent();
        }

        private void cassette_Load(object sender, EventArgs e)
        {
            picCassette.Image = Properties.Resources.cassette;
            picCentralize.Image = Properties.Resources.centralize;
            pictureBox1.Image = Properties.Resources.cassette2;
            picCentralize.Image = Properties.Resources.centralize;
            picChamber.Image = Properties.Resources.chamber;
            picRobot.Image = Properties.Resources.robotbotton;


           
            
        }
    }
}
