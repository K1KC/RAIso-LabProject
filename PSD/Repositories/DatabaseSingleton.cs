using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD.Models;
using PSD.Repositories;
using PSD.Factories;

namespace PSD.Views.Repositories
{
    public class DatabaseSingleton
    {

        private static RAIsoEntities1 db;

        public static RAIsoEntities1 getInstance()
        {
            if (db == null)
            {
                db = new RAIsoEntities1();
            }
            return db;
        }


    }
}