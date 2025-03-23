using DubaiEstate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DubaiEstate.DAL.Configurations;

public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.HasKey(e => e.AreaId).HasName("PK_Area1");

        builder.ToTable("Area");

        builder.Property(e => e.AreaId)
            .ValueGeneratedNever()
            .HasColumnName("area_id");

        builder.Property(e => e.AreaNameEn)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("area_name_en");
    }
}
