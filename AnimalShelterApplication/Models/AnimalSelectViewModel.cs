using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApplication.Models
{
    public class AnimalSelectViewModel
    {
        public int selectedId { get; set; }
        public IEnumerable<Animal> animals { get; set; }
    }
}
