using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftApp.Domain.Interfaces
{
    public interface IJurosService
    {
        Task<decimal> CalculaJuros(decimal pValorInicial, int pMeses);
        Task<decimal> Truncate(decimal pValor, int pCasas);
        Task<decimal> ObterTaxaJuro();
        Task<decimal> RecuperarTaxaJuros();
    }
}
