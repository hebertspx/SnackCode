using mvc1.Context;
using Microsoft.EntityFrameworkCore;
using mvc1.Models;

namespace LanchesMac.Models
{
    public class Cart
    {
        private readonly AppDbContext _context;

        public Cart(AppDbContext context)
        {
            _context = context;
        }

        public string CartId { get; set; }
        public List<CartItens> CartItens { get; set; }
        public static Cart GetCart(IServiceProvider services)
        {
            //define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto 
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string CartId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", CartId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new Cart(context)
            {
                CartId = CartId
            };
        }

        public void AddToCart(Snack snack)
        {
            var CartItens = _context.CartItens.SingleOrDefault(
                     s => s.Snack.SnackId == snack.SnackId &&
                     s.BuyerCart == CartId);

            if (CartItens == null)
            {
                CartItens = new CartItens
                {
                    BuyerCart = CartId,
                    Snack = snack,
                    Qtd = 1
                };
                _context.CartItens.Add(CartItens);
            }
            else
            {
                CartItens.Qtd++;
            }
            _context.SaveChanges();
        }

        public int RemoveToCart(Snack snack)
        {
            var CartItens = _context.CartItens.SingleOrDefault(s => s.Snack.SnackId == snack.SnackId && s.BuyerCart == CartId);

            var QtdLocal = 0;

            if (CartItens != null)
            {
                if (CartItens.Qtd > 1)
                {
                    CartItens.Qtd--;
                    QtdLocal = CartItens.Qtd;
                }
                else
                {
                    _context.CartItens.Remove(CartItens);
                }
            }
            _context.SaveChanges();
            return QtdLocal;
        }

        public List<CartItens> GetCartItens()
        {
            return CartItens ??
                   (CartItens =
                       _context.CartItens.Where(c => c.BuyerCart == CartId)
                           .Include(s => s.Snack)
                           .ToList());
        }

        public void CleanCart()
        {
            var CartItens = _context.CartItens
                                 .Where(carrinho => carrinho.BuyerCart == CartId);

            _context.CartItens.RemoveRange(CartItens);
            _context.SaveChanges();
        }

        public decimal CartTotal()
        {
            var total = _context.CartItens.Where(c => c.BuyerCart == CartId)
                .Select(c => c.Snack.Price * c.Qtd).Sum();
            return total;
        }
    }
}

