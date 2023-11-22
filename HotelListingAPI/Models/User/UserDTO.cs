using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models.User {
    public class UserDTO : LoginUserDTO {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
