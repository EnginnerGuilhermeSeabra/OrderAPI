using Order.Application.Commands.Dtos;
using Order.Infra.Validator;

namespace Order.Application.Commands
{
    public class CreateOrderCommand : Command
    {
        public string? Email { get; set; }
        public List<ProductDto>? Products { get; set; }
    }   
}
