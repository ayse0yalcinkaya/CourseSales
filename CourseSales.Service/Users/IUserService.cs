using Azure;
using CourseSales.Repositories.Users;
using Microsoft.AspNetCore.Identity.Data;

namespace CourseSales.Service.Users
{
    public interface IUserService
    {
        //Task<ServiceResult<int>> RegisterAsync(RegisterRequest request);
        //Task<ServiceResult<string>> LoginAsync(LoginRequest request);
        //Task<ServiceResult<User>> GetProfileAsync(int userId);
        Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<UserDto>> GetUserByNameAsync(string userName);
    }

    
}
