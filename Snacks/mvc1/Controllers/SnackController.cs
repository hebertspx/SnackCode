using Microsoft.AspNetCore.Mvc;
using mvc1.Repositories.interfaces;
using mvc1.ViewModels;

namespace mvc1.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }
        public IActionResult List()
        {
            // var Snacks = _snackRepository.Snacks;
            // return View(Snacks);
            var snacksListWiewModel = new SnackListViewModel();
            snacksListWiewModel.Snacks = _snackRepository.Snacks;
            snacksListWiewModel.CurrentCategory = "Categoria Atual TEMPORARIA";

            return View(snacksListWiewModel);

        }
    }
}