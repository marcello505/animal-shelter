using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AdoptionRequestSqlRepository : IAdoptionRequestRepository
    {
        private AnimalShelterSqlContext _context;

        public AdoptionRequestSqlRepository()
        {
            _context = new AnimalShelterSqlContext();
        }

        public async Task Add(AdoptionRequest adoptionRequest)
        {
            _context.AdoptionRequests.Add(adoptionRequest);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(AdoptionRequest adoptionRequest)
        {
            _context.AdoptionRequests.Remove(adoptionRequest);
            await _context.SaveChangesAsync();
        }

        public AdoptionRequest Get(int id)
        {
            return _context.AdoptionRequests.SingleOrDefault(adr => adr.Id == id);
        }

        public IEnumerable<AdoptionRequest> GetAll()
        {
            return _context.AdoptionRequests;
        }

        public async Task Update(AdoptionRequest adoptionRequest)
        {
            _context.AdoptionRequests.Update(adoptionRequest);
            await _context.SaveChangesAsync();
        }
    }
}
