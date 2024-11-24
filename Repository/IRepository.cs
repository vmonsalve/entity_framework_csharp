using System;

namespace ENTITY_FRAMEWORK_EXAMPLE.Repository;

public interface IRepository<TEntity> 
{
    Task<IEnumerable<TEntity>> Get();
}
