using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    interface ITreatmentRepository
    {
        public IEnumerable<Treatment> GetAll();
        public void Add(Treatment treatment);
        public void Update(Treatment treatment);
        public void Delete(int id);
    }
}
