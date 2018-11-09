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
    public partial class LotInformation : Form
    {
        public LotInformation()
        {
            InitializeComponent();
        }
        public string Lot;

        private void LotInformation_Load(object sender, EventArgs e)
        {

           

        }
        public string getLotID()
        {
            return Lot;


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Lot = textBox1.Text;


        }
    }
}
