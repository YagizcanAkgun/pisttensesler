using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        VeriModel Model = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_Mail.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(Tb_Sifre.Text))
                {
                    Yonetici y = Model.YoneticiGiris(Tb_Mail.Text.Trim(), Tb_Sifre.Text);
                    if (y != null)
                    {
                        Session["yonetici"] = y;
                        //Veriyi Client'ın RAM'inde tutmak için kullanılır
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Pnl_Mesaj.Visible = true;
                        Lbl_Mesaj.Text = "Kullanıcı bulunamadı";
                    }
                }
                else
                {
                    Pnl_Mesaj.Visible = true;
                    Lbl_Mesaj.Text = "Şifre Boş Bırakılamaz";
                }
            }
            else
            {
                Pnl_Mesaj.Visible = true;
                Lbl_Mesaj.Text = "Mail Boş Bırakılamaz";
            }
        }
    }
}