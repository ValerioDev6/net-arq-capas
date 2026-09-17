
namespace Galasy.Pedidos.Entities;

public class Cliente : BaseEntity
{

    ///<sumary>
    /// Razon Social del cliente, registrada por la entidad SUNAT
    ///</sumary>

    public string RazonSocial { get; set; } = null!;

    public string TipoDocumento { get; set; } = string.Empty;
    public string? NumeroDocumento { get; set; }

    public string Contacto { get; set; } = null!;
    public string Direccion { get; set; } = string.Empty;
    public string CorreoElectronico { get; set; } = null!;

    public string? Celular { get; set; }

    public int IdRubroMae { get; set; }

    public virtual MaestroDetalle IdRubroMaeNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
