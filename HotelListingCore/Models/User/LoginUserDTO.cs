using System.ComponentModel.DataAnnotations;

namespace HotelListingCore.Models.User {
    public class LoginUserDTO {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Your password is limited between {2} and {1} characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
