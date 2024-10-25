using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransaction(int userId, DateTime date)
        {
            TransactionHeader transactionHeader = new TransactionHeader();
            transactionHeader.UserID = userId;
            transactionHeader.TransactionDate = date;
            return transactionHeader;
        }
    }
}