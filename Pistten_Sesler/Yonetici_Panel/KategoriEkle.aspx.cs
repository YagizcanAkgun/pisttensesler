using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_KategoriEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_Isim.Text))
            {
                Kategori kat = new Kategori();
                kat.Isim = Tb_Isim.Text;
                kat.Durum = Cb_Durum.Checked;
                if (vm.KategoriEkle(kat))
                {
                    Pnl_Basarili.Visible = true;
                    Pnl_Basarisiz.Visible = false;
                }
            }
            else
            {
                Pnl_Basarili.Visible = false;
                Pnl_Basarisiz.Visible = true;
                Lbl_HataMesaj.Text = "Kategori Adı Boş Bırakılamaz";
            }
        }
    }
}