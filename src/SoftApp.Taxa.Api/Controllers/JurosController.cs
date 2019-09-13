using System;
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
        public IActionResult TaxaJuros()
        {
            try
            {
                var result = _jurosService.ObterTaxaJuro().Result;
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
