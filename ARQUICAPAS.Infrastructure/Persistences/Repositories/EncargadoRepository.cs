using ARQUICAPAS.Domain.Entities;
using ARQUICAPAS.Infrastructure.Commons.Bases.Request;
using ARQUICAPAS.Infrastructure.Commons.Bases.Response;
using ARQUICAPAS.Infrastructure.Persistences.Contexts;
using ARQUICAPAS.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ARQUICAPAS.Infrastructure.Persistences.Repositories
{
    public class EncargadoRepository : GenericRepository<Encargado>, IEncargadoRepository
    {

        public EncargadoRepository(CRUDContext context) : base(context) { }

        public async Task<BaseEntityResponse<Encargado>> ListEncargados(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Encargado>();

            var encargados = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null);

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        encargados = encargados.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        encargados = encargados.Where(x => x.Email!.Contains(filters.TextFilter));
                        break;
                }
            }

            if (filters.StateFilter is not null)
            {
                encargados = encargados.Where(x => x.State.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                encargados = encargados.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await encargados.CountAsync();
            response.Items = await Ordering(filters, encargados).ToListAsync();

            return response;
        }

        
    }
}
