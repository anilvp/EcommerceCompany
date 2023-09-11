using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mapping;

public class CustomersMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder, string schema)
    {
        builder.HasKey(e => e.CustomerId);

        builder.ToTable("Customers");

        builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
        builder.Property(e => e.Name)
            .HasMaxLength(10)
            .IsFixedLength();
    }
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        Configure(builder, "dbo");
    }
}