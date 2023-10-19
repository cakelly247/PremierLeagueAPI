using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.User;

namespace PremierLeagueApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly PLDbContext _context;
        private readonly UserManager<UserEntity> _userManager;

        public UserService(PLDbContext context,
                UserManager<UserEntity> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> CreateUserAsync(UserRegister model)
        {
            if (await UserNameNotAvailable(model.UserName) || await EmailNotAvailable(model.Email))
            {
                return false;
            }

            UserEntity entity = new()
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            IdentityResult createResult = await _userManager.CreateAsync(entity, model.Password);
            return createResult.Succeeded;
        }

        private Task<bool> UserNameNotAvailable(string userName)
        {
            return _context.Users.AnyAsync(u => u.UserName == userName);
        }

        private Task<bool> EmailNotAvailable(string email)
        {
            return _context.Users.AnyAsync(e => e.Email == email);
        }
    }
}