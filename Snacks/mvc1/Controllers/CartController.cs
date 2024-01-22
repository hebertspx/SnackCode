using LanchesMac.Models;
using Microsoft.AspNetCore.Mvc;
using mvc1.Repositories.interfaces;
using mvc1.ViewModels;

namespace mvc1.Controllers
{
    public class CartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly Cart _cart;

        public CartController(ISnackRepository snackRepository, Cart cart)
        {
            _snackRepository = snackRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var itens = _cart.GetCartItens();
            _cart.CartItens = itens;

            var CartVM = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.CartTotal()
            };

            return View(CartVM);
        }

        public IActionResult AddItemToCart(int SnackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(p => p.SnackId == SnackId);
            if (selectedSnack != null)
            {
                _cart.AddToCart(selectedSnack);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemToCart(int SnackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(p => p.SnackId == SnackId);
            if (selectedSnack != null)
            {
                _cart.RemoveToCart(selectedSnack);
            }

            return RedirectToAction("Index");
        }

    }
}