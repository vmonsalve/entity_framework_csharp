using System;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using Microsoft.EntityFrameworkCore;

namespace ENTITY_FRAMEWORK_EXAMPLE.Repository;

public class UserRepository : IRepository<User>
{
    private StoreContext _context;
    public UserRepository(StoreContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> Get()
        => await _context.Users.ToArrayAsync();

    public async Task<User> GetById(int id)
        => await _context.Users.FindAsync(id);
    public async Task Add(User user)
        => await _context.Users.AddAsync(user);
    void IRepository<User>.Update(User user)
    {
        _context.Users.Attach(user);
        _context.Users.Entry(user).State = EntityState.Modified;
    }
    void IRepository<User>.Delete(User user)
        => _context.Users.Remove(user);
    public async Task Save()
        =>  await _context.SaveChangesAsync();
    public IEnumerable<User> Search(Func<User, bool> filter)
        => _context.Users.Where(filter).ToList();
}
