using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping;

public class DeliveriesMap : IEntityTypeConfiguration<Deliveries>
{
    public void Configure(EntityTypeBuilder<Deliveries> builder, string schema)
    {
        builder.HasKey(e => e.DeliveryId);

        builder.ToTable("Deliveries");

        builder.Property(e => e.DeliveryId).HasColumnName("DeliveryID");
        builder.Property(e => e.Date).HasColumnType("datetime");
        builder.Property(e => e.OrderId).HasColumnName("OrderID");

        builder.HasOne(d => d.Order).WithMany(p => p.Deliveries)
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("FK_Deliveries_Orders");
    }
    public void Configure(EntityTypeBuilder<Deliveries> builder)
    {
        Configure(builder, "dbo");
    }
}