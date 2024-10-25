using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using PSD.Models;
using PSD.Views.Repositories;
using PSD.Handlers;
using PSD.Datasets;
using PSD.Reports;
namespace PSD.Views
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        private RAIsoEntities1 db = DatabaseSingleton.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MsUser user = (MsUser)Session["user"];
                if (user != null && user.UserRole == "Admin")
                {
                    RAIsoCrystalReport report = new RAIsoCrystalReport();
                    report.Load(Server.MapPath("~/Reports/RAIsoCrystalReport.rpt"));
                    CrystalReportViewer1.ReportSource = null;
                    List<TransactionHeader> TH_List = TransactionHeaderHandler.GetTransactionHeaderList();
                    RAIsoDataset ds = GetTransaction(TH_List);
                    report.SetDataSource(ds);
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.DataBind();
                }
            }
        }

        private RAIsoDataset GetTransaction(List<TransactionHeader> TransactionHeaderList)
        {
            RAIsoDataset ds = new RAIsoDataset();
            var Info_Table = ds.TransactionInfo;
            var Detail_Table = ds.TransactionDetail;

            foreach (TransactionHeader TransactionHeader in TransactionHeaderList)
            {
                int GrandTotal = 0;
                var Info_row = Info_Table.NewRow();
                Info_row["TransactionID"] = TransactionHeader.TransactionID;
                Info_row["UserID"] = TransactionHeader.UserID;
                Info_row["TransactionDate"] = TransactionHeader.TransactionDate.ToString();

                foreach (PSD.Models.TransactionDetail transactionDetail in TransactionHeader.TransactionDetails)
                {
                    var Detail_row = Detail_Table.NewRow();
                    Detail_row["TransactionID"] = transactionDetail.TransactionID;
                    Detail_row["StationeryName"] = transactionDetail.MsStationery.StationeryName;
                    Detail_row["Quantity"] = transactionDetail.Quantity;
                    Detail_row["StationeryPrice"] = transactionDetail.MsStationery.StationeryPrice;
                    Detail_row["SubTotalValue"] = transactionDetail.Quantity * transactionDetail.MsStationery.StationeryPrice;
                    GrandTotal += transactionDetail.Quantity * transactionDetail.MsStationery.StationeryPrice;
                    Detail_Table.Rows.Add(Detail_row);
                }
                Info_row["TotalValue"] = GrandTotal;
                Info_Table.Rows.Add(Info_row);
            }
            return ds;
        }
    }
}