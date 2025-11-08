namespace Visions.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public Task CommitAsync();

    }
}
