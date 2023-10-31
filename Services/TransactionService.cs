using Aptech_TH.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptech_TH.Services
{
    internal interface TransactionService
    {
        Transaction createTransaction(Transaction transaction);
    }
}
