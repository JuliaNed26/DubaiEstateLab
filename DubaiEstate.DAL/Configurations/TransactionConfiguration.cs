using DubaiEstate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DubaiEstate.DAL.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasNoKey();

        builder.Property(e => e.ActualWorth).HasColumnName("actual_worth");
        builder.Property(e => e.AreaId).HasColumnName("area_id");
        builder.Property(e => e.InstanceDate).HasColumnName("instance_date");
        builder.Property(e => e.ProcedureArea).HasColumnName("procedure_area");
        builder.Property(e => e.ProcedureId).HasColumnName("procedure_id");
        builder.Property(e => e.PropertySubTypeId).HasColumnName("property_sub_type_id");
        builder.Property(e => e.RentValue).HasColumnName("rent_value");

        builder.HasOne(d => d.InstanceDateNavigation).WithMany()
            .HasForeignKey(d => d.InstanceDate)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Transactions_Date");
    }
}