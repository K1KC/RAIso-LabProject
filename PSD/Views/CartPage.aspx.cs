using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        private RAIsoEntities1 db = new RAIsoEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }
        private void LoadCart()
        {
            if (Session["user"] != null)
            {
                int userId = ((MsUser)Session["user"]).UserID;
                var cartItems = from cart in db.Carts
                                join stationery in db.MsStationeries on cart.StationeryID equals stationery.StationeryID
                                where cart.UserID == userId
                                select new
                                {
                                    cart.StationeryID,
                                    Name = stationery.StationeryName,
                                    cart.Quantity,
                                    Price = stationery.StationeryPrice
                                };

                GV_Cart.DataSource = cartItems.ToList();
                GV_Cart.DataBind();
            }
        }

        private int GetUserIdFromSession()
        {
            if (Session["user"] != null)
            {
                MsUser user = (MsUser)Session["user"];
                return user.UserID;
            }
            return -1;
        }

        protected void GV_Cart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int stationeryID = Convert.ToInt32(e.CommandArgument);
            int userId = GetUserIdFromSession();

            if (userId != -1)
            {
                if (e.CommandName == "Update")
                {
                    Response.Redirect($"UpdateCart.aspx?id={stationeryID}");
                }
                else if (e.CommandName == "Remove")
                {
                    var cartItem = db.Carts.FirstOrDefault(c => c.StationeryID == stationeryID && c.UserID == userId);
                    if (cartItem != null)
                    {
                        db.Carts.Remove(cartItem);
                        db.SaveChanges();
                    }
                    LoadCart();
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }


        protected void Btn_Checkout_Click(object sender, EventArgs e)
        {
            int userId = GetUserIdFromSession();
            if (userId != -1)
            {
                var cartItems = db.Carts.Where(c => c.UserID == userId).ToList();

                if (cartItems.Count > 0)
                {
                    var transactionHeader = new TransactionHeader
                    {
                        UserID = userId,
                        TransactionDate = DateTime.Now
                    };
                    db.TransactionHeaders.Add(transactionHeader);
                    db.SaveChanges();

                    foreach (var item in cartItems)

                    {
                        var transactionDetail = new PSD.Models.TransactionDetail
                        {
                            TransactionID = transactionHeader.TransactionID,
                            StationeryID = item.StationeryID,
                            Quantity = item.Quantity
                        };
                        db.TransactionDetails.Add(transactionDetail);
                    }
                    db.Carts.RemoveRange(cartItems);
                    db.SaveChanges();

                    Response.Redirect("CustomerHomePage.aspx");
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}