using System;
using System.Web;
using RAiso.Controllers;

namespace RAiso.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];
            
            if(userRole != null)
            {
                if (userRole.Equals("Customer"))
                {
                    Response.Redirect("~/Views/Customer/HomeCustomer.aspx");
                }
                else if (userRole.Equals("Admin"))
                {
                    Response.Redirect("~/Views/Admin/HomeAdmin.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String userName = txtName.Text;
            String userPassword = txtPassword.Text;

            string response = UserController.LoginUser(userName, userPassword);
            lblError.Text = response;

            if(response.Equals("Success"))
            {
                string userRole = UserController.GetUser(userName, userPassword).UserRole;
                string userId = UserController.GetUser(userName, userPassword).UserID.ToString();
                if (cbRememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("cookieId");
                    cookie.Values["UserRole"] = userRole;
                    cookie.Values["UserId"] = userId;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                Session["UserRole"] = userRole;
                Session["UserId"] = userId;

                if (userRole.Equals("Customer"))
                {
                    Response.Redirect("~/Views/Customer/HomeCustomer.aspx");
                }
                else if (userRole.Equals("Admin"))
                {
                    Response.Redirect("~/Views/Admin/HomeAdmin.aspx");
                }
            }
        }
    }
}