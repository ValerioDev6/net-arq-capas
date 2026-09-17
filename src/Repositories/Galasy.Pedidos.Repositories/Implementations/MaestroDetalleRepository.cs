using Galasy.Pedidos.DataAccess.Context;
using Galasy.Pedidos.Entities;
using Galasy.Pedidos.Repositories.Interfaces;

namespace Galasy.Pedidos.Repositories.Implementations;

public class MaestroDetalleRepository(DbDatabaseContext context) : BaseRepository<MaestroDetalle>(context), IMaestroDetalleRepository
{
}