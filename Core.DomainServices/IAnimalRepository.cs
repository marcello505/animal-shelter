using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IAnimalRepository
    {
        public IEnumerable<Animal> GetAll();
        public Animal Get(int id);
        public IEnumerable<Animal> GetByCageId(int cageId);
        public void Add(Animal animal);
        public void Update(Animal animal);
        public void Delete(Animal animal);
        public void Delete(int id);
    }
}
