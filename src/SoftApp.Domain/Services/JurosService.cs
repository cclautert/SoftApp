using Newtonsoft.Json;
using SoftApp.Domain.Interfaces;
using SoftApp.Domain.Services;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SoftApp.Domain.Entities
{
    public class JurosService : IJurosService
    {
        private readonly HttpClient _ClientHttp;
        private readonly ConfigApp _configApp;

        public JurosService(ConfigApp pConfigApp)
        {
            _ClientHttp = new HttpClient();
            _configApp = pConfigApp;
        }

        public async Task <decimal> CalculaJuros(decimal pValorInicial, int pMeses)
        {
            var juros = await this.RecuperarTaxaJuros();

            var calculo = (decimal)Math.Pow((double)(1 + juros), pMeses);
            calculo = pValorInicial * calculo;

            return await this.Truncate(calculo, 2);
        }

        /// <summary>
        /// Números Literais
        /// 0f - single
        /// 0d - double
        /// 0m - decimal (money)
        /// 0u - unsigned int
        /// 0l - long
        /// 0ul - unsigned long
        /// </summary>
        /// <returns></returns>
        public Task<decimal> ObterTaxaJuro()
        {
            return Task.Run(() =>
            {
                var taxa = 0.01m;
                return taxa;
            });
        }

        private class JsonDes
        {
            private decimal _resultado;

            public decimal resultado
            {
                get { return _resultado; }
                set { _resultado = value; }
            }
        }

        public async Task<decimal> RecuperarTaxaJuros()
        {
            HttpResponseMessage response = await _ClientHttp.GetAsync(_configApp.UrlTaxaApi);
            if (response.IsSuccessStatusCode)
            {                
                var taxaJsonString = await response.Content.ReadAsStringAsync();
                                
                return JsonConvert.DeserializeObject<JsonDes>(taxaJsonString).resultado;
            }
            return 0m;            
        }

        public Task<decimal> Truncate(decimal pValor, int pCasas)
        {
            return Task.Run(() =>
            {
                decimal powCasas = (decimal)Math.Pow(10, pCasas);
                decimal dTrunc = Math.Truncate(powCasas * pValor);
                return dTrunc / powCasas;
            });
        }
    }
}
