using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AnimalSqlRepository : IAnimalRepository
    {

        private AnimalShelterSqlContext _context;

        public AnimalSqlRepository()
        {
            _context = new AnimalShelterSqlContext();
        }
        
        public async Task Add(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
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
            var result = _context.Animals.Include(a => a.Comments).Include(a => a.Treatments).ToList();
            //if(result != null) foreach(Animal element in result){
            //    element.Treatments = treatmentRepository.GetByAnimalId(element.Id).ToList();
            //}
            return result;
        }

        public IEnumerable<Animal> GetByCageId(int cageId)
        {
            return GetAll().Where(a => a.CageId == cageId);
        }

        public async Task Update(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }
    }
}
