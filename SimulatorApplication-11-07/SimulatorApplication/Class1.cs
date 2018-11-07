using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorApplication
{
    class Class1
    {
        SqlConnectionStringBuilder scsb;

        public void update()
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"HP-PC\SQLEXPRESS";
            scsb.InitialCatalog = "RecipeType";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();




        }
    



    }
}
