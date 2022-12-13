using Microsoft.EntityFrameworkCore;
using TrainingScheduler.DAL.Common.Interfaces.Repositories;

namespace TrainingScheduler.DAL.Common.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }
        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class;
    }
}
