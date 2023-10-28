using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptech_TH.Entity
{
    internal class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int LoyaltyPoint { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Transaction> Transactions { get; } = new();
    }
}
