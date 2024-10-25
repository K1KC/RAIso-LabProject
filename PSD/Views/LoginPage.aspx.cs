 using PSD.Controllers;
using PSD.Models;
using PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {

                string id = Request.Cookies["user_cookie"].Value;
                MsUser userfromcookie = UserRepository.getUserById(id);
                if (userfromcookie.UserRole.Equals("Customer"))
                {
                    Response.Redirect("CustomerHomePage.aspx");
                }
                else if (userfromcookie.UserRole.Equals("Admin"))
                {
                    Response.Redirect("AdminHomePage.aspx");

                }
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string Username = TBox_Username.Text;
            string Password = TBox_Password.Text;
            bool RememberMe = CBox_RememberMe.Checked;

            Lbl_Error.Text = UserController.DoLogin(Username, Password);
            Lbl_Error.ForeColor = System.Drawing.Color.Red;


            if (Lbl_Error.Text == "")
            {
                var us = UserRepository.getUserByUsername(Username);
                if (RememberMe)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = us.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);
                }
                Session["user"] = us;
                if (us.UserRole.Equals("Admin"))
                {
                    Response.Redirect("AdminHomePage.aspx");
                }
                else if (us.UserRole.Equals("Customer"))
                {
                    Response.Redirect("CustomerHomePage.aspx");
                }

            }
        }
    }
}