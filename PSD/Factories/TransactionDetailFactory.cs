using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail(int transactionId, int stationeryId, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = transactionId;
            transactionDetail.StationeryID = stationeryId;
            transactionDetail.Quantity = quantity;
            return transactionDetail;
        }
    }
}