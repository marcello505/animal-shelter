using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApplication.Models
{
    public class AnimalFilterViewModel
    {
        public string DogOrCat { get; set; }
        public string Gender { get; set; }
        public bool? SafeForKids { get; set; }
    }
}
