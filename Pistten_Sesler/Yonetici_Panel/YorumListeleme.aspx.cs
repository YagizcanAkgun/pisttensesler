using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler.Yonetici_Panel
{
    public partial class YorumListeleme : System.Web.UI.Page
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
            Lv_Yorumlar.DataSource = vm.YorumListele(-1);
            Lv_Yorumlar.DataBind();
        }

        protected void Lv_Yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DurumDegistir")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                vm.YorumDurumDegistir(id); 

                Doldur();
            }
        }
    }
}