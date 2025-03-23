using DubaiEstate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DubaiEstate.DAL.Configurations;

public class DateConfiguration : IEntityTypeConfiguration<Date>
{
    public void Configure(EntityTypeBuilder<Date> builder)
    {
        builder.HasKey(e => e.FullDate).HasName("PK_Date12");

        builder.ToTable("Date");

        builder.Property(e => e.FullDate).HasColumnName("date");
        builder.Property(e => e.Day).HasColumnName("day");
        builder.Property(e => e.Month).HasColumnName("month");
        builder.Property(e => e.MonthYear)
            .HasMaxLength(10)
            .IsUnicode(false)
            .HasColumnName("month_year");
        builder.Property(e => e.Year).HasColumnName("year");
    }
}