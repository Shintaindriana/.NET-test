using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb
{
    public partial class DataMasukEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            TCGEntities tcg = new TCGEntities();
            cmbKodeCabang.DataSource = tcg.TCG_MASTER_CABANG.ToList();
            cmbKodeCabang.DataBind();
            cmbKodeSupplier.DataSource = tcg.TCG_MASTER_SUPPLIER_BARANG.ToList();
            cmbKodeSupplier.DataBind();
        }
        //protected void imgCal_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (cld.Visible)
        //    {
        //        cld.Visible = false;
        //    }
        //    else
        //        cld.Visible = true;

            
        //}

        //protected void cld_SelectionChanged(object sender, EventArgs e)
        //{
        //    txtTanggal.Text = cld.SelectedDate.ToString("dd/MM/yyyy");
        //    cld.Visible = false;
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.mp1.Show();
        }

        protected void cmbDataBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbDataBarang.SelectedValue.ToString();
            TCGEntities tcg = new TCGEntities();
            var list = tcg.TCG_DATA_BARANG.ToList().Where(p => p.KD_BARANG == value).ToList();
            grdBarang.DataSource = list;
            this.mp1.Hide();
        }
    }
}