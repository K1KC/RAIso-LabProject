using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD.Models;

namespace PSD.Factories
{
    public class UserFactory
    {
        public static MsUser CreateUser(String name, String gender, DateTime date, String phone, String address, String password, String role)
        {
            MsUser user = new MsUser();
            user.UserName = name;
            user.UserGender = gender;
            user.UserDOB = date;
            user.UserPhone = phone;
            user.UserAddress = address;
            user.UserPassword = password;
            user.UserRole = role;
            return user;
        }
    }
}