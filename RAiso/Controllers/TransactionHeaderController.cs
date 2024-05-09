using RAiso.Handlers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controllers
{
    public class TransactionHeaderController
    {
        public static string AddTransactionHeader(int userId)
        {
            return TransactionHeaderHandler.AddTransactionHeader(userId);
        }

        public static List<TransactionHeader> GetListTransactionHeaders()
        {
            return TransactionHeaderHandler.GetListTransactionHeaders();
        }

        public static int GetTransactionId()
        {
            return TransactionHeaderHandler.GetTransactionId();
        }
    }
}