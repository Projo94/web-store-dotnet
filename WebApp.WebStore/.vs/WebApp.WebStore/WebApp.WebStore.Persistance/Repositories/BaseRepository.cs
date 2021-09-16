using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly WebStoreDbContext _dbContext;

        private readonly DbSet<T> table = null;

        public BaseRepository(WebStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<T>();

        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdIntAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task AddRange(List<T> entityList)
        {
            await _dbContext.AddRangeAsync(entityList);

            //await _dbContext.SaveChangesAsync();
        }



        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        public async Task<bool> Exists(object id)
        {
            return await table.FindAsync(id) != null;
        }

    }
}
