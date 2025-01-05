using CourseSales.Service.Authentication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Service.Authentication.Auth
{
    public interface IAuthService
    {
        Task<ServiceResult<TokenDto>> LoginAsync(string email, string password);
        Task<ServiceResult<TokenDto>> RefreshAccessTokenAsync(string refreshToken, string userId);
        Task<ServiceResult> RevokeRefreshToken(string refreshToken);
    }
}
