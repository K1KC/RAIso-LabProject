using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class CustomerHomePage : System.Web.UI.Page
    {
        RAIsoEntities1 db = new RAIsoEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<MsStationery> stationery = (from MsStationery in db.MsStationeries select MsStationery).ToList();

            ListView1.DataSource = stationery;
            ListView1.DataBind();
        }
    }
}