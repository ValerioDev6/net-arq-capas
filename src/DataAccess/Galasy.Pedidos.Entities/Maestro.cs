namespace Galasy.Pedidos.Entities;


public partial class Maestro : BaseEntity
{

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }
    
    public virtual ICollection<MaestroDetalle> MaestroDetalles { get; set; } = new List<MaestroDetalle>();
}
