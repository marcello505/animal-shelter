using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfComment { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string CommentMadeBy { get; set; }
        [ForeignKey("Animal")]
        public int? AnimalId { get; set; }
    }
}