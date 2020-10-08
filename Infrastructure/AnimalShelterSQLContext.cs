using Core.DomainServices;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AnimalShelterSqlContext : DbContext, IAnimalShelterContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Replace this with the correct string, or find a more louse coupled solution.
            optionsBuilder.UseSqlServer("");
        }
    }
}