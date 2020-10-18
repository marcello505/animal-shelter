using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TreatmentSqlRepository : ITreatmentRepository
    {
        private AnimalShelterSqlContext _context;

        public TreatmentSqlRepository()
        {
            _context = new AnimalShelterSqlContext();
        }

        public async Task Add(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Treatment> GetAll()
        {
            return _context.Treatments;
        }

        public async Task Update(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Treatment> GetByAnimalId(int animalId)
        {
            return _context.Treatments.Where(t => t.AnimalId == animalId);
        }

        public Treatment Get(int id)
        {
            return _context.Treatments.SingleOrDefault(t => t.Id == id);
        }

        public async Task Delete(Treatment treatment)
        {
            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();
        }
    }
}
