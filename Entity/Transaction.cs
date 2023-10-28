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
        public int Id { get; set; }
        public string description { get; set; }
        public double TotalBill { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
