using RAiso.Models;
using RAiso.Repository;
using System.Collections.Generic;

namespace RAiso.Handlers
{
    public class TransactionHeaderHandler
    {
        public static string AddTransactionHeader(int userId)
        {
            TransactionHeaderRepository.AddTransactionHeader(userId);
            return "Success";
        }

        public static List<TransactionHeader> GetListTransactionHeaders()
        {
            List<TransactionHeader> transactionHeaders = TransactionHeaderRepository.GetListTransactionHeaders();
            if(transactionHeaders != null)
            {
                return transactionHeaders;
            }

            return null;
        }

        public static int GetTransactionId()
        {
            return TransactionHeaderRepository.GetTransactionId();
        }
    }
}