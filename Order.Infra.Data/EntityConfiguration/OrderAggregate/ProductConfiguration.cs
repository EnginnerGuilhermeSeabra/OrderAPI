using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Infra.Data.EntityConfiguration.OrderAggregate
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Aggregates.OrderAggregate.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.OrderAggregate.Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Value).IsRequired();
        }
    }
}
