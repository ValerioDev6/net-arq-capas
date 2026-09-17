using Galasy.Pedidos.DTO.Request.Pedido;
using Galasy.Pedidos.DTO.Response;
using Galasy.Pedidos.Entities;

namespace Galasy.Pedidos.Business.Interfaces;

public interface IPedidoService
{
    Task<BaseResponse<ICollection<Pedido>>> GetAllPedidos();
    Task<BaseResponse<Pedido>> GetPedidoById(int id);
    Task<BaseResponse> AddPedido(PedidoRequest request);
    Task<BaseResponse> UpdatePedido(int id, PedidoRequest request);
    Task<BaseResponse> DeletePedido(int id);
}
