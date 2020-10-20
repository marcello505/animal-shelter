using Core.DomainServices;
using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AdoptionRequestHttpRepository : IAdoptionRequestRepository
    {
        private HttpClient _httpClient;
        public AdoptionRequestHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(AdoptionRequest adoptionRequest)
        {
            var json = JsonConvert.SerializeObject(adoptionRequest);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/v2/adoptionrequest", httpContent);
        }

        public AdoptionRequest Get(int id)
        {
            AdoptionRequest result = null;
            var response = _httpClient.GetAsync("api/v2/adoptionrequest/" + id).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                result = JsonConvert.DeserializeObject<AdoptionRequest>(json);                
            }
            return result;
        }

        public IEnumerable<AdoptionRequest> GetAll()
        {
            IEnumerable<AdoptionRequest> result = null;
            var response = _httpClient.GetAsync("api/v2/adoptionrequest").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                result = JsonConvert.DeserializeObject<IEnumerable<AdoptionRequest>>(json);
            }
            return result;
        }

        public async Task Update(AdoptionRequest adoptionRequest)
        {
            var json = JsonConvert.SerializeObject(adoptionRequest);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/v2/adoptionrequest/" + adoptionRequest.Id, httpContent);
        }
    }
}
