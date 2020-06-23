using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.Validations.IServices
{
    public interface ICustomerService
    {
        bool ExistsEmail(string email);
    }
}
