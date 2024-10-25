 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD.Controllers;
using PSD.Models;
using PSD.Repositories;

namespace PSD.Views
{
    public partial class RegisterPage : System.Web.UI.Page
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

            protected void Btn_Register_Click(object sender, EventArgs e)
            {
                string UserName = TBox_Username.Text;
                string UserGender = DDL_Gender.SelectedValue;
                DateTime UserDOB;
                bool isParsed = DateTime.TryParse(TBox_DOB.Text, out UserDOB);
                string UserAddress = TBox_Address.Text;
                string Password = TBox_Password.Text;
                string UserPhone = TBox_Phone.Text;

                Lbl_Error.Text = UserController.DoRegist(UserName, UserGender, UserDOB, UserPhone, UserAddress, Password);
                Lbl_Error.ForeColor = System.Drawing.Color.Red;

                if (Lbl_Error.Text == "")
                {
                    Response.Redirect("LoginPage.aspx");
                }

            }

            protected void CV_DOB_ServerValidate(object source, ServerValidateEventArgs args)
            {
                DateTime dob;
                if (DateTime.TryParse(args.Value, out dob))
                {
                    args.IsValid = (DateTime.Now.Year - dob.Year) >= 1;
                }
                else
                {
                    args.IsValid = false;
                }
            }

    }
}