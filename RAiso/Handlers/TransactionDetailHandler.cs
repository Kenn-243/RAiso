using RAiso.Models;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handlers
{
    public class TransactionDetailHandler
    {
        public static List<TransactionDetail> GetListTransactionDetails()
        {
            List<TransactionDetail> transactionDetails = TransactionDetailsRepository.GetListTransactionDetails();
            if(transactionDetails != null)
            {
                return transactionDetails;
            }

            return null;
        }

        public static string AddTransactionDetail(int transactionId, int stationeryid, int quantity)
        {
            TransactionDetailsRepository.AddTransactionDetail(transactionId, stationeryid, quantity);
            return "Success";
        }
    }
}