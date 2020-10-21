using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface ICageRepository
    {
        public IEnumerable<Cage> GetAll();
        public IEnumerable<Cage> GetAllFreeCages();
        public Cage Get(int id);
        public Task Add(Cage cage);
        public Task Delete(Cage cage);
        
    }
}
