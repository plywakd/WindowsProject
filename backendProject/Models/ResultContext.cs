using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProject.Models
{
    public class ResultContext : DbContext
    {
        public ResultContext(DbContextOptions<ResultContext> options) : base(options) { }
        public DbSet<Result> accounts { set; get; }
    }
}
