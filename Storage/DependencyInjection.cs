using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Storage.Interfaces;
using Storage.Models;
using Storage.Repositories;
using Storage.Services;

namespace Storage
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            return services;
        }
    }
}