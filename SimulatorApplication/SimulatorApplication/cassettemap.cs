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
    public partial class cassettemap : Form
    {
        public Form1 form1 = new Form1();
        public cassettemap()
        {
            InitializeComponent();
        }

        private async void btnmap_Click(object sender, EventArgs e)
        {
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
            for (int j = 1; j<=24; j++)
            {
                await Task.Delay(20);
                form1.picmap1.Top += 13;
            }
            form1.picmap1.Visible = false;
            form1.picmap1.Top -= 312;
        }
    }
}
