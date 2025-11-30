using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        protected void Lv_Kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            vm.KategoriDurumDegistir(id);
            Doldur();
        }
        private void Doldur()
        {
            Lv_Kategoriler.DataSource = vm.KategoriListele();
            Lv_Kategoriler.DataBind();
        }
    }
}