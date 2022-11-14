using ARQUICAPAS.Domain.Entities;
using ARQUICAPAS.Infrastructure.Commons.Bases.Request;
using ARQUICAPAS.Infrastructure.Commons.Bases.Response;

namespace ARQUICAPAS.Infrastructure.Persistences.Interfaces
{
    public interface IEncargadoRepository : IGenericRepository<Encargado>
    {
        Task<BaseEntityResponse<Encargado>> ListEncargados(BaseFiltersRequest filters);
    }
}
