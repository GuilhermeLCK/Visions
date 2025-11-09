using Visions.Domain.Models;

namespace Visions.Domain.Interfaces
{
    public interface IAlunoRepository  
    {
        public Task AddAsync(Aluno aluno);
        public Task<Aluno> GetById(long alunoId);

    }
}
