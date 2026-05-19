using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateBlog.Domain.Entities.Addresses;

namespace PrivateBlog.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("ADDRESSES");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("id_Address");
            builder.Property(a => a.ClientId).HasColumnName("id_client");
            
            builder.Property(a => a.AddressLine).HasColumnName("Address").IsRequired().HasMaxLength(250);
            builder.Property(a => a.City).HasColumnName("City").IsRequired().HasMaxLength(100);
            builder.Property(a => a.Reference).HasColumnName("Reference").HasMaxLength(250);

            builder.HasMany(a => a.Orders)
                   .WithOne(o => o.Address)
                   .HasForeignKey(o => o.AddressId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
