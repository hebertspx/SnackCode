using mvc1.Models;

namespace mvc1.ViewModels
{
    public class SnackListViewModel
    {
        public IEnumerable<Snack> Snacks { get; set; }
        public string CurrentCategory { get; set; }
    }
}