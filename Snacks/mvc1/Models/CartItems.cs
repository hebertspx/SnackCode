using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc1.Models
{
    [Table("CartItens")]
    public class CartItens
    {
        public int CartItensId { get; set; }
        public Snack Snack { get; set; }
        public int Qtd { get; set; }
        [StringLength(200)]
        public string BuyerCart { get; set; }
    }
}