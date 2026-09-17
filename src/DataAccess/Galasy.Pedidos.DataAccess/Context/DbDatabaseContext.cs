using Galasy.Pedidos.Entities;
using Microsoft.EntityFrameworkCore;

namespace Galasy.Pedidos.DataAccess.Context;

public partial class DbDatabaseContext : DbContext
{
    public DbDatabaseContext()
    {
    }

    public DbDatabaseContext(DbContextOptions<DbDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Maestro> Maestros { get; set; }

    public virtual DbSet<MaestroDetalle> MaestroDetalles { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbDatabaseContext).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
