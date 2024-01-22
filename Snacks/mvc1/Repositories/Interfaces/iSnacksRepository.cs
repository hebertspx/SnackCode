using mvc1.Models;

namespace mvc1.Repositories.interfaces
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }
        IEnumerable<Snack> FavoriteSnack { get; }
        Snack GetSnackById(int SnackId);
    }
}