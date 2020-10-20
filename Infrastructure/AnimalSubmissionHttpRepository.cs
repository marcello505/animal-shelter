using Core.DomainServices;
using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task Add(AnimalSubmission animalSubmission)
        {
            var json = JsonConvert.SerializeObject(animalSubmission);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/v2/animalsubmissions", httpContent);
            Console.WriteLine(response);
        }

        public Task Delete(AnimalSubmission animalSubmission)
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
                result = JsonConvert.DeserializeObject<AnimalSubmission>(json);                
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
                result = JsonConvert.DeserializeObject<IEnumerable<AnimalSubmission>>(json);
            }
            return result;
        }

        public async Task Update(AnimalSubmission animalSubmission)
        {
            var json = JsonConvert.SerializeObject(animalSubmission);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/v2/animalsubmissions/" + animalSubmission.Id, httpContent);
        }
    }
}
