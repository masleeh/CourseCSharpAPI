using HotelListingAPI.Models;

namespace HotelListingAPI.Contracts {
    public interface IGenericRepository<T> where T : class {
        Task<T> GetAsync(int? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> DoesExist(int id);
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParams);
    }
}
