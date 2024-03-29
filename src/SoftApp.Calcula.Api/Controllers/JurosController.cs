﻿using System;
using System.Threading.Tasks;
using Aggregates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftApp.Domain.Interfaces;

namespace SoftApp.Calcula.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
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
        /// Ela faz um cálculo em memória, de juros compostos, onde: Valor Final = Valor Inicial * (1 + juros) ^ Tempo
        /// </summary>
        /// <param name="valorinicial">É um decimal que representa o valor inicial</param>
        /// <param name="meses">É um inteiro que representa meses</param>
        /// <returns>O resultado final é truncado (sem arredondamento) em duas casas decimais</returns>

        [MapToApiVersion("1.0")]
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

        /// <summary>
        /// Ela faz um cálculo em memória, de juros compostos, onde: Valor Final = Valor Inicial * (1 + juros) ^ Tempo
        /// </summary>
        /// <param name="valorinicial">É um decimal que representa o valor inicial</param>
        /// <param name="meses">É um inteiro que representa meses</param>
        /// <returns>O resultado final é truncado (sem arredondamento) em duas casas decimais</returns>
        [MapToApiVersion("2.0")]
        [HttpGet("calculajuros"), Authorize]        
        public async Task<IActionResult> Calculajuros_v2(decimal valorinicial, int meses)
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
