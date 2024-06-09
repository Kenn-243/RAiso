using RAiso.Controllers;
using RAiso.Models;
using System;
using System.Web;

namespace RAiso.Views
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userRole = cookie?.Values["UserRole"];
            string userIdCookie = cookie?.Values["userId"];

            if (Session["UserRole"] == null && userRole == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            if (!IsPostBack)
            {
                int userId = userIdCookie == null ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(userIdCookie);
                MsUser user = UserController.GetUserByUserId(userId);
                if (user != null)
                {
                    txtName.Text = user.UserName;
                    txtDate.Text = user.UserDOB.ToString("yyyy-MM-dd");
                    rblGender.Text = user.UserGender;
                    txtAddress.Text = user.UserAddress;
                    txtPassword.Text = user.UserPassword;
                    txtPhone.Text = user.UserPhone;
                }
            }
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieId"];
            string userIdCookie = cookie?.Values["userId"];
            int userId = userIdCookie == null ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(userIdCookie);
            string userName = txtName.Text.ToString();
            string userDOB = txtDate.Text.ToString();
            string userGender = rblGender.Text.ToString();
            string userAddress = txtAddress.Text.ToString();
            string userPassword = txtPassword.Text.ToString();
            string userPhone = txtPhone.Text.ToString();

            string response = UserController.UpdateUser(userId, userName, userGender, userDOB, userPhone, userAddress, userPassword);
            lblError.Text = response;
            if (response.Equals("Success"))
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }
    }
}