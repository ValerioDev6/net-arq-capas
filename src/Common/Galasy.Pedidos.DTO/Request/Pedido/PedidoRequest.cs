using System.ComponentModel.DataAnnotations;
using Galasy.Pedidos.Common.Contasnts;

namespace Galasy.Pedidos.DTO.Request.Pedido;

public class PedidoRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un cliente")]
    [Display(Name = "Cliente")]
    public int IdCliente { get; set; }

    [Display(Name = "Adelanto")]
    public decimal Adelanto { get; set; }

    [MinLength(1, ErrorMessage = "Debe agregar al menos un producto")]
    public List<PedidoDetalleRequest> Detalles { get; set; } = new();
}

public class PedidoDetalleRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un producto")]
    public int IdProducto { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Cantidad inválida")]
    public decimal Cantidad { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Precio inválido")]
    public decimal PrecioUnitario { get; set; }
}
