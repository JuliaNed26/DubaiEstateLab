using DubaiEstate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DubaiEstate.DAL.Configurations;

public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
{
    public void Configure(EntityTypeBuilder<PropertyType> builder)
    {
        builder.HasKey(e => e.PropertyTypeId).HasName("PK_PropertyType1");

        builder.ToTable("PropertyType");

        builder.Property(e => e.PropertyTypeId)
            .ValueGeneratedOnAdd()
            .HasColumnName("property_type_id");
        builder.Property(e => e.PropertyTypeEn)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("property_type_en");
    }
}