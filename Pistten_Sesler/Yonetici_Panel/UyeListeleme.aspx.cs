using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Doldur();
            }
        }
        private void Doldur()
        {
            Lv_Uyeler.DataSource = vm.UyeListele();
            Lv_Uyeler.DataBind();
        }

        protected void Lv_Uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DurumDegistir")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                vm.UyeDurumDegistir(id);

                Doldur();
            }
        }
    }
}