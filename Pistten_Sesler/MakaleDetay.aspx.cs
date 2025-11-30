using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int makaleid = Convert.ToInt32(Request.QueryString["makaleID"]);
                Makale m = vm.MakaleGetir(makaleid);
                Img_Resim.ImageUrl = "MakaleGorselleri/" + m.KapakResim;
                Lbl_Baslik.Text = m.Baslik;
                Lbl_Icerik.Text = m.Icerik;
                Ltrl_kategori.Text = m.KategoriAdi;
                Ltrl_eklemeTarihi.Text = m.EklemeTarihiStr;
                Ltrl_yazar.Text = m.Yazar;
                Ltrl_GorntulemeSayi.Text = m.GoruntulemeSayi.ToString();

                Pnl_GirisVar.Visible = false;
                Pnl_GirisYok.Visible = true;

                if (Session["uye"] != null)
                {
                    Pnl_GirisVar.Visible = true;
                    Pnl_GirisYok.Visible = false;
                }
                List<Yorum> onaylilar = vm.OnayliMakaleYorumlari(makaleid);
                Pnl_YorumYok.Visible = onaylilar == null ? true : false;
                Rp_Yorumlar.DataSource = onaylilar;
                Rp_Yorumlar.DataBind();

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Btn_YorumYap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_Yorum.Text))
            {
                int makaleid = Convert.ToInt32(Request.QueryString["makaleID"]);

                Uye u = (Uye)Session["uye"];

                Yorum y = new Yorum();
                y.Icerik = Tb_Yorum.Text;
                y.MakaleID = makaleid;
                y.UyeID = u.ID;
                y.Tarih = DateTime.Now;
                y.Yayinla = false;

                if (vm.YorumYap(y))
                {
                    Pnl_Basarisiz.Visible = false;
                    Pnl_Basarili.Visible = true;
                }
                else
                {
                    Pnl_Basarisiz.Visible = true;
                    Pnl_Basarili.Visible = false;
                    Lbl_Mesaj.Text = "Yorum gönderilirken bir hata ile karşılaşıldı. Lütfen daha sonra tekrar denemeyiniz";
                }
            }
            else
            {
                Pnl_Basarisiz.Visible = true;
                Pnl_Basarili.Visible = false;
                Lbl_Mesaj.Text = "Sistem boş yorumlara izin vermemektedir.";
            }
        }
    }
}