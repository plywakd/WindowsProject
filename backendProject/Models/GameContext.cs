using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProject.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }
        public DbSet<Game> accounts { set; get; }
    }
}
