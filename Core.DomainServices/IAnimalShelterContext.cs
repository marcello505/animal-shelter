using System.Collections;
using System.Collections.Generic;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.DomainServices
{
    public interface IAnimalShelterContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        public int SaveChanges();

    }
}