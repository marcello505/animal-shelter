using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;

namespace WebService.Controllers.GraphQL
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

        public AdoptionRequest AddAdoptionRequest(AdoptionRequest adoptionRequest)
        {
            _adoptionRequestRepository.Add(adoptionRequest);
            return adoptionRequest;
        }
        public AdoptionRequest EditAdoptionRequest(AdoptionRequest adoptionRequest)
        {
            _adoptionRequestRepository.Update(adoptionRequest);
            return adoptionRequest;
        }
        public AnimalSubmission AddAnimalSubmissions(AnimalSubmission animalSubmission)
        {
            _animalSubmissionRepository.Add(animalSubmission);
            return animalSubmission;
        }
        public AnimalSubmission EditAnimalSubmission(AnimalSubmission animalSubmission)
        {
            _animalSubmissionRepository.Update(animalSubmission);
            return animalSubmission;

        }
    }
}
