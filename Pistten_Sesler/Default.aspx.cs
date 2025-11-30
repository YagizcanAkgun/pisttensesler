using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace Pistten_Sesler
{
    public partial class Default : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Rp_Makaleler.DataSource = vm.AktifMakaleleriListele();
            Rp_Makaleler.DataBind();
        }
    }
}