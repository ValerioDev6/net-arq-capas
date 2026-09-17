using Galasy.Pedidos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galasy.Pedidos.DataAccess.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07014744CA");
        entity.ToTable("Producto", "Sch_Pedido");
        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Descripcion).HasMaxLength(200).IsUnicode(false);
        entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
        entity.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false);
        entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.UsuarioCreacion).HasMaxLength(50).IsUnicode(false).HasDefaultValue("sql");
        entity.Property(e => e.UsuarioModificacion).HasMaxLength(100).IsUnicode(false);
        entity.HasOne(d => d.IdCategoriaMaeNavigation).WithMany(p => p.ProductoIdCategoriaMaeNavigations)
            .HasForeignKey(d => d.IdCategoriaMae).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Producto_Categoria");
        entity.HasOne(d => d.IdMarcaMaeNavigation).WithMany(p => p.ProductoIdMarcaMaeNavigations)
            .HasForeignKey(d => d.IdMarcaMae).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Producto_Marca");
    }
}
