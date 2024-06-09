using RAiso.Controllers;
using System;
using System.Web;

namespace RAiso.Views.Admin
{
    public partial class InsertStationery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];

            if (Session["UserRole"] == null && userRole == null)
            {
                Response.Redirect("~/Views/Guest/Login.aspx");
            }
            else if (userRole != null && userRole.Equals("Customer"))
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void btnAddStationery_Click(object sender, EventArgs e)
        {
            string stationeryName = txtStationeryName.Text.ToString();
            int stationeryPrice = string.IsNullOrEmpty(txtStationeryPrice.Text) ? 0 : Convert.ToInt32(txtStationeryPrice.Text.ToString());
            string response = StationeryController.AddStationery(stationeryName, stationeryPrice);
            lblError.Text = response;

            if (response.Equals("Success"))
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }
    }
}