using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Web;

namespace RAiso.Views.Customer
{
    public partial class DetailsCustomer : System.Web.UI.Page
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
                int id = Convert.ToInt32(Request["ID"]);
                MsStationery stationery = StationeryController.GetStationeryByStationeryId(id);
                if (stationery != null)
                {
                    lblStationeryNameValue.Text = stationery.StationeryName;
                    lblStationeryPriceValue.Text = stationery.StationeryPrice.ToString();
                }
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            int userId = cookie == null ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(cookie.Values["UserId"]);
            int stationeryId = Convert.ToInt32(Request["ID"]);
            int quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToInt32(txtQuantity.Text);
            string response = CartController.AddToCart(userId, stationeryId, quantity);

            lblError.Text = response;

            if (response.Equals("Success"))
            {
                Response.Redirect("~/Views/Customer/HomeCustomer.aspx");
            }
        }
    }
}