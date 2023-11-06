using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infra.Data.EntityConfiguration.OrderAggregate
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.Aggregates.OrderAggregate.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.OrderAggregate.Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(x => x.Products)
              .WithOne()
              .HasForeignKey("OrderId")
              .IsRequired(true)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
