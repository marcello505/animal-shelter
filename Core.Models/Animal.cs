using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Core.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int? Age { get
            {
                if (DateOfBirth.HasValue && EstimatedAge.HasValue) return null;
                if (DateOfBirth.HasValue) return (DateTime.Today - DateOfBirth.Value.Date).Days / 365;
                if (EstimatedAge.HasValue) return EstimatedAge.Value;
                return null;
            } }
        public int? EstimatedAge { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public string DogOrCat { get; set; }
        public string Breed { get; set; }
        [Required]
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfArrival { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfAdoption { get; set; }
        [DataType(DataType.Date)]
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
        public ICollection<Treatment> Treatments { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string ReasonForLeavingOwner { get; set; }
        [Required]
        public bool Adoptable { get; set; }
        public string AdoptedBy { get; set; }
        [ForeignKey("Cage")]
        public int? CageId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
    }
}