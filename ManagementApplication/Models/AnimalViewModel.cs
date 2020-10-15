using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string DogOrCat { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfArrival { get; set; }
        public bool CastratedOrSterilized { get; set; }
        public bool? SafeForKids { get; set; }
        public string Treatments { get; set; }
        public bool Adoptable { get; set; }
    }
}
