using TrainingScheduler.BLL.Interfaces;
using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> repository)
        {
            _userRepository = repository;
        }

        public void Add(User user)
        {
            var registrationTime = DateTime.Now;
            user.RegistrationTime = registrationTime;
            _userRepository.Add(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
