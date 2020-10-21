using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class AnimalSubmission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DogOrCat { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public bool CastratedOrSterilized { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string ReasonForLeavingOwner { get; set; }
        public string OwnerName { get; set; }

    }
}
