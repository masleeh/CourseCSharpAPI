using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListingCore.Contracts;
using HotelListingCore.Models;
using HotelListingData;
using Microsoft.EntityFrameworkCore;

namespace HotelListingCore.Repositories {
    public class GenericRepository<T> : IGenericRepository<T> where T : class {

        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(HotelListingDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParams) {
            var totalSize = await _context.Set<T>().CountAsync();
            var items = await _context.Set<T>()
                .Skip(queryParams.StartIndex)
                .Take(queryParams.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new PagedResult<TResult>() {
                Items = items,
                PageIndex = queryParams.PageIndex,
                RecordIndex = queryParams.StartIndex,
                TotalCount = totalSize
            };
        }

        public async Task<T> GetAsync(int? id) {
            if (id is null)
                return null;
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity) {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity) {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DoesExist(int id) {
            var entity = await GetAsync(id);
            return entity != null;
        }
    }
}
