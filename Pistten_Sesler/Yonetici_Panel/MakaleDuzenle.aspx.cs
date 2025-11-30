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
    public partial class WebForm5 : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    Ddl_Kategoriler.DataSource = vm.KategoriListele();
                    Ddl_Kategoriler.DataBind();
                    Getir();
                }
            }
            else
            {
                Response.Redirect("MakaleListeleme.aspx");
            }
        }

        protected void Btn_MakaleDuzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_Baslik.Text))
            {
                int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
                Makale mak = vm.MakaleGetir(id);
                mak.Baslik = Tb_Baslik.Text;
                mak.KategoriID = Convert.ToInt32(Ddl_Kategoriler.SelectedItem.Value);
                mak.Ozet = Tb_Ozet.Text;
                mak.Icerik = Tb_Icerik.Text;
                mak.AktifMi = Cb_AktifMi.Checked;
                if (Fu_Resim.HasFile)
                {
                    FileInfo dosya = new FileInfo(Fu_Resim.FileName);
                    string isim = Guid.NewGuid().ToString();
                    string uzanti = dosya.Extension;
                    if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png")
                    {
                        string fullname = isim + uzanti;
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
                if (vm.MakaleDuzenle(mak))
                {
                    Pnl_Basarili.Visible = true;
                    Pnl_Basarisiz.Visible = false;
                    Getir();

                }
                else
                {
                    Pnl_Basarili.Visible = false;
                    Pnl_Basarisiz.Visible = true;
                    Lbl_HataMesaj.Text = "Bir Hata Oluştu";
                }
            }
            else
            {
                Pnl_Basarili.Visible = false;
                Pnl_Basarisiz.Visible = true;
                Lbl_HataMesaj.Text = "Başlık boş bırakılamaz";
            }
        }
        private void Getir()
        {
            int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
            Makale mak = vm.MakaleGetir(id);
            Ddl_Kategoriler.SelectedValue = Convert.ToString(mak.KategoriID);
            Tb_Baslik.Text = mak.Baslik;
            Tb_Icerik.Text = mak.Icerik;
            Tb_Ozet.Text = mak.Ozet;
            Img_Resim.ImageUrl = "../MakaleGorselleri/" + mak.KapakResim;
            Cb_AktifMi.Checked = mak.AktifMi;
        }
    }
    
}