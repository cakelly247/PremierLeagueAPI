using PremierLeagueApi.Services.User;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Services;
using PremierLeagueApi.Models;
using PremierLeagueApi.Api;
using PremierLeagueApi.Api.Controllers;
using PremierLeagueApi.Data;
using PremierLeagueApi.Models.User;
using PremierLeagueApi.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Services.Player;
using PremierLeagueApi.Services.Teams;
using PremierLeagueApi.Services.ManagerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IPlayerStatsService, PlayerStatsService>();
builder.Services.AddScoped<ITeamService, TeamServices>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PLDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<UserEntity>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<PLDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
