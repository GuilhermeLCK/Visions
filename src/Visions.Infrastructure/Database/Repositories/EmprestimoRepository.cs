using Microsoft.EntityFrameworkCore;
using Visions.Domain.Enum;
using Visions.Domain.Interfaces;
using Visions.Domain.Models;

namespace Visions.Infrastructure.Database.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly VisionsDbContext _context;

        public EmprestimoRepository(VisionsDbContext context) => _context = context;

        public async Task AddAsync(Emprestimo emprestimo)
        {
            await _context.Emprestimos.AddAsync(emprestimo);
        }

        public async Task AddUpdateAsync(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);

        }

        public async Task<List<Emprestimo>> GetAssetsByAlunoIdAsync(long alunoId)
        { 
            return await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Aluno)
                .Where(e => e.AlunoID == alunoId && e.Status == (byte)EmprestimoStatus.RETIRADO)
                .ToListAsync();     
        }

        public async Task<Emprestimo> GetByIdAsync(long emprestimoId)
        {
           return await _context.Emprestimos.FirstOrDefaultAsync(e => e.Id == emprestimoId);      
        }

        public async Task<List<object>> GetDelayedLoansAsync(long? id = null)
        {
            DateTime hoje = DateTime.Now;

            var query = _context.Emprestimos
                .Include(e => e.Aluno)
                .Include(e => e.Livro)
                .Where(e => e.DataPrevistaDevolucao < hoje && e.DataDevolucaoReal == null);

            if (id.HasValue)
                query = query.Where(e => e.AlunoID == id.Value);

            return await query
                .Select(e => new
                {
                    Aluno = e.Aluno.Nome,
                    Livro = e.Livro.Titulo,
                    DataEmprestimo = e.DataEmprestimo,
                    DataPrevistaDevolucao = e.DataPrevistaDevolucao,
                    DiasAtraso = EF.Functions.DateDiffDay(e.DataPrevistaDevolucao, hoje)
                })
                .OrderByDescending(e => e.DiasAtraso)
                .ToListAsync<object>();
        }


        public async Task<List<object>> GetHistoryByPeriodAsync(DateTime? inicio, DateTime? fim)
        {
            var query = _context.Emprestimos
                .Include(e => e.Aluno)
                .Include(e => e.Livro)
                .AsQueryable();

            query = query.Where(e =>
               (!inicio.HasValue || e.DataEmprestimo.Date >= inicio.Value.Date) &&
               (!fim.HasValue || e.DataEmprestimo.Date <= fim.Value.Date)
            );

            return await query
                .Select(e => new
                {
                    Aluno = e.Aluno.Nome,
                    Livro = e.Livro.Titulo,
                    DataEmprestimo = e.DataEmprestimo,
                    DataDevolucao = e.DataDevolucaoReal,
                    Status = e.Status
                })
                .OrderBy(e => e.DataEmprestimo)
                .ToListAsync<object>();
        }


        public async Task<List<object>> GetTopAsync()
        {
            return await _context.Emprestimos
                 .Include(e => e.Livro)
                 .Include(e => e.Aluno)
                 .GroupBy(e => new { e.LivroID, e.Livro.Titulo })
                 .Select(g => new
                 {
                     Livro = g.Key.Titulo,
                     TotalEmprestimos = g.Count(),
                     PrimeiroAluno = g.OrderBy(e => e.DataEmprestimo)
                                      .Select(e => e.Aluno.Nome)
                                      .FirstOrDefault(),
                     UltimoAluno = g.OrderByDescending(e => e.DataEmprestimo)
                                    .Select(e => e.Aluno.Nome)
                                    .FirstOrDefault(),
                     AlunoMaisFrequente = g.GroupBy(e => e.Aluno.Nome)
                                           .OrderByDescending(a => a.Count())
                                           .Select(a => a.Key)
                                           .FirstOrDefault()
                 })
                 .OrderByDescending(r => r.TotalEmprestimos)
                 .Take(10)
                 .ToListAsync<object>();
        }
    }
}
