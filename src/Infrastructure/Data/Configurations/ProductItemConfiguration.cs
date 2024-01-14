using Kore.Domain.Entities;
using Kore.Infrastructure.Data.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kore.Infrastructure.Data.Configurations;

public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
{
    public void Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasIndex(t => t.Code)
            .IsUnique();
           //.HasValueGenerator<CodeGenerator>();

        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(400);

        builder.HasOne(t => t.Category)
            .WithMany(c => c.ProductItems)
            .HasForeignKey(t => t.CategoryCode)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
