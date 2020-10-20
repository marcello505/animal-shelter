using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApplication.Models
{
    public class AdoptionRequestViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Need atleast 1 animal")]
        public int? AnimalId1 { get; set; }
        public int? AnimalId2 { get; set; }
        public int? AnimalId3 { get; set; }
        public ICollection<Animal> AnimalsView { get; set; } = new List<Animal>();
    }
}
