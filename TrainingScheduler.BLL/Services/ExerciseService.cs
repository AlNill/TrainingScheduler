using TrainingScheduler.BLL.Interfaces;
using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.BLL.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IGenericRepository<Exercise> _genericRepository;

        public ExerciseService(IGenericRepository<Exercise> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Add(Exercise exercise)
        {
            _genericRepository.Add(exercise);
        }

        public void Delete(Exercise exercise)
        {
            _genericRepository.Delete(exercise);
        }

        public IEnumerable<Exercise> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public void Update(Exercise exercise)
        {
            _genericRepository.Update(exercise);
        }
    }
}
