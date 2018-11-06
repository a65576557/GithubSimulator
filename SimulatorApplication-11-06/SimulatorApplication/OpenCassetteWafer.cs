using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorApplication
{
    public partial class OpenCassetteWafer : Form
    {
        SqlConnectionStringBuilder scsb;

        ListViewItem itm;

        List<string> listnoofwafers = new List<string>();
        List<string> listwaferrecipe = new List<string>();
        List<string> listconditioningrecipe = new List<string>();
        List<string> listid = new List<string>();

        public delegate void UpdateListbox(object sender, EventArgs e);

        public UpdateListbox updatelistbox;

        public static string strsearchname;

        string strtag;

        public OpenCassetteWafer()
        {
            InitializeComponent();
        }

        private void OpenCassetteWafer_Load(object sender, EventArgs e)
        {
            


            cmbWaferRecipe.Items.Add("Null");




            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());
            
          
            string strSQL = "select * from CassetteWafer inner join CassetteRecipe on CassetteWafer.CassetterecipeName = Cassetterecipe.CassetterecipeName where CassetteWafer.CassetterecipeName = @Newrecipename";

            string strcmbwaferrecipe = "select * from recipe";

           


            string strcmbconditioningrecipe = "select * from conditionrecipe";




            con.Open();
            SqlCommand cmdcmbwaferrecipe = new SqlCommand(strcmbwaferrecipe, con);
            SqlDataReader readercmbwaferrecipe = cmdcmbwaferrecipe.ExecuteReader();

            while (readercmbwaferrecipe.Read())
            {
                cmbWaferRecipe.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe2.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe3.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe4.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe5.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe6.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe7.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe8.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe9.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe10.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe11.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe12.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe13.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe14.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe15.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe16.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe17.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe18.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe19.Items.Add(readercmbwaferrecipe["recipeName"]);
                cmbWaferRecipe20.Items.Add(readercmbwaferrecipe["recipeName"]);


            }

            con.Close();

            con.Open();

            SqlCommand cmdcmbconditioningrecipe = new SqlCommand(strcmbconditioningrecipe, con);

            SqlDataReader readercmbconditioningrecipe = cmdcmbconditioningrecipe.ExecuteReader();

            while (readercmbconditioningrecipe.Read())
            {

                cmbConditioningRecipe.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe2.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe3.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe4.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe5.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe6.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe7.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe8.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe9.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe10.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe11.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe12.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe13.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe14.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe15.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe16.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe17.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe18.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe19.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);
                cmbConditioningRecipe20.Items.Add(readercmbconditioningrecipe["conditionrecipename"]);


            }





            con.Close();


            con.Open();


            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@Newrecipename", RecipeType.strSearchName);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                listid.Add(reader["cassettewaferid"].ToString());
                listnoofwafers.Add(reader["noofwafers"].ToString());
                listwaferrecipe.Add(reader["waferrecipe"].ToString());
                listconditioningrecipe.Add(reader["conditioningrecipe"].ToString());

            }
            if (listnoofwafers.Count == 1)
            {
                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                strtag = "panel1";


            }
            else if (listnoofwafers.Count == 2)
            {
                panel2.Visible = true;
                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];
                strtag = "panel2";

            }
            else if (listnoofwafers.Count==3)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                lblid3.Text = listid[2];
                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];
                strtag = "panel3";


            }
            else if (listnoofwafers.Count == 4)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;

                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];


                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                lblid3.Text = listid[2];
                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                lblid4.Text = listid[3];
                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];

                strtag = "panel4";
            }

            else if (listnoofwafers.Count == 5)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;

                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                lblid3.Text = listid[2];
                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                lblid4.Text = listid[3];
                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];

                lblid5.Text = listid[4];
                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                strtag = "panel5";
            }

            else if (listnoofwafers.Count == 6)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;

                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                lblid3.Text = listid[2];
                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                lblid4.Text = listid[3];
                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];

                lblid5.Text = listid[4];
                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                lblid6.Text = listid[5];
                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                strtag = "panel6";
            }

            else if (listnoofwafers.Count == 7)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;

                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                lblid3.Text = listid[2];
                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                lblid4.Text = listid[3];
                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];

                lblid5.Text = listid[4];
                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                lblid6.Text = listid[5];
                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                lblid7.Text = listid[6];
                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                strtag = "panel7";
            }

            else if (listnoofwafers.Count == 8)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;

                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                lblid3.Text = listid[2];
                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                lblid4.Text = listid[3];
                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];

                lblid5.Text = listid[4];
                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                lblid6.Text = listid[5];
                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                lblid7.Text = listid[6];
                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                lblid8.Text = listid[7];
                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe2.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                strtag = "panel8";
            }

            else if (listnoofwafers.Count == 9)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;

                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                lblid3.Text = listid[2];
                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                lblid4.Text = listid[3];
                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];

                lblid5.Text = listid[4];
                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                lblid6.Text = listid[5];
                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                lblid7.Text = listid[6];
                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                lblid8.Text = listid[7];
                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                lblid9.Text = listid[8];
                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                strtag = "panel9";
            }

            else if (listnoofwafers.Count == 10)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;

                lblid.Text = listid[0];
                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                lblid2.Text = listid[1];
                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                lblid3.Text = listid[2];
                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                lblid4.Text = listid[3];
                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];

                lblid5.Text = listid[4];
                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                lblid6.Text = listid[5];
                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                lblid7.Text = listid[6];
                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                lblid8.Text = listid[7];
                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                lblid9.Text = listid[8];
                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                lblid10.Text = listid[9];
                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                strtag = "panel10";
            }

            else if (listnoofwafers.Count == 11)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];
                strtag = "panel11";
            }

            else if (listnoofwafers.Count == 12)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];
                strtag = "panel12";
            }

            else if (listnoofwafers.Count == 13)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];

                tbNoOfWafers13.Text = listnoofwafers[12];
                cmbWaferRecipe13.Text = listwaferrecipe[12];
                cmbConditioningRecipe13.Text = listconditioningrecipe[12];

                strtag = "panel13";
            }
          

              else if (listnoofwafers.Count == 14)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;
                panel14.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];

                tbNoOfWafers13.Text = listnoofwafers[12];
                cmbWaferRecipe13.Text = listwaferrecipe[12];
                cmbConditioningRecipe13.Text = listconditioningrecipe[12];

                tbNoOfWafers14.Text = listnoofwafers[13];
                cmbWaferRecipe14.Text = listwaferrecipe[13];
                cmbConditioningRecipe14.Text = listconditioningrecipe[13];

                strtag = "panel14";
            }

            else if (listnoofwafers.Count == 15)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;
                panel14.Visible = true;
                panel15.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];

                tbNoOfWafers13.Text = listnoofwafers[12];
                cmbWaferRecipe13.Text = listwaferrecipe[12];
                cmbConditioningRecipe13.Text = listconditioningrecipe[12];

                tbNoOfWafers14.Text = listnoofwafers[13];
                cmbWaferRecipe14.Text = listwaferrecipe[13];
                cmbConditioningRecipe14.Text = listconditioningrecipe[13];

                tbNoOfWafers15.Text = listnoofwafers[14];
                cmbWaferRecipe15.Text = listwaferrecipe[14];
                cmbConditioningRecipe15.Text = listconditioningrecipe[14];
                strtag = "panel15";
            }

            else if (listnoofwafers.Count == 16)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;
                panel14.Visible = true;
                panel15.Visible = true;
                panel16.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];

                tbNoOfWafers13.Text = listnoofwafers[12];
                cmbWaferRecipe13.Text = listwaferrecipe[12];
                cmbConditioningRecipe13.Text = listconditioningrecipe[12];

                tbNoOfWafers14.Text = listnoofwafers[13];
                cmbWaferRecipe14.Text = listwaferrecipe[13];
                cmbConditioningRecipe14.Text = listconditioningrecipe[13];

                tbNoOfWafers15.Text = listnoofwafers[14];
                cmbWaferRecipe15.Text = listwaferrecipe[14];
                cmbConditioningRecipe15.Text = listconditioningrecipe[14];

                tbNoOfWafers16.Text = listnoofwafers[15];
                cmbWaferRecipe16.Text = listwaferrecipe[15];
                cmbConditioningRecipe16.Text = listconditioningrecipe[15];
                strtag = "panel16";
            }

            else if (listnoofwafers.Count == 17)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;
                panel14.Visible = true;
                panel15.Visible = true;
                panel16.Visible = true;
                panel17.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];

                tbNoOfWafers13.Text = listnoofwafers[12];
                cmbWaferRecipe13.Text = listwaferrecipe[12];
                cmbConditioningRecipe13.Text = listconditioningrecipe[12];

                tbNoOfWafers14.Text = listnoofwafers[13];
                cmbWaferRecipe14.Text = listwaferrecipe[13];
                cmbConditioningRecipe14.Text = listconditioningrecipe[13];

                tbNoOfWafers15.Text = listnoofwafers[14];
                cmbWaferRecipe15.Text = listwaferrecipe[14];
                cmbConditioningRecipe15.Text = listconditioningrecipe[14];

                tbNoOfWafers16.Text = listnoofwafers[15];
                cmbWaferRecipe16.Text = listwaferrecipe[15];
                cmbConditioningRecipe16.Text = listconditioningrecipe[15];

                tbNoOfWafers17.Text = listnoofwafers[16];
                cmbWaferRecipe17.Text = listwaferrecipe[16];
                cmbConditioningRecipe17.Text = listconditioningrecipe[16];
                strtag = "panel17";
            }

            else if (listnoofwafers.Count == 18)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;
                panel14.Visible = true;
                panel15.Visible = true;
                panel16.Visible = true;
                panel17.Visible = true;
                panel18.Visible = true;


                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];

                tbNoOfWafers13.Text = listnoofwafers[12];
                cmbWaferRecipe13.Text = listwaferrecipe[12];
                cmbConditioningRecipe13.Text = listconditioningrecipe[12];

                tbNoOfWafers14.Text = listnoofwafers[13];
                cmbWaferRecipe14.Text = listwaferrecipe[13];
                cmbConditioningRecipe14.Text = listconditioningrecipe[13];

                tbNoOfWafers15.Text = listnoofwafers[14];
                cmbWaferRecipe15.Text = listwaferrecipe[14];
                cmbConditioningRecipe15.Text = listconditioningrecipe[14];

                tbNoOfWafers16.Text = listnoofwafers[15];
                cmbWaferRecipe16.Text = listwaferrecipe[15];
                cmbConditioningRecipe16.Text = listconditioningrecipe[15];

                tbNoOfWafers17.Text = listnoofwafers[16];
                cmbWaferRecipe17.Text = listwaferrecipe[16];
                cmbConditioningRecipe17.Text = listconditioningrecipe[16];

                tbNoOfWafers18.Text = listnoofwafers[17];
                cmbWaferRecipe18.Text = listwaferrecipe[17];
                cmbConditioningRecipe18.Text = listconditioningrecipe[17];
                strtag = "panel18";
            }

            else if (listnoofwafers.Count == 19)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;
                panel14.Visible = true;
                panel15.Visible = true;
                panel16.Visible = true;
                panel17.Visible = true;
                panel18.Visible = true;
                panel19.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];

                tbNoOfWafers13.Text = listnoofwafers[12];
                cmbWaferRecipe13.Text = listwaferrecipe[12];
                cmbConditioningRecipe13.Text = listconditioningrecipe[12];

                tbNoOfWafers14.Text = listnoofwafers[13];
                cmbWaferRecipe14.Text = listwaferrecipe[13];
                cmbConditioningRecipe14.Text = listconditioningrecipe[13];

                tbNoOfWafers15.Text = listnoofwafers[14];
                cmbWaferRecipe15.Text = listwaferrecipe[14];
                cmbConditioningRecipe15.Text = listconditioningrecipe[14];

                tbNoOfWafers16.Text = listnoofwafers[15];
                cmbWaferRecipe16.Text = listwaferrecipe[15];
                cmbConditioningRecipe16.Text = listconditioningrecipe[15];

                tbNoOfWafers17.Text = listnoofwafers[16];
                cmbWaferRecipe17.Text = listwaferrecipe[16];
                cmbConditioningRecipe17.Text = listconditioningrecipe[16];

                tbNoOfWafers18.Text = listnoofwafers[17];
                cmbWaferRecipe18.Text = listwaferrecipe[17];
                cmbConditioningRecipe18.Text = listconditioningrecipe[17];

                tbNoOfWafers19.Text = listnoofwafers[18];
                cmbWaferRecipe19.Text = listwaferrecipe[18];
                cmbConditioningRecipe19.Text = listconditioningrecipe[18];
                strtag = "panel19";
            }

            else if (listnoofwafers.Count == 20)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;
                panel14.Visible = true;
                panel15.Visible = true;
                panel16.Visible = true;
                panel17.Visible = true;
                panel18.Visible = true;
                panel19.Visible = true;
                panel20.Visible = true;

                tbNoOfWafers.Text = listnoofwafers[0];
                cmbWaferRecipe.Text = listwaferrecipe[0];
                cmbConditioningRecipe.Text = listconditioningrecipe[0];

                tbNoOfWafers2.Text = listnoofwafers[1];
                cmbWaferRecipe2.Text = listwaferrecipe[1];
                cmbConditioningRecipe2.Text = listconditioningrecipe[1];

                tbNoOfWafers3.Text = listnoofwafers[2];
                cmbWaferRecipe3.Text = listwaferrecipe[2];
                cmbConditioningRecipe3.Text = listconditioningrecipe[2];

                tbNoOfWafers4.Text = listnoofwafers[3];
                cmbWaferRecipe4.Text = listwaferrecipe[3];
                cmbConditioningRecipe4.Text = listconditioningrecipe[3];


                tbNoOfWafers5.Text = listnoofwafers[4];
                cmbWaferRecipe5.Text = listwaferrecipe[4];
                cmbConditioningRecipe5.Text = listconditioningrecipe[4];

                tbNoOfWafers6.Text = listnoofwafers[5];
                cmbWaferRecipe6.Text = listwaferrecipe[5];
                cmbConditioningRecipe6.Text = listconditioningrecipe[5];

                tbNoOfWafers7.Text = listnoofwafers[6];
                cmbWaferRecipe7.Text = listwaferrecipe[6];
                cmbConditioningRecipe7.Text = listconditioningrecipe[6];

                tbNoOfWafers8.Text = listnoofwafers[7];
                cmbWaferRecipe8.Text = listwaferrecipe[7];
                cmbConditioningRecipe8.Text = listconditioningrecipe[7];

                tbNoOfWafers9.Text = listnoofwafers[8];
                cmbWaferRecipe9.Text = listwaferrecipe[8];
                cmbConditioningRecipe9.Text = listconditioningrecipe[8];

                tbNoOfWafers10.Text = listnoofwafers[9];
                cmbWaferRecipe10.Text = listwaferrecipe[9];
                cmbConditioningRecipe10.Text = listconditioningrecipe[9];

                tbNoOfWafers11.Text = listnoofwafers[10];
                cmbWaferRecipe11.Text = listwaferrecipe[10];
                cmbConditioningRecipe11.Text = listconditioningrecipe[10];

                tbNoOfWafers12.Text = listnoofwafers[11];
                cmbWaferRecipe12.Text = listwaferrecipe[11];
                cmbConditioningRecipe12.Text = listconditioningrecipe[11];

                tbNoOfWafers13.Text = listnoofwafers[12];
                cmbWaferRecipe13.Text = listwaferrecipe[12];
                cmbConditioningRecipe13.Text = listconditioningrecipe[12];

                tbNoOfWafers14.Text = listnoofwafers[13];
                cmbWaferRecipe14.Text = listwaferrecipe[13];
                cmbConditioningRecipe14.Text = listconditioningrecipe[13];

                tbNoOfWafers15.Text = listnoofwafers[14];
                cmbWaferRecipe15.Text = listwaferrecipe[14];
                cmbConditioningRecipe15.Text = listconditioningrecipe[14];

                tbNoOfWafers16.Text = listnoofwafers[15];
                cmbWaferRecipe16.Text = listwaferrecipe[15];
                cmbConditioningRecipe16.Text = listconditioningrecipe[15];

                tbNoOfWafers17.Text = listnoofwafers[16];
                cmbWaferRecipe17.Text = listwaferrecipe[16];
                cmbConditioningRecipe17.Text = listconditioningrecipe[16];

                tbNoOfWafers18.Text = listnoofwafers[17];
                cmbWaferRecipe18.Text = listwaferrecipe[17];
                cmbConditioningRecipe18.Text = listconditioningrecipe[17];

                tbNoOfWafers19.Text = listnoofwafers[18];
                cmbWaferRecipe19.Text = listwaferrecipe[18];
                cmbConditioningRecipe19.Text = listconditioningrecipe[18];

                tbNoOfWafers20.Text = listnoofwafers[19];
                cmbWaferRecipe20.Text = listwaferrecipe[19];
                cmbConditioningRecipe20.Text = listconditioningrecipe[19];
                strtag = "panel20";
            }


            con.Close();


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*  con.Open();
              string strSQLRecipe = "select * from recipe";
              SqlCommand cmdRecipe = new SqlCommand(strSQLRecipe, con);
              SqlDataReader readerRecipe = cmdRecipe.ExecuteReader();
              while (readerRecipe.Read())
              {

                  cmbWaferRecipe.Items.Add(readerRecipe["recipeName"]);



              }

            cmbWaferRecipe.Text =cmbWaferRecipe.Items[0].ToString();



              con.Close();*/


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*    con.Open();
                string strSQL1 = "select * from CassetteWafer where CassetteRecipeName = @NewCassetteRecipeName";
                SqlCommand cmd1 =new SqlCommand(strSQL1, con);
                cmd1.Parameters.AddWithValue("@NewCassetteRecipeName", RecipeType.strSearchName);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    listBox1.Items.Add(reader1["NoOfWafers"]);



                }
                con.Close();
                listBox1.SetSelected(0, true);*/

        }

        private void btnAppend_Click(object sender, EventArgs e)
        {







        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

          /*  string strSelectd = listBox1.SelectedItem.ToString();

            if (strSelectd.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select * from CassetteWafer where NoOfWafers like @NewSearchWafer";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewSearchWafer", strSelectd);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tbNoOfWafers.Text = string.Format("{0}", reader["NoOfWafers"]);
                    cmbWaferRecipe.Text = string.Format("{0}", reader["WaferRecipe"]);
                    cmbConditioningRecipe.Text = string.Format("{0}", reader["ConditioningRecipe"]);



                }
                con.Close();




            }*/





        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            switch (strtag)
            {
                case "panel1":
                    panel2.Visible = true;
                    strtag = "panel2";
                    break;

                case "panel2":
                    panel3.Visible = true;
                    strtag = "panel3";
                    break;

                case "panel3":
                    panel4.Visible = true;
                    strtag = "panel4";
                    break;
                case "panel4":
                    panel5.Visible = true;
                    strtag = "panel5";
                    break;

                case "panel5":
                    panel6.Visible = true;
                    strtag = "panel6";
                    break;

                case "panel6":
                    panel7.Visible = true;
                    strtag = "panel7";
                    break;

                case "panel7":
                    panel8.Visible = true;
                    strtag = "panel8";
                    break;

                case "panel8":
                    panel9.Visible = true;
                    strtag = "panel9";
                    break;

                case "panel9":
                    panel10.Visible = true;
                    strtag = "pane10";
                    break;

                case "pane10":
                    panel11.Visible = true;
                    strtag = "panel11";
                    break;

                case "panel11":
                    panel12.Visible = true;
                    strtag = "panel12";
                    break;

                case "panel12":
                    panel13.Visible = true;
                    strtag = "panel13";
                    break;

                case "panel13":
                    panel14.Visible = true;
                    strtag = "panel14";
                    break;

                case "panel14":
                    panel15.Visible = true;
                    strtag = "panel15";
                    break;

                case "panel15":
                    panel16.Visible = true;
                    strtag = "panel16";
                    break;

                case "panel16":
                    panel17.Visible = true;
                    strtag = "panel17";
                    break;
                case "panel17":
                    panel18.Visible = true;
                    strtag = "panel18";
                    break;
                case "panel18":
                    panel19.Visible = true;
                    strtag = "panel19";
                    break;
                case "panel19":
                    panel20.Visible = true;
                    strtag = "panel20";
                    break;
                case "panel20":
                    MessageBox.Show("maximum 20");
                    break;



            }


            }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (strtag)
            {


                case "panel2":
                    panel2.Visible = false;
                    strtag = "panel1";
                    break;

                case "panel3":
                    panel3.Visible = false;
                    strtag = "panel2";
                    break;
                case "panel4":
                    panel4.Visible = false;
                    strtag = "panel3";
                    break;

                case "panel5":
                    panel5.Visible = false;
                    strtag = "panel4";
                    break;

                case "panel6":
                    panel6.Visible = false;
                    strtag = "panel5";
                    break;

                case "panel7":
                    panel7.Visible = false;
                    strtag = "panel6";
                    break;

                case "panel8":
                    panel8.Visible = false;
                    strtag = "panel7";
                    break;

                case "panel9":
                    panel9.Visible = true;
                    strtag = "pane8";
                    break;

                case "pane10":
                    panel10.Visible = true;
                    strtag = "panel9";
                    break;

                case "panel11":
                    panel12.Visible = true;
                    strtag = "panel12";
                    break;

                case "panel12":
                    panel12.Visible = false;
                    strtag = "panel11";
                    break;

                case "panel13":
                    panel13.Visible = false;
                    strtag = "panel12";
                    break;

                case "panel14":
                    panel14.Visible = false;
                    strtag = "panel13";
                    break;

                case "panel15":
                    panel15.Visible = false;
                    strtag = "panel14";
                    break;

                case "panel16":
                    panel16.Visible = false;
                    strtag = "panel15";
                    break;
                case "panel17":
                    panel17.Visible = false;
                    strtag = "panel16";
                    break;
                case "panel18":
                    panel18.Visible = false;
                    strtag = "panel17";
                    break;
                case "panel19":
                    panel19.Visible = false;
                    strtag = "panel18";
                    break;
                case "panel20":
                    panel20.Visible = false;
                    strtag = "panel19";
                    break;

            }

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());



            con.Open();

            string strSQL = "update cassettewafer set noofwafers=@1,waferrecipe=@2,conditioningrecipe=@3 where cassettewaferid = @id";
            string strdelete = "delete from cassettewafer where cassettewaferid = @id";
            // string strSQL2 = "update cassettewafer set noofwafers=@1,waferrecipe=@2,conditioningrecipe=@3 where cassettewaferid = @id";

            if (strtag == "panel1" && lblid2.Text == "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();


            }

            else if (strtag == "panel1" && lblid2.Text != "no" && lblid3.Text == "no")//從 lblid2 刪除1筆
            {


                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();



                SqlCommand cmddelete = new SqlCommand(strdelete, con);
                cmddelete.Parameters.AddWithValue("@id", lblid2.Text);
                cmddelete.ExecuteNonQuery();



            }

            else if (strtag == "panel1" && lblid2.Text != "no" && lblid3.Text != "no")//從 lblid3 刪除2筆
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();



                SqlCommand cmddelete2 = new SqlCommand(strdelete, con);
                cmddelete2.Parameters.AddWithValue("@id", lblid2.Text);

                cmddelete2.ExecuteNonQuery();


                SqlCommand cmddelete3 = new SqlCommand(strdelete, con);
                cmddelete3.Parameters.AddWithValue("@id", lblid3.Text);

                cmddelete3.ExecuteNonQuery();



            }

            else if (strtag == "panel2" && lblid2.Text != "no" && lblid3.Text != "no" && lblid4.Text == "no")//從 lblid3 刪除1筆
            {




                SqlCommand cmddelete3 = new SqlCommand(strdelete, con);
                cmddelete3.Parameters.AddWithValue("@id", lblid3.Text);

                cmddelete3.ExecuteNonQuery();



            }
            else if (strtag == "panel3" && lblid4.Text != "no")//從 lblid4 刪除1筆
            {
                SqlCommand cmddelete4 = new SqlCommand(strdelete, con);
                cmddelete4.Parameters.AddWithValue("@id", lblid4.Text);

                cmddelete4.ExecuteNonQuery();




            }

            else if (strtag == "panel2" && lblid4.Text != "no" && lblid3.Text != "no")//從 lblid4 刪除2筆
            {


                SqlCommand cmddelete3 = new SqlCommand(strdelete, con);
                cmddelete3.Parameters.AddWithValue("@id", lblid3.Text);

                cmddelete3.ExecuteNonQuery();




                SqlCommand cmddelete4 = new SqlCommand(strdelete, con);
                cmddelete4.Parameters.AddWithValue("@id", lblid4.Text);

                cmddelete4.ExecuteNonQuery();




            }

            else if (strtag=="panel4"&&lblid5.Text!="no")//從 lblid5 刪除1筆
            {
                SqlCommand cmddelete5 = new SqlCommand(strdelete, con);
                cmddelete5.Parameters.AddWithValue("@id", lblid5.Text);

                cmddelete5.ExecuteNonQuery();




            }





            /*   else if (strtag == "panel1" && lblid2.Text != "no"&&lblid3.Text!="no")
               {
                   string strdelete = "delete from cassettewafer where cassettewaferid = @id";

                   SqlCommand cmddelete = new SqlCommand(strdelete, con);
                   cmddelete.Parameters.AddWithValue("@id", lblid2.Text);
                   cmddelete.ExecuteNonQuery();
                   SqlCommand cmddelete3 = new SqlCommand(strdelete, con);
                   cmddelete3.Parameters.AddWithValue("@id", lblid3.Text);
                   cmddelete3.ExecuteNonQuery();
               }*/


            else if (strtag == "panel2" && lblid2.Text != "no")
            {
                SqlCommand cmd1 = new SqlCommand(strSQL, con);
                cmd1.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd1.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd1.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd1.Parameters.AddWithValue("@id", lblid.Text);

                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();

            }



            else if (strtag == "panel2" && lblid2.Text == "no")//從lblid insert 1 筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinsert2 = new SqlCommand(insert2, con);

                cmdinsert2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert2.Parameters.AddWithValue("@2", tbNoOfWafers2.Text);
                cmdinsert2.Parameters.AddWithValue("@3", cmbWaferRecipe2.Text);
                cmdinsert2.Parameters.AddWithValue("@4", cmbConditioningRecipe2.Text);

                cmdinsert2.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

            }



            else if (strtag == "panel3" && lblid3.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();



                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbNoOfWafers3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbWaferRecipe3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbConditioningRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);



                cmd3.ExecuteNonQuery();
            }

            else if (strtag == "panel3" && lblid3.Text == "no" && lblid2.Text == "no") //從lblid1 insert 2 筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinsert2 = new SqlCommand(insert2, con);

                cmdinsert2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert2.Parameters.AddWithValue("@2", tbNoOfWafers2.Text);
                cmdinsert2.Parameters.AddWithValue("@3", cmbWaferRecipe2.Text);
                cmdinsert2.Parameters.AddWithValue("@4", cmbConditioningRecipe2.Text);


                cmdinsert2.ExecuteNonQuery();

                SqlCommand cmdinsert3 = new SqlCommand(insert2, con);
                cmdinsert3.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert3.Parameters.AddWithValue("@2", tbNoOfWafers3.Text);
                cmdinsert3.Parameters.AddWithValue("@3", cmbWaferRecipe3.Text);
                cmdinsert3.Parameters.AddWithValue("@4", cmbConditioningRecipe3.Text);
                cmdinsert3.ExecuteNonQuery();


                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();





            }

            else if (strtag == "panel3" && lblid3.Text == "no" && lblid2.Text != "no")//從lblid2 insert 1 筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinsert2 = new SqlCommand(insert2, con);

                cmdinsert2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert2.Parameters.AddWithValue("@2", tbNoOfWafers3.Text);
                cmdinsert2.Parameters.AddWithValue("@3", cmbWaferRecipe3.Text);
                cmdinsert2.Parameters.AddWithValue("@4", cmbConditioningRecipe3.Text);
                cmdinsert2.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();



            }

            else if (strtag == "panel4" && lblid4.Text != "no")
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();



                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbNoOfWafers3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbWaferRecipe3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbConditioningRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);



                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand(strSQL, con);
                cmd4.Parameters.AddWithValue("@1", tbNoOfWafers4.Text);
                cmd4.Parameters.AddWithValue("@2", cmbWaferRecipe4.Text);
                cmd4.Parameters.AddWithValue("@3", cmbConditioningRecipe4.Text);
                cmd4.Parameters.AddWithValue("@id", lblid4.Text);



                cmd4.ExecuteNonQuery();
            }

            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid3 insert 1筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinsert2 = new SqlCommand(insert2, con);

                cmdinsert2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert2.Parameters.AddWithValue("@2", tbNoOfWafers4.Text);
                cmdinsert2.Parameters.AddWithValue("@3", cmbWaferRecipe4.Text);
                cmdinsert2.Parameters.AddWithValue("@4", cmbConditioningRecipe4.Text);
                cmdinsert2.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();



                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbNoOfWafers3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbWaferRecipe3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbConditioningRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);



                cmd3.ExecuteNonQuery();





            }

            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text != "no")//從lblid2 insert 2筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinsert2 = new SqlCommand(insert2, con);

                cmdinsert2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert2.Parameters.AddWithValue("@2", tbNoOfWafers4.Text);
                cmdinsert2.Parameters.AddWithValue("@3", cmbWaferRecipe4.Text);
                cmdinsert2.Parameters.AddWithValue("@4", cmbConditioningRecipe4.Text);
                cmdinsert2.ExecuteNonQuery();


                SqlCommand cmdinsert = new SqlCommand(insert2, con);

                cmdinsert.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert.Parameters.AddWithValue("@2", tbNoOfWafers3.Text);
                cmdinsert.Parameters.AddWithValue("@3", cmbWaferRecipe3.Text);
                cmdinsert.Parameters.AddWithValue("@4", cmbConditioningRecipe3.Text);
                cmdinsert.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();



            }
            else if (strtag == "panel4" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text == "no")//從lblid insert 3筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinsert2 = new SqlCommand(insert2, con);

                cmdinsert2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert2.Parameters.AddWithValue("@2", tbNoOfWafers4.Text);
                cmdinsert2.Parameters.AddWithValue("@3", cmbWaferRecipe4.Text);
                cmdinsert2.Parameters.AddWithValue("@4", cmbConditioningRecipe4.Text);
                cmdinsert2.ExecuteNonQuery();


                SqlCommand cmdinsert = new SqlCommand(insert2, con);

                cmdinsert.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert.Parameters.AddWithValue("@2", tbNoOfWafers3.Text);
                cmdinsert.Parameters.AddWithValue("@3", cmbWaferRecipe3.Text);
                cmdinsert.Parameters.AddWithValue("@4", cmbConditioningRecipe3.Text);
                cmdinsert.ExecuteNonQuery();

                SqlCommand cmdinserttwo = new SqlCommand(insert2, con);

                cmdinserttwo.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinserttwo.Parameters.AddWithValue("@2", tbNoOfWafers2.Text);
                cmdinserttwo.Parameters.AddWithValue("@3", cmbWaferRecipe2.Text);
                cmdinserttwo.Parameters.AddWithValue("@4", cmbConditioningRecipe2.Text);
                cmdinserttwo.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();


            }

            else if (strtag == "panel5" && lblid5.Text != "no")
            {
                SqlCommand cmd5 = new SqlCommand(strSQL, con);
                cmd5.Parameters.AddWithValue("@1", tbNoOfWafers5.Text);
                cmd5.Parameters.AddWithValue("@2", cmbWaferRecipe5.Text);
                cmd5.Parameters.AddWithValue("@3", cmbConditioningRecipe5.Text);
                cmd5.Parameters.AddWithValue("@id", lblid5.Text);



                cmd5.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();



                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbNoOfWafers3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbWaferRecipe3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbConditioningRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);



                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand(strSQL, con);
                cmd4.Parameters.AddWithValue("@1", tbNoOfWafers4.Text);
                cmd4.Parameters.AddWithValue("@2", cmbWaferRecipe4.Text);
                cmd4.Parameters.AddWithValue("@3", cmbConditioningRecipe4.Text);
                cmd4.Parameters.AddWithValue("@id", lblid4.Text);



                cmd4.ExecuteNonQuery();


            }

            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid4 insert 1筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinserttwo = new SqlCommand(insert2, con);

                cmdinserttwo.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinserttwo.Parameters.AddWithValue("@2", tbNoOfWafers5.Text);
                cmdinserttwo.Parameters.AddWithValue("@3", cmbWaferRecipe5.Text);
                cmdinserttwo.Parameters.AddWithValue("@4", cmbConditioningRecipe5.Text);
                cmdinserttwo.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();



                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbNoOfWafers3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbWaferRecipe3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbConditioningRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);



                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand(strSQL, con);
                cmd4.Parameters.AddWithValue("@1", tbNoOfWafers4.Text);
                cmd4.Parameters.AddWithValue("@2", cmbWaferRecipe4.Text);
                cmd4.Parameters.AddWithValue("@3", cmbConditioningRecipe4.Text);
                cmd4.Parameters.AddWithValue("@id", lblid4.Text);



                cmd4.ExecuteNonQuery();

            }
            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid3 insert 2筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinserttwo = new SqlCommand(insert2, con);

                cmdinserttwo.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinserttwo.Parameters.AddWithValue("@2", tbNoOfWafers5.Text);
                cmdinserttwo.Parameters.AddWithValue("@3", cmbWaferRecipe5.Text);
                cmdinserttwo.Parameters.AddWithValue("@4", cmbConditioningRecipe5.Text);
                cmdinserttwo.ExecuteNonQuery();


                SqlCommand cmdinsert4 = new SqlCommand(insert2, con);

                cmdinsert4.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert4.Parameters.AddWithValue("@2", tbNoOfWafers4.Text);
                cmdinsert4.Parameters.AddWithValue("@3", cmbWaferRecipe4.Text);
                cmdinsert4.Parameters.AddWithValue("@4", cmbConditioningRecipe4.Text);
                cmdinsert4.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();



                SqlCommand cmd3 = new SqlCommand(strSQL, con);
                cmd3.Parameters.AddWithValue("@1", tbNoOfWafers3.Text);
                cmd3.Parameters.AddWithValue("@2", cmbWaferRecipe3.Text);
                cmd3.Parameters.AddWithValue("@3", cmbConditioningRecipe3.Text);
                cmd3.Parameters.AddWithValue("@id", lblid3.Text);



                cmd3.ExecuteNonQuery();



            }
            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text != "no")//從lblid2 insert 3筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinserttwo = new SqlCommand(insert2, con);

                cmdinserttwo.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinserttwo.Parameters.AddWithValue("@2", tbNoOfWafers5.Text);
                cmdinserttwo.Parameters.AddWithValue("@3", cmbWaferRecipe5.Text);
                cmdinserttwo.Parameters.AddWithValue("@4", cmbConditioningRecipe5.Text);
                cmdinserttwo.ExecuteNonQuery();


                SqlCommand cmdinsert4 = new SqlCommand(insert2, con);

                cmdinsert4.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert4.Parameters.AddWithValue("@2", tbNoOfWafers4.Text);
                cmdinsert4.Parameters.AddWithValue("@3", cmbWaferRecipe4.Text);
                cmdinsert4.Parameters.AddWithValue("@4", cmbConditioningRecipe4.Text);
                cmdinsert4.ExecuteNonQuery();

                SqlCommand cmdinsert3 = new SqlCommand(insert2, con);

                cmdinsert3.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert3.Parameters.AddWithValue("@2", tbNoOfWafers3.Text);
                cmdinsert3.Parameters.AddWithValue("@3", cmbWaferRecipe3.Text);
                cmdinsert3.Parameters.AddWithValue("@4", cmbConditioningRecipe3.Text);
                cmdinsert3.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@1", tbNoOfWafers2.Text);
                cmd2.Parameters.AddWithValue("@2", cmbWaferRecipe2.Text);
                cmd2.Parameters.AddWithValue("@3", cmbConditioningRecipe2.Text);
                cmd2.Parameters.AddWithValue("@id", lblid2.Text);



                cmd2.ExecuteNonQuery();




            }
            else if (strtag == "panel5" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text == "no")//從lblid insert 4筆
            {
                string insert2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe) values(@1,@2,@3,@4)";
                SqlCommand cmdinserttwo = new SqlCommand(insert2, con);

                cmdinserttwo.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinserttwo.Parameters.AddWithValue("@2", tbNoOfWafers5.Text);
                cmdinserttwo.Parameters.AddWithValue("@3", cmbWaferRecipe5.Text);
                cmdinserttwo.Parameters.AddWithValue("@4", cmbConditioningRecipe5.Text);
                cmdinserttwo.ExecuteNonQuery();


                SqlCommand cmdinsert4 = new SqlCommand(insert2, con);

                cmdinsert4.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert4.Parameters.AddWithValue("@2", tbNoOfWafers4.Text);
                cmdinsert4.Parameters.AddWithValue("@3", cmbWaferRecipe4.Text);
                cmdinsert4.Parameters.AddWithValue("@4", cmbConditioningRecipe4.Text);
                cmdinsert4.ExecuteNonQuery();

                SqlCommand cmdinsert3 = new SqlCommand(insert2, con);

                cmdinsert3.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert3.Parameters.AddWithValue("@2", tbNoOfWafers3.Text);
                cmdinsert3.Parameters.AddWithValue("@3", cmbWaferRecipe3.Text);
                cmdinsert3.Parameters.AddWithValue("@4", cmbConditioningRecipe3.Text);
                cmdinsert3.ExecuteNonQuery();

                SqlCommand cmdinsert2 = new SqlCommand(insert2, con);

                cmdinsert2.Parameters.AddWithValue("@1", RecipeType.strSearchName);
                cmdinsert2.Parameters.AddWithValue("@2", tbNoOfWafers2.Text);
                cmdinsert2.Parameters.AddWithValue("@3", cmbWaferRecipe2.Text);
                cmdinsert2.Parameters.AddWithValue("@4", cmbConditioningRecipe2.Text);
                cmdinsert2.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@1", tbNoOfWafers.Text);
                cmd.Parameters.AddWithValue("@2", cmbWaferRecipe.Text);
                cmd.Parameters.AddWithValue("@3", cmbConditioningRecipe.Text);
                cmd.Parameters.AddWithValue("@id", lblid.Text);



                cmd.ExecuteNonQuery();
            }


            else if (strtag == "panel6" && lblid6.Text != "no")
            {

                SqlCommand cmd6 = new SqlCommand(strSQL, con);
                cmd6.Parameters.AddWithValue("@1", tbNoOfWafers6.Text);
                cmd6.Parameters.AddWithValue("@2", cmbWaferRecipe6.Text);
                cmd6.Parameters.AddWithValue("@3", cmbConditioningRecipe6.Text);
                cmd6.Parameters.AddWithValue("@id", lblid6.Text);



                cmd6.ExecuteNonQuery();
            }

            else if (strtag == "panel6" && lblid16.Text == "no" && lblid5.Text != "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid5 insert 1筆
            {


            }
            else if (strtag == "panel6" && lblid16.Text == "no" && lblid5.Text == "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid4 insert 4筆
            {


            }
            else if (strtag == "panel6" && lblid16.Text == "no" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid3 insert 3筆
            {


            }
            else if (strtag == "panel6" && lblid16.Text == "no" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text != "no")//從lblid2 insert 4筆
            {


            }
            else if (strtag == "panel6" && lblid16.Text == "no" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text == "no")//從lblid insert 5筆
            {


            }







            else if (strtag == "panel7" && lblid7.Text != "no")
            {

                SqlCommand cmd7 = new SqlCommand(strSQL, con);
                cmd7.Parameters.AddWithValue("@1", tbNoOfWafers7.Text);
                cmd7.Parameters.AddWithValue("@2", cmbWaferRecipe7.Text);
                cmd7.Parameters.AddWithValue("@3", cmbConditioningRecipe7.Text);
                cmd7.Parameters.AddWithValue("@id", lblid7.Text);



                cmd7.ExecuteNonQuery();
            }
            else if (strtag == "panel7" && lblid7.Text == "no" && lblid6.Text != "no" && lblid5.Text != "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid6 insert 1筆
            {



            }
            else if (strtag == "panel7" && lblid7.Text == "no" && lblid6.Text == "no" && lblid5.Text != "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid5 insert 2筆
            {



            }
            else if (strtag == "panel7" && lblid7.Text == "no" && lblid6.Text == "no" && lblid5.Text == "no" && lblid4.Text != "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid4 insert 3筆
            {



            }
            else if (strtag == "panel7" && lblid7.Text == "no" && lblid6.Text == "no" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text != "no" && lblid2.Text != "no")//從lblid3 insert 4筆
            {



            }
            else if (strtag == "panel7" && lblid7.Text == "no" && lblid6.Text == "no" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text != "no")//從lblid2 insert 5筆
            {



            }
            else if (strtag == "panel7" && lblid7.Text == "no" && lblid6.Text == "no" && lblid5.Text == "no" && lblid4.Text == "no" && lblid3.Text == "no" && lblid2.Text == "no")//從lblid6 insert 1筆
            {



            }



            else if (strtag == "panel8" && lblid8.Text != "no")
            {
                SqlCommand cmd8 = new SqlCommand(strSQL, con);
                cmd8.Parameters.AddWithValue("@1", tbNoOfWafers8.Text);
                cmd8.Parameters.AddWithValue("@2", cmbWaferRecipe8.Text);
                cmd8.Parameters.AddWithValue("@3", cmbConditioningRecipe8.Text);
                cmd8.Parameters.AddWithValue("@id", lblid8.Text);



                cmd8.ExecuteNonQuery();
            }

            else if (strtag == "panel9")
            {
                SqlCommand cmd9 = new SqlCommand(strSQL, con);
                cmd9.Parameters.AddWithValue("@1", tbNoOfWafers9.Text);
                cmd9.Parameters.AddWithValue("@2", cmbWaferRecipe9.Text);
                cmd9.Parameters.AddWithValue("@3", cmbConditioningRecipe9.Text);
                cmd9.Parameters.AddWithValue("@id", lblid9.Text);



                cmd9.ExecuteNonQuery();
            }

            else if (strtag == "panel10")
            {
                SqlCommand cmd10 = new SqlCommand(strSQL, con);
                cmd10.Parameters.AddWithValue("@1", tbNoOfWafers10.Text);
                cmd10.Parameters.AddWithValue("@2", cmbWaferRecipe10.Text);
                cmd10.Parameters.AddWithValue("@3", cmbConditioningRecipe10.Text);
                cmd10.Parameters.AddWithValue("@id", lblid10.Text);



                cmd10.ExecuteNonQuery();
            }
            else if (strtag == "panel11")
            {
                SqlCommand cmd11 = new SqlCommand(strSQL, con);
                cmd11.Parameters.AddWithValue("@1", tbNoOfWafers11.Text);
                cmd11.Parameters.AddWithValue("@2", cmbWaferRecipe11.Text);
                cmd11.Parameters.AddWithValue("@3", cmbConditioningRecipe11.Text);
                cmd11.Parameters.AddWithValue("@id", lblid11.Text);



                cmd11.ExecuteNonQuery();
            }

            else if (strtag == "panel2")
            {
                SqlCommand cmd12 = new SqlCommand(strSQL, con);
                cmd12.Parameters.AddWithValue("@1", tbNoOfWafers12.Text);
                cmd12.Parameters.AddWithValue("@2", cmbWaferRecipe12.Text);
                cmd12.Parameters.AddWithValue("@3", cmbConditioningRecipe12.Text);
                cmd12.Parameters.AddWithValue("@id", lblid12.Text);



                cmd12.ExecuteNonQuery();
            }
            else if (strtag == "panel13")
            {
                SqlCommand cmd13 = new SqlCommand(strSQL, con);
                cmd13.Parameters.AddWithValue("@1", tbNoOfWafers13.Text);
                cmd13.Parameters.AddWithValue("@2", cmbWaferRecipe13.Text);
                cmd13.Parameters.AddWithValue("@3", cmbConditioningRecipe13.Text);
                cmd13.Parameters.AddWithValue("@id", lblid13.Text);



                cmd13.ExecuteNonQuery();
            }

            else if (strtag == "panel14")
            {
                SqlCommand cmd14 = new SqlCommand(strSQL, con);
                cmd14.Parameters.AddWithValue("@1", tbNoOfWafers14.Text);
                cmd14.Parameters.AddWithValue("@2", cmbWaferRecipe14.Text);
                cmd14.Parameters.AddWithValue("@3", cmbConditioningRecipe14.Text);
                cmd14.Parameters.AddWithValue("@id", lblid14.Text);



                cmd14.ExecuteNonQuery();
            }

            else if (strtag == "panel15")
            {
                SqlCommand cmd15 = new SqlCommand(strSQL, con);
                cmd15.Parameters.AddWithValue("@1", tbNoOfWafers15.Text);
                cmd15.Parameters.AddWithValue("@2", cmbWaferRecipe15.Text);
                cmd15.Parameters.AddWithValue("@3", cmbConditioningRecipe15.Text);
                cmd15.Parameters.AddWithValue("@id", lblid15.Text);



                cmd15.ExecuteNonQuery();
            }

            else if (strtag == "panel16")
            {
                SqlCommand cmd16 = new SqlCommand(strSQL, con);
                cmd16.Parameters.AddWithValue("@1", tbNoOfWafers16.Text);
                cmd16.Parameters.AddWithValue("@2", cmbWaferRecipe16.Text);
                cmd16.Parameters.AddWithValue("@3", cmbConditioningRecipe16.Text);
                cmd16.Parameters.AddWithValue("@id", lblid16.Text);



                cmd16.ExecuteNonQuery();
            }
            else if (strtag == "panel17")
            {

                SqlCommand cmd17 = new SqlCommand(strSQL, con);
                cmd17.Parameters.AddWithValue("@1", tbNoOfWafers17.Text);
                cmd17.Parameters.AddWithValue("@2", cmbWaferRecipe17.Text);
                cmd17.Parameters.AddWithValue("@3", cmbConditioningRecipe17.Text);
                cmd17.Parameters.AddWithValue("@id", lblid17.Text);



                cmd17.ExecuteNonQuery();

            }
            else if (strtag == "panel18")
            {
                SqlCommand cmd18 = new SqlCommand(strSQL, con);
                cmd18.Parameters.AddWithValue("@1", tbNoOfWafers18.Text);
                cmd18.Parameters.AddWithValue("@2", cmbWaferRecipe18.Text);
                cmd18.Parameters.AddWithValue("@3", cmbConditioningRecipe18.Text);
                cmd18.Parameters.AddWithValue("@id", lblid18.Text);



                cmd18.ExecuteNonQuery();
            }
            else if (strtag == "panel19")
            {

                SqlCommand cmd19 = new SqlCommand(strSQL, con);
                cmd19.Parameters.AddWithValue("@1", tbNoOfWafers19.Text);
                cmd19.Parameters.AddWithValue("@2", cmbWaferRecipe19.Text);
                cmd19.Parameters.AddWithValue("@3", cmbConditioningRecipe19.Text);
                cmd19.Parameters.AddWithValue("@id", lblid19.Text);



                cmd19.ExecuteNonQuery();
            }

            else if (strtag == "panel20")
            {
                SqlCommand cmd20 = new SqlCommand(strSQL, con);
                cmd20.Parameters.AddWithValue("@1", tbNoOfWafers20.Text);
                cmd20.Parameters.AddWithValue("@2", cmbWaferRecipe20.Text);
                cmd20.Parameters.AddWithValue("@3", cmbConditioningRecipe20.Text);
                cmd20.Parameters.AddWithValue("@id", lblid20.Text);



                cmd20.ExecuteNonQuery();
            }
            con.Close();

          
           



       

         

            MessageBox.Show("Save Successfully");
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            // RecipeType rct = new RecipeType();
            SqlConnection con = new SqlConnection(scsb.ToString());



            con.Open();

            string strSQL = "insert into CassetteRecipe (CassetterecipeName,CassetterecipeDate) values(@NewrecipeName,@NewrecipeDate)";

            string strSQL1 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4)";
            string strSQL2 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42)";
            string strSQL3 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43)";
            string strSQL4 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44)";
            string strSQL5 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45)";
            string strSQL6 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46)";
            string strSQL7 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47)";
            string strSQL8 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48)";
            string strSQL9 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)";
            string strSQL10 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410)";
            string strSQL11 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411)";
            string strSQL12 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412)";
            string strSQL13 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413)";
            string strSQL14 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414)";
            string strSQL15 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415)";
            string strSQL16 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416)";
            string strSQL17 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416),(@117,@217,@317,@417)";
            string strSQL18 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416),(@117,@217,@317,@417),(@118,@218,@318,@418)";
            string strSQL19 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416),(@117,@217,@317,@417),(@118,@218,@318,@418),(@119,@219,@319,@419)";
            string strSQL20 = "insert into cassettewafer(cassetterecipename,noofwafers,waferrecipe,conditioningrecipe)values(@1,@2,@3,@4),(@12,@22,@32,@42),(@13,@23,@33,@43),(@14,@24,@34,@44),(@15,@25,@35,@45),(@16,@26,@36,@46),(@17,@27,@37,@47),(@18,@28,@38,@48),(@19,@29,@39,@49)" +
                ",(@110,@210,@310,@410),(@111,@211,@311,@411),(@112,@212,@312,@412),(@113,@213,@313,@413),(@114,@214,@314,@414),(@115,@215,@315,@415),(@116,@216,@316,@416),(@117,@217,@317,@417),(@118,@218,@318,@418),(@119,@219,@319,@419),(@120,@220,@320,@420)";
            SqlCommand cmd = new SqlCommand(strSQL, con);


            CustomMessageBox messgebox = new CustomMessageBox();
            DialogResult dr = messgebox.ShowDialog();
            if (dr == DialogResult.OK && tbNoOfWafers.Text.Length > 0)
            {

                //recipeName=  messgebox.GetMsg();
                cmd.Parameters.AddWithValue("@NewrecipeName", messgebox.GetMsg().ToString());
                cmd.Parameters.AddWithValue("@NewrecipeDate", DateTime.Now);
                // SqlDataReader reader1 = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();


                con.Close();

                con.Open();
                //reader1.Close();

                if (strtag == "panel1")
                {
                    if (tbNoOfWafers.Text.Length > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand(strSQL1, con);
                        cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                        cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                        cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                        cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);

                        cmd1.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("123");
                    }
                }
                else if (strtag == "panel2")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL2, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);

                    cmd1.ExecuteNonQuery();
                }
                else if (strtag == "panel3")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL3, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3.Text);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3.Text);

                    cmd1.ExecuteNonQuery();


                }
                else if (strtag == "panel4")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL4, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3.Text);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4.Text);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4.Text);
                    cmd1.ExecuteNonQuery();




                }
                else if (strtag == "panel5")
                {

                    SqlCommand cmd1 = new SqlCommand(strSQL5, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3.Text);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4.Text);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5.Text);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5.Text);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5.Text);
                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel6")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL6, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3.Text);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4.Text);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5.Text);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5.Text);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5.Text);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6.Text);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6.Text);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6.Text);
                    cmd1.ExecuteNonQuery();




                }
                else if (strtag == "panel7")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL7, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers.Text);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe.Text);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe.Text);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2.Text);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2.Text);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3.Text);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3.Text);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4.Text);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4.Text);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5.Text);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5.Text);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5.Text);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6.Text);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6.Text);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6.Text);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7.Text);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7.Text);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7.Text);

                    cmd1.ExecuteNonQuery();



                }
                else if (strtag == "panel8")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL8, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);

                    cmd1.ExecuteNonQuery();


                }
                else if (strtag == "panel9")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL9, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);

                    cmd1.ExecuteNonQuery();



                }
                else if (strtag == "panel10")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL10, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);

                    cmd1.ExecuteNonQuery();




                }
                else if (strtag == "panel11")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL11, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);

                    cmd1.ExecuteNonQuery();





                }


                else if (strtag == "panel12")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL12, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);

                    cmd1.ExecuteNonQuery();





                }

                else if (strtag == "panel13")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL13, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);

                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel14")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL14, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);

                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel15")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL15, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);


                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel16")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL16, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);

                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel17")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL17, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);
                    cmd1.Parameters.AddWithValue("@117", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@217", tbNoOfWafers17);
                    cmd1.Parameters.AddWithValue("@317", cmbWaferRecipe17);
                    cmd1.Parameters.AddWithValue("@417", cmbConditioningRecipe17);


                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel18")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL18, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);
                    cmd1.Parameters.AddWithValue("@117", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@217", tbNoOfWafers17);
                    cmd1.Parameters.AddWithValue("@317", cmbWaferRecipe17);
                    cmd1.Parameters.AddWithValue("@417", cmbConditioningRecipe17);
                    cmd1.Parameters.AddWithValue("@118", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@218", tbNoOfWafers18);
                    cmd1.Parameters.AddWithValue("@318", cmbWaferRecipe18);
                    cmd1.Parameters.AddWithValue("@418", cmbConditioningRecipe18);


                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel19")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL19, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);
                    cmd1.Parameters.AddWithValue("@117", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@217", tbNoOfWafers17);
                    cmd1.Parameters.AddWithValue("@317", cmbWaferRecipe17);
                    cmd1.Parameters.AddWithValue("@417", cmbConditioningRecipe17);
                    cmd1.Parameters.AddWithValue("@118", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@218", tbNoOfWafers18);
                    cmd1.Parameters.AddWithValue("@318", cmbWaferRecipe18);
                    cmd1.Parameters.AddWithValue("@418", cmbConditioningRecipe18);
                    cmd1.Parameters.AddWithValue("@119", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@219", tbNoOfWafers19);
                    cmd1.Parameters.AddWithValue("@319", cmbWaferRecipe19);
                    cmd1.Parameters.AddWithValue("@419", cmbConditioningRecipe19);


                    cmd1.ExecuteNonQuery();





                }
                else if (strtag == "panel20")
                {
                    SqlCommand cmd1 = new SqlCommand(strSQL20, con);
                    cmd1.Parameters.AddWithValue("@1", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@2", tbNoOfWafers);
                    cmd1.Parameters.AddWithValue("@3", cmbWaferRecipe);
                    cmd1.Parameters.AddWithValue("@4", cmbConditioningRecipe);
                    cmd1.Parameters.AddWithValue("@12", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@22", tbNoOfWafers2);
                    cmd1.Parameters.AddWithValue("@32", cmbWaferRecipe2);
                    cmd1.Parameters.AddWithValue("@42", cmbConditioningRecipe2);
                    cmd1.Parameters.AddWithValue("@13", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@23", tbNoOfWafers3);
                    cmd1.Parameters.AddWithValue("@33", cmbWaferRecipe3);
                    cmd1.Parameters.AddWithValue("@43", cmbConditioningRecipe3);
                    cmd1.Parameters.AddWithValue("@14", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@24", tbNoOfWafers4);
                    cmd1.Parameters.AddWithValue("@34", cmbWaferRecipe4);
                    cmd1.Parameters.AddWithValue("@44", cmbConditioningRecipe4);
                    cmd1.Parameters.AddWithValue("@15", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@25", tbNoOfWafers5);
                    cmd1.Parameters.AddWithValue("@35", cmbWaferRecipe5);
                    cmd1.Parameters.AddWithValue("@45", cmbConditioningRecipe5);
                    cmd1.Parameters.AddWithValue("@16", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@26", tbNoOfWafers6);
                    cmd1.Parameters.AddWithValue("@36", cmbWaferRecipe6);
                    cmd1.Parameters.AddWithValue("@46", cmbConditioningRecipe6);
                    cmd1.Parameters.AddWithValue("@17", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@27", tbNoOfWafers7);
                    cmd1.Parameters.AddWithValue("@37", cmbWaferRecipe7);
                    cmd1.Parameters.AddWithValue("@47", cmbConditioningRecipe7);
                    cmd1.Parameters.AddWithValue("@18", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@28", tbNoOfWafers8);
                    cmd1.Parameters.AddWithValue("@38", cmbWaferRecipe8);
                    cmd1.Parameters.AddWithValue("@48", cmbConditioningRecipe8);
                    cmd1.Parameters.AddWithValue("@19", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@29", tbNoOfWafers9);
                    cmd1.Parameters.AddWithValue("@39", cmbWaferRecipe9);
                    cmd1.Parameters.AddWithValue("@49", cmbConditioningRecipe9);
                    cmd1.Parameters.AddWithValue("@110", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@210", tbNoOfWafers10);
                    cmd1.Parameters.AddWithValue("@310", cmbWaferRecipe10);
                    cmd1.Parameters.AddWithValue("@410", cmbConditioningRecipe10);
                    cmd1.Parameters.AddWithValue("@111", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@211", tbNoOfWafers11);
                    cmd1.Parameters.AddWithValue("@311", cmbWaferRecipe11);
                    cmd1.Parameters.AddWithValue("@411", cmbConditioningRecipe11);
                    cmd1.Parameters.AddWithValue("@112", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@212", tbNoOfWafers12);
                    cmd1.Parameters.AddWithValue("@312", cmbWaferRecipe12);
                    cmd1.Parameters.AddWithValue("@412", cmbConditioningRecipe12);
                    cmd1.Parameters.AddWithValue("@113", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@213", tbNoOfWafers13);
                    cmd1.Parameters.AddWithValue("@313", cmbWaferRecipe13);
                    cmd1.Parameters.AddWithValue("@413", cmbConditioningRecipe13);
                    cmd1.Parameters.AddWithValue("@114", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@214", tbNoOfWafers14);
                    cmd1.Parameters.AddWithValue("@314", cmbWaferRecipe14);
                    cmd1.Parameters.AddWithValue("@414", cmbConditioningRecipe14);
                    cmd1.Parameters.AddWithValue("@115", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@215", tbNoOfWafers15);
                    cmd1.Parameters.AddWithValue("@315", cmbWaferRecipe15);
                    cmd1.Parameters.AddWithValue("@415", cmbConditioningRecipe15);
                    cmd1.Parameters.AddWithValue("@116", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@216", tbNoOfWafers16);
                    cmd1.Parameters.AddWithValue("@316", cmbWaferRecipe16);
                    cmd1.Parameters.AddWithValue("@416", cmbConditioningRecipe16);
                    cmd1.Parameters.AddWithValue("@117", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@217", tbNoOfWafers17);
                    cmd1.Parameters.AddWithValue("@317", cmbWaferRecipe17);
                    cmd1.Parameters.AddWithValue("@417", cmbConditioningRecipe17);
                    cmd1.Parameters.AddWithValue("@118", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@218", tbNoOfWafers18);
                    cmd1.Parameters.AddWithValue("@318", cmbWaferRecipe18);
                    cmd1.Parameters.AddWithValue("@418", cmbConditioningRecipe18);
                    cmd1.Parameters.AddWithValue("@119", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@219", tbNoOfWafers19);
                    cmd1.Parameters.AddWithValue("@319", cmbWaferRecipe19);
                    cmd1.Parameters.AddWithValue("@419", cmbConditioningRecipe19);
                    cmd1.Parameters.AddWithValue("@120", messgebox.GetMsg().ToString());
                    cmd1.Parameters.AddWithValue("@20", tbNoOfWafers20);
                    cmd1.Parameters.AddWithValue("@320", cmbWaferRecipe20);
                    cmd1.Parameters.AddWithValue("@420", cmbConditioningRecipe20);


                    cmd1.ExecuteNonQuery();





                }
                con.Close();
                MessageBox.Show("Save Successfully");
                /////////////////////////////////////////////////清空暫存資料表
                con.Open();
                string strSQLtruncate = "TRUNCATE table TemCassetteWafer";
                SqlCommand cmdClear = new SqlCommand(strSQLtruncate, con);
                cmdClear.ExecuteNonQuery();
                con.Close();
                ////////////////////////////////////////清空集合

              




                ////////////////////////////////////////更新RecipType.listboxrecipeName

                updatelistbox(sender, e);

                //RecipeType recipe = new RecipeType();
                // RecipeType.update();

                //recipetype.btnCassette_Click();
                // recipetype.btnCassette_Click(sender,e);

                //  UpdateListbox updatelistbox = new UpdateListbox();


                // RecipeType recipetype = new RecipeType();
                // recipetype.update();



            }
            else
            {
                MessageBox.Show("Field No of wafers can not be blank");
            }




        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cmbWaferRecipe.SelectedItem.ToString().Length > 0|| cmbWaferRecipe2.SelectedItem.ToString().Length > 0)
            {
                /*  selectwaferrecipe = cmbWaferRecipe.SelectedItem.ToString();
                  SqlConnection con = new SqlConnection(scsb.ToString());
                  con.Open();
                  string strSQL = "select * from newrecipe where recipename like @1";
                  SqlCommand cmd = new SqlCommand(strSQL, con);
                  cmd.Parameters.AddWithValue("@1", selectwaferrecipe);*/
                Openrecipe2 openrecipe = new Openrecipe2();
                openrecipe.ShowDialog();

            }




        }

        private void cmbWaferRecipe_Click(object sender, EventArgs e)
        {
            strsearchname = cmbWaferRecipe.SelectedItem.ToString();
        }

        private void cmbWaferRecipe2_Click(object sender, EventArgs e)
        {
            strsearchname = cmbWaferRecipe2.SelectedItem.ToString();
        }
    }
}
