using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateBlog.Domain.Entities.Shipments;

namespace PrivateBlog.Persistence.Configurations
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("SHIPMENTS");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("id_Shipment");
            builder.Property(s => s.OrderId).HasColumnName("id_Order");
            
            builder.Property(s => s.DeliveryMethod).HasColumnName("Delivery_method").IsRequired().HasMaxLength(100);
            builder.Property(s => s.ShippingCost).HasColumnName("Shipping_cost").IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.ShippingState).HasColumnName("Shipping_state").IsRequired().HasMaxLength(50);
            builder.Property(s => s.DeliveryDate).HasColumnName("Delivery_date").HasColumnType("date").IsRequired();
        }
    }
}
