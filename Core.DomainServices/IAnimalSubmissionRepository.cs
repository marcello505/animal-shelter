using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface IAnimalSubmissionRepository
    {
        public IEnumerable<AnimalSubmission> GetAll();
        public AnimalSubmission Get(int id);
        public Task Add(AnimalSubmission animalSubmission);
    }
}
