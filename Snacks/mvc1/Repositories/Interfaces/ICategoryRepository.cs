using mvc1.Models;

namespace mvc1.Repositories.interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}