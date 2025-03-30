using DubaiEstate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DubaiEstate.DAL.Configurations;

public class TransactionsGroupConfiguration : IEntityTypeConfiguration<TransactionsGroup>
{
    public void Configure(EntityTypeBuilder<TransactionsGroup> builder)
    {
        builder.HasKey(e => e.TransGroupId).HasName("PK_TransactionsGroup1");

        builder.ToTable("TransactionsGroup");

        builder.Property(e => e.TransGroupId)
            .ValueGeneratedOnAdd()
            .HasColumnName("trans_group_id");
        builder.Property(e => e.TransGroupEn)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("trans_group_en");
    }
}