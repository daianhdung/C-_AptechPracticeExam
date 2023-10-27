using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptech_TH.Entity
{
    internal class Role
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Description { get; private set; }
        public List<User> Users { get; } = new();
    }
}
