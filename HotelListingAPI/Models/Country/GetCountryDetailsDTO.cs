using HotelListingAPI.Models.Hotel;

namespace HotelListingAPI.Models.Country {
    public class GetCountryDetailsDTO : BaseCountryDTO {
        public int Id { get; set; }

        public List<GetHotelDTO> Hotels { get; set; }
    }
}
