using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.EntityConfigurations
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