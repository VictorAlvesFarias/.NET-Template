﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void AddAsync(TEntity entity);
        void RemoveAsync(TEntity item);
        void UpdateAsync(TEntity entity);
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllWhereAsync(Expression<Func<TEntity, bool>> filter);
    }
}
