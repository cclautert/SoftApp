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
                var ValorCalculado = await _jurosService.CalculaJuros(valorinicial, meses);

                var result = string.Format("{0:0.00}", ValorCalculado);

                return Ok(new
                {
                    resultado = result
                });
            }
            catch (BusinessException be)
            {
                return BadRequest(new { ErroCalcularJuros = be.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { ErroCalcularJuros = e.Message });
            }
        }
    }
}
