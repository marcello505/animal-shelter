using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface ITreatmentRepository
    {
        public IEnumerable<Treatment> GetAll();
        public IEnumerable<Treatment> GetByAnimalId(int animalId);
        public void Add(Treatment treatment);
        public void Update(Treatment treatment);
        public void Delete(int id);
    }
}
