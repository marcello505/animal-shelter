using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class NewCageViewModel
    {
        [Required]
        public int MaximumAnimals { get; set; }
    }
}
