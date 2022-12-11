﻿using Microsoft.EntityFrameworkCore;
using TrainingScheduler.DAL.Common.Interfaces.Repositories;
using TrainingScheduler.DAL.Contexts;

namespace TrainingScheduler.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly ApplicationContext _applicationContext;

        public GenericRepository(ApplicationContext context)
        {
            _applicationContext = context;
            _dbSet = _applicationContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new Exception("Adding entity must be not null");
            _dbSet.Add(entity);
            _applicationContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new Exception("Deleting entity must be not null"); ;
            _dbSet.Remove(entity);
            _applicationContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new Exception("Updating entity must be not null"); ;
            _dbSet.Update(entity);
            _applicationContext.SaveChanges();
        }
    }
}
