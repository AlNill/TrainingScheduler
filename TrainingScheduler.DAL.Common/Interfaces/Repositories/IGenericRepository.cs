namespace TrainingScheduler.DAL.Common.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {        
        public void Add(TEntity entity);
        public IEnumerable<TEntity> GetAll();
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
