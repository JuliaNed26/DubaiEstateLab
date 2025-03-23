using DubaiEstate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DubaiEstate.DAL.Configurations;

public class PropertySubTypeConfiguration : IEntityTypeConfiguration<PropertySubType>
{
    public void Configure(EntityTypeBuilder<PropertySubType> builder)
    {
        builder.HasKey(e => e.PropertySubTypeId).HasName("PK_PropertySubType1");

        builder.ToTable("PropertySubType");

        builder.Property(e => e.PropertySubTypeId)
            .ValueGeneratedNever()
            .HasColumnName("property_sub_type_id");
        builder.Property(e => e.PropertySubTypeEn)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("property_sub_type_en");
        builder.Property(e => e.PropertyTypeId).HasColumnName("property_type_id");

        builder.HasOne(d => d.PropertyType).WithMany(p => p.PropertySubTypes)
            .HasForeignKey(d => d.PropertyTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PropertySubType1_PropertyType1");
    }
}