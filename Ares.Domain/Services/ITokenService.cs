using Ares.Domain.Models;

namespace Ares.Domain.Services
{
    public interface ITokenService
    {
        string Create(User user);
    }
}
