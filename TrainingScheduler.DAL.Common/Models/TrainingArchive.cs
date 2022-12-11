using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScheduler.DAL.Common.Models
{
    public class TrainingArchive
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime DateTime { get; set; }
        
        public User User { get; set; }

        [Required]
        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        [Required]
        [MaxLength(20)]
        public int RepeatCount { get; set; }

        [MaxLength(20)]
        public int? Weight { get; set; }
    }
}