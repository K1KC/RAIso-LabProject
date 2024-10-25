using PSD.Models;
using PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD.Factories;

namespace PSD.Handlers
{
    public class UserHandler
    {
        public static String registUser(string UserName, string Gender, DateTime UserDOB, string UserPhone, string UserAddress, string UserPassword)
        {
            MsUser user = UserRepository.getUserByUsername(UserName);

            if (user != null)
            {
                return "Username already in used";
            }

            MsUser us = UserFactory.CreateUser(UserName, Gender, UserDOB, UserPhone, UserAddress, UserPassword, "Customer");
            UserRepository.Register(us);

            return "";
        }

        public static String loginUser(String username, String password)
        {
            MsUser user = UserRepository.checkLogin(username, password);

            if (user == null)
            {
                return "Username or Password is invalid";
            }

            return "";
        }

    }
}