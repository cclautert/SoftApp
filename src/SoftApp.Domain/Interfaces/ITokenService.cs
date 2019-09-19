using SoftApp.Domain.Services;
using System.Threading.Tasks;

namespace SoftApp.Domain.Interfaces
{
    public interface ITokenService
    {
        Task<string> BuildToken(UserService user);
        Task<UserService> Authenticate(LoginService login);
    }
}
