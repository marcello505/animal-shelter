using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AnimalSubmissionHttpRepository : IAnimalSubmissionRepository
    {
        private HttpClient _httpClient;
        public AnimalSubmissionHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(AnimalSubmission animalSubmission)
        {
            throw new NotImplementedException();
        }

        public AnimalSubmission Get(int id)
        {
            AnimalSubmission result = null;
            var response = _httpClient.GetAsync("api/v2/animalsubmissions/" + id).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                result = JsonSerializer.Deserialize<AnimalSubmission>(json);
                
            }
            return result;
        }

        public IEnumerable<AnimalSubmission> GetAll()
        {
            IEnumerable<AnimalSubmission> result = null;
            var response = _httpClient.GetAsync("api/v2/animalsubmissions").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                result = JsonSerializer.Deserialize<IEnumerable<AnimalSubmission>>(json);
            }
            return result;
        }

        public Task Update(AnimalSubmission animalSubmission)
        {
            throw new NotImplementedException();
        }
    }
}
