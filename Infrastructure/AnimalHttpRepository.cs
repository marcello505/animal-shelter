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
    public class AnimalHttpRepository : IAnimalRepository
    {
        private HttpClient _httpClient;
        public AnimalHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void Delete(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Animal Get(int id)
        {
            Animal result = null;
            var response = _httpClient.GetAsync("api/v2/animals/" + id).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                result = JsonConvert.DeserializeObject<Animal>(json);
            }
            return result;
        }

        public IEnumerable<Animal> GetAll()
        {
            IEnumerable<Animal> result = null;
            var response = _httpClient.GetAsync("api/v2/animals").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                result = JsonConvert.DeserializeObject<IEnumerable<Animal>>(json);
            }
            return result;
        }

        public IEnumerable<Animal> GetByCageId(int cageId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
