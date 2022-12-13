using Moq;
using Pose;
using TrainingScheduler.BLL.Services;
using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Common.Interfaces.UnitOfWork;
using TrainingScheduler.DAL.Common.Models;
using TrainingScheduler.Tests.ServicesTests.Fake;

namespace TrainingScheduler.Tests.ServicesTests
{    
    public class Tests
    {
        private IGenericRepository<User> _genericRepository;

        [SetUp]
        public void SetUp()
        {
            _genericRepository = new FakeUserRepository();
        }

        [Test]
        public void TestAdd()
        {
            // Mock UnitOfWork
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.GenericRepository<User>()).Returns(_genericRepository);
            var userService = new UserService(mockUnitOfWork.Object);

            // Using library Pose to mock internal DateTime.Now
            Shim shim = Shim.Replace(() => DateTime.Now).With(() => new DateTime(2022, 10, 20));

            PoseContext.Isolate(() =>
            {
                User user1 = new User() { Name = "User1" };
                User user2 = new User() { Name = "User2" };
                userService.Add(user1);
                userService.Add(user2);
            }, shim);

            var dbResult = _genericRepository.GetAll();
            Assert.That(dbResult.Count, NUnit.Framework.Is.EqualTo(2));
            foreach(User user in dbResult)
            {
                Assert.That(user.RegistrationTime, NUnit.Framework.Is.EqualTo(new DateTime(2022, 10, 20)));
            }
        }
    }
}
