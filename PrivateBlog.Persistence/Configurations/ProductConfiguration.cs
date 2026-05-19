using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateBlog.Domain.Entities.Products;

namespace PrivateBlog.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id_Product");
            builder.Property(p => p.CategoryId).HasColumnName("id_Category");
            
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(150);
            builder.Property(p => p.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(p => p.Price).HasColumnName("Price").IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Stock).HasColumnName("Stock").IsRequired();
            builder.Property(p => p.IsPersonality).HasColumnName("is_personality").IsRequired();

            builder.HasMany(p => p.OrderDetails)
                   .WithOne(od => od.Product)
                   .HasForeignKey(od => od.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
