using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public int? MinimumAgeInMonths { get; set; }
        public string TreatmentDoneBy { get; set; }
        public DateTime DateOfTreatment { get; set; }
        public int? AnimalId { get; set; }
        public string Animal { get; set; }
    }
}
