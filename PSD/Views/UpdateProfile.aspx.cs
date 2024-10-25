using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD.Views
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private RAIsoEntities1 db = new RAIsoEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserProfileLoad();
            }
        }

        private void UserProfileLoad()
        {
            if (Session["user"] != null)
            {
                MsUser user = (MsUser)Session["user"];
                TBox_Name.Text = user.UserName;
                TBox_DoB.Text = user.UserDOB.ToString("yyyy-MM-dd");
                DDL_Gender.SelectedValue = user.UserGender;
                TBox_Address.Text = user.UserAddress;
                TBox_Password.Text = user.UserPassword;
                TBox_Phone.Text = user.UserPhone;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void CV_DoB_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void CV_Unique_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string userName = args.Value;
            MsUser user = (MsUser)Session["user"];
            var existingUser = db.MsUsers.FirstOrDefault(u => u.UserName == userName && u.UserID != user.UserID);
            args.IsValid = existingUser != null;
        }



        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null) 
            {
                MsUser sessionUser = (MsUser)Session["user"];
                using (var dbContext = new RAIsoEntities1())
                {
                    MsUser user = dbContext.MsUsers.FirstOrDefault(u => u.UserID == sessionUser.UserID);
                    if (user != null)
                    {
                        user.UserName = TBox_Name.Text;
                        user.UserDOB = DateTime.Parse(TBox_DoB.Text);
                        user.UserGender = DDL_Gender.SelectedValue;
                        user.UserAddress = TBox_Address.Text;
                        user.UserPassword = TBox_Password.Text;
                        user.UserPhone = TBox_Phone.Text;

                        dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();

                        Session["user"] = user;

                        Lbl_Message.Text = "Successfully Updated";
                        Lbl_Message.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}