namespace Galasy.Pedidos.Common.Contasnts;

public static class ErrorMessages
{
    public const string RequiredMessage = "El campo {0} es obligatorio";

    public const string ProductoNotFound = "Producto no encontrado";
    public const string ProductoAlreadyExists = "Producto ya existe";

    public const string PedidoNotFound = "Pedido no encontrado";
    public const string PedidoMustHaveItems = "El pedido debe tener al menos un producto";
    public const string StockInsuficiente = "Stock insuficiente para el producto {0}";
}