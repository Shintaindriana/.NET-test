using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Entity;

namespace TestWeb
{
    public partial class test1 : System.Web.UI.Page
    {
        public string constring = "Data Source=.\\SQLEXPRESS;Initial Catalog=TCG;Integrated Security=True";

        string kode;
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
            Session["item"] = tcg.TCG_MASTER_INS_BRG.ToList();
            grdJenis.DataSource = Session["item"];
            grdJenis.DataBind();

        }

        protected void grdJenis_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdJenis.EditIndex = e.NewEditIndex;

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string message = "Message from server side";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            this.mp1.Show();
        }

        protected void grdJenis_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if(e.CommandName=="edit")
            //{
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);

            //    GridViewRow row = grdJenis.Rows[rowIndex];
            //    txtKode.Text = row.Cells[1].Text;
            //    txtNama.Text = row.Cells[2].Text;
            //    kode = row.Cells[1].Text;
            //    lblHeader.Text = "Edit Master Jenis Barang";
            //    this.mp1.Show();
            //}
        }

       

        protected void imgEdit_Click1(object sender, ImageClickEventArgs e)
        {
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            lblHeader.Text = "Edit Master Jenis Barang";

            GridViewRow row = grdJenis.Rows[rowIndex];
            txtKode.Text = row.Cells[2].Text;
            txtNama.Text = row.Cells[3].Text;
            //GridView gv = sender as GridView;
            //GridViewRow gvr = (GridViewRow)(sender as ImageButton).NamingContainer;
            //txtKode.Text = ((Label)gvr.FindControl("KODE_JENIS")).Text;

            this.mp1.Show();
        }
        protected void btn2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            if (lblHeader.Text.Contains("Add"))
            {
                
                if (con.State == System.Data.ConnectionState.Open)
                {
                    //string q = "insert into TCG_MASTER_INS_BRG (KODE_JENIS, NAMA_JENIS_BARANG) VALUES ('" + txtKode.Text + "', '" + txtNama.Text + "')";
                    //SqlCommand cmd = new SqlCommand(q, con);
                    //cmd.ExecuteNonQuery();

                    TCGEntities tCG = new TCGEntities();
                    TCG_MASTER_INS_BRG model = new TCG_MASTER_INS_BRG();
                    model.KODE_JENIS = txtKode.Text;
                    model.NAMA_JENIS_BARANG = txtNama.Text;
                    tCG.TCG_MASTER_INS_BRG.Add(model);
                    tCG.SaveChanges();

                    this.mp1.Hide();

                }
            }
            else
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    //string q = "UPDATE TCG_MASTER_INS_BRG SET KODE_JENIS='"+txtKode.Text+"',NAMA_JENIS_BARANG='"+txtNama.Text+"' WHERE KODE_JENIS ='"+txtKode.Text+"'";
                    //SqlCommand cmd = new SqlCommand(q, con);
                    //cmd.ExecuteNonQuery();
                    TCGEntities tCG = new TCGEntities();
                    TCG_MASTER_INS_BRG model = new TCG_MASTER_INS_BRG();
                    model.KODE_JENIS = txtKode.Text;
                    model.NAMA_JENIS_BARANG = txtNama.Text;
                    tCG.Entry(model).State = EntityState.Modified;
                    tCG.SaveChanges();

                    this.mp1.Hide();

                }
            }
            LoadGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Add Master Jenis Barang";
            txtKode.Text = "";
            txtNama.Text = "";
            this.mp1.Show();
        }

        protected void grdJenis_DataBinding(object sender, EventArgs e)
        {
            //TCGEntities tcg = new TCGEntities();
            ////TCG_MASTER_INS_BRG jns = new TCG_MASTER_INS_BRG();
            //var item = tcg.TCG_MASTER_INS_BRG.ToList();
            //grdJenis.DataSource = item;
            //grdJenis.DataBind();
        }

        

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            TCGEntities tcg = new TCGEntities();
           
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
           
            GridViewRow row = grdJenis.Rows[rowIndex];

            TCG_MASTER_INS_BRG model = new TCG_MASTER_INS_BRG();
            model.KODE_JENIS = row.Cells[2].Text;
            model.NAMA_JENIS_BARANG = row.Cells[3].Text;
            var entry = tcg.Entry(model);
            
                tcg.TCG_MASTER_INS_BRG.Attach(model);
                tcg.TCG_MASTER_INS_BRG.Remove(model);
                tcg.SaveChanges();



            LoadGrid();


        }
    }
}