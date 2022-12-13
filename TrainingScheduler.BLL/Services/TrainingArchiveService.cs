using TrainingScheduler.BLL.Interfaces;
using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Common.Interfaces.UnitOfWork;
using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.BLL.Services
{
    public class TrainingArchiveService : ITrainingArchiveService
    {
        private readonly IGenericRepository<TrainingArchive> _genericRepository;

        public TrainingArchiveService(IUnitOfWork unitOfWork)
        {
            _genericRepository = unitOfWork.GenericRepository<TrainingArchive>();
        }

        public void Add(TrainingArchive entity)
        {
            _genericRepository.Add(entity);
        }

        public void Delete(TrainingArchive entity)
        {
            _genericRepository.Delete(entity);
        }

        public IEnumerable<TrainingArchive> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public void Update(TrainingArchive entity)
        {
            _genericRepository.Update(entity);
        }
    }
}
