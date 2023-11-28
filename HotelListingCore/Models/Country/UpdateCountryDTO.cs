using System.ComponentModel.DataAnnotations;

namespace HotelListingCore.Models.Country {
    public class UpdateCountryDTO : BaseCountryDTO {
        [Required]
        public int Id { get; set; }
    }
}
