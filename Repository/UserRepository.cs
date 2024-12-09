using System;
using ENTITY_FRAMEWORK_EXAMPLE.Models;

namespace ENTITY_FRAMEWORK_EXAMPLE.Repository;

public class UserRepository : IRepository<User>
{
    Task IRepository<User>.Add(User entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<User>.Delete(User entity)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<User>> IRepository<User>.Get()
    {
        throw new NotImplementedException();
    }

    Task<User> IRepository<User>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    Task IRepository<User>.Save()
    {
        throw new NotImplementedException();
    }

    IEnumerable<User> IRepository<User>.Search(Func<User, bool> filter)
    {
        throw new NotImplementedException();
    }

    void IRepository<User>.Update(User entity)
    {
        throw new NotImplementedException();
    }
}
