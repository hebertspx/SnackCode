using mvc1.Context;
using mvc1.Models;
using mvc1.Repositories.interfaces;

namespace mvc1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Category;
    }
}