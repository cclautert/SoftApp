using SoftApp.Domain.Interfaces;

namespace SoftApp.Domain.Services
{
    public class LoginService : ILoginService
    {
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
    }
}
