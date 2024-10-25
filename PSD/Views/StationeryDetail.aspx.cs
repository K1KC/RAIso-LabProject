using CrystalDecisions.ReportAppServer.DataDefModel;
using PSD.Models;
using PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class StationeryDetail : System.Web.UI.Page
    {
        private RAIsoEntities1 db = new RAIsoEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null || Request.Cookies["user_cookie"] == null)
                {
                    Lbl_Error.Text = "Please login first";
                }
                LoadStationeryDetail();
                if (IsCustomer())
                {
                    Pnl_AddToCart.Visible = true;
                }
            }
        }
        private void LoadStationeryDetail()
        {
            Lbl_Error.Visible = false;
            int StatId = Convert.ToInt32(Request.QueryString["id"]);
            String stationeryDetailName = (from sd in db.MsStationeries where sd.StationeryID == StatId select sd.StationeryName).FirstOrDefault();
            String stationeryDetailPrice = (from sd in db.MsStationeries where sd.StationeryID == StatId select sd.StationeryPrice).FirstOrDefault().ToString();
            if (stationeryDetailPrice != null && stationeryDetailName != null)
            {
                Lbl_StationeryName.Text = stationeryDetailName;
                Lbl_StationeryPrice.Text = "$" + stationeryDetailPrice;
            }

            /* var stationeries = db.MsStationeries.ToList();
            if (stationeries.Any())
            {
                DDL_Stationery.DataSource = stationeries;
                DDL_Stationery.DataTextField = "StationeryName";
                DDL_Stationery.DataValueField = "StationeryID";
                DDL_Stationery.DataBind();

                var firstStationery = stationeries.First();
                Lbl_StationeryName.Text = firstStationery.StationeryName;
                Lbl_StationeryPrice.Text = firstStationery.StationeryPrice.ToString("C");
                Pnl_AddToCart.Visible = true;
            }*/
            else
            {
                Lbl_Error.Text = "No stationery items found.";
                Pnl_AddToCart.Visible = false;
            }
        }

        private bool IsCustomer()
        {
            if (Session["user"] != null)
            {
                MsUser user = (MsUser)Session["user"];
                return user.UserRole == "Customer";
            }
            return false;
        }

        protected void Btn_AddToCart_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null && TBox_Quantity.Text != null)
            {
                int userId = ((MsUser)Session["user"]).UserID;
                int StatId = Convert.ToInt32(Request.QueryString["id"]);

                var existingCartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.StationeryID == StatId);

                if (existingCartItem != null)
                {
                    if (int.TryParse(TBox_Quantity.Text, out int quantity) && quantity > 0)
                    {
                        existingCartItem.Quantity += quantity;
                        db.SaveChanges();
                        Response.Redirect("CartPage.aspx");
                    }
                    else
                    {
                        Lbl_Error.Text = "Invalid quantity.";
                    }
                }
                else
                {
                    if (int.TryParse(TBox_Quantity.Text, out int quantity) && quantity > 0)
                    {
                        var cartItem = new PSD.Models.Cart
                        {
                            UserID = userId,
                            StationeryID = StatId,
                            Quantity = quantity
                        };

                        db.Carts.Add(cartItem);
                        db.SaveChanges();
                        Response.Redirect("CartPage.aspx");
                    }
                    else
                    {
                        Lbl_Error.Text = "Invalid quantity.";
                    }
                }
            }
            else
            {
                Lbl_Error.Text = "Error adding to cart. Please login first.";
            }
        }
    }
}