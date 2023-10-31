using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aptech_TH.Entity
{
    internal class User
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? LoyaltyPoint { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Transaction> Transactions { get; } = new();


        public override string ToString()
        {
            return $"Username: {this.UserName}, Loyalty Point: {(this.LoyaltyPoint != null ? this.LoyaltyPoint : 0)}";
        }
    }
}
