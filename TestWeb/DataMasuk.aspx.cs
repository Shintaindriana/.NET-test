using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace TestWeb
{
    public partial class DataMasuk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
                LoadGrid();
                cld.Visible = false;
            }
        }

        public void Init()
        {
            TCGEntities tcg = new TCGEntities();
            TCG_DATA_BARANG jns = new TCG_DATA_BARANG();
            cmbNamaBarang.DataSource = tcg.TCG_DATA_BARANG.ToList();
            cmbNamaBarang.DataBind();

            //cmbJenis.DataSource = tcg.TCG_MASTER_INS_BRG.ToList();
            //cmbJenis.DataBind();

            //cmbSup.DataSource = tcg.TCG_MASTER_SUPPLIER_BARANG.ToList();
            //cmbSup.DataBind();

            //cmbType.DataSource = tcg.TCG_MASTER_TYPE_BRG.ToList();
            //cmbType.DataBind();

            //cmbUkuran.DataSource = tcg.TCG_MASTER_UKURAN.ToList();
            //cmbUkuran.DataBind();

        }

        public void LoadGrid()
        {
            TCGEntities tcg = new TCGEntities();
            var masukDetail = tcg.TCG_D_BARANG_MASUK.ToList();
            var masukHeader = tcg.TCG_H_BARANG_MASUK.ToList();
            var data = tcg.TCG_DATA_BARANG.ToList();
            var jenis = tcg.TCG_MASTER_INS_BRG.ToList();
            var merk = tcg.TCG_MASTER_MERK_BRG.ToList();
            var supplier = tcg.TCG_MASTER_SUPPLIER_BARANG.ToList();
            var ukuran = tcg.TCG_MASTER_UKURAN.ToList();
            var type = tcg.TCG_MASTER_TYPE_BRG.ToList();

            var query = (from h in masukHeader
                         join d in masukDetail on h.KD_TRANSAKSI equals d.KD_TRANSAKSI
                         join dta in data on d.KODE_BARANG equals dta.KD_BARANG
                         join m in merk on d.KODE_MERK equals m.KODE_MERK
                         join s in supplier on h.KODE_SUPPLIER equals s.KODE_SUPPLIER
                         join u in ukuran on d.KODE_UKURAN equals u.KODE_UKURAN
                         join t in type on d.KODE_TYPE equals t.KODE_TYPE
                         join j in jenis on d.KODE_JENIS equals j.KODE_JENIS
                         select new
                         {
                             d.PKID,
                             h.TGL_TRANSAKSI,
                             h.KD_TRANSAKSI,
                             d.KODE_CABANG,
                             d.KODE_BARANG,
                             dta.ID,
                             m.NAMA_DISTRIBUTOR,
                             dta.NAMA_BARANG,
                             dta.SERI,
                             dta.ITEM,
                             j.NAMA_JENIS_BARANG,
                             t.NAMA_TYPE_BARANG,
                             u.UKURAN,
                             s.NAMA_SUPPLIER,
                             d.JUMLAH_BARANG,
                             dta.HARGA_JUAL_SUPPLIER,
                             d.STATUS,
                             h.KETERANGAN
                         }).ToList();

            grdBarangMasuk.DataSource = query;
            grdBarangMasuk.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataMasukEditor.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TCGEntities tcg = new TCGEntities();
            string kode = cmbNamaBarang.SelectedValue.ToString();
            var data = tcg.TCG_DATA_BARANG.ToList().Where(p => p.KD_BARANG == kode).ToList();
            var jenis = tcg.TCG_MASTER_INS_BRG.ToList().Where(p => p.KODE_JENIS == data[0].KODE_JENIS).ToList();
            var merk = tcg.TCG_MASTER_MERK_BRG.ToList().Where(p => p.KODE_MERK == data[0].KODE_MERK).ToList();
            var supplier = tcg.TCG_MASTER_SUPPLIER_BARANG.ToList().Where(p => p.KODE_SUPPLIER == data[0].KODE_SUPPLIER).ToList();
            var ukuran = tcg.TCG_MASTER_UKURAN.ToList().Where(p => p.KODE_UKURAN == data[0].KODE_UKURAN).ToList();
            var type = tcg.TCG_MASTER_TYPE_BRG.ToList().Where(p => p.KODE_TYPE == data[0].KODE_TYPE).ToList();
            var cabang = tcg.TCG_MASTER_CABANG.ToList().Where(p => p.KODE_CABANG == data[0].KODE_CABANG).ToList();

            if (lblHeader.Text.Contains("Add"))
            {
                TCG_H_BARANG_MASUK modelHeader = new TCG_H_BARANG_MASUK();
                modelHeader.KD_TRANSAKSI = txtKode.Text;
                modelHeader.KETERANGAN = txtKet.Text;
                modelHeader.KODE_CABANG = cabang.Count == 0 ? "" : cabang[0].KODE_CABANG;
                modelHeader.KODE_SUPPLIER = supplier[0].KODE_SUPPLIER;
                modelHeader.TGL_TRANSAKSI = DateTime.ParseExact(txtTanggal.Text, "dd/MM/yyyy", null);
                modelHeader.JUMLAH_BARANG = Convert.ToInt32(txtJumlah.Text);

                TCG_D_BARANG_MASUK modelDetail = new TCG_D_BARANG_MASUK();
                modelDetail.KD_TRANSAKSI = txtKode.Text;
                modelDetail.KODE_BARANG = data[0].KD_BARANG;
                modelDetail.ID = data[0].ID;
                modelDetail.KODE_JENIS = jenis[0].KODE_JENIS;
                modelDetail.KODE_MERK = merk[0].KODE_MERK;
                modelDetail.KODE_SUPPLIER = supplier[0].KODE_SUPPLIER;
                modelDetail.KODE_UKURAN = ukuran[0].UKURAN;
                modelDetail.KODE_TYPE = type[0].KODE_TYPE;
                modelDetail.KODE_CABANG = cabang.Count == 0 ? "" : cabang[0].KODE_CABANG;
                modelDetail.HARGA_BELI = data[0].HARGA_JUAL_SUPPLIER;
                modelDetail.JUMLAH_BARANG = Convert.ToInt32(txtJumlah.Text);
                modelDetail.STATUS = txtStatus.Text;
                modelDetail.KETERANGAN = txtKet.Text;
                modelDetail.KODE_UKURAN = ukuran[0].KODE_UKURAN;

                tcg.TCG_H_BARANG_MASUK.Add(modelHeader);
                tcg.TCG_D_BARANG_MASUK.Add(modelDetail);
                tcg.SaveChanges();
            }
            else
            {
                TCG_H_BARANG_MASUK modelHeader = new TCG_H_BARANG_MASUK();
                modelHeader.KD_TRANSAKSI = txtKode.Text;
                modelHeader.KETERANGAN = txtKet.Text;
                modelHeader.KODE_CABANG = cabang.Count == 0 ? "" : cabang[0].KODE_CABANG;
                modelHeader.KODE_SUPPLIER = supplier[0].KODE_SUPPLIER;
                modelHeader.TGL_TRANSAKSI = DateTime.ParseExact(txtTanggal.Text, "dd/MM/yyyy", null);
                modelHeader.JUMLAH_BARANG = Convert.ToInt32(txtJumlah.Text);


                tcg.Entry(modelHeader).State = EntityState.Modified;
                tcg.SaveChanges();
                var d = tcg.TCG_D_BARANG_MASUK.Where(p => p.KD_TRANSAKSI == txtKode.Text).ToList();
                

                //TCGEntities tcg1 = new TCGEntities();

                TCG_D_BARANG_MASUK modelDetail = new TCG_D_BARANG_MASUK();
                modelDetail.PKID = d[0].PKID;
                modelDetail.KD_TRANSAKSI = txtKode.Text;
                modelDetail.KODE_BARANG = data[0].KD_BARANG;
                modelDetail.ID = data[0].ID;
                modelDetail.KODE_JENIS = jenis[0].KODE_JENIS;
                modelDetail.KODE_MERK = merk[0].KODE_MERK;
                modelDetail.KODE_SUPPLIER = supplier[0].KODE_SUPPLIER;
                modelDetail.KODE_UKURAN = ukuran[0].UKURAN;
                modelDetail.KODE_TYPE = type[0].KODE_TYPE;
                modelDetail.KODE_CABANG = cabang.Count == 0 ? "" : cabang[0].KODE_CABANG;
                modelDetail.HARGA_BELI = data[0].HARGA_JUAL_SUPPLIER;
                modelDetail.JUMLAH_BARANG = Convert.ToInt32(txtJumlah.Text);
                modelDetail.STATUS = txtStatus.Text;
                modelDetail.KETERANGAN = txtKet.Text;
                modelDetail.KODE_UKURAN = ukuran[0].KODE_UKURAN;

                
                using (var context = new TCGEntities())
                {
                    context.Entry(modelDetail).State = EntityState.Modified;
                    tcg.Entry(modelDetail).State = EntityState.Modified;

                    tcg.SaveChanges();
                }
                    


                this.mp1.Hide();
            }

        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            lblHeader.Text = "Edit Data Barang Masuk";
            TCGEntities tcg = new TCGEntities();
            

            GridViewRow row = grdBarangMasuk.Rows[rowIndex];
            var det = tcg.TCG_D_BARANG_MASUK.ToList().Where(p => p.KODE_BARANG == row.Cells[5].Text).ToList();
            txtKode.Text = row.Cells[3].Text;
            //cmbNamaBarang.Items.FindByText(row.Cells[8].Text).Selected = true;
            //cmbNamaBarang.Items.FindByText(row.Cells[8].Text).Selected = true;
            cmbNamaBarang.SelectedValue = det[0].KODE_BARANG;
            txtMerk.Text = row.Cells[7].Text;

            txtJenis.Text = row.Cells[11].Text;
            txtType.Text = row.Cells[12].Text;
            txtUkuran.Text = row.Cells[13].Text;
            txtSupplier.Text = row.Cells[14].Text;
            txtHargaBeli.Text = row.Cells[15].Text;
            txtJumlah.Text = row.Cells[16].Text;
            txtStatus.Text = row.Cells[17].Text;
            txtKet.Text = row.Cells[18].Text;
            lblPKID.Text = row.Cells[19].Text;

            this.mp1.Show();
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {


            TCGEntities tcg = new TCGEntities();

            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            GridViewRow row = grdBarangMasuk.Rows[rowIndex];

            string kode = cmbNamaBarang.SelectedValue.ToString();
            var data = tcg.TCG_DATA_BARANG.ToList().Where(p => p.KD_BARANG == kode).ToList();
            var jenis = tcg.TCG_MASTER_INS_BRG.ToList().Where(p => p.KODE_JENIS == data[0].KODE_JENIS).ToList();
            var merk = tcg.TCG_MASTER_MERK_BRG.ToList().Where(p => p.KODE_MERK == data[0].KODE_MERK).ToList();
            var supplier = tcg.TCG_MASTER_SUPPLIER_BARANG.ToList().Where(p => p.KODE_SUPPLIER == data[0].KODE_SUPPLIER).ToList();
            var ukuran = tcg.TCG_MASTER_UKURAN.ToList().Where(p => p.KODE_UKURAN == data[0].KODE_UKURAN).ToList();
            var type = tcg.TCG_MASTER_TYPE_BRG.ToList().Where(p => p.KODE_TYPE == data[0].KODE_TYPE).ToList();
            var cabang = tcg.TCG_MASTER_CABANG.ToList().Where(p => p.KODE_CABANG == data[0].KODE_CABANG).ToList();
            var header = tcg.TCG_H_BARANG_MASUK.ToList().Where(p => p.KD_TRANSAKSI == row.Cells[3].Text.ToString()).ToList();

            
            

            TCG_H_BARANG_MASUK modelHeader = new TCG_H_BARANG_MASUK();
            modelHeader.KD_TRANSAKSI = row.Cells[3].Text;
            modelHeader.KETERANGAN = row.Cells[18].Text;
            modelHeader.KODE_CABANG = row.Cells[4].Text;
            modelHeader.KODE_SUPPLIER = supplier[0].KODE_SUPPLIER;
            modelHeader.TGL_TRANSAKSI = header[0].TGL_TRANSAKSI;
            modelHeader.JUMLAH_BARANG = Convert.ToInt32(row.Cells[16].Text);


            var entry = tcg.Entry(modelHeader);
            tcg.TCG_H_BARANG_MASUK.Attach(modelHeader);
            tcg.TCG_H_BARANG_MASUK.Remove(modelHeader);
            tcg.SaveChanges();
            var d = tcg.TCG_D_BARANG_MASUK.Where(p => p.KD_TRANSAKSI == txtKode.Text).ToList();


            //TCGEntities tcg1 = new TCGEntities();

            TCG_D_BARANG_MASUK modelDetail = new TCG_D_BARANG_MASUK();
            modelDetail.PKID = d[0].PKID;
            modelDetail.KD_TRANSAKSI = txtKode.Text;
            modelDetail.KODE_BARANG = data[0].KD_BARANG;
            modelDetail.ID = data[0].ID;
            modelDetail.KODE_JENIS = jenis[0].KODE_JENIS;
            modelDetail.KODE_MERK = merk[0].KODE_MERK;
            modelDetail.KODE_SUPPLIER = supplier[0].KODE_SUPPLIER;
            modelDetail.KODE_UKURAN = ukuran[0].UKURAN;
            modelDetail.KODE_TYPE = type[0].KODE_TYPE;
            modelDetail.KODE_CABANG = cabang.Count == 0 ? "" : cabang[0].KODE_CABANG;
            modelDetail.HARGA_BELI = data[0].HARGA_JUAL_SUPPLIER;
            modelDetail.JUMLAH_BARANG = Convert.ToInt32(row.Cells[16].Text);
            modelDetail.STATUS = row.Cells[17].Text;
            modelDetail.KETERANGAN = row.Cells[18].Text;
            modelDetail.KODE_UKURAN = ukuran[0].KODE_UKURAN;

            var entry1 = tcg.Entry(modelHeader);
            tcg.TCG_D_BARANG_MASUK.Attach(modelDetail);
            tcg.TCG_D_BARANG_MASUK.Remove(modelDetail);
            tcg.SaveChanges();

            LoadGrid();

        }

        protected void cmbNamaBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            TCGEntities tcg = new TCGEntities();
            string kode = cmbNamaBarang.SelectedValue.ToString();
            var data = tcg.TCG_DATA_BARANG.ToList().Where(p => p.KD_BARANG == kode).ToList();
            var jenis = tcg.TCG_MASTER_INS_BRG.ToList().Where(p => p.KODE_JENIS == data[0].KODE_JENIS).ToList();
            var merk = tcg.TCG_MASTER_MERK_BRG.ToList().Where(p => p.KODE_MERK == data[0].KODE_MERK).ToList();
            var supplier = tcg.TCG_MASTER_SUPPLIER_BARANG.ToList().Where(p => p.KODE_SUPPLIER == data[0].KODE_SUPPLIER).ToList();
            var ukuran = tcg.TCG_MASTER_UKURAN.ToList().Where(p => p.KODE_UKURAN == data[0].KODE_UKURAN).ToList();
            var type = tcg.TCG_MASTER_TYPE_BRG.ToList().Where(p => p.KODE_TYPE == data[0].KODE_TYPE).ToList();

            txtMerk.Text = merk[0].NAMA_DISTRIBUTOR;
            txtJenis.Text = jenis[0].NAMA_JENIS_BARANG;
            txtType.Text = type[0].NAMA_TYPE_BARANG;
            txtUkuran.Text = ukuran[0].UKURAN;
            txtSupplier.Text = supplier[0].NAMA_SUPPLIER;
            txtHargaBeli.Text = data[0].HARGA_SUPPLIER.ToString();
            this.mp1.Show();
        }

        protected void imgCal_Click(object sender, ImageClickEventArgs e)
        {
            if (cld.Visible)
            {
                cld.Visible = false;
            }
            else
                cld.Visible = true;

            this.mp1.Show();
        }

        protected void cld_SelectionChanged(object sender, EventArgs e)
        {
            txtTanggal.Text = cld.SelectedDate.ToString("dd/MM/yyyy");
            cld.Visible = false;
            this.mp1.Show();
        }
    }
}