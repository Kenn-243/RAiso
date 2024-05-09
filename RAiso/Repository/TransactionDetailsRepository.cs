using RAiso.Factory;
using RAiso.Models;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class TransactionDetailsRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<TransactionDetail> GetListTransactionDetails()
        {
            return db.TransactionDetails.ToList();
        }
        public static void AddTransactionDetail(int transactionId, int stationeryId, int quantity)
        {
            TransactionDetail createaTransactionDetail = TransactionDetailFactory.Create(transactionId, stationeryId, quantity);
            db.TransactionDetails.Add(createaTransactionDetail);
            db.SaveChanges();
        }
    }
}