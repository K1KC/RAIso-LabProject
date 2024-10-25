using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD.Factories;
using PSD.Handlers;
using PSD.Models;
using PSD.Repositories;

namespace PSD.Controllers
{
    public class UserController
    {
        public static String DoRegist(string UserName, string Gender, DateTime UserDOB, string UserPhone, string UserAddress, string UserPassword)
        {
            if (UserName == "")
            {
                return "Username is Required";
            }
            else if (UserName.Length < 5 || UserName.Length > 50)
            {
                return "Username must be between 5 to 50 Characters";
            }

            if (UserDOB == DateTime.MinValue)
            {
                return "At least 1 year age";
            }

            if (Gender == "")
            {
                return "Gender Must Be Choosen";
            }

            if (UserAddress == "")
            {
                return "Address Must Be Filled!";
            }

            if (UserPassword == "")
            {
                return "Password is Required";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(UserPassword, "^[a-zA-Z0-9]+$"))
            {
                return "Password needs to be alphanumeric";
            }

            if (UserPhone == "")
            {
                return "Phone Must Be Filled!";
            }
            return UserHandler.registUser(UserName, Gender, UserDOB, UserPhone, UserAddress, UserPassword);
        }

        public static String DoLogin(String username, String password)
        {
            if (username == "")
            {
                return "Username cannot be empty!";
            }
            if (password == "")
            {
                return "Password cannot be empty";
            }

            return UserHandler.loginUser(username, password);
        }

    }
}