using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeDataAPI.JwtService
{
    public class JwtServiceClass
    {
        public String SecretKey { get; set; }
        public int TokenDuration { get; set; }

        private readonly IConfiguration configuration;
        public JwtServiceClass(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.SecretKey = configuration.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuration = int.Parse(configuration.GetSection("jwtConfig").GetSection("Duration").Value);
        }
        public String GenerateToken(String id, String name, String email, String gender)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));

            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var payload = new[]
            {
                 new Claim("id",id),
                 new Claim("name",name),
                 new Claim("email",email),
                 new Claim("gender",gender)
            };

            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature
                );
          
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

    }
}
