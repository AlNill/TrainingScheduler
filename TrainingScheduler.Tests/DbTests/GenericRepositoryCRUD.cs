using Microsoft.EntityFrameworkCore;
using TrainingScheduler.DAL.Common.Models;
using TrainingScheduler.DAL.Contexts;
using TrainingScheduler.DAL.Repositories;

namespace TrainingScheduler.Tests.Db
{
    public class Tests
    {
        public DbContextOptions<ApplicationContext> DbOptions;
        public ApplicationContext Context;

        [SetUp]
        public void Setup()
        {
            DbOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            Context = new ApplicationContext(DbOptions);
        }

        [Test]
        public void TestAddUser()
        {
            GenericRepository<User> rep = new GenericRepository<User>(Context);
            var user1 = new User() { Id = 1, Name = "User1" };
            var user2 = new User() { Id = 2, Name = "User2" };
            var user3 = new User() { Id = 3, Name = "User3" };

            rep.Add(user1);
            rep.Add(user2);
            rep.Add(user3);

            List<User> result = (List<User>)rep.GetAll();
            Assert.That(result.Count(), Is.EqualTo(3));

            foreach(User user in result)
            {
                if (user.Id == 1)
                    Assert.That(user.Name, Is.EqualTo("User1"));
                else if (user.Id == 2)
                    Assert.That(user.Name, Is.EqualTo("User2"));
                else if (user.Id == 3)
                    Assert.That(user.Name, Is.EqualTo("User3"));
                else
                    throw new Exception($"No such user with id {user.Id}");
            }
        }

        [Test]
        public void TestDeleteUser()
        {
            GenericRepository<User> rep = new GenericRepository<User>(Context);
            var user1 = new User() { Id = 1, Name = "User1" };
            var user2 = new User() { Id = 2, Name = "User2" };
            var user3 = new User() { Id = 3, Name = "User3" };

            rep.Add(user1);
            rep.Add(user2);
            rep.Add(user3);

            rep.Delete(user2);
            List<User> result = (List<User>)rep.GetAll();
            Assert.That(result.Count(), Is.EqualTo(2));
            foreach (User user in result)
            {
                if (user.Id == 1)
                    Assert.That(user.Name, Is.EqualTo("User1"));
                else if (user.Id == 3)
                    Assert.That(user.Name, Is.EqualTo("User3"));
                else
                    throw new Exception($"No such user with id {user.Id}");
            }
        }

        [Test]
        public void TestUpdateUser()
        {
            GenericRepository<User> rep = new GenericRepository<User>(Context);
            var user1 = new User() { Id = 1, Name = "User1" };
            var user2 = new User() { Id = 2, Name = "User2" };
            var user3 = new User() { Id = 3, Name = "User3" };

            rep.Add(user1);
            rep.Add(user2);
            rep.Add(user3);

            user3.Name = "User4";
            rep.Update(user3);
            List<User> result = (List<User>)rep.GetAll();
            Assert.That(result.Count(), Is.EqualTo(3));
            foreach (User user in result)
            {
                if (user.Id == 3)
                    Assert.That(user.Name, Is.EqualTo("User4"));
            }
        }

        [Test]
        public void TestAddUpdateDeleteNullUser()
        {
            GenericRepository<User> rep = new GenericRepository<User>(Context);

            Assert.Throws<Exception>(() => rep.Add(null));
            Assert.Throws<Exception>(() => rep.Delete(null));
            Assert.Throws<Exception>(() => rep.Update(null));
        }
    }
}