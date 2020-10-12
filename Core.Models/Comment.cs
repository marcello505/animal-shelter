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
        public DateTime DateOfComment { get; set; }
        [Required]
        public string CommentMadeBy { get; set; }
        [ForeignKey("Treatment")]
        public int TreatmentId { get; set; }
    }
}