using Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderAggregate
{
    public class Product : Entity
    {
        public Product(string? name, int amount, decimal value)
        {
            Name = name;
            Amount = amount;
            Value = value;
        }

        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }
}
