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

        public void Delete(int id)
        {
            _context.Animals.Remove(Get(id));
            _context.SaveChanges();
        }

        public void Delete(IEnumerable<Animal> animals)
        {
            _context.Animals.RemoveRange(animals);
            _context.SaveChanges();
        }

        public Animal Get(int id)
        {
            var treatmentRepository = new TreatmentSqlRepository();
            var result = _context.Animals.SingleOrDefault(p => p.Id == id);
            if (result != null) result.Treatments = treatmentRepository.GetByAnimalId(id).ToList();
            return result;
        }

        public IEnumerable<Animal> GetAll()
        {
            var treatmentRepository = new TreatmentSqlRepository();
            var result = _context.Animals;
            if(result != null) foreach(Animal element in result){
                element.Treatments = treatmentRepository.GetByAnimalId(element.Id).ToList();
            }
            return result;
        }

        public IEnumerable<Animal> GetByCageId(int cageId)
        {
            return GetAll().Where(a => a.CageId == cageId);
        }

        public void Update(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
