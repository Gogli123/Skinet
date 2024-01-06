using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired(); // Id is required
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100); // Name is required and has a max length of 100
            builder.Property(p => p.Description).IsRequired().HasMaxLength(280); // Description is required and has a max length of 180
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)"); // Price is a decimal with 18 digits and 2 decimal places
            builder.Property(p => p.PictureUrl).IsRequired(); // PictureUrl is required
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId); // ProductBrand is a foreign key
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId); // ProductType is a foreign key
        }
    }
}