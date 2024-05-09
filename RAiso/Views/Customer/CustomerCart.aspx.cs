using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RAiso.Views.Customer
{
    public partial class CustomerCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];
            string userIdCookie = cookie?.Values["userId"];

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
                int userId = userIdCookie == null ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(userIdCookie);
                List<Cart> carts = CartController.GetListCartsByUserId(userId);
                List <MsStationery> stationeries = StationeryController.GetListStationeries();

                var cartItems = carts
                .Join(
                    stationeries,
                    cart => cart.StationeryID,
                    stationery => stationery.StationeryID,
                    (cart, stationery) => new
                    {
                        UserID = cart.UserID,
                        StationeryID = cart.StationeryID,
                        StationeryName = stationery.StationeryName,
                        StationeryPrice = stationery.StationeryPrice,
                        Quantity = cart.Quantity
                    }
                )
                .ToList();

                if (cartItems.Count == 0)
                {
                    lblNoData.Visible = true;
                    btnCheckout.Visible = false;
                }
                else
                {
                    lblNoData.Visible = false;
                    btnCheckout.Visible = true;
                    gvCart.DataSource = cartItems;
                    gvCart.DataBind();
                }
            }
        }

        protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string userId = gvCart.DataKeys[e.NewEditIndex]["UserID"].ToString();
            string stationeryId = gvCart.DataKeys[e.NewEditIndex]["StationeryID"].ToString();
            Response.Redirect($"~/Views/Customer/UpdateCart.aspx?UserID={userId}&StationeryID={stationeryId}");
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int UserId = Convert.ToInt32(gvCart.DataKeys[e.RowIndex]["UserID"]);
            int StationeryId = Convert.ToInt32(gvCart.DataKeys[e.RowIndex]["StationeryID"]);
            string response = CartController.RemoveCart(UserId, StationeryId);
            if (response.Equals("Success"))
            {
                Response.Redirect("~/Views/Customer/CustomerCart.aspx");
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userIdCookie = cookie?.Values["userId"];

            int userId = userIdCookie == null ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(userIdCookie);
            string response = TransactionHeaderController.AddTransactionHeader(userId);

            if (response.Equals("Success")){
                int transactionId = TransactionHeaderController.GetTransactionId();

                List<Cart> carts = CartController.GetListCartsByUserId(userId);
                
                foreach(Cart items in carts)
                {
                    response = TransactionDetailController.AddTransactionDetail(transactionId, items.StationeryID, items.Quantity);
                }

                if (response.Equals("Success"))
                {
                    foreach(Cart items in carts)
                    {
                        CartController.RemoveCart(userId, items.StationeryID);
                    }

                    Response.Redirect("~/Views/Customer/HomeCustomer.aspx");
                }
            }

        }
    }
}