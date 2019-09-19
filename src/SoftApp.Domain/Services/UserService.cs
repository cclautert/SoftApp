using SoftApp.Domain.Interfaces;
using System;

namespace SoftApp.Domain.Services
{
    public class UserService : IUserService
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private DateTime _Birthdate;
        public DateTime Birthdate
        {
            get { return _Birthdate; }
            set { _Birthdate = value; }
        }
    }
}
