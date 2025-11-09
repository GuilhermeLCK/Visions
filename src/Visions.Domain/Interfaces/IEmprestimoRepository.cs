using Visions.Domain.Models;

namespace Visions.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        public Task AddAsync(Emprestimo emprestimo);
        public Task AddUpdateAsync(Emprestimo emprestimo);
        public Task<Emprestimo> GetByIdAsync(long emprestimoId);
        public Task<List<Emprestimo>> GetAssetsByAlunoIdAsync(long  alunoId);
        Task<List<object>> GetTopAsync();
        Task<List<object>> GetDelayedLoansAsync(long? id = null);
        Task<List<object>> GetHistoryByPeriodAsync(DateTime? inicio, DateTime? fim);
    }
}
