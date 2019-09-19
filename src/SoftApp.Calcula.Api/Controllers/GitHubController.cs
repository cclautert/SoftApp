using System;
using Microsoft.AspNetCore.Mvc;
using SoftApp.Domain.Services;

namespace SoftApp.Calcula.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("showmethecode")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly ConfigAppService _configApp;

        public GitHubController(ConfigAppService configApp)
        {
            _configApp = configApp;
        }

        /// <summary>
        /// Retorna a url onde encontra-se o fonte no github
        /// </summary>
        /// <returns>Retorna uma string contendo a url com o fonte no github</returns>
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