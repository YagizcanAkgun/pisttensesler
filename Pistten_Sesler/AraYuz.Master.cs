using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Rp_Kategoriler.DataSource = vm.AktifKategoriListele();
            Rp_Kategoriler.DataBind();

            if (Session["uye"] == null)
            {
                Pnl_GirisVar.Visible = false;
                Pnl_GirisYok.Visible = true;
                Lbl_Uye.Text = ""; 
            }
            else
            {
                Pnl_GirisVar.Visible = true;
                Pnl_GirisYok.Visible = false;

                Uye u = (Uye)Session["uye"];
                Lbl_Uye.Text = u.KullaniciAdi + " (" + u.Isim + " " + u.Soyisim + ")";
            }

        }

        protected void Lbtn_Cikis_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("GirisYap.aspx");
        }
    }
}