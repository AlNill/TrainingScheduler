using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.BLL.Interfaces
{
    public interface IUserService
    {
        public void Add(User user);
        public IEnumerable<User> GetAll();
        public void Update(User user);
        public void Delete(User user);
    }
}
