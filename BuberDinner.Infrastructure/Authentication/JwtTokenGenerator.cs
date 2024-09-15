using Microsoft.Extensions.Options;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _timeProvider;
        private readonly JwtSettings _options;

        public JwtTokenGenerator(IDateTimeProvider timeProvider,IOptions<JwtSettings> options)
        {
            _timeProvider = timeProvider;
            _options = options.Value;
        }
        public string GenerateToken(User user)
        {
            
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.Secret)),
                    SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _options.Issuer,
                expires: _timeProvider.UtcNow.AddMinutes(_options.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials,
                audience:_options.Audience
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
