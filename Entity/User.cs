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
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public int LoyaltyPoint { get; private set; }
        public int RoleId { get; private set; }
        public Role Role { get; private set; }
        public List<Transaction> Transactions { get; } = new();
    }
}
