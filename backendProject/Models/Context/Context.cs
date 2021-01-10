using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backendProject.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<WritingText> WritingTexts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Result>().ToTable("Result");
            modelBuilder.Entity<WritingText>().ToTable("WritingText");
        }    
    }
}
