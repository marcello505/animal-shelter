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
    public class MutationsGraphQL
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalSubmissionRepository _animalSubmissionRepository;
        public MutationsGraphQL(IAdoptionRequestRepository adoptionRequestRepository, IAnimalRepository animalRepository, IAnimalSubmissionRepository animalSubmissionRepository)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _animalRepository = animalRepository;
            _animalSubmissionRepository = animalSubmissionRepository;
        }

        public void AddAdoptionRequest(AdoptionRequest adoptionRequest) => _adoptionRequestRepository.Add(adoptionRequest);
        public void EditAdoptionRequest(AdoptionRequest adoptionRequest) => _adoptionRequestRepository.Update(adoptionRequest);
        public void AddAnimalSubmissions(AnimalSubmission animalSubmission) => _animalSubmissionRepository.Add(animalSubmission);
        public void EditAnimalSubmission(AnimalSubmission animalSubmission) => _animalSubmissionRepository.Update(animalSubmission);

    }
}
