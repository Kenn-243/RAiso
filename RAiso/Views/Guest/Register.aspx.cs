using System;
using System.Web;
using RAiso.Controllers;

namespace RAiso.Views.Guest
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];

            if (userRole != null || Session["UserRole"] != null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text.ToString();
            string userDOB = txtDate.Text.ToString();
            string userGender = rblGender.Text.ToString();
            string userAddress = txtAddress.Text.ToString();
            string userPassword = txtPassword.Text.ToString();
            string userPhone = txtPhone.Text.ToString();

            string response = UserController.RegisterUser(userName, userDOB, userGender, userAddress, userPassword, userPhone);
            lblError.Text = response;
            if (response.Equals("Success"))
            {
                Response.Redirect("./Login.aspx");
            }
        }
    }
}