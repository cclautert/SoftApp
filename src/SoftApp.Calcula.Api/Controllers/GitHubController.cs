using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftApp.Domain.Services;

namespace SoftApp.Calcula.Api.Controllers
{
    [Route("showmethecode")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly ConfigApp _configApp;

        public GitHubController(ConfigApp configApp)
        {
            _configApp = configApp;
        }

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