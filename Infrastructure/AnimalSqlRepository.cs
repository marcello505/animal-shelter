using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainServices;
using Core.Models;

namespace Infrastructure
{
    public class AnimalSqlRepository : IAnimalRepository
    {

        private AnimalShelterSqlContext _context;

        public AnimalSqlRepository()
        {
            _context = new AnimalShelterSqlContext();
        }
        
        public void Add(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public void Delete(Animal animal)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }

        public IEnumerable<Animal> GetAll()
        {
            return _context.Animals;
        }

        public void Update(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
