using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;

namespace WebService.Controllers
{
    public class Query
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalSubmissionRepository _animalSubmissionRepository;
        public Query(IAdoptionRequestRepository adoptionRequestRepository, IAnimalRepository animalRepository, IAnimalSubmissionRepository animalSubmissionRepository)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _animalRepository = animalRepository;
            _animalSubmissionRepository = animalSubmissionRepository;
        }

        public IEnumerable<Animal> Animals() => _animalRepository.GetAll();
        public Animal Animal(int id) => _animalRepository.Get(id);
        public IEnumerable<AdoptionRequest> AdoptionRequests() => _adoptionRequestRepository.GetAll();
        public AdoptionRequest AdoptionRequest(int id) => _adoptionRequestRepository.Get(id);
        public IEnumerable<AnimalSubmission> AnimalSubmissions() => _animalSubmissionRepository.GetAll();
        public AnimalSubmission AnimalSubmission(int id) => _animalSubmissionRepository.Get(id);

    }
}
