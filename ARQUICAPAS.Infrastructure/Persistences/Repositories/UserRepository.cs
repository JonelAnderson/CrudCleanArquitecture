using ARQUICAPAS.Domain.Entities;
using ARQUICAPAS.Infrastructure.Persistences.Contexts;
using ARQUICAPAS.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ARQUICAPAS.Infrastructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly CRUDContext _context;

        public UserRepository(CRUDContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> AcountByUserName(string userName)
        {
            var account = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName!.Equals(userName));

            return account!;
        }
    }
}
