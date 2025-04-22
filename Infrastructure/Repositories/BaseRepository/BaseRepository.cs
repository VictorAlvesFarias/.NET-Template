using Domain.Entitites;
using Infrastructure.Context;
using Infrastructure.Factories.DbContextFactory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entity;
        private readonly DbContext _context;

        public BaseRepository(DbContextFactory dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext<TEntity>();
            _entity = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
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
            var entity = _entity.Find(id);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(TEntity entity)
        {
            _entity.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public TEntity GetById(int id)
        {
            return _entity.Find(id);
        }

        public IQueryable<TEntity> Get()
        {
            return _entity;
        }
    }
}
