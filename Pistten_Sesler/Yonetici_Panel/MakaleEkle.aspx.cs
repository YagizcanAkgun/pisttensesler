using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class MakaleEkle : System.Web.UI.Page
    {

        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddl_Kategoriler.DataSource = vm.KategoriListele();
                Ddl_Kategoriler.DataBind();
            }
        }

        protected void Btn_MakaleEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_Baslik.Text))
            {
                Makale mak = new Makale();
                mak.Baslik = Tb_Baslik.Text;
                mak.KategoriID = Convert.ToInt32(Ddl_Kategoriler.SelectedItem.Value);
                mak.YazarID = ((Yonetici)Session["yonetici"]).ID;
                mak.EklemeTarihi = DateTime.Now;
                mak.GoruntulemeSayi = 0;
                mak.SilinmisMi = false;
                mak.AktifMi = Cb_AktifMi.Checked;
                mak.Ozet = Tb_Ozet.Text;
                mak.Icerik = Tb_Icerik.Text;
                if (Fu_Resim.HasFile)
                {
                    FileInfo dosya = new FileInfo(Fu_Resim.FileName);
                    string uzanti = dosya.Extension;
                    if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png")
                    {
                        string name = Convert.ToString(Guid.NewGuid());
                        string fullname = name + uzanti;
                        mak.KapakResim = fullname;
                        Fu_Resim.SaveAs(Server.MapPath("../MakaleGorselleri/" + fullname));
                    }
                    else
                    {
                        Pnl_Basarili.Visible = false;
                        Pnl_Basarisiz.Visible = true;
                        Lbl_HataMesaj.Text = "Dosya Formatı Geçersiz. jpg, jpeg, png dosyası yükleyiniz";
                    }
                }
                else
                {
                    mak.KapakResim = "resimyok.png";
                }
                if (vm.MakaleEkle(mak))
                {
                    Pnl_Basarili.Visible = true;
                    Pnl_Basarisiz.Visible = false;
                }
                else
                {
                    Pnl_Basarili.Visible = false;
                    Pnl_Basarisiz.Visible = true;
                    Lbl_HataMesaj.Text = "Makale eklenirken bir hata oluştu";
                }
            }
            else
            {
                Pnl_Basarili.Visible = false;
                Pnl_Basarisiz.Visible = true;
                Lbl_HataMesaj.Text = "Başlık boş bırakılamaz";
            }
        }
    }
}