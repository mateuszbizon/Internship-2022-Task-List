using Helpers.Requests;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserRequest user)
        {
            var userDto = new User
            {
                Email = user.Email,
                Password = user.Password,
                IsConfirmed = user.IsConfirmed,
            };

            await _userRepository.CreateAsync(userDto);
        }

        public void Login(LoginRequest loginDto)
        {
            var result = _userRepository.GetUserByName(loginDto);

            if (result == null)
            {
                Console.WriteLine("Nie zalogowano");
            }
            else
            {
                Console.WriteLine("Zalogowano");
            }
        }
    }
}
