using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface ICageRepository
    {
        public IEnumerable<Cage> GetAll();
        public Cage Get(int id);
        public void Add(Cage cage);
        
    }
}
