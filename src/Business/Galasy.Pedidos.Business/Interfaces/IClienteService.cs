using Galasy.Pedidos.DTO.Request.Cliente;
using Galasy.Pedidos.DTO.Response;
using Galasy.Pedidos.Entities;

namespace Galasy.Pedidos.Business.Interfaces;

public interface IClienteService
{
    Task<BaseResponse<ICollection<Cliente>>> GetAllClientes();
    Task<BaseResponse<Cliente>> GetClienteById(int id);
    Task<BaseResponse> AddCliente(ClienteRequest request);
    Task<BaseResponse> UpdateCliente(int id, ClienteRequest request);
    Task<BaseResponse> DeleteCliente(int id);
}