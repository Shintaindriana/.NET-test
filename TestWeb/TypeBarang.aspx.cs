using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb
{
    public partial class TypeBarang : System.Web.UI.Page
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
            Session["item"] = tcg.TCG_MASTER_TYPE_BRG.ToList();
            grdType.DataSource = Session["item"];
            grdType.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Add Master Type Barang";
            txtKode.Text = "";
            txtNama.Text = "";

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
                TCG_MASTER_TYPE_BRG model = new TCG_MASTER_TYPE_BRG();
                model.KODE_TYPE = txtKode.Text;
                model.NAMA_TYPE_BARANG = txtNama.Text;

                tCG.TCG_MASTER_TYPE_BRG.Add(model);
                tCG.SaveChanges();

                this.mp1.Hide();


            }
            else
            {

                //string q = "UPDATE TCG_MASTER_INS_BRG SET KODE_JENIS='"+txtKode.Text+"',NAMA_JENIS_BARANG='"+txtNama.Text+"' WHERE KODE_JENIS ='"+txtKode.Text+"'";
                //SqlCommand cmd = new SqlCommand(q, con);
                //cmd.ExecuteNonQuery();
                TCGEntities tCG = new TCGEntities();
                TCG_MASTER_TYPE_BRG model = new TCG_MASTER_TYPE_BRG();
                model.KODE_TYPE = txtKode.Text;
                model.NAMA_TYPE_BARANG = txtNama.Text;

                tCG.Entry(model).State = EntityState.Modified;
                tCG.SaveChanges();

                this.mp1.Hide();


            }
            LoadGrid();
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            lblHeader.Text = "Edit Master Type Barang";

            GridViewRow row = grdType.Rows[rowIndex];
            txtKode.Text = row.Cells[2].Text;
            txtNama.Text = row.Cells[3].Text;

            this.mp1.Show();
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            TCGEntities tcg = new TCGEntities();

            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            GridViewRow row = grdType.Rows[rowIndex];

            TCG_MASTER_TYPE_BRG model = new TCG_MASTER_TYPE_BRG();
            model.KODE_TYPE = row.Cells[2].Text;
            model.NAMA_TYPE_BARANG = row.Cells[3].Text;

            var entry = tcg.Entry(model);

            tcg.TCG_MASTER_TYPE_BRG.Attach(model);
            tcg.TCG_MASTER_TYPE_BRG.Remove(model);
            tcg.SaveChanges();



            LoadGrid();
        }
    }
}