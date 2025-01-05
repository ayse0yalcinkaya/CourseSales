using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSales.Repositories.Users;
using CourseSales.Service.Authentication.Dto;

namespace CourseSales.Service.Authentication.Token
{
    public interface ITokenService
    {
        string GenerateAccessToken(string userId, string email, string role);
        string GenerateRefreshToken();
        Task SaveRefreshTokenAsync(string token, string userId);
        Task<bool> ValidateRefreshTokenAsync(string token, string userId);
    }

}
