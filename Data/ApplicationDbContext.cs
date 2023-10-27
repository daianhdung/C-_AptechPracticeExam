﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aptech_TH.Entity;
using Microsoft.EntityFrameworkCore;

namespace Aptech_TH.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public string DbPath { get; set; }
        public ApplicationDbContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "consoleC2204L.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=consoleC2204L.db");

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
