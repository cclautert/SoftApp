using SoftApp.Domain.Interfaces;

namespace SoftApp.Domain.Services
{
    public class ConfigAppService: IConfigAppService
    {
        private string _GitHubUrl;
        public string GitHubUrl
        {
            get { return _GitHubUrl; }
            set { _GitHubUrl = value; }
        }

        private string _UrlTaxaApi;
        public string UrlTaxaApi
        {
            get { return _UrlTaxaApi; }
            set { _UrlTaxaApi = value; }
        }

        private bool _IsRunningTest;
        public bool IsRunningTest
        {
            get { return _IsRunningTest; }
            set { _IsRunningTest = value; }
        }

        private string _TokenKey;
        public string TokenKey
        {
            get { return _TokenKey; }
            set { _TokenKey = value; }
        }

        private string _TokenIssuer;
        public string TokenIssuer
        {
            get { return _TokenIssuer; }
            set { _TokenIssuer = value; }
        }
    }
}
