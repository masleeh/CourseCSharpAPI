﻿using HotelListingAPI.Contracts;
using HotelListingAPI.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListingAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            this._authManager = authManager;
        }

        // POST: api/Auth/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Register([FromBody] UserDTO dto) {
            var errors = await _authManager.Register(dto);
            if (errors.Any()) {
                foreach (var error in errors) {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        // POST: api/Auth/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO dto) {
            var authResponse = await _authManager.Login(dto);

            if (authResponse == null)
                return Unauthorized();
            else
                return Ok(authResponse);
        }

        // POST api/Auth/registerAdmin
        [HttpPost]
        [Route("registerAdmin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterAdmin([FromBody] UserDTO dto) {
            var errors = await _authManager.Register(dto, true);
            if (errors.Any()) {
                foreach (var error in errors) {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            dto.FirstName.Substring(1, dto.FirstName.Length - 2);
            return Ok();
        }

        // POST api/Auth/refreshToken
        [HttpPost]
        [Route("refreshToken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDTO dto) {
            var refreshResponse = await _authManager.ValidateRefreshToken(dto);
            if (refreshResponse != null) {
                return Unauthorized();
            }
            return Ok(refreshResponse);
        }
    }
}
