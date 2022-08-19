using Helpers.Requests;
using Microsoft.AspNetCore.Identity;
using Storage.Interfaces;
using Storage.Models;
using System.Text.RegularExpressions;

namespace Storage.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<(bool success, string message)> CreateUser(RegistrationRequest request)
        {
            try
            {
                var existingUser = _userRepository.GetUserByEmail(request.Email);
                if (existingUser != null)
                    return (success: false, message: "Ten email jest juz zajety");

                User user = new User()
                {
                    Email = request.Email,
                    IsConfirmed = false, //TODO
                };

                var hashedPassword = _passwordHasher.HashPassword(user, request.Password);
                user.Password = hashedPassword;

                await _userRepository.CreateAsync(user);

                return (success: true, message: "Stworzono uzytkownika");
            }
                catch(Exception ex)
            {
                return (success: false, message: ex.Message);
            }

        }

        public async Task<(bool success, string message)> Login(UserRequest request)
        {
            var user = _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                return (success: false, message: "Bledny email lub haslo");
            }                

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                return (success: false, message: "Bledny email lub haslo");
            }

            return (success: true, message: "Zalogowano");
        }
    }
}