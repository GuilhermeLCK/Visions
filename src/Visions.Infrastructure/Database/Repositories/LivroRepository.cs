using Microsoft.EntityFrameworkCore;
using Visions.Domain.Interfaces;
using Visions.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Visions.Infrastructure.Database.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly VisionsDbContext _context;

        public LivroRepository(VisionsDbContext context) => _context = context;

        public async Task AddAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
        }

        public async Task<Livro> GetExistByIsbnAsync(string isbn)
        {
            return await _context.Livros.FirstOrDefaultAsync(f => f.ISBN == isbn);     
        }

        public async Task<List<Livro>> GetByFilterAsync(string? titulo, string? autor, string? isbn)
        {
            var query = _context.Livros.AsQueryable();

            if (!string.IsNullOrEmpty(titulo))
                query = query.Where(w => w.Titulo.Contains(titulo));

            if (!string.IsNullOrEmpty(autor))
                query = query.Where(w => w.Autor.Contains(autor));

            if (!string.IsNullOrEmpty(isbn))
                query = query.Where(w => w.ISBN.Contains(isbn));

            return await query.ToListAsync();
        }
        public Task<List<Livro>> GetAvailablesAsync()
        {
            return _context.Livros.Where(w => w.QuantidadeDisponivel != 0).ToListAsync();
        }
    }


}
