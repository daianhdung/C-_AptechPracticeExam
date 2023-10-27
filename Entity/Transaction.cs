using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptech_TH.Entity
{
    internal class Transaction
    {
        public int Id { get; private set; }
        public string description { get; private set; }
        public double TotalBill { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
    }
}
