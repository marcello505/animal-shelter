using Core.DomainServices;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AnimalShelterSqlContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Cage> Cages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Replace this with the correct string, or find a more louse coupled solution.
            optionsBuilder.UseSqlServer("Server=tcp:mhaddeman.database.windows.net,1433;Initial Catalog=AnimalShelterData;Persist Security Info=False;User ID=marcello505;Password=/8OjJCKCB\\9U|z[S~T|NPXH\")69^ug;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}