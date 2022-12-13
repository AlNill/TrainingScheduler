using Microsoft.EntityFrameworkCore;
using System.Linq;
using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Common.Interfaces.UnitOfWork;
using TrainingScheduler.DAL.Contexts;

namespace TrainingScheduler.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(ApplicationContext context)
        {
            var DbOptions = new DbContextOptionsBuilder<ApplicationContext>().Options;                
            _context = context;
        }

        public DbContext Context { get { return (DbContext)_context; } }

        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(IGenericRepository<TEntity>);
                var repositoryInstance = Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)));
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
