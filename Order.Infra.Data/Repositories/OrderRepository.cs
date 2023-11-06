using Order.Domain.Aggregates.OrderAggregate.Interface;
using Order.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Domain.Aggregates.OrderAggregate.Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }
    }
}
