using Galasy.Pedidos.Business.Interfaces;
using Galasy.Pedidos.DTO.Request.Producto;
using Galasy.Pedidos.DTO.Response;
using Galasy.Pedidos.Entities;
using Galasy.Pedidos.Repositories.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Galasy.Pedidos.Business.Implementations;

public class ProductoService(IProductoRepository productoRepository, ILogger<ProductoService> logger) : IProductoService
{
    private readonly IProductoRepository _productoRepository = productoRepository;
    private readonly ILogger<ProductoService> _logger = logger;

    public async Task<BaseResponse<ICollection<Producto>>> GetAllProductos()
    {
        var response = new BaseResponse<ICollection<Producto>>();
        try
        {
            response.Data = await _productoRepository.ListAsync(p => p.Estado);
            response.Success = true;
            response.Message = "Productos obtenidos correctamente";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al obtener los productos";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse<Producto>> GetProductoById(int id)
    {
        var response = new BaseResponse<Producto>();
        try
        {
            response.Data = await _productoRepository.GetByIdAsync(id);
            response.Success = response.Data is not null;
            response.Message = response.Success
                ? "Producto obtenido correctamente"
                : "Producto no encontrado";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al obtener el producto";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> AddProducto(ProductoRequest request)
    {
        var response = new BaseResponse();
        try
        {
            var producto = request.Adapt<Producto>();
            await _productoRepository.AddAsync(producto);
            response.Success = true;
            response.Message = "Producto registrado correctamente";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al registrar el producto";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> UpdateProducto(int id, ProductoRequest request)
    {
        var response = new BaseResponse();
        try
        {
            var existing = await _productoRepository.GetByIdAsync(id);
            if (existing is null)
            {
                response.Message = "Producto no encontrado";
                return response;
            }

            var producto = request.Adapt<Producto>();
            producto.Id = id;
            await _productoRepository.UpdateAsync(producto);
            response.Success = true;
            response.Message = "Producto actualizado correctamente";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al actualizar el producto";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> DeleteProducto(int id)
    {
        var response = new BaseResponse();
        try
        {
            var existing = await _productoRepository.GetByIdAsync(id);
            if (existing is null)
            {
                response.Message = "Producto no encontrado";
                return response;
            }

            await _productoRepository.DeleteAsync(id);
            response.Success = true;
            response.Message = "Producto eliminado correctamente";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al eliminar el producto";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }
}
