
using System.Data.Entity;

namespace LiveScore.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext():base("DefaultConnection")
        {
                
        }
        public AppDbContext(string nameOrConnectionString):base(nameOrConnectionString)
        {
                
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
