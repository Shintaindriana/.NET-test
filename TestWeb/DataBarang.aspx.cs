using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb
{
    public partial class DataBarang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
                LoadGrid();
            }
        }

        public void Init()
        {
            TCGEntities tcg = new TCGEntities();
            //TCG_MASTER_INS_BRG jns = new TCG_MASTER_INS_BRG();
            cmbMerk.DataSource = tcg.TCG_MASTER_MERK_BRG.ToList();
            cmbMerk.DataBind();

            cmbJenis.DataSource = tcg.TCG_MASTER_INS_BRG.ToList();
            cmbJenis.DataBind();

            cmbSup.DataSource = tcg.TCG_MASTER_SUPPLIER_BARANG.ToList();
            cmbSup.DataBind();

            cmbType.DataSource = tcg.TCG_MASTER_TYPE_BRG.ToList();
            cmbType.DataBind();

            cmbUkuran.DataSource = tcg.TCG_MASTER_UKURAN.ToList();
            cmbUkuran.DataBind();

        }

        public void LoadGrid()
        {
            TCGEntities tcg = new TCGEntities();
            //TCG_MASTER_INS_BRG jns = new TCG_MASTER_INS_BRG();
            var data = tcg.TCG_DATA_BARANG.ToList();
            var jenis = tcg.TCG_MASTER_INS_BRG.ToList();
            var merk = tcg.TCG_MASTER_MERK_BRG.ToList();
            var supplier = tcg.TCG_MASTER_SUPPLIER_BARANG.ToList();
            var ukuran = tcg.TCG_MASTER_UKURAN.ToList();
            var type = tcg.TCG_MASTER_TYPE_BRG.ToList();

            var query = (from d in data
                         join j in jenis on d.KODE_JENIS equals j.KODE_JENIS
                         join m in merk on d.KODE_MERK equals m.KODE_MERK
                         join s in supplier on d.KODE_SUPPLIER equals s.KODE_SUPPLIER
                         join u in ukuran on d.KODE_UKURAN equals u.KODE_UKURAN
                         join t in type on d.KODE_TYPE equals t.KODE_TYPE
                         select new
                         {
                             d.KD_BARANG,
                             d.ID,
                             m.NAMA_DISTRIBUTOR,
                             d.NAMA_BARANG,
                             d.SERI,
                             j.NAMA_JENIS_BARANG,
                             t.NAMA_TYPE_BARANG,
                             u.UKURAN,
                             s.KODE_SUPPLIER,
                             d.HARGA_SUPPLIER,
                             d.HARGA_JUAL_TCG,
                             d.STOK_BARANG,
                             d.KETERANGAN
                         }).ToList();
            grdBarang.DataSource = query;
            grdBarang.DataBind();

        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            TCGEntities tcg = new TCGEntities();

            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            GridViewRow row = grdBarang.Rows[rowIndex];

            TCG_DATA_BARANG model = new TCG_DATA_BARANG();

            model.KD_BARANG = row.Cells[2].Text;
            model.ID = Convert.ToInt32(row.Cells[3].Text);
            model.KODE_MERK = cmbMerk.Items.FindByText(row.Cells[4].Text).ToString();
            model.NAMA_BARANG = row.Cells[5].Text;
            model.SERI = row.Cells[6].Text;
            model.KODE_JENIS = cmbJenis.Items.FindByText(row.Cells[7].Text).ToString();
            model.KODE_TYPE = cmbType.Items.FindByText(row.Cells[8].Text).ToString();
            model.KODE_UKURAN = cmbUkuran.Items.FindByText(row.Cells[9].Text).ToString();
            model.KODE_SUPPLIER = cmbSup.Items.FindByText(row.Cells[10].Text).ToString();
            model.HARGA_SUPPLIER = Convert.ToDecimal(row.Cells[11].Text);
            model.HARGA_JUAL_TCG = Convert.ToDecimal(row.Cells[12].Text);
            model.STOK_BARANG = Convert.ToInt32(row.Cells[13].Text);
            model.KETERANGAN = row.Cells[14].Text;
            var entry = tcg.Entry(model);

            tcg.TCG_DATA_BARANG.Attach(model);
            tcg.TCG_DATA_BARANG.Remove(model);
            tcg.SaveChanges();



            LoadGrid();

        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            lblHeader.Text = "Edit Data Barang";

            GridViewRow row = grdBarang.Rows[rowIndex];
            txtKode.Text = row.Cells[2].Text;
            txtID.Text = row.Cells[3].Text;
            cmbMerk.Items.FindByText(row.Cells[4].Text).Selected = true;
            txtNama.Text = row.Cells[5].Text;
            txtSeri.Text = row.Cells[6].Text;
            //cmbJenis.Items.FindByText(row.Cells[7].Text).Selected = true;
            cmbJenis.SelectedValue = "EF";
            cmbType.Items.FindByText(row.Cells[8].Text).Selected = true;
            cmbUkuran.Items.FindByText(row.Cells[9].Text).Selected = true;
            cmbSup.Items.FindByText(row.Cells[10].Text).Selected = true;
            txtHargaSup.Text = row.Cells[11].Text;
            txtHargaJu.Text = row.Cells[12].Text;
            txtStok.Text = row.Cells[13].Text;
            txtCat.Text = row.Cells[14].Text;

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
                TCG_DATA_BARANG model = new TCG_DATA_BARANG();
                model.KD_BARANG = txtKode.Text;
                model.ID = Convert.ToInt32(txtID.Text);
                model.KODE_MERK = cmbMerk.SelectedItem.Value;
                model.NAMA_BARANG = txtNama.Text;
                model.SERI = txtSeri.Text;
                model.KODE_JENIS = cmbJenis.SelectedItem.Value;
                model.KODE_TYPE = cmbType.SelectedItem.Value;
                model.KODE_UKURAN = cmbUkuran.SelectedItem.Value;
                model.KODE_SUPPLIER = cmbSup.SelectedItem.Value;
                model.HARGA_SUPPLIER = Convert.ToDecimal(txtHargaSup.Text);
                model.HARGA_JUAL_TCG = Convert.ToDecimal(txtHargaJu.Text);
                model.STOK_BARANG = Convert.ToInt32(txtStok.Text);
                model.HARGA_JUAL_SUPPLIER = Convert.ToInt32(txtJualSup.Text);
                model.KETERANGAN = txtCat.Text;
                tCG.TCG_DATA_BARANG.Add(model);
                tCG.SaveChanges();

                this.mp1.Hide();


            }
            else
            {

                //string q = "UPDATE TCG_MASTER_INS_BRG SET KODE_JENIS='"+txtKode.Text+"',NAMA_JENIS_BARANG='"+txtNama.Text+"' WHERE KODE_JENIS ='"+txtKode.Text+"'";
                //SqlCommand cmd = new SqlCommand(q, con);
                //cmd.ExecuteNonQuery();
                TCGEntities tCG = new TCGEntities();
                TCG_DATA_BARANG model = new TCG_DATA_BARANG();
                model.KD_BARANG = txtKode.Text;
                model.ID = Convert.ToInt32(txtID.Text);
                model.KODE_MERK = cmbMerk.SelectedItem.Value;
                model.NAMA_BARANG = txtNama.Text;
                model.SERI = txtSeri.Text;
                model.KODE_JENIS = cmbJenis.SelectedItem.Value;
                model.KODE_TYPE = cmbType.SelectedItem.Value;
                model.KODE_UKURAN = cmbUkuran.SelectedItem.Value;
                model.KODE_SUPPLIER = cmbSup.SelectedItem.Value;
                model.HARGA_SUPPLIER = Convert.ToDecimal(txtHargaSup.Text);
                model.HARGA_JUAL_TCG = Convert.ToDecimal(txtHargaJu.Text);
                model.STOK_BARANG = Convert.ToInt32(txtStok.Text);
                model.KETERANGAN = txtCat.Text;
                tCG.Entry(model).State = EntityState.Modified;
                tCG.SaveChanges();

                this.mp1.Hide();


            }
            LoadGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Add Data Barang";
            txtKode.Text = "";
            txtNama.Text = "";
            txtCat.Text = "";
            txtHargaJu.Text = "";
            txtHargaSup.Text = "";
            txtID.Text = "";
            txtSeri.Text = "";
            txtStok.Text = "";
            this.mp1.Show();
        }

        
    }
}