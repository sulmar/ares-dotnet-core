using Ares.Domain.Models;
using Ares.Domain.Models.SearchCriterias;
using System.Collections.Generic;

namespace Ares.Domain.Services
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        IEnumerable<Product> Get(string color);

        IEnumerable<Product> Get(ProductSearchCriteria criteria);


    }
}
