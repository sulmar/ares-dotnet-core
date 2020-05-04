using Ares.Domain.Models;

namespace Ares.Domain.Services
{
    public interface IAuthorizationService
    {
        bool TryAuthorize(string userId, string hashedPassword, out User user);
    }
}
