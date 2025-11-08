using Visions.Domain.Models;

namespace Visions.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        public Task AddAsync(Emprestimo emprestimo);
        public Task AddReturnAsync(long id);
        public Task GetAllAssetsByAlunoId(long alunoId);

    }
}
