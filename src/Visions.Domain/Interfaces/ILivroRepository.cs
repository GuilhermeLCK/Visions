using Visions.Domain.Models;

namespace Visions.Domain.Interfaces
{
    public interface ILivroRepository
     {
        public Task AddAsync(Livro livro);
        public Task<List<Livro>> GetByFilterAsync(string? titulo , string? autor , string? isbn);
        public Task<Livro> GetExistByIsbnAsync(string isbn);
        public Task<List<Livro>> GetAvailablesAsync();

    }
}
