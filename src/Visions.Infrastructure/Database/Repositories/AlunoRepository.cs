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
    }
}
