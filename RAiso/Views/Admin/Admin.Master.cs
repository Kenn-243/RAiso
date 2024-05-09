using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lblLogout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["cookieId"] != null)
            {
                HttpCookie myCookie = new HttpCookie("cookieId");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            Session.Clear();
            Response.Redirect("~/Views/Guest/Login.aspx");
        }
    }
}