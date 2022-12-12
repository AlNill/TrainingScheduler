using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.Tests.ServicesTests.Fake
{
    public class FakeUserRepository<TEntity> : IGenericRepository<TEntity> where TEntity : User
    {
        private List<TEntity> _entities = new List<TEntity>();

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _entities.RemoveAll(x => x.Id == entity.Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public void Update(TEntity entity)
        {
            _entities.RemoveAll(x => x.Id == entity.Id);
            _entities.Add(entity);
        }
    }
}
