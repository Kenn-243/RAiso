using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace RAiso.Views.Customer
{
    public partial class UpdateCart : System.Web.UI.Page
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
                int userId = Convert.ToInt32(Request["UserID"]);
                int stationeryId = Convert.ToInt32(Request["StationeryID"]);
                Cart cart = CartController.GetCartByUserIdAndStationeryId(userId, stationeryId);
                MsStationery stationery = StationeryController.GetStationeryByStationeryId(stationeryId);
                lblStationeryName.Text = stationery.StationeryName;
                lblStationeryPrice.Text = stationery.StationeryPrice.ToString();
                txtQuantity.Text = cart.Quantity.ToString();
            }
        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Request["UserID"]);
            int stationeryId = Convert.ToInt32(Request["StationeryID"]);
            int quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToInt32(txtQuantity.Text);
            string response = CartController.UpdateCart(userId, stationeryId, quantity);

            lblError.Text = response;

            if (response.Equals("Success"))
            {
                Response.Redirect("~/Views/Customer/CustomerCart.aspx");
            }
        }
    }
}