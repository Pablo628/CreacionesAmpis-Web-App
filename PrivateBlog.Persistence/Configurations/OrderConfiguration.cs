using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateBlog.Domain.Entities.Orders;

namespace PrivateBlog.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDERS");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("Id_Order");
            builder.Property(o => o.ClientId).HasColumnName("id_client");
            builder.Property(o => o.AddressId).HasColumnName("id_Address");
            
            builder.Property(o => o.Date).HasColumnName("Date").HasColumnType("date").IsRequired();
            builder.Property(o => o.State).HasColumnName("State").IsRequired().HasMaxLength(50);
            builder.Property(o => o.Total).HasColumnName("Total").IsRequired().HasColumnType("decimal(18,2)");

            builder.HasMany(o => o.OrderDetails)
                   .WithOne(od => od.Order)
                   .HasForeignKey(od => od.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Payments)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Shipments)
                   .WithOne(s => s.Order)
                   .HasForeignKey(s => s.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
