using System;
using Microsoft.EntityFrameworkCore;

namespace ENTITY_FRAMEWORK_EXAMPLE.Models;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options){}

    public DbSet<Beer> Beers {get; set;}
    public DbSet<Brand> Brands {get; set;}
}
