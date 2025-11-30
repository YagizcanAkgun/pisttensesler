using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["yonetici"];
                Lbl_Kullanici.Text = y.KullaniciAdi;
            }
            else
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
        }

        protected void Btn_Cikis_Click(object sender, EventArgs e)
        {
            Response.Redirect("YoneticiGiris.aspx");
        }
    }
}