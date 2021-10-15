using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TestWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        public string constring = "Data Source=.\\SQLEXPRESS;Initial Catalog=TCG;Integrated Security=True";

        public void LoadGrid()
        {
            TCGEntities tcg = new TCGEntities();
            //TCG_MASTER_INS_BRG jns = new TCG_MASTER_INS_BRG();
            var item = tcg.TCG_MASTER_INS_BRG.ToList();
            grdJenis.DataSource = item;
            grdJenis.DataBind();

        }
    }
}