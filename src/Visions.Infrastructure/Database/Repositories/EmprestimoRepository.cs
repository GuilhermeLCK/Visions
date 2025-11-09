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

        public async Task<List<Emprestimo>> GetAllAssetsByAlunoId(long alunoId)
        {
            return await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Aluno)
                .Where(e => e.AlunoID == alunoId && e.Status == (byte)EmprestimoStatus.RETIRADO)
                .ToListAsync();
        }

        public async Task<Emprestimo> GetById(long emprestimoId)
        {
           return await _context.Emprestimos.FirstOrDefaultAsync(e => e.Id == emprestimoId);      

        }
    }
}
