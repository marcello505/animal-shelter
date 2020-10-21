using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AnimalSubmissionSqlRepository : IAnimalSubmissionRepository
    {
        private AnimalShelterSqlContext _context;

        public AnimalSubmissionSqlRepository()
        {
            _context = new AnimalShelterSqlContext();
        }

        public async Task Add(AnimalSubmission animalSubmission)
        {
            _context.AnimalSubmissions.Add(animalSubmission);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(AnimalSubmission animalSubmission)
        {
            _context.AnimalSubmissions.Remove(animalSubmission);
            await _context.SaveChangesAsync();
        }

        public AnimalSubmission Get(int id)
        {
            return _context.AnimalSubmissions.SingleOrDefault(ans => ans.Id == id);
        }

        public IEnumerable<AnimalSubmission> GetAll()
        {
            return _context.AnimalSubmissions;
        }

        public async Task Update(AnimalSubmission animalSubmission)
        {
            _context.AnimalSubmissions.Update(animalSubmission);
            await _context.SaveChangesAsync();
        }
    }
}
