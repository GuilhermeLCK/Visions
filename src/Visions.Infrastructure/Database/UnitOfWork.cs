using Microsoft.EntityFrameworkCore;
using Visions.Domain.Interfaces;

namespace Visions.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly VisionsDbContext _context;
        public UnitOfWork(VisionsDbContext context)
        {
            _context = context;
        }
        public async Task CommitAsync() => await _context.SaveChangesAsync();

    }
}
