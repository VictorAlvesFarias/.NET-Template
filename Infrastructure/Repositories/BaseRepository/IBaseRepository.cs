namespace Infrastructure.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        bool RemoveAsync(TEntity item);
        bool RemoveAsync(int id);
        bool UpdateAsync(TEntity entity);
        Task<TEntity> GetAsync(int id);
        IQueryable<TEntity> GetAll();
    }
}
