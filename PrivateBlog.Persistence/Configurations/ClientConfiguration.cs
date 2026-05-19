using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateBlog.Domain.Entities.Clients;

namespace PrivateBlog.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("CLIENTS");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id_Client");
            
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(150);
            builder.Property(c => c.EmailAddress).HasColumnName("Email_Address").IsRequired().HasMaxLength(150);
            builder.Property(c => c.Tel).HasColumnName("Tel").IsRequired().HasMaxLength(20);
            builder.Property(c => c.AcceptPromotions).HasColumnName("Acept_promotions").IsRequired();
            builder.Property(c => c.PreferredChannel).HasColumnName("Preferred_Channel").IsRequired().HasMaxLength(50);

            builder.HasMany(c => c.Addresses)
                   .WithOne(a => a.Client)
                   .HasForeignKey(a => a.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Client)
                   .HasForeignKey(o => o.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
