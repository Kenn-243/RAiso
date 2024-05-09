using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace RAiso.Views
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];

            if (userRole != null)
            {
                if (userRole.Equals("Customer"))
                {
                    Response.Redirect("~/Views/Customer/HomeCustomer.aspx");
                }
                else if (userRole.Equals("Admin"))
                {
                    Response.Redirect("~/Views/Admin/HomeAdmin.aspx");
                }
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["ID"]);
                MsStationery stationery = StationeryController.GetStationeryByStationeryId(id);
                List<MsStationery> stationeryList = new List<MsStationery> { stationery };
                if (stationery != null)
                {
                    gvDetailsGuest.DataSource = stationeryList;
                    gvDetailsGuest.DataBind();
                }
            }
        }
    }
}