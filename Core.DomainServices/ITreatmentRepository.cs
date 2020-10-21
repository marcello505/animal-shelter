using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface ITreatmentRepository
    {
        public IEnumerable<Treatment> GetAll();
        public IEnumerable<Treatment> GetByAnimalId(int animalId);
        public Treatment Get(int id);
        public Task Add(Treatment treatment);
        public Task Update(Treatment treatment);
        public Task Delete(Treatment treatment);
        public Task Delete(int id);
    }
}
