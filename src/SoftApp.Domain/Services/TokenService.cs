using SoftApp.Domain.Interfaces;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace SoftApp.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly ConfigAppService _configApp;

        public TokenService(ConfigAppService _pConfig)
        {
            _configApp = _pConfig;
        }

        public async Task<UserService> Authenticate(LoginService pLogin)
        {
            //return Task.Run(() =>
            //{
            //    UserService user = null;
            //    if (pLogin.Username == "cristiano" && pLogin.Password == "lautert")
            //    {
            //        user = new UserService { Name = "Cristiano Lautert", Email = "cristiano.c.lautert@gmail.com" };
            //    }
            //    return user;
            //});            

            UserService user = null;

            if (pLogin.Username == "cristiano" && pLogin.Password == "lautert")
            {
                user = new UserService { Name = "Cristiano Lautert", Email = "cristiano.c.lautert@gmail.com" };
            }
            return user;
        }

        public async Task<string> BuildToken(UserService user)
        {
            //return Task.Run(() =>
            //{
            //    var claims = new[] {
            //    new Claim(JwtRegisteredClaimNames.Sub, user.Name),
            //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
            //    new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};

            //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configApp.TokenKey));
            //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //    var token = new JwtSecurityToken(_configApp.TokenIssuer,
            //      _configApp.TokenIssuer,
            //      claims,
            //      expires: DateTime.Now.AddMinutes(30),
            //      signingCredentials: creds);

            //    return new JwtSecurityTokenHandler().WriteToken(token);
            //});            

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configApp.TokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configApp.TokenIssuer,
              _configApp.TokenIssuer,
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
