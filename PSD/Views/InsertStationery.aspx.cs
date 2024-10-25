using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using PSD.Factories;
using PSD.Models;


namespace PSD.Views
{
    public partial class InsertStationery : System.Web.UI.Page
    {
        private RAIsoEntities1 db = new RAIsoEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        private bool IsAdmin()
        {
            if (Session["user"] != null)
            {
                MsUser user = (MsUser)Session["user"];
                return user.UserRole == "Admin";
            }
            return false;
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string name = TBox_Name.Text;
                int price = int.Parse(TBox_Price.Text);

                MsStationery stationery = StationeryFactory.CreateStationery(name, price);

                db.MsStationeries.Add(stationery);
                db.SaveChanges();

                Response.Redirect("AdminHomePage.aspx");
            }
            else
            {
                Lbl_Error.Text = "Please fix the errors and try again.";
            }
        }
    }
}