using Ares.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Domain.Services
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }

    public interface IAuthorizationService
    {
        bool TryAuthorize(string userId, string hashedPassword, out User user);
    }
}
