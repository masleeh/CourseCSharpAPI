using AutoMapper;
using HotelListingCore.Contracts;
using HotelListingData;
using Microsoft.EntityFrameworkCore;

namespace HotelListingCore.Repositories {
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository {

        private readonly HotelListingDbContext _context;
        public CountriesRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper) {
            _context = context;
        }

        public async Task<Country> GetCountryDetails(int id) {
            return await _context.Countries.Include(item => item.Hotels).FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}
