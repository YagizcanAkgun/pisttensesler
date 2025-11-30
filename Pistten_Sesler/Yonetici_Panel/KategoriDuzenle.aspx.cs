using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["kategoriID"]);
                if (!IsPostBack)
                {
                    Kategori kategori = vm.kategoriGetir(id);
                    if (kategori != null)
                    {
                        Tb_Isim.Text = kategori.Isim;
                        Cb_Durum.Checked = kategori.Durum;
                    }
                    else
                    {
                        Response.Redirect("KategoriListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void btn_kategoriDuzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_Isim.Text))
            {
                if (Tb_Isim.Text.Length <= 25)
                {
                    Kategori kat = new Kategori();
                    kat.ID = Convert.ToInt32(Request.QueryString["kategoriID"]);
                    kat.Isim = Tb_Isim.Text;
                    kat.Durum = Cb_Durum.Checked;
                    if (vm.KategoriDuzenle(kat))
                    {
                        Pnl_Basarisiz.Visible = false;
                        Pnl_Basarili.Visible = true;
                    }
                    else
                    {
                        Pnl_Basarisiz.Visible = true;
                        Pnl_Basarili.Visible = false;
                        Lbl_HataMesaj.Text = "Kategori güncellenirken bir hata oluştu";
                    }
                }
                else
                {
                    Pnl_Basarisiz.Visible = true;
                    Pnl_Basarili.Visible = false;
                    Lbl_HataMesaj.Text = "Kategori adı en fazla 25 karakterden oluşmalıdır";
                }
            }
            else
            {
                Pnl_Basarisiz.Visible = true;
                Pnl_Basarili.Visible = false;
                Lbl_HataMesaj.Text = "Kategori adı boş bırakılamaz";
            }
        }
    }
}