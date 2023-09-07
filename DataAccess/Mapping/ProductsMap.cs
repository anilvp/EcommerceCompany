using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping;

public class ProductsMap : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder, string schema)
    {
        builder.HasKey(e => e.ProductId);

        builder.ToTable("Products");

        builder.Property(e => e.ProductId).HasColumnName("ProductID");
        builder.Property(e => e.Name)
            .HasMaxLength(20)
            .IsFixedLength();
        builder.Property(e => e.Price).HasColumnType("decimal(10, 2)");
    }
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        Configure(builder, "dbo");
    }
}