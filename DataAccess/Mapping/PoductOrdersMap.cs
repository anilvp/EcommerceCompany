using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping;

public class ProductOrdersMap : IEntityTypeConfiguration<ProductOrder>
{
    public void Configure(EntityTypeBuilder<ProductOrder> builder, string schema)
    {
        builder.HasKey(e => new { e.OrderId, e.ProductId });

        builder.ToTable("ProductOrders");

        builder.Property(e => e.OrderId).HasColumnName("OrderID");
        builder.Property(e => e.ProductId).HasColumnName("ProductID");
        builder.Property(e => e.Price).HasColumnType("decimal(10, 2)");

        builder.HasOne(d => d.Order).WithMany(p => p.ProductOrders)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product Orders_Orders");

        builder.HasOne(d => d.Product).WithMany(p => p.ProductOrders)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product Orders_Products");
    }
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
        Configure(builder, "dbo");
    }
}