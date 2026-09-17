using Galasy.Pedidos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galasy.Pedidos.DataAccess.Configurations;

public class PedidoDetalleConfiguration : IEntityTypeConfiguration<PedidoDetalle>
{
    public void Configure(EntityTypeBuilder<PedidoDetalle> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__PedidoDe__3214EC0736B3AF6F");
        entity.ToTable("PedidoDetalle", "Sch_Pedido");
        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.TotalBruto).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.TotalNeto).HasColumnType("decimal(18, 2)");
        entity.Ignore(e => e.Estado);
        entity.Ignore(e => e.FechaCreacion);
        entity.Ignore(e => e.UsuarioCreacion);
        entity.Ignore(e => e.FechaModificacion);
        entity.Ignore(e => e.UsuarioModificacion);
        entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalles)
            .HasForeignKey(d => d.IdPedido).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PedidoDetalle_Pedido");
        entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PedidoDetalles)
            .HasForeignKey(d => d.IdProducto).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PedidoDetalle_Producto");
    }
}
