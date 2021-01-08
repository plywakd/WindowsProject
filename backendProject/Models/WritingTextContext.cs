using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProject.Models
{
    public class WritingTextContext : DbContext
    {
        public WritingTextContext(DbContextOptions<WritingTextContext> options) : base(options) { }
        public DbSet<WritingText> accounts { set; get; }
    }
}
