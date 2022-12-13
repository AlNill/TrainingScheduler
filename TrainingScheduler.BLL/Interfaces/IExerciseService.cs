using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.BLL.Interfaces
{
    public interface IExerciseService
    {
        public void Add(Exercise exercise);
        public IEnumerable<Exercise> GetAll();
        public void Update(Exercise exercise);
        public void Delete(Exercise exercise);
    }
}
