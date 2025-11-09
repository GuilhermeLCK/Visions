using Visions.Domain.Models;

namespace Visions.Domain.Interfaces
{
    public interface ILivroRepository
     {
        public Task AddAsync(Livro livro);
        public Task UpdateAsync(Livro livro);
        public Task<List<Livro>> GetByFiltersAsync(string? titulo, string? autor, string? isbn);
        public Task<List<Livro>> GetavailablesAsync();
        public Task<Livro> GetById(long livroId);
    }
}
