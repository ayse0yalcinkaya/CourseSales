using CourseSales.Service.Authentication.Auth;
using CourseSales.Service.Authentication.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CourseSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : CustomBaseController
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var result = await _authService.LoginAsync(loginRequest.Email, loginRequest.Password);
            return CreateActionResult(result); // ServiceResult ile çalışır
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto refreshTokenRequest)
        {
            var result = await _authService.RefreshAccessTokenAsync(refreshTokenRequest.RefreshToken, refreshTokenRequest.UserId);
            return result == null ? Unauthorized() : Ok(result);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken([FromBody] RefreshTokenRequestDto refreshTokenRequest)
        {
            var result = await _authService.RevokeRefreshToken(refreshTokenRequest.RefreshToken);
            return CreateActionResult(result);
        }
    }
}
