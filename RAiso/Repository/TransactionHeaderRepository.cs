using RAiso.Factory;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class TransactionHeaderRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static int GenerateID()
        {
            int newID = db.TransactionHeaders.Select(x => x.TransactionID).ToList().LastOrDefault();
            if (newID == 0)
            {
                newID = 1;
            }
            else
            {
                newID++;
            }

            return newID;
        }

        public static List<TransactionHeader> GetListTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public static void AddTransactionHeader(int userId)
        {
            int transactionId = GenerateID();
            DateTime now = DateTime.Now;
            TransactionHeader createTransactionHeader = TransactionHeaderFactory.Create(transactionId, now, userId);
            db.TransactionHeaders.Add(createTransactionHeader);
            db.SaveChanges();
        }

        public static int GetTransactionId() {
            return db.TransactionHeaders.Select(x => x.TransactionID).ToList().LastOrDefault();
        }
    }
}