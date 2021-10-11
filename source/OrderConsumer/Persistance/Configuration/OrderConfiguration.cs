using System;
using System.Collections.Generic;
using System.Text;
using Domain.AggregateModels.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CustomerLastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CustomerFullName).IsRequired().HasMaxLength(200);
            builder.Property(e => e.CustomerEmail).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ShippingAddress).IsRequired().HasMaxLength(200);
            builder.Property(e => e.BillingAddress).IsRequired().HasMaxLength(200);
            builder.Property(e => e.CreatedBy).IsRequired().HasMaxLength(100);
            builder.Property(e => e.UpdatedBy).IsRequired().HasMaxLength(100);
            builder.Property(e => e.UpdatedDate).IsRequired();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.HasIndex(e => e.CustomerId);
        }
    }
}
