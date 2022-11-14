using ARQUICAPAS.Infrastructure.Persistences.Contexts;
using ARQUICAPAS.Infrastructure.Persistences.Interfaces;

namespace ARQUICAPAS.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRUDContext _context;
        public IEncargadoRepository Encargado { get; private set; }

        public IUserRepository User { get; private set; }

        public UnitOfWork(CRUDContext context)
        {
            _context = context;
            Encargado = new EncargadoRepository(_context);
            User= new UserRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
