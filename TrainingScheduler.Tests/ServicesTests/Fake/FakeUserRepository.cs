using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.Tests.ServicesTests.Fake
{
    public class FakeUserRepository : IUserRepository, IGenericRepository<User>
    {
        private List<User> _entities = new List<User>();

        public void Add(User entity)
        {
            _entities.Add(entity);
        }

        public void Delete(User entity)
        {
            _entities.RemoveAll(x => x.Id == entity.Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _entities;
        }

        public User GetById(int id)
        {
            return _entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUserByName(string name)
        {
            return _entities.Where(x => x.Name == name).FirstOrDefault();
        }

        public void Update(User entity)
        {
            _entities.RemoveAll(x => x.Id == entity.Id);
            _entities.Add(entity);
        }
    }
}
