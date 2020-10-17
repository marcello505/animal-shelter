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
            Sterilization = 0,
            Castration = 1,
            Vaccination = 2,
            Operation = 3,
            Chipping = 4,
            Euthanasia = 5
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public Types Type { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        public decimal? Cost { get; set; }
        public int? MinimumAgeInMonths { get; set; }
        [Required]
        public string TreatmentDoneBy { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfTreatment { get; set; }

        [ForeignKey("Animal")]
        public int? AnimalId { get; set; }
    }
}