using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
    public class AdoptionRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [ForeignKey("Animal.Id")]
        public int? Animal1 { get; set; }
        [ForeignKey("Animal.Id")]
        public int? Animal2 { get; set; }
        [ForeignKey("Animal.Id")]
        public int? Animal3 { get; set; }

    }
}
