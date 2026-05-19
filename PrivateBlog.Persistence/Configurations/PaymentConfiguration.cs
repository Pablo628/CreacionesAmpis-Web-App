using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateBlog.Domain.Entities.Payments;

namespace PrivateBlog.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("PAYMENTS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id_payment");
            builder.Property(p => p.OrderId).HasColumnName("id_Order");
            
            builder.Property(p => p.PaymentMethod).HasColumnName("Payment_method").IsRequired().HasMaxLength(50);
            builder.Property(p => p.PaymentType).HasColumnName("Payment_type").IsRequired().HasMaxLength(50);
            builder.Property(p => p.Date).HasColumnName("Date").HasColumnType("date").IsRequired();
        }
    }
}
