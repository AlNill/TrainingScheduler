using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Common.Interfaces.UnitOfWork;
using TrainingScheduler.DAL.Common.Models;
using TrainingScheduler.DAL.Contexts;

namespace TrainingScheduler.DAL.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public UserRepository(ApplicationContext context)
            : base(context)
        {

        }

        public User GetUserByName(string name)
        {
            return _dbSet.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
