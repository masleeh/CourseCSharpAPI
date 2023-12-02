using HotelListingCore.Models;
using System.Runtime.CompilerServices;

namespace HotelListingCore.Contracts {
    public interface IGenericRepository<T> where T : class {
        Task<T> GetAsync(int? id);
        Task<TResult> GetAsync<TResult>(int? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<TResult>> GetAllAsync<TResult>();
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParams);
        Task<T> AddAsync(T entity);
        Task<TResult> AddAsync<TSource, TResult>(TSource source);
        Task UpdateAsync(T entity);
        Task UpdateAsync<TSource>(int id, TSource source);
        Task DeleteAsync(int id);
        Task<bool> DoesExist(int id);
    }
}
