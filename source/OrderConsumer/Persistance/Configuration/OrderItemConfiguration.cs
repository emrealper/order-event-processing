using System;
using System.Collections.Generic;
using System.Text;
using Domain.AggregateModels.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(e => e.ItemCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Brand).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Type).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Size).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Colour).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LongDescription).IsRequired().HasMaxLength(200);
            builder.Property(e => e.CreatedBy).IsRequired().HasMaxLength(100);
            builder.Property(e => e.UpdatedBy).IsRequired().HasMaxLength(100);
            builder.Property(e => e.UpdatedDate).IsRequired();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.HasIndex(e => e.ItemCode);
        }
    }
}
