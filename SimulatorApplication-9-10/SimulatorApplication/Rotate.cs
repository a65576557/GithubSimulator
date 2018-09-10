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
    public partial class Rotate : Form
    {
        public string rotate;
        public Form1 myform1 = new Form1();
        public ActionArm actionArm1 = new ActionArm();
        public string msg;
        public Rotate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            msg = rotate;




        }

        private void listBoxRotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotate = listBoxRotate.SelectedItem.ToString();


        }

        private void Rotate_Load(object sender, EventArgs e)
        {

        }
        public string getmsg()
        {
            return msg;
        }
    }
}
