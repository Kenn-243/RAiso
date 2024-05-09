using RAiso.Handlers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controllers
{
    public class TransactionDetailController
    {
        public static List<TransactionDetail> GetListTransactionDetails()
        {
            return TransactionDetailHandler.GetListTransactionDetails();
        }

        public static string AddTransactionDetail(int transactionId, int stationeryId, int quantity)
        {
            return TransactionDetailHandler.AddTransactionDetail(transactionId, stationeryId, quantity);
        }
    }
}