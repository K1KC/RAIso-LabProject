using PSD.Models;
using PSD.Views.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        private RAIsoEntities1 db = DatabaseSingleton.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Lbl_Error.Visible = false;
                string QueryTransactionID = Request.QueryString["DetailforTransactionID"];
                if (QueryTransactionID == null)
                {
                    Lbl_Error.Visible = true;
                }

                int UserID = GetUserID();
                if(UserID != -1)
                {
                    if (QueryTransactionID != null)
                    {
                        int Requested_TransactionID = Convert.ToInt32(QueryTransactionID);
                        GV_TransactionDetail.DataSource = (from TD in db.TransactionDetails
                                                where TD.TransactionID == Requested_TransactionID && TD.TransactionHeader.UserID == UserID
                                                select new
                                                {
                                                    TD.MsStationery.StationeryName,
                                                    TD.MsStationery.StationeryPrice,
                                                    TD.Quantity,
                                                }).ToList();
                        GV_TransactionDetail.DataBind();
                    }
                    else
                    {
                        Lbl_Error.Visible = true;
                    }
                }
            }
        }

        private int GetUserID()
        {
            MsUser userSession = (MsUser)Session["user"];
            if (userSession != null)
            {
                return userSession.UserID;
            }
            else
            {
                return -1;
            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistory.aspx");
        }
    }
}