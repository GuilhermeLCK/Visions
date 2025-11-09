using Visions.Domain.Models;

namespace Visions.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        public Task AddAsync(Emprestimo emprestimo);
        public Task AddUpdateAsync(Emprestimo emprestimo);
        public Task<List<Emprestimo>> GetAllAssetsByAlunoId(long  alunoId);
        public Task<Emprestimo> GetById(long emprestimoId);

    }
}
