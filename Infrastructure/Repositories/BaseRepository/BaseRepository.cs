using Domain.Entitites;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entity;
        private readonly ApplicationContext _context;

        public BaseRepository(
            ApplicationContext entity
        )
        {
            _entity = entity.Set<TEntity>();
            _context = entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity is BaseEntityUserRelation)
            {
                var baseEntity = entity as BaseEntityUserRelation;

                if (baseEntity is not null)
                {
                    baseEntity.SetUser(_context.GetUserId());
                }
            }

            var result = await _entity.AddAsync(entity);

            _context.SaveChanges();

            return result.Entity;
        }
        public bool Remove(TEntity item)
        {
            _context.Remove(item);

            _context.SaveChanges();

            return true;
        }
        public bool Remove(int id)
        {
            _context.Remove(_entity.FindAsync(id).Result);
            _context.SaveChanges();

            return true;
        }
        public bool Update(TEntity entity)
        {
            _entity.Update(entity);

            _context.SaveChanges();

            return true;
        }
        public async Task<TEntity> GetAsync(int id)
        {
            var item = await _entity.FindAsync(id);

            return item;
        }
        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _entity;

            if (typeof(BaseEntityUserRelation).IsAssignableFrom(typeof(TEntity)))
            {
                var userId = _context.GetUserId();
                var newQuery = query.OfType<BaseEntityUserRelation>().Where(x => x.UserId == userId).Cast<TEntity>();
                return newQuery;
            }

            return query;
        }
    }
}