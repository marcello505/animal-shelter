using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Treatment
    {
        public enum Types
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
        public Types Type { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Cost { get; set; }
        public int? MinimumAgeInMonths { get; set; }
        [Required]
        public string TreatmentDoneBy { get; set; }
        [Required]
        public DateTime DateOfTreatment { get; set; }

        [ForeignKey("Animal")]
        public int? AnimalId { get; set; }
    }
}