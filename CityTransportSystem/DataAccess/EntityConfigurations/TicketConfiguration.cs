using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasAlternateKey(t => t.SerialNumber);
            builder.Property(t => t.SerialNumber)
                   .IsRequired();
            builder.Property(t => t.Cost)
                   .IsRequired();
            builder.ToTable("ticket");
        }
    }
}