using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class GuestHomePage : System.Web.UI.Page
    {
        RAIsoEntities1 db = new RAIsoEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                MsUser currentUser = (MsUser)Session["user"];
                String currentRole = currentUser.UserRole;

                int currentID = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                String currentRoleFromC = (from C in db.MsUsers where C.UserID == currentID select C.UserRole).FirstOrDefault();
                if (currentRole == "Admin" || currentRoleFromC == "Admin")
                {
                    Response.Redirect("AdminHomePage.aspx");
                }
                else if(currentRole == "Customer" || currentRoleFromC == "Customer")
                {
                    Response.Redirect("CustomerHomePage.aspx");
                }
            }
            List<MsStationery> stationery = (from MsStationery in db.MsStationeries select MsStationery).ToList();

            ListView1.DataSource = stationery;
            ListView1.DataBind();
        }
    }
}