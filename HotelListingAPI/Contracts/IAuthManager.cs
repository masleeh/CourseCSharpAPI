using HotelListingAPI.Models.User;
using Microsoft.AspNetCore.Identity;

namespace HotelListingAPI.Contracts {
    public interface IAuthManager {
        Task<IEnumerable<IdentityError>> Register(UserDTO userDto);
        Task<AuthResponseDTO> Login(LoginUserDTO dto);
    }
}
