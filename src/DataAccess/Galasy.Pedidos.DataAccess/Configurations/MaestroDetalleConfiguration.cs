using Galasy.Pedidos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galasy.Pedidos.DataAccess.Configurations;

public class MaestroDetalleConfiguration : IEntityTypeConfiguration<MaestroDetalle>
{
    public void Configure(EntityTypeBuilder<MaestroDetalle> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__MaestroD__3214EC07FAB6D347");
        entity.ToTable("MaestroDetalle", "Sch_Configuracion");
        entity.HasIndex(e => e.Codigo, "UQ__MaestroD__06370DAC50631999").IsUnique();
        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Codigo).HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
        entity.Property(e => e.UsuarioCreacion).HasMaxLength(50).IsUnicode(false).HasDefaultValue("sql");
        entity.Property(e => e.UsuarioModificacion).HasMaxLength(100).IsUnicode(false);
        entity.Property(e => e.Valor).HasMaxLength(50).IsUnicode(false);
        entity.HasOne(d => d.IdMaestroNavigation).WithMany(p => p.MaestroDetalles)
            .HasForeignKey(d => d.IdMaestro).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_MaestroDetalle_Maestro");
    }
}
