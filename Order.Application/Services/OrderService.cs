using Flunt.Notifications;
using Order.Application.Commands;
using Order.Application.Commands.Dtos;
using Order.Application.Services.Interfaces;
using Order.Application.Validators;
using Order.Application.ViewModels;
using Order.Domain.Aggregates.OrderAggregate;
using Order.Domain.Aggregates.OrderAggregate.Interface;

namespace Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICreateOrderCommandValidator _commandValidator;
        private readonly IOrderRepository _orderRepository;
        public OrderService(ICreateOrderCommandValidator commandValidator,
                            IOrderRepository orderRepository)
        {
            _commandValidator = commandValidator;
            _orderRepository = orderRepository;
        }

        public async Task<CommandResponse> Add(CreateOrderCommand command)
        {
            var validator = _commandValidator.Validate(command);

            if (!validator.IsValid)
                return GenerateErrorValidatior(validator);


            var totalProducts = CalculateOrder(command.Products);
            var order = await AddOrderRepository(command, totalProducts);

            await _orderRepository.SaveChanges();
            return new CommandResponse(order.Notifications);
        }

        private async Task<Domain.Aggregates.OrderAggregate.Order> AddOrderRepository(CreateOrderCommand command, decimal totalProducts)
        {
            var products = new List<Product>();
            foreach (var product in command.Products)
            {
                products.Add(new Product(product.Name, product.Amount, product.Value));
            }
            var order = new Domain.Aggregates.OrderAggregate.Order(command.Email, products, totalProducts);

            await _orderRepository.AddAsync(order);
            return order;
        }

        private static decimal CalculateOrder(List<ProductDto> products)
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += CalculateTotalProducts(product);
            }

            return total;
        }

        private static decimal CalculateTotalProducts(ProductDto product)
        {
            return product.Amount * product.Value;
        }

        private static CommandResponse GenerateErrorValidatior(FluentValidation.Results.ValidationResult validator)
        {
            return new CommandResponse(validator.Errors.Select(x => new Notification(nameof(CreateOrderCommand), x.ErrorMessage)).ToList());
        }

        public Task<IEnumerable<OrderViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
