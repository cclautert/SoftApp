using System;
using System.Threading.Tasks;
using Aggregates;
using Microsoft.AspNetCore.Mvc;
using SoftApp.Domain.Interfaces;

namespace SoftApp.Taxa.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly IJurosService _jurosService;

        public JurosController(IJurosService pJurosService)
        {
            _jurosService = pJurosService;
        }

        /// <summary>
        /// Retorna o juros de 0,01 (fixo no código)
        /// </summary>
        /// <returns>Retorna 0,01</returns>
        [MapToApiVersion("1.0")]
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
