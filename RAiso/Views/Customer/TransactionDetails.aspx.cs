using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RAiso.Views.Customer
{
    public partial class TransactionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];
            string userIdCookie = cookie?.Values["UserId"];

            if (Session["UserRole"] == null && userRole == null)
            {
                Response.Redirect("~/Views/Guest/Login.aspx");
            }
            else if (Session["UserRole"] != null && Session["UserRole"].Equals("Admin"))
            {
                Response.Redirect("~/Views/Home.aspx");
            }
            else if (userRole != null && userRole.Equals("Admin"))
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            if (!IsPostBack)
            {
                int transactionId = Convert.ToInt32(Request["ID"]);
                List<TransactionDetail> transactionDetails = TransactionDetailController.GetListTransactionDetails();
                List<MsStationery> stationeries = StationeryController.GetListStationeries();

                var transactions = transactionDetails
                    .Where(x => x.TransactionID == transactionId)
                    .Join(
                        stationeries,
                        transactionDetail => transactionDetail.StationeryID,
                        stationery => stationery.StationeryID,
                        (transactionDetail, stationery) => new
                        {
                            StationeryName = stationery.StationeryName,
                            StationeryPrice = stationery.StationeryPrice,
                            Quantity = transactionDetail.Quantity,
                        }
                    )
                    .ToList();

                if (transactions.Count == 0)
                {
                    lblNoData.Visible = true;
                }
                else
                {
                    lblNoData.Visible = false;
                    gvTransactionDetails.DataSource = transactions;
                    gvTransactionDetails.DataBind();
                }
            }
        }
    }
}