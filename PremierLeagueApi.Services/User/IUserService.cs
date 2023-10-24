using PremierLeagueApi.Models.User;

namespace PremierLeagueApi.Services.User
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserRegister model);
    }
}