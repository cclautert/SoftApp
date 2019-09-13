using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aggregates;
using Microsoft.AspNetCore.Mvc;
using SoftApp.Domain.Interfaces;

namespace SoftApp.Calcula.Api.Controllers
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

        [HttpGet("calculajuros/valorinicial/{valorinicial}/meses/{meses}")]
        public async Task<IActionResult> Calculajuros(decimal valorinicial, int meses)
        {
            try
            {
                var result = await _jurosService.CalculaJuros(valorinicial, meses);
                return Ok(new
                {
                    resultado = result
                });
            }
            catch (BusinessException be)
            {
                return BadRequest(new { TaxaErro = be.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { TaxaErro = e.Message });
            }
        }
    }
}
