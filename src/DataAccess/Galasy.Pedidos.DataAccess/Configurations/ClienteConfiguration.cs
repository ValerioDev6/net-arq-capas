using Galasy.Pedidos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galasy.Pedidos.DataAccess.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC07279C8B82");
        entity.ToTable("Cliente", "Sch_Pedido");
        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Celular).HasMaxLength(9).IsUnicode(false).IsFixedLength();
        entity.Property(e => e.Contacto).HasMaxLength(100).IsUnicode(false);
        entity.Property(e => e.CorreoElectronico).HasMaxLength(200).IsUnicode(false);
        entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
        entity.Property(e => e.NumeroDocumento).HasMaxLength(15).IsUnicode(false);
        entity.Property(e => e.RazonSocial).HasMaxLength(150).IsUnicode(false);
        entity.Property(e => e.UsuarioCreacion).HasMaxLength(50).IsUnicode(false).HasDefaultValue("sql");
        entity.Property(e => e.UsuarioModificacion).HasMaxLength(100).IsUnicode(false);
        entity.HasOne(d => d.IdRubroMaeNavigation).WithMany(p => p.Clientes)
            .HasForeignKey(d => d.IdRubroMae).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Cliente_Rubro");
    }
}
