using Galasy.Pedidos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galasy.Pedidos.DataAccess.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC074B3BB4A4");
        entity.ToTable("Pedido", "Sch_Pedido");
        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Adelanto).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
        entity.Property(e => e.TotalBruto).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.TotalNeto).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.UsuarioCreacion).HasMaxLength(50).IsUnicode(false).HasDefaultValue("sql");
        entity.Property(e => e.UsuarioModificacion).HasMaxLength(100).IsUnicode(false);
        entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.IdCliente).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Pedido_Cliente");
    }
}
