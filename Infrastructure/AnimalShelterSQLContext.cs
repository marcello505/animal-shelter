using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class AnimalShelterSqlContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<AnimalSubmission> AnimalSubmissions { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Replace this with the correct string, or find a more louse coupled solution.
            optionsBuilder.UseSqlServer("Server=tcp:mhaddeman.database.windows.net,1433;Initial Catalog=AnimalShelterData;Persist Security Info=False;User ID=marcello505;Password=/8OjJCKCB\\9U|z[S~T|NPXH\")69^ug;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("Core.Models.Animal", b =>
                {
                    b.HasOne("Core.Models.Cage", null)
                        .WithMany("Animals")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Models.Comment", b =>
                {
                    b.HasOne("Core.Models.Animal", null)
                        .WithMany("Comments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Models.Treatment", b =>
                {
                    b.HasOne("Core.Models.Animal", null)
                        .WithMany("Treatments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Animal>().HasData(
                new Animal() { Id = 1, Name = "Carolientje", EstimatedAge = 18, Description = "Een mooie lapjeskat", DogOrCat = "cat", Breed = "LapjesKat", Gender = "f", DateOfArrival = new DateTime(2020, 06, 08), SafeForKids = true, CastratedOrSterilized = true, ReasonForLeavingOwner = "Eigenaar had het te druk met werk.", Adoptable = true },
                new Animal() { Id = 2, Name = "Tom", EstimatedAge = 15, Description = "Een brutale kater", DogOrCat = "cat", Breed = "Amerikaanse Korthaar", Gender = "m", DateOfArrival = new DateTime(2020, 06, 08), SafeForKids = false, CastratedOrSterilized = true, ReasonForLeavingOwner = "Veel te eigenwijs en iritant.", Adoptable = true });

            modelBuilder.Entity<Treatment>().HasData(
                new Treatment() { Id = 1, Type = Treatment.Types.Sterilization, TreatmentDoneBy = "Marcello", DateOfTreatment = new DateTime(2005, 05, 06), AnimalId = 1 },
                new Treatment() { Id = 2, Type = Treatment.Types.Castration, TreatmentDoneBy = "Dirk", DateOfTreatment = new DateTime(2008, 02, 15), AnimalId = 2 });
        }
    }
}