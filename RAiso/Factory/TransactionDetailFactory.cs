using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int transactionId, int stationertyId, int quantity)
        {
            return new TransactionDetail()
            {
                TransactionID = transactionId,
                StationeryID = stationertyId,
                Quantity = quantity
            };
        }
    }
}