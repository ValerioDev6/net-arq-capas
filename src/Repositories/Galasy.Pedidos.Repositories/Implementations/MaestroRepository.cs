using Galasy.Pedidos.DataAccess.Context;
using Galasy.Pedidos.Entities;
using Galasy.Pedidos.Repositories.Interfaces;

namespace Galasy.Pedidos.Repositories.Implementations;

public class MaestroRepository(DbDatabaseContext context): BaseRepository<Maestro>(context), IMaestroRepository
{
    
}