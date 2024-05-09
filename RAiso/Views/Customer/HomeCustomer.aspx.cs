using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace RAiso.Views.Customer
{
    public partial class HomeCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];

            if (Session["UserRole"] == null && userRole == null)
            {
                Response.Redirect("~/Views/Guest/Login.aspx");
            }
            else if (userRole != null)
            {
                if (userRole.Equals("Admin"))
                {
                    Response.Redirect("~/Views/Admin/HomeAdmin.aspx");
                }
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

        protected void gvStationery_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stationeryId = gvStationery.DataKeys[gvStationery.SelectedIndex].Value.ToString();
            Response.Redirect("~/Views/Customer/DetailsCustomer.aspx?ID=" + stationeryId);
        }
    }
}