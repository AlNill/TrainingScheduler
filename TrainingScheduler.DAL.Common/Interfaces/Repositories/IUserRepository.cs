using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.DAL.Common.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetUserByName(string name);
    }
}
