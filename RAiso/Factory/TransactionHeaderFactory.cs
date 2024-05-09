using RAiso.Models;
using System;

namespace RAiso.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int transactionId, DateTime transactionDate, int userId)
        {
            return new TransactionHeader()
            {
                TransactionID = transactionId,
                UserID = userId,
                TransactionDate = transactionDate,
            };
        }
    }
}