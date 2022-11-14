using ARQUICAPAS.Domain.Entities;

namespace ARQUICAPAS.Infrastructure.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AcountByUserName(string userName);
    }
}
