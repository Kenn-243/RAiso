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
            else if (Session["UserRole"] != null && Session["UserRole"].Equals("Customer"))
            {
                Response.Redirect("~/Views/Home.aspx");
            }
            else if (userRole != null && userRole.Equals("Customer"))
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["ID"]);
                MsStationery stationery = StationeryController.GetStationeryByStationeryId(id);
                if(stationery != null)
                {
                    txtStationeryName.Text = stationery.StationeryName.ToString();
                    txtStationeryPrice.Text = stationery.StationeryPrice.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
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
                Response.Redirect("~/Views/Home.aspx");
            }
        }
    }
}