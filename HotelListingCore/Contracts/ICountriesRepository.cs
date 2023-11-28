using HotelListingData;

namespace HotelListingCore.Contracts {
    public interface ICountriesRepository : IGenericRepository<Country> {
        Task<Country> GetCountryDetails(int id);
    }
}
