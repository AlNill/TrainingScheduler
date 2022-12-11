using System.ComponentModel.DataAnnotations;

namespace TrainingScheduler.DAL.Common.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public IEnumerable<TrainingArchive> TrainingArchives { get; set; }
    }
}
