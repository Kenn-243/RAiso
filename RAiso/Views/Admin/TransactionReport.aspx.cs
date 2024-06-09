using RAiso.Report;
using RAiso.Dataset;
using System;
using System.Collections.Generic;
using RAiso.Models;
using RAiso.Repository;
using RAiso.Handlers;
using System.Web;

namespace RAiso.Views.Admin
{
    public partial class TransactionReport : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                CrystalReport report = new CrystalReport();
                CrystalReportViewer.ReportSource = report;
                DataSet data = getData(TransactionHeaderHandler.GetListTransactionHeaders());
                report.SetDataSource(data);
            }
        }

        private DataSet getData(List<TransactionHeader> transactionHeaders)
        {
            DataSet data = new DataSet();
            var headerTable = data.transaction_headers;
            var detailTable = data.transaction_details;

            foreach (TransactionHeader t in transactionHeaders)
            {
                int total = 0;
                var hrow = headerTable.NewRow();
                hrow["transaction_id"] = t.TransactionID;
                hrow["user_id"] = t.UserID;
                hrow["transaction_date"] = t.TransactionDate;

                foreach(TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["transaction_id"] = d.TransactionID;
                    drow["stationery_name"] = d.MsStationery.StationeryName;
                    drow["quantity"] = d.Quantity;
                    drow["stationery_price"] = d.MsStationery.StationeryPrice;
                    drow["sub_total_value"] = d.Quantity * d.MsStationery.StationeryPrice;
                    total += d.Quantity * d.MsStationery.StationeryPrice;
                    detailTable.Rows.Add(drow);
                }

                hrow["grand_total_value"] = total;
                headerTable.Rows.Add(hrow);
                total = 0;
            }
            return data;
        }
    }
}