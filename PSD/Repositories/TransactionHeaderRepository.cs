using PSD.Models;
using PSD.Views.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD.Repositories
{
    public class TransactionHeaderRepository
    {
        private static RAIsoEntities1 db = DatabaseSingleton.getInstance();
        public static List<TransactionHeader> GetTransactionHeaderList()
        {
            return db.TransactionHeaders.ToList();
        }

    }
}