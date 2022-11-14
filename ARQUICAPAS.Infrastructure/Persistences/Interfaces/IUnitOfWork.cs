namespace ARQUICAPAS.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaracion o matricula de nuestras interfaces a nivel de repositorio
        IEncargadoRepository Encargado { get; }

        IUserRepository User { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
