using Ares.Domain.Models;
using System.Collections.Generic;

namespace Ares.Domain.Services
{
    public interface IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Remove(int id);
    }
}
