using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface IAdoptionRequestRepository
    {
        public IEnumerable<AdoptionRequest> GetAll();
        public AdoptionRequest Get(int id);
        public Task Add(AdoptionRequest adoptionRequest);
        public Task Update(AdoptionRequest adoptionRequest);
    }
}
