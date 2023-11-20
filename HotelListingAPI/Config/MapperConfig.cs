using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models.Country;
using HotelListingAPI.Models.Hotel;

namespace HotelListingAPI.Config {
    public class MapperConfig : Profile {
        public MapperConfig()
        {
            // Country
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDetailsDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();

            // Hotel
            CreateMap<Hotel, GetHotelDTO>().ReverseMap();
        }
    }
}
