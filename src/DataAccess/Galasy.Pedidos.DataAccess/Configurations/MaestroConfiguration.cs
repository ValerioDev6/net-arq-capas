using Galasy.Pedidos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galasy.Pedidos.DataAccess.Configurations;

public class MaestroConfiguration : IEntityTypeConfiguration<Maestro>
{
    public void Configure(EntityTypeBuilder<Maestro> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__Maestro__3214EC07E5B7FD1D");
        entity.ToTable("Maestro", "Sch_Configuracion");
        entity.HasIndex(e => e.Codigo, "UQ__Maestro__06370DAC62BB1E92").IsUnique();
        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Codigo).HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.Descripcion).HasMaxLength(200).IsUnicode(false);
        entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
        entity.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.UsuarioCreacion).HasMaxLength(50).IsUnicode(false).HasDefaultValue("sql");
        entity.Property(e => e.UsuarioModificacion).HasMaxLength(100).IsUnicode(false);
    }
}
