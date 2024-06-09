using System;
using System.Web;

namespace RAiso.Views
{
    public partial class NavbarMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];

            if ((Session["UserRole"] != null && Session["UserRole"].Equals("Customer")) || (userRole != null && userRole.Equals("Customer")))
            {
                hlLogin.Visible = false;
                hlRegister.Visible = false;
                hlCustomerCart.Visible = true;
                hlUpdateProfile.Visible = true;
                hlTransactionHistory.Visible = true;
                lbLogout.Visible = true;
            }
            else if ((Session["UserRole"] != null && Session["UserRole"].Equals("Admin")) || (userRole != null && userRole.Equals("Admin")))
            {
                hlLogin.Visible = false;
                hlRegister.Visible = false;
                hlTransactionReport.Visible = true;
                hlUpdateProfile.Visible = true;
                lbLogout.Visible = true;
            }
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["cookieId"] != null)
            {
                HttpCookie myCookie = new HttpCookie("cookieId");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            Session.Clear();
            Response.Redirect("~/Views/Home.aspx");
        }
    }
}