using Ares.Domain.Models;
using System.Collections.Generic;

namespace Ares.Domain.Services
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        IEnumerable<Product> Get(string color);

    }
}
