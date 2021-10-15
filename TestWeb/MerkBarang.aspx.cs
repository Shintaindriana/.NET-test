using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb
{
    public partial class MerkBarang : System.Web.UI.Page
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
            Session["item"] = tcg.TCG_MASTER_MERK_BRG.ToList();
            grdMerk.DataSource = Session["item"];
            grdMerk.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Add Master Merk Barang";
            txtKode.Text = "";
            txtNama.Text = "";
            txtTlp.Text = "";
            txtAlamat.Text = "";
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
                TCG_MASTER_MERK_BRG model = new TCG_MASTER_MERK_BRG();
                model.KODE_MERK = txtKode.Text;
                model.NAMA_DISTRIBUTOR = txtNama.Text;
                model.TELEPON = txtTlp.Text;
                model.ALAMAT = txtAlamat.Text;
                tCG.TCG_MASTER_MERK_BRG.Add(model);
                tCG.SaveChanges();

                this.mp1.Hide();


            }
            else
            {

                //string q = "UPDATE TCG_MASTER_INS_BRG SET KODE_JENIS='"+txtKode.Text+"',NAMA_JENIS_BARANG='"+txtNama.Text+"' WHERE KODE_JENIS ='"+txtKode.Text+"'";
                //SqlCommand cmd = new SqlCommand(q, con);
                //cmd.ExecuteNonQuery();
                TCGEntities tCG = new TCGEntities();
                TCG_MASTER_MERK_BRG model = new TCG_MASTER_MERK_BRG();
                model.KODE_MERK = txtKode.Text;
                model.NAMA_DISTRIBUTOR = txtNama.Text;
                model.TELEPON = txtTlp.Text;
                model.ALAMAT = txtAlamat.Text;
                tCG.Entry(model).State = EntityState.Modified;
                tCG.SaveChanges();

                this.mp1.Hide();


            }
            LoadGrid();
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            lblHeader.Text = "Edit Master Merk Barang";

            GridViewRow row = grdMerk.Rows[rowIndex];
            txtKode.Text = row.Cells[2].Text;
            txtNama.Text = row.Cells[3].Text;
            txtTlp.Text = row.Cells[4].Text;
            txtAlamat.Text = row.Cells[5].Text;
            //GridView gv = sender as GridView;
            //GridViewRow gvr = (GridViewRow)(sender as ImageButton).NamingContainer;
            //txtKode.Text = ((Label)gvr.FindControl("KODE_JENIS")).Text;

            this.mp1.Show();
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            TCGEntities tcg = new TCGEntities();

            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            GridViewRow row = grdMerk.Rows[rowIndex];

            TCG_MASTER_MERK_BRG model = new TCG_MASTER_MERK_BRG();
            model.KODE_MERK = row.Cells[2].Text;
            model.NAMA_DISTRIBUTOR = row.Cells[3].Text;
            model.TELEPON = row.Cells[4].Text;
            model.ALAMAT = row.Cells[5].Text;
            var entry = tcg.Entry(model);

            tcg.TCG_MASTER_MERK_BRG.Attach(model);
            tcg.TCG_MASTER_MERK_BRG.Remove(model);
            tcg.SaveChanges();



            LoadGrid();
        }
    }
}