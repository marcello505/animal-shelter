using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class TreatmentSqlRepository : ITreatmentRepository
    {
        private AnimalShelterSqlContext _context;

        public TreatmentSqlRepository()
        {
            _context = new AnimalShelterSqlContext();
        }

        public void Add(Treatment treatment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Treatment> GetAll()
        {
            return _context.Treatments;
        }

        public void Update(Treatment treatment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Treatment> GetByAnimalId(int animalId)
        {
            return _context.Treatments.Where(t => t.AnimalId == animalId);
        }
    }
}
