using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Core.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int Age { get
            {
                if (DateOfBirth.HasValue && EstimatedAge.HasValue) throw  new InvalidOperationException("DateOfBirth and EstimatedAge can't both have values.");
                if (DateOfBirth.HasValue) return (DateTime.Today - DateOfBirth.Value.Date).Days / 365;
                if (EstimatedAge.HasValue) return EstimatedAge.Value;
                throw new InvalidOperationException("DateOfBirth or EstimatedAge needs to be filled.");
            } }
        public int? EstimatedAge { get; set; }
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
        public DateTime? DateOfAdoption { get; set; }
        public DateTime? DateOfDeath { get; set; }
        private bool _castratedOrSterilized { get; set; }
        [Required]
        public bool CastratedOrSterilized {
            get
            {
                //Dit checkt of de _castratedOrSterilized value true is, zo niet
                //dan kijk hij of er treatments zijn geweest die het type
                //Castrated of Sterilized hebben. Anders returned hij false.
                if (_castratedOrSterilized) return _castratedOrSterilized;
                if (Treatments != null) return Treatments
                    .Any(t => t.Type == Treatment.Types.Castration
                              || t.Type == Treatment.Types.Sterilization);
                return _castratedOrSterilized;
            }
            set
            {
                _castratedOrSterilized = value;
            } }
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