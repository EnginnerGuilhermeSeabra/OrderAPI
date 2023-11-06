using Order.Application.Commands;
using Order.Application.ViewModels;

namespace Order.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<CommandResponse> Add(CreateOrderCommand command);

        Task<IEnumerable<OrderViewModel>> GetAll();
    }
}
