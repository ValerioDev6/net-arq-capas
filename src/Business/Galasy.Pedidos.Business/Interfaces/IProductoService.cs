using Galasy.Pedidos.DTO.Request.Producto;
using Galasy.Pedidos.DTO.Response;
using Galasy.Pedidos.Entities;

namespace Galasy.Pedidos.Business.Interfaces;

public interface IProductoService
{
    Task<BaseResponse<ICollection<Producto>>> GetAllProductos();
    Task<BaseResponse<Producto>> GetProductoById(int id);
    Task<BaseResponse> AddProducto(ProductoRequest request);
    Task<BaseResponse> UpdateProducto(int id, ProductoRequest request);
    Task<BaseResponse> DeleteProducto(int id);
}
