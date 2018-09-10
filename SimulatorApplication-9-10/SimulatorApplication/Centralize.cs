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
    public partial class Centralize : Form
    {
        public Centralize()
        {
            InitializeComponent();
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {

            RecipeType recipetype = new RecipeType();
            recipetype.ShowDialog();



        }

        private void Centralize_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.centralize12;
        }
    }
}
