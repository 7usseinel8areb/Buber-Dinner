using BuberDinner.Application.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _generator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator generator, IUserRepository userRepository)
        {
            _generator = generator;
            _userRepository = userRepository;
        }
        public AuthenticationResult Login(string email, string password)
        {
            // Check the user if exist
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User doesn't exists");
            }

            // Validate user password is correct
            if(user.Password != password)
            {
                throw new Exception("User password is not correct");
            }

            // Create Jwt token
            var token = _generator.GenerateToken(user);

            return new AuthenticationResult(
                //new User() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email }
                user,
                token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //Check if user already exists
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new DuplicateEmailException();
            }

            //Create a user (generate unique Id)
            User user = new()
            {
                FirstName = firstName,
                Email = email,
                LastName = lastName,
                Password = password
            };
            _userRepository.Add(user);
            //Create Jwt Token
            var token = _generator.GenerateToken(user);

            return new AuthenticationResult(
                //new User() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email }
                user,
                token);
        }
    }
}
