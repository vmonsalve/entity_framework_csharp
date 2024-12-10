using System;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using Microsoft.EntityFrameworkCore;

namespace ENTITY_FRAMEWORK_EXAMPLE.Repository;

public class RoleRepository : IRepository<Role>
{
    private StoreContext _context;
    public RoleRepository(StoreContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Role>> Get()
        => await _context.Roles.ToArrayAsync();
    public async Task<Role> GetById(int id)
        => await _context.Roles.FindAsync(id);
    public async Task Add(Role role)
        => await _context.Roles.AddAsync(role);
    void IRepository<Role>.Update(Role role)
    {
        _context.Roles.Attach(role);
        _context.Roles.Entry(role).State = EntityState.Modified;
    }
    void IRepository<Role>.Delete(Role role)
        => _context.Roles.Remove(role);

    public async Task Save()
        =>  await _context.SaveChangesAsync();
    public IEnumerable<Role> Search(Func<Role, bool> filter)
        => _context.Roles.Where(filter).ToList();

   
}
