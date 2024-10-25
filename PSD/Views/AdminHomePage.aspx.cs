using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        RAIsoEntities1 db = new RAIsoEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<MsStationery> stationery = (from MsStationery in db.MsStationeries select MsStationery).ToList();

            StationeryList.DataSource = stationery;
            StationeryList.DataBind();
        }

        protected void InsertStationery_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertStationery.aspx");
        }

        protected void StationeryList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int stationeryId = (int)StationeryList.DataKeys[e.RowIndex].Value;
            Response.Redirect("UpdateStationery.aspx?StationeryId=" + stationeryId);
        }

        protected void StationeryList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (StationeryList.Rows.Count > e.RowIndex)
            {
                int stationeryId = (int)StationeryList.DataKeys[e.RowIndex].Value;
                MsStationery stationery = db.MsStationeries.Find(stationeryId);

                db.MsStationeries.Remove(stationery);
                db.SaveChanges();

                StationeryList.DataSource = db.MsStationeries.ToList();
                StationeryList.DataBind();
            }

        }
    }
}