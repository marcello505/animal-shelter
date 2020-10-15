using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class NewAnimalViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
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
        [Required]
        public bool CastratedOrSterilized { get; set; }
        [Required]
        public bool? SafeForKids { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string ReasonForLeavingOwner { get; set; }
        [Required]
        public bool Adoptable { get; set; }
        public string AdoptedBy { get; set; }
        public int? CageId { get; set; }
    }
}
