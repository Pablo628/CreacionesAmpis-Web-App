using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateBlog.Domain.Entities.OrderDetails;

namespace PrivateBlog.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("ORDERDETAILS");
            builder.HasKey(od => od.Id);
            builder.Property(od => od.Id).HasColumnName("id_Detail");
            builder.Property(od => od.OrderId).HasColumnName("id_Order");
            builder.Property(od => od.ProductId).HasColumnName("id_Product");
            
            builder.Property(od => od.Quantity).HasColumnName("Quantity").IsRequired();
            builder.Property(od => od.UnitPrice).HasColumnName("Unit_Price").IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(od => od.Subtotal).HasColumnName("Subtotal").IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(od => od.Size).HasColumnName("Size").HasMaxLength(20);
            builder.Property(od => od.Color).HasColumnName("Color").HasMaxLength(50);
            builder.Property(od => od.PersonalizationNotes).HasColumnName("Personalization_notes").HasMaxLength(500);
        }
    }
}
