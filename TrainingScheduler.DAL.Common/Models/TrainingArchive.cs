namespace TrainingScheduler.DAL.Common.Models
{
    public class TrainingArchive
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ExerciseId { get; set; }
        public Exercide Exercise { get; set; }
        public int RepeatCount { get; set; }
        public int? Weight { get; set; }
    }
}