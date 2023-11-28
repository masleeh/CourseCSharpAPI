using HotelListingCore.Models.User;
using Microsoft.AspNetCore.Identity;

namespace HotelListingCore.Contracts {
    public interface IAuthManager {
        Task<IEnumerable<IdentityError>> Register(UserDTO userDto, bool isAdmin = false);
        Task<AuthResponseDTO> Login(LoginUserDTO dto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDTO> ValidateRefreshToken(AuthResponseDTO req);
    }
}
