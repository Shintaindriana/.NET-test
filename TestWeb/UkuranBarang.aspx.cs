using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb
{
    public partial class UkuranBarang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        public void LoadGrid()
        {
            TCGEntities tcg = new TCGEntities();
            //TCG_MASTER_INS_BRG jns = new TCG_MASTER_INS_BRG();
            Session["item"] = tcg.TCG_MASTER_UKURAN.ToList();
            grdUkuran.DataSource = Session["item"];
            grdUkuran.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Add Master Ukuran Barang";
            txtKode.Text = "";
            txtUkuran.Text = "";
            txtM.Text = "";
            txt1.Text = "";

            this.mp1.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblHeader.Text.Contains("Add"))
            {


                //string q = "insert into TCG_MASTER_INS_BRG (KODE_JENIS, NAMA_JENIS_BARANG) VALUES ('" + txtKode.Text + "', '" + txtNama.Text + "')";
                //SqlCommand cmd = new SqlCommand(q, con);
                //cmd.ExecuteNonQuery();

                TCGEntities tCG = new TCGEntities();
                TCG_MASTER_UKURAN model = new TCG_MASTER_UKURAN();
                model.KODE_UKURAN = txtKode.Text;
                model.UKURAN = txtUkuran.Text;
                model.JUMLAH_1_DUS = Convert.ToInt32(txt1.Text);
                model.JUMLAH_M2_DUS = txtM.Text;

                tCG.TCG_MASTER_UKURAN.Add(model);
                tCG.SaveChanges();

                this.mp1.Hide();


            }
            else
            {

                //string q = "UPDATE TCG_MASTER_INS_BRG SET KODE_JENIS='"+txtKode.Text+"',NAMA_JENIS_BARANG='"+txtNama.Text+"' WHERE KODE_JENIS ='"+txtKode.Text+"'";
                //SqlCommand cmd = new SqlCommand(q, con);
                //cmd.ExecuteNonQuery();
                TCGEntities tCG = new TCGEntities();
                TCG_MASTER_UKURAN model = new TCG_MASTER_UKURAN();
                model.KODE_UKURAN = txtKode.Text;
                model.UKURAN = txtUkuran.Text;
                model.JUMLAH_1_DUS = Convert.ToInt32(txt1.Text);
                model.JUMLAH_M2_DUS = txtM.Text;

                tCG.Entry(model).State = EntityState.Modified;
                tCG.SaveChanges();

                this.mp1.Hide();


            }
            LoadGrid();
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            lblHeader.Text = "Edit Master Ukuran Barang";

            GridViewRow row = grdUkuran.Rows[rowIndex];
            txtKode.Text = row.Cells[2].Text;
            txtUkuran.Text = row.Cells[3].Text;
            txt1.Text = row.Cells[4].Text;
            txtM.Text = row.Cells[5].Text;

            this.mp1.Show();
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            TCGEntities tcg = new TCGEntities();

            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            GridViewRow row = grdUkuran.Rows[rowIndex];

            TCG_MASTER_UKURAN model = new TCG_MASTER_UKURAN();
            model.KODE_UKURAN = row.Cells[2].Text;
            model.UKURAN = row.Cells[3].Text;
            model.JUMLAH_1_DUS = Convert.ToInt32(row.Cells[4].Text);
            model.JUMLAH_M2_DUS = row.Cells[5].Text;

            var entry = tcg.Entry(model);

            tcg.TCG_MASTER_UKURAN.Attach(model);
            tcg.TCG_MASTER_UKURAN.Remove(model);
            tcg.SaveChanges();



            LoadGrid();
        }
    }
}