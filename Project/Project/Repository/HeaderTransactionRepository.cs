﻿using Project.Factory;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repository
{
    public class HeaderTransactionRepository
    {
        static TokobediaEntities dbEntity = new TokobediaEntities();

        public static int insertHeaderTransaction(int userID, int paymentTypeID)
        {
            HeaderTransaction ht = HeaderTransactionFactory.addHeaderTransaction(userID, paymentTypeID);
            dbEntity.HeaderTransactions.Add(ht);
            dbEntity.SaveChanges();
            return ht.TransactionID;
        }

        public static int getTransactionID()
        {
            return dbEntity.HeaderTransactions.Max(ht => ht.TransactionID);
        }

        public static HeaderTransaction searchByPaymentID(int paymentID)
        {
            return (from x in dbEntity.HeaderTransactions
                    where x.PaymentTypeID == paymentID
                    select x).FirstOrDefault();
        }

        public static List<HeaderTransaction> getAllHeaderTransaction()
        {
            return dbEntity.HeaderTransactions.ToList();
        }
    }
}