namespace Helpers.Requests
{
    public class RegistrationRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
