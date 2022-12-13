using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.BLL.Interfaces
{
    public interface ITrainingArchiveService
    {
        public void Add(TrainingArchive exercise);

        public void Delete(TrainingArchive exercise);

        public IEnumerable<TrainingArchive> GetAll();

        public void Update(TrainingArchive exercise);
    }
}
