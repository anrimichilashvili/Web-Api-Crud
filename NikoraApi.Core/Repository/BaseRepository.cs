using Microsoft.EntityFrameworkCore;
using NikoraApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikoraApi.Core.Repository
{
    public class BaseRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class, IIdentity
    {
        private readonly NikDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(NikDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async Task Add(TEntity model)
        {
            _dbSet.Add(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity model)
        {
            _dbSet.Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entry = await GetById(id);
            _dbSet.Remove(entry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        
        
        public async Task<TEntity> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> Filter(Func<TEntity, bool> predicate)
        {
            return  _dbSet.Where(predicate);
        }

        public async Task Update(TEntity model)
        {
            _dbSet.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
