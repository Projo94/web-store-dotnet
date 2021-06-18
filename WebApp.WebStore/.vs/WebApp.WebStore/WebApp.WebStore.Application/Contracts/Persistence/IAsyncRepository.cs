using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
        Task AddRange(List<T> entityList);


    }
}
