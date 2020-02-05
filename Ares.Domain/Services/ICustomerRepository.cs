using Ares.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Domain.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
    }
}
