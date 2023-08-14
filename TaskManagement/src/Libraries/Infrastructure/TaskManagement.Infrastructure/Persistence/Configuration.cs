using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TaskManagement.Model;
using TaskManagement.Shared.Enum;

namespace TaskManagement.Infrastructure.Persistence;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.HasData(new
        {
            Id = 1,
            ProdcutName = "Walton",
            ProductPrice = 1200.0,
            ProductModel="walto primo ",
            Created = DateTimeOffset.Now,
            CreatedBy = "1",
            Status = EntityStatus.created
        });
    }
}
