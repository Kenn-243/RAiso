using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Web;

namespace RAiso.Views.Admin
{
    public partial class UpdateStationery : System.Web.UI.Page
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
                if (userRole.Equals("Customer"))
                {
                    Response.Redirect("~/Views/Customer/HomeCustomer.aspx");
                }
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["ID"]);
                MsStationery stationery = StationeryController.GetStationeryByStationeryId(id);
                txtStationeryName.Text = stationery.StationeryName.ToString();
                txtStationeryPrice.Text = stationery.StationeryPrice.ToString();
            }
        }

        protected void btnUpdateStationery_Click(object sender, EventArgs e)
        {
            int stationeryId = Convert.ToInt32(Request["ID"]);
            string stationeryName = txtStationeryName.Text.ToString();
            int stationeryPrice = string.IsNullOrEmpty(txtStationeryPrice.Text) ? 0 : Convert.ToInt32(txtStationeryPrice.Text.ToString());
            string response = StationeryController.UpdateStationery(stationeryId, stationeryName, stationeryPrice);
            lblError.Text = response;

            if (response.Equals("Success")){
                Response.Redirect("~/Views/Admin/HomeAdmin.aspx");
            }
        }
    }
}