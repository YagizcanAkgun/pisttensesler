using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class WebForm6 : System.Web.UI.Page
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
            Lv_Makaleler.DataSource = vm.MakaleListele(0);
            Lv_Makaleler.DataBind();
        }

        protected void Lv_Makaleler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            
            if (e.CommandName == "DurumDegistir")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                vm.MakaleDurumDegistir(id);
                Doldur();
            }
            else if (e.CommandName == "Sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                vm.MakaleSil(id);
                Doldur();
            }
        }


    }
}
