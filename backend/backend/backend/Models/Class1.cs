using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
    }
}