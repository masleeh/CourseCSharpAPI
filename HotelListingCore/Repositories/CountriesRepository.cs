using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListingCore.Contracts;
using HotelListingCore.Exceptions;
using HotelListingCore.Models.Country;
using HotelListingData;
using Microsoft.EntityFrameworkCore;

namespace HotelListingCore.Repositories {
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository {

        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public CountriesRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper) {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<Country> GetCountryDetails(int id) {
            var country =  await _context.Countries.Include(item => item.Hotels)
                .ProjectTo<Country>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (country == null) {
                throw new NotFoundException(nameof(GetCountryDetails), id);
            }

            return country;
        }
    }
}
