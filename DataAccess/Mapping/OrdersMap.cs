using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping;

public class OrdersMap : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder, string schema)
    {
        builder.HasKey(e => e.OrderId);

        builder.ToTable("Orders");

        builder.Property(e => e.OrderId).HasColumnName("OrderID");
        builder.Property(e => e.Address)
            .HasMaxLength(20)
            .IsFixedLength();
        builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
        builder.Property(e => e.Date).HasColumnType("datetime");

        builder.HasOne(d => d.Customer).WithMany(p => p.Orders)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("FK_Orders_Customers");
    }
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        Configure(builder, "dbo");
    }
}