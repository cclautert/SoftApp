using SoftApp.Domain.Interfaces;

namespace SoftApp.Domain.Services
{
    public class JsonResponseService: IJsonResponseService
    {
        private decimal _resultado;
        public decimal resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }
    }
}
