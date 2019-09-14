using System;
using System.Threading.Tasks;
using Aggregates;
using Microsoft.AspNetCore.Mvc;
using SoftApp.Domain.Interfaces;

namespace SoftApp.Taxa.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly IJurosService _jurosService;

        public JurosController(IJurosService pJurosService)
        {
            _jurosService = pJurosService;
        }

        [HttpGet("taxaJuros")]
        public async Task<IActionResult> TaxaJuros()
        {
            try
            {
                var result = await _jurosService.ObterTaxaJuro();
                return Ok(new
                {
                    resultado = result
                });
            }
            catch (BusinessException be)
            {
                return BadRequest(new { ErroObterTaxa = be.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { ErroObterTaxa = e.Message });
            }
        }
    }
}
