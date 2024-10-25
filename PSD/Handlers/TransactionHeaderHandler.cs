using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD.Repositories;

namespace PSD.Handlers
{
    public class TransactionHeaderHandler
    {
        public static List<TransactionHeader> GetTransactionHeaderList()
        {
            List<TransactionHeader> TH = TransactionHeaderRepository.GetTransactionHeaderList();
            if  (TH != null)
            {
                return TH;
            }
            else
            {
                return new List<TransactionHeader>();
            }
            
        }
    }
}