using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremierLeagueApi.Models.User;

namespace PremierLeagueApi.Services.User
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserRegister model);
    }
}