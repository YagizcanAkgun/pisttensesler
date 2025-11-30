using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Lbtn_Kaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_Isim.Text) &&
              !string.IsNullOrEmpty(Tb_Soyisim.Text) &&
              !string.IsNullOrEmpty(Tb_KullaniciAdi.Text) &&
              !string.IsNullOrEmpty(Tb_Mail.Text) &&
              !string.IsNullOrEmpty(Tb_Sifre.Text))
            {
                Uye uye = new Uye();
                uye.Isim = Tb_Isim.Text;
                uye.Soyisim = Tb_Soyisim.Text;
                uye.KullaniciAdi = Tb_KullaniciAdi.Text;
                uye.Mail = Tb_Mail.Text;
                uye.sifre = Tb_Sifre.Text;

                // ✔ CheckBox'a göre aktiflik durumu
                uye.AktifMi = true;
      

                if (vm.KayitOl(uye))
                {
                    Pnl_Basarili.Visible = true;
                    Pnl_Basarisiz.Visible = false;
                }
                else
                {
                    Pnl_Basarili.Visible = false;
                    Pnl_Basarisiz.Visible = true;
                    Lbl_HataMesaj.Text = "Kayıt sırasında bir hata oluştu.";
                }
            }
            else
            {
                Pnl_Basarili.Visible = false;
                Pnl_Basarisiz.Visible = true;
                Lbl_HataMesaj.Text = "Lütfen tüm alanları doldurunuz.";
            }
        }
    }
}