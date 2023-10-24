using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.User;

namespace PremierLeagueApi.Services.User
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserRegister model);
        Task<List<UserEntity>> GetAllUsersAsync();
    }
}