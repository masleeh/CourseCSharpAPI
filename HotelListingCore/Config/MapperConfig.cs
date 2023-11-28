using AutoMapper;
using HotelListingCore.Models.Country;
using HotelListingCore.Models.Hotel;
using HotelListingCore.Models.User;
using HotelListingData;

namespace HotelListingCore.Config {
    public class MapperConfig : Profile {
        public MapperConfig() {
            // Country
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDetailsDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();

            // Hotel
            CreateMap<Hotel, GetHotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();

            // User
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
