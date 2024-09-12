namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _generator;

        public AuthenticationService(IJwtTokenGenerator generator)
        {
            _generator = generator;
        }
        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                "Token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //Check if user already exists


            //Create a user (generate unique Id)


            //Create Jwt Token
            Guid id = Guid.NewGuid();

            var token = _generator.GenerateToken(id, firstName, lastName);

            return new AuthenticationResult(
                id,
                firstName,
                lastName,
                email,
                token);
        }
    }
}
