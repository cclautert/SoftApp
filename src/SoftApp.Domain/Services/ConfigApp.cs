namespace SoftApp.Domain.Services
{
    public class ConfigApp
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
    }
}
