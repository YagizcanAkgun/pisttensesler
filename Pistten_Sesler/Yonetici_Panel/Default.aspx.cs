using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Lbl_CategoryCount.Text = vm.KategoriSayisi().ToString();
                Lbl_ArthicleCount.Text = vm.MakaleSayisi().ToString();
                Lbl_MemberCount.Text = vm.UyeSayisi().ToString();
                Lbl_CommentCount.Text = vm.YorumSayisi().ToString();

                Lv_SonUyeler.DataSource = vm.SonUyeler(5);
                Lv_SonUyeler.DataBind();

                Lv_SonYorumlar.DataSource = vm.SonYorumlar(5);
                Lv_SonYorumlar.DataBind();
            }
        }
    }
}