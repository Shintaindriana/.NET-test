using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TestWeb
{
    public partial class Test : System.Web.UI.Page
    {

        public string constring = "Data Source=.\\SQLEXPRESS;Initial Catalog=TCG;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            if(con.State==System.Data.ConnectionState.Open)
            {
                string q = "insert into TCG_MASTER_INS_BRG (KODE_JENIS, NAMA_JENIS_BARANG) VALUES ('AB', 'ABCD')";
                SqlCommand cmd = new SqlCommand(q,con);
                cmd.ExecuteNonQuery();
                
            }
        }
    }
}