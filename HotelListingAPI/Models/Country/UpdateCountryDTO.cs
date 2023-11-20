using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models.Country {
    public class UpdateCountryDTO : BaseCountryDTO {
        [Required]
        public int Id { get; set; }
    }
}
