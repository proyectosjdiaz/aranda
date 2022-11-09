using Aranda.Persistencia.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Aranda.Persistencia.Context;

public partial class ArandaDbContext : DbContext
{

    public ArandaDbContext()
    {
    }

    public ArandaDbContext(DbContextOptions<ArandaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; } = null!;
    public virtual DbSet<Producto> Productos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
