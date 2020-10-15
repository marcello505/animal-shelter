using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface IAnimalRepository
    {
        public IEnumerable<Animal> GetAll();
        public Animal Get(int id);
        public IEnumerable<Animal> GetByCageId(int cageId);
        public Task Add(Animal animal);
        public Task Update(Animal animal);
        public void Delete(Animal animal);
        public void Delete(int id);
    }
}
