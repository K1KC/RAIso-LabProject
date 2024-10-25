using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class UpdateStationery1 : System.Web.UI.Page
    {
        RAIsoEntities1 db = new RAIsoEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                Response.Redirect("LoginPage.aspx");
            } else
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["StationeryId"] != null)
                    {
                        int stationeryId;
                        if (int.TryParse(Request.QueryString["StationeryId"], out stationeryId))
                        {
                            LoadStationeryData(stationeryId);
                        }
                        else
                        {
                            lblMessage.Text = "Invalid Stationery ID.";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "No Stationery ID provided.";
                    }
                }
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

        private void LoadStationeryData(int stationeryId)
        {
            var stationery = db.MsStationeries.Find(stationeryId);
            if (stationery != null)
            {
                txtStationeryID.Text = stationery.StationeryID.ToString();
                txtStationeryName.Text = stationery.StationeryName;
                txtStationeryPrice.Text = stationery.StationeryPrice.ToString();
            }
            else
            {
                lblMessage.Text = "Stationery not found.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int stationeryId = int.Parse(txtStationeryID.Text);
                var stationery = db.MsStationeries.Find(stationeryId);
                if (stationery != null)
                {
                    string name = txtStationeryName.Text.Trim();
                    int price;
                    if (int.TryParse(txtStationeryPrice.Text, out price) && price >= 2000)
                    {
                        stationery.StationeryName = name;
                        stationery.StationeryPrice = price;
                        db.SaveChanges();

                        lblMessage.Text = "Stationery updated successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Invalid price. It must be a numeric value greater than or equal to 2000.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMessage.Text = "Stationery not found.";
                }
                
            }
            Response.Redirect("AdminHomePage.aspx");
        }
    }
}