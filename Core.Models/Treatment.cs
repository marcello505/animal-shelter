using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Treatment
    {
        public enum TreatmentTypes
        {
            Sterilization,
            Castration,
            Vaccination,
            Operation,
            Chipping,
            Euthanasia
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public TreatmentTypes Type { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int MinimumAgeInMonths { get; set; }
        [Required]
        public string TreatmentDoneBy { get; set; }
        [Required]
        public DateTime DateOfTreatment { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}