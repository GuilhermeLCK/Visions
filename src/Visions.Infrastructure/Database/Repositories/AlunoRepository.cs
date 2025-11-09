using Microsoft.EntityFrameworkCore;
using Visions.Domain.Interfaces;
using Visions.Domain.Models;

namespace Visions.Infrastructure.Database.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly VisionsDbContext _context;
        public AlunoRepository(VisionsDbContext context) => _context = context;
        public async Task AddAsync(Aluno aluno)
        {
             await _context.Alunos.AddAsync(aluno); 
        }
        public async Task<Aluno> GetById(long alunoId)
        {
            return await _context.Alunos.FirstOrDefaultAsync(f => f.Id == alunoId);        
        }
    }
}
