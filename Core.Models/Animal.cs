using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        public int EstimatedAge { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DogOrCat { get; set; }
        public string Breed { get; set; }
        [Required]
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfAdoption { get; set; }
        public DateTime DateOfDeath { get; set; }
        [Required]
        public bool CastratedOrSterilized { get; set; }
        [Required]
        public bool? SafeForKids { get; set; }
        public string Treatments { get; set; }
        [Required]
        public string ReasonForLeavingOwner { get; set; }
        [Required]
        public bool Adoptable { get; set; }
        public string AdoptedBy { get; set; }
        
    }
}