using Order.Domain.Core;

namespace Order.Domain.Aggregates.OrderAggregate
{
    public class Order : Entity
    {
        public string? Email { get; set; }
        private readonly List<Product> _products = new();

        public Order()
        {

        }

        public Order(string? email, List<Product> products, decimal total)
        {
            Email = email;
            _products = products;
            Total = total;
            CreatedDate = DateTime.Now;
        }

        public IReadOnlyCollection<Product> Products => _products;
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
