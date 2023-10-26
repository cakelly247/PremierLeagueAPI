using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.User;

namespace PremierLeagueApi.Services.User
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserRegister model);
        Task<UserEntity?> GetUserByIdAsync(int userId);
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(int userId);
    }
}