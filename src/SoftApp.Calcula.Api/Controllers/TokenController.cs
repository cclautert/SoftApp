using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftApp.Domain.Interfaces;
using SoftApp.Domain.Services;

namespace SoftApp.Calcula.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly ITokenService _token;
        public TokenController(ITokenService pTokenService)
        {
            _token = pTokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody]LoginService login)
        {
            IActionResult response = Unauthorized();
            var user = await _token.Authenticate(login);

            if (user != null)
            {
                var tokenString = await _token.BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}