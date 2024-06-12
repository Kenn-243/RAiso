using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RAiso.Views.Customer
{
    public partial class TransactionHistory : System.Web.UI.Page
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
                List<MsStationery> msStationeries = StationeryController.GetListStationeries();
                int userId = userIdCookie == null ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(userIdCookie);
                List<TransactionHeader> transactionHeaders = TransactionHeaderController.GetListTransactionHeaders();
                MsUser user = UserController.GetUserByUserId(userId);
                
                var userTransactions = transactionHeaders
                    .Where(th => th.UserID == user.UserID)
                    .Select(th => new
                    {
                        TransactionID = th.TransactionID,
                        UserName = user.UserName,
                        TransactionDate = th.TransactionDate.ToString("dd/MM/yyyy"),
                    })
                    .ToList();
                
                if(userTransactions.Count == 0)
                {
                    lblNoData.Visible = true;
                }
                else
                {
                    lblNoData.Visible = false;
                    gvTransactionHistory.DataSource = userTransactions;
                    gvTransactionHistory.DataBind();
                }
            }
        }

        protected void gvTransactionHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTransactionHistory.Rows[gvTransactionHistory.SelectedIndex];
            string transactionId = row.Cells[0].Text;
            Response.Redirect("~/Views/Customer/TransactionDetails.aspx?ID=" + transactionId);
        }
    }
}