using CourseSales.Service.Authentication.Dto;
using CourseSales.Service.Authentication.Token;
using System.Threading.Tasks;

namespace CourseSales.Service.Authentication.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // Login metodu
        public async Task<ServiceResult<TokenDto>> LoginAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email)) return ServiceResult<TokenDto>.Fail("Email cannot be null or empty");
            if (string.IsNullOrEmpty(password)) return ServiceResult<TokenDto>.Fail("Password cannot be null or empty");


            // Kullanıcıyı doğrula (örnek için hardcoded)
            var userId = "123"; // Örnek kullanıcı ID
            var accessToken = _tokenService.GenerateAccessToken(userId, email, "User");
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Refresh token'ı kaydet
            await _tokenService.SaveRefreshTokenAsync(refreshToken, userId);

            // Token bilgilerini TokenDto ile döndür
            var tokenDto = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(15) // Access token geçerlilik süresi
            };

            return ServiceResult<TokenDto>.Success(tokenDto);
        }

        // Refresh Access Token metodu
        public async Task<ServiceResult<TokenDto>> RefreshAccessTokenAsync(string refreshToken, string userId)
        {
            var isValid = await _tokenService.ValidateRefreshTokenAsync(refreshToken, userId);
            if (!isValid)
            {
                return ServiceResult<TokenDto>.Fail("Invalid refresh token");
            }

            var accessToken = _tokenService.GenerateAccessToken(userId, "user@example.com", "User");
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            // Yeni refresh token'ı kaydet
            await _tokenService.SaveRefreshTokenAsync(newRefreshToken, userId);

            var tokenDto = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(15) // Yeni token süresi
            };

            return ServiceResult<TokenDto>.Success(tokenDto);
        }

        // Refresh Token'ı geçersiz yapma metodu
        public async Task<ServiceResult> RevokeRefreshToken(string refreshToken)
        {
            var isValid = await _tokenService.ValidateRefreshTokenAsync(refreshToken, "123"); // UserId örneği
            if (!isValid)
            {
                return ServiceResult.Fail("Invalid refresh token");
            }

            // Refresh token'ı sıfırla veya sil
            await _tokenService.SaveRefreshTokenAsync(string.Empty, "123"); // Token'ı geçersiz yap
            return ServiceResult.Success();
        }
    }
}
