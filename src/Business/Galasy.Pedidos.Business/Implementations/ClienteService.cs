using Galasy.Pedidos.Business.Interfaces;
using Galasy.Pedidos.DTO.Request.Cliente;
using Galasy.Pedidos.DTO.Response;
using Galasy.Pedidos.Entities;
using Galasy.Pedidos.Repositories.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Galasy.Pedidos.Business.Implementations;

public class ClienteService(IClienteRepository clienteRespository, ILogger<ClienteService> logger) : IClienteService
{
    private readonly IClienteRepository _clienteRespository = clienteRespository;
    private readonly ILogger<ClienteService> _logger = logger;

    public async Task<BaseResponse<ICollection<Cliente>>> GetAllClientes()
    {
        var response = new BaseResponse<ICollection<Cliente>>();
        try
        {
            response.Data = await _clienteRespository.ListAsync(c => c.Estado);
            response.Message = "Clientes obtenidos correctamente";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al obtener los clientes";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse<Cliente>> GetClienteById(int id)
    {
        var response = new BaseResponse<Cliente>();
        try
        {
            response.Data = await _clienteRespository.GetByIdAsync(id);
            response.Success = response.Data is not null;
            response.Message = response.Success
                ? "Cliente obtenido correctamente"
                : "Cliente no encontrado";
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al obtener el cliente";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> AddCliente(ClienteRequest request)
    {
        var response = new BaseResponse();
        try
        {
            var cliente = request.Adapt<Cliente>();
            await _clienteRespository.AddAsync(cliente);
            response.Message = "Cliente agregado correctamente";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al registrar el cliente";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> UpdateCliente(int id, ClienteRequest request)
    {
        var response = new BaseResponse();
        try
        {
            var existing = await _clienteRespository.GetByIdAsync(id);
            if (existing is null)
            {
                response.Message = "Cliente no encontrado";
                return response;
            }

            var cliente = request.Adapt<Cliente>();
            await _clienteRespository.UpdateAsync(cliente);
            response.Message = "Cliente actualizado correctamente";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al actualizar el cliente";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }

    public async Task<BaseResponse> DeleteCliente(int id)
    {
        var response = new BaseResponse();
        try
        {
            var existing = await _clienteRespository.GetByIdAsync(id);
            if (existing is null)
            {
                response.Message = "Cliente no encontrado";
                return response;
            }

            await _clienteRespository.DeleteAsync(id);
            response.Message = "Cliente eliminado correctamente";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.ErrorMessage = e.Message;
            response.Message = "Hubo un error al eliminar el cliente";
            _logger.LogError(e, "{Message}", response.Message);
        }
        return response;
    }
}
