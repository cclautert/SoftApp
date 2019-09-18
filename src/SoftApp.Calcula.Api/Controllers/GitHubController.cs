using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftApp.Domain.Services;

namespace SoftApp.Calcula.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("showmethecode")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly ConfigApp _configApp;

        public GitHubController(ConfigApp configApp)
        {
            _configApp = configApp;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("")]
        public IActionResult Index()
        {
            try
            {
                return Ok(new
                {
                    AddressGitHub = _configApp.GitHubUrl
                });
            }
            catch (Exception e)
            {
                return BadRequest(new { ShowmeTheCode = e.Message });
            }
        }
    }
}