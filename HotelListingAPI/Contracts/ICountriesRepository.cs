using HotelListingAPI.Data;

namespace HotelListingAPI.Contracts {
    public interface ICountriesRepository : IGenericRepository<Country> {
        Task<Country> GetCountryDetails(int id);
    }
}
