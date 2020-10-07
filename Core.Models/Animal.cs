using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get 
            {
                return DateOfBirth;
            }
            set
            {
                DateOfBirth = value;
                if(value.HasValue)
                {
                    EstimatedAge = null;
                    Age = (DateTime.Now - DateOfBirth.Value).Days / 365;
                }
            }
        }
        [Required]
        public int Age { get; private set; }
        public int? EstimatedAge {
            get 
            {
                return EstimatedAge;
            }
            set
            {
                EstimatedAge = value;
                if(value.HasValue)
                {
                    DateOfBirth = null;
                    Age = value.Value;
                }
            }
        }
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
        public IEnumerable<Treatment> Treatments { get; set; }
        [Required]
        public string ReasonForLeavingOwner { get; set; }
        [Required]
        public bool Adoptable { get; set; }
        public string AdoptedBy { get; set; }
        
    }
}