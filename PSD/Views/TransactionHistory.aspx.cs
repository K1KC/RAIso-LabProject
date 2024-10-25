using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD.Models;
using PSD.Repositories;
using PSD.Views.Repositories;
namespace PSD.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        private RAIsoEntities1 db = DatabaseSingleton.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int UserID = GetUserID();
                if (UserID != -1)
                {
                    GV_TransactionHistory.DataSource = (from Transactions in db.TransactionHeaders
                                                        where Transactions.UserID == UserID
                                                        select new
                                                        {
                                                            Transactions.TransactionID,
                                                            Transactions.TransactionDate,
                                                            CustomerName = Transactions.MsUser.UserName
                                                        }).ToList();

                    GV_TransactionHistory.DataBind();
                }
                else { Response.Redirect("~/Views/LoginPage.aspx"); }
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

        protected void GV_TransactionHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowTransactionDetail")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument) - 1;

                String ClickedTransactionID = GV_TransactionHistory.Rows[rowIndex].Cells[0].Text;

                Response.Redirect("~/Views/TransactionDetail.aspx?DetailforTransactionID=" + ClickedTransactionID);
            }
        }
    }
}