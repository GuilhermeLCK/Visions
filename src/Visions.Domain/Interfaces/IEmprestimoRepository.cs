using NPOI.SS.Formula.Functions;
using Visions.Domain.Models;

namespace Visions.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        public Task AddAsync(Emprestimo emprestimo);
        public Task AddUpdateAsync(Emprestimo emprestimo);
        public Task<Emprestimo> GetByIdAsync(long emprestimoId);
        public Task<List<Emprestimo>> GetAssetsByAlunoIdAsync(long  alunoId);
        Task<List<T>> GetTopAsync<T>();
        Task<List<T>> GetDelayedLoansAsync<T>(long? alunoId = null);
        Task<List<T>> GetHistoryByPeriodAsync<T>(DateTime? inicio, DateTime? fim);
    }
}
