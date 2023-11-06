using Order.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderAggregate.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
