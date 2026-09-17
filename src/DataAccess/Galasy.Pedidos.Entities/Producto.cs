namespace Galasy.Pedidos.Entities;


public partial class Producto : BaseEntity
{

    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public int IdMarcaMae { get; set; }
    public int IdCategoriaMae { get; set; }
    public decimal PrecioUnitario { get; set; }

    public int Stock { get; set; }

    public virtual MaestroDetalle IdCategoriaMaeNavigation { get; set; } = null!;

    public virtual MaestroDetalle IdMarcaMaeNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
