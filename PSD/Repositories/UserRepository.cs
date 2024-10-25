using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD.Factories;
using PSD.Repositories;
using PSD.Views.Repositories;

namespace PSD.Repositories
{
    public class UserRepository
    {

        public static RAIsoEntities1 db = DatabaseSingleton.getInstance();
        public static MsUser getUserById(String id)
        {

            return db.MsUsers.Where(u => u.UserID.ToString() == id).FirstOrDefault();
        }


        //public static int GenerateID()
        //{
        //    if (db == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        int maxUserID = db.MsUsers.Max(u => (int?)u.UserID) ?? 0;
        //        return maxUserID + 1;
        //    }
        //}

        public static MsUser getUserByUsername(String username)
        {

            return db.MsUsers.Where(u => u.UserName == username).FirstOrDefault();
        }


        public static void Register(MsUser newUser)
        {
            db.MsUsers.Add(newUser);
            db.SaveChanges();

        }

        public static MsUser checkLogin(String UserName, String Password)
        {
            return db.MsUsers.Where(u => u.UserName == UserName
            && u.UserPassword == Password).FirstOrDefault();
        }


    }
}