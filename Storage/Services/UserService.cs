using Helpers.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Storage.Interfaces;
using Storage.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Storage.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IConfiguration config)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _config = config;
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
            catch (Exception ex)
            {
                return (success: false, message: ex.Message);
            }

        }

        public async Task<(bool success, string message)> Login(LoginRequest request)
        {
            var user = _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                return (success: false, message: "Bledny email lub haslo");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return (success: false, message: "Bledny email lub haslo");
            }

            //var tokenHandler = new JwtSecurityTokenHandler();

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));

            //var tokenDescriptor = new SecurityTokenDescriptor()
            //{
            //    Subject = new ClaimsIdentity(new[]
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString().ToUpper()),
            //        new Claim(ClaimTypes.Email, user.Email),
            //    }),

            //    Expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays),
            //    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);

            //var jwtToken = tokenHandler.WriteToken(token);
            var key = Encoding.UTF8.GetBytes(_config["Authentication:JwtKey"]);
            var claims = new List<Claim>();
            claims.Add(new(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(15),
                Issuer = _config["Authentication:JwtIssuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256),
            };
            

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenHandler.WriteToken(token);


            return (success: true, message: tokenHandler.WriteToken(token));
        }
    }
}