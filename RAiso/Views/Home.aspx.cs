using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace RAiso.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];

            if ((Session["UserRole"] != null && Session["UserRole"].Equals("Admin")) || (userRole != null && userRole.Equals("Admin")))
            {
                btnInsert.Visible = true;
                gvStationery.Columns[3].Visible = true;
                gvStationery.Columns[4].Visible = true;
            }
            if (!IsPostBack)
            {
                List<MsStationery> msStationeries = StationeryController.GetListStationeries();
                if (msStationeries.Count == 0)
                {
                    lblNoData.Visible = true;
                }
                else
                {
                    lblNoData.Visible = false;
                    gvStationery.DataSource = msStationeries;
                    gvStationery.DataBind();
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/InsertStationery.aspx");
        }

        protected void gvStationery_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stationeryId = Convert.ToInt32(gvStationery.DataKeys[e.RowIndex].Value);
            string response = StationeryController.RemoveStationery(stationeryId);
            if (response.Equals("Success"))
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void gvStationery_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string stationeryId = gvStationery.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/Views/Admin/UpdateStationery.aspx?ID=" + stationeryId);
        }

        protected void gvStationery_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stationeryId = gvStationery.DataKeys[gvStationery.SelectedIndex].Value.ToString();
            Response.Redirect("~/Views/Details.aspx?ID=" + stationeryId);
        }
    }
}