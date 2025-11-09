using Microsoft.EntityFrameworkCore;
using Visions.Domain.Interfaces;
using Visions.Domain.Models;

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
        public async Task UpdateAsync(Livro livro)
        {
            _context.Livros.Update(livro);
        }
        public async Task<List<Livro>> GetByFiltersAsync(string? titulo, string? autor, string? isbn)
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
        public Task<List<Livro>> GetavailablesAsync()
        {
            return _context.Livros.Where(w => w.QuantidadeDisponivel != 0).ToListAsync();
        }
        public async Task<Livro> GetById(long livroId)
        {
            return await _context.Livros.FirstOrDefaultAsync(f => f.Id == livroId && f.QuantidadeDisponivel > 0);
        }    

    }


}
