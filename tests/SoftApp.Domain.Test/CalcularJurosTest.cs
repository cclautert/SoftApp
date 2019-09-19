using SoftApp.Domain.Entities;
using SoftApp.Domain.Interfaces;
using SoftApp.Domain.Services;
using System.Threading.Tasks;
using Xunit;

namespace SoftApp.Domain.Test
{
    public class CalcularJurosTest
    {
        private readonly IJurosService _jurosService;

        public CalcularJurosTest()
        {
            ConfigAppService configApp = new ConfigAppService();
            configApp.IsRunningTest = true;            
            _jurosService = new JurosService(configApp);
        }

        [Fact(DisplayName = "Efetuar Calculo com erro")]
        public void CalcularJuros_Erro()
        {
            Task.Run(async () =>
            {
                var result = await _jurosService.CalculaJuros(100, 5);
                Assert.NotEqual(105.0m, result);
            }).GetAwaiter().GetResult();
        }        

        [Fact(DisplayName = "Efetuar Calculo Correto")]
        public void CalcularJuros_Correto()
        {
            Task.Run(async () => {
                var result = await _jurosService.CalculaJuros(100, 5);
                Assert.Equal(105.1m, result);
            }).GetAwaiter().GetResult();
        }

        [Fact(DisplayName = "Efetuar Calculo com erro passando 0 meses")]
        public void CalcularJuros_Erro_Zero_Mes()
        {
            Task.Run(async () =>
            {
                var result = await _jurosService.CalculaJuros(100, 0);
                Assert.NotEqual(105.0m, result);
            }).GetAwaiter().GetResult();
        }

        [Fact(DisplayName = "Efetuar Calculo Correto passando 0 meses")]
        public void CalcularJuros_Correto_Zero_Mes()
        {
            Task.Run(async () => {
                var result = await _jurosService.CalculaJuros(100, 0);
                Assert.Equal(100.0m, result);
            }).GetAwaiter().GetResult();
        }

        [Fact(DisplayName = "Efetuar Calculo com erro passando 0 ValorInicial")]
        public void CalcularJuros_Erro_Zero_ValorInicial()
        {
            Task.Run(async () =>
            {
                var result = await _jurosService.CalculaJuros(0, 5);
                Assert.NotEqual(105.0m, result);
            }).GetAwaiter().GetResult();
        }

        [Fact(DisplayName = "Efetuar Calculo Correto passando 0 ValorInicial")]
        public void CalcularJuros_Correto_Zero_ValorInicial()
        {
            Task.Run(async () => {
                var result = await _jurosService.CalculaJuros(0, 5);
                Assert.Equal(0m, result);
            }).GetAwaiter().GetResult();
        }
    }
}
