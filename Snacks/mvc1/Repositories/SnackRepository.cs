

using Microsoft.EntityFrameworkCore;
using mvc1.Context;
using mvc1.Models;
using mvc1.Repositories.interfaces;

namespace mvc1.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _context;
        public SnackRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Snack> Snacks => _context.Snacks.Include(c => c.Category);
        public IEnumerable<Snack> FavoriteSnack => _context.Snacks
        .Where(l => l.FavoriteSnack)
        .Include(c => c.Category);
        public Snack GetSnackById(int SnackId)
        {
            return _context.Snacks.FirstOrDefault(l => l.SnackId == SnackId);
        }
    }
}