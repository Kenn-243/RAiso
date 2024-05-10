using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace RAiso.Views.Admin
{
    public partial class DetailsAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];
            
            if (Session["UserRole"] == null && userRole == null)
            {
                Response.Redirect("~/Views/Guest/Login.aspx");
            }
            else if(userRole != null)
            {
                if (userRole.Equals("Customer"))
                {
                    Response.Redirect("~/Views/Customer/HomeCustomer.aspx");
                }
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["ID"]);
                MsStationery stationery = StationeryController.GetStationeryByStationeryId(id);
                List<MsStationery> stationeryList = new List<MsStationery> { stationery };
                if (stationery != null)
                {
                    gvDetailsAdmin.DataSource = stationeryList;
                    gvDetailsAdmin.DataBind();
                }
            }
        }
    }
}