namespace Galasy.Pedidos.Entities;


public partial class Pedido: BaseEntity
{

    public int IdCliente { get; set; }

    public decimal TotalBruto { get; set; }

    public decimal TotalNeto { get; set; }

    public decimal Adelanto { get; set; }

    
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
