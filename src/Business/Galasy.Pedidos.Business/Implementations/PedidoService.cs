using Galasy.Pedidos.Business.Interfaces;
using Galasy.Pedidos.DTO.Request.Pedido;
using Galasy.Pedidos.DTO.Response;
using Galasy.Pedidos.Entities;
using Galasy.Pedidos.Repositories.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Galasy.Pedidos.Business.Implementations;

public class PedidoService(
    IPedidoRepository pedidoRepository,
    IProductoRepository productoRepository,
    IClienteRepository clienteRepository,
    ILogger<PedidoService> logger) : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository = pedidoRepository;
    private readonly IProductoRepository _productoRepository = productoRepository;
    private readonly IClienteRepository _clienteRepository = clienteRepository;
    private readonly ILogger<PedidoService> _logger = logger;

    public async Task<BaseResponse<ICollection<Pedido>>> GetAllPedidos()
    {
        var response = new BaseResponse<ICollection<Pedido>>();
        try
        {
            response.Data = await _pedidoRepository.ListAsync(p => p.Estado);
            response.Success = true;
            response.Message = "Pedidos obtenidos correctamente";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al obtener los pedidos";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse<Pedido>> GetPedidoById(int id)
    {
        var response = new BaseResponse<Pedido>();
        try
        {
            response.Data = await _pedidoRepository.GetByIdAsync(id);
            response.Success = response.Data is not null;
            response.Message = response.Success
                ? "Pedido obtenido correctamente"
                : "Pedido no encontrado";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al obtener el pedido";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> AddPedido(PedidoRequest request)
    {
        var response = new BaseResponse();
        try
        {
            if (request.Detalles is null || request.Detalles.Count == 0)
            {
                response.Message = "El pedido debe tener al menos un producto";
                return response;
            }

            var cliente = await _clienteRepository.GetByIdAsync(request.IdCliente);
            if (cliente is null)
            {
                response.Message = "Cliente no encontrado";
                return response;
            }

            var pedido = new Pedido
            {
                IdCliente = request.IdCliente,
                Adelanto = request.Adelanto,
                Estado = true,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = Environment.UserName
            };

            decimal totalBruto = 0;
            foreach (var det in request.Detalles)
            {
                var producto = await _productoRepository.GetByIdAsync(det.IdProducto);
                if (producto is null)
                {
                    response.Message = $"Producto ID {det.IdProducto} no encontrado";
                    return response;
                }

                var subtotal = det.Cantidad * det.PrecioUnitario;
                totalBruto += subtotal;

                pedido.PedidoDetalles.Add(new PedidoDetalle
                {
                    IdProducto = det.IdProducto,
                    Cantidad = det.Cantidad,
                    PrecioUnitario = det.PrecioUnitario,
                    TotalBruto = subtotal,
                    TotalNeto = subtotal
                });
            }

            pedido.TotalBruto = totalBruto;
            pedido.TotalNeto = totalBruto;

            await _pedidoRepository.AddAsync(pedido);
            response.Success = true;
            response.Message = "Pedido registrado correctamente";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al registrar el pedido";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> UpdatePedido(int id, PedidoRequest request)
    {
        var response = new BaseResponse();
        try
        {
            var existing = await _pedidoRepository.GetByIdAsync(id);
            if (existing is null)
            {
                response.Message = "Pedido no encontrado";
                return response;
            }

            if (request.Detalles is null || request.Detalles.Count == 0)
            {
                response.Message = "El pedido debe tener al menos un producto";
                return response;
            }

            var cliente = await _clienteRepository.GetByIdAsync(request.IdCliente);
            if (cliente is null)
            {
                response.Message = "Cliente no encontrado";
                return response;
            }

            existing.IdCliente = request.IdCliente;
            existing.Adelanto = request.Adelanto;
            existing.FechaModificacion = DateTime.Now;
            existing.UsuarioModificacion = Environment.UserName;

            existing.PedidoDetalles.Clear();
            decimal totalBruto = 0;
            foreach (var det in request.Detalles)
            {
                var producto = await _productoRepository.GetByIdAsync(det.IdProducto);
                if (producto is null)
                {
                    response.Message = $"Producto ID {det.IdProducto} no encontrado";
                    return response;
                }

                var subtotal = det.Cantidad * det.PrecioUnitario;
                totalBruto += subtotal;

                existing.PedidoDetalles.Add(new PedidoDetalle
                {
                    IdPedido = id,
                    IdProducto = det.IdProducto,
                    Cantidad = det.Cantidad,
                    PrecioUnitario = det.PrecioUnitario,
                    TotalBruto = subtotal,
                    TotalNeto = subtotal
                });
            }

            existing.TotalBruto = totalBruto;
            existing.TotalNeto = totalBruto;

            await _pedidoRepository.UpdateAsync(existing);
            response.Success = true;
            response.Message = "Pedido actualizado correctamente";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al actualizar el pedido";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> DeletePedido(int id)
    {
        var response = new BaseResponse();
        try
        {
            var existing = await _pedidoRepository.GetByIdAsync(id);
            if (existing is null)
            {
                response.Message = "Pedido no encontrado";
                return response;
            }

            await _pedidoRepository.DeleteAsync(id);
            response.Success = true;
            response.Message = "Pedido eliminado correctamente";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al eliminar el pedido";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }
}
