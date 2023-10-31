using Aptech_TH.Data;
using Aptech_TH.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptech_TH.Services.Imp
{

    internal class TransactionServiceImp : TransactionService
    {
        private readonly ApplicationDbContext db;
        public Transaction createTransaction(Transaction transaction)
        {
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return transaction;
        }
    }
}
