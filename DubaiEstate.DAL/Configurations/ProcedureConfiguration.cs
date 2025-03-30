using DubaiEstate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DubaiEstate.DAL.Configurations;

public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
{
    public void Configure(EntityTypeBuilder<Procedure> builder)
    {
        builder.HasKey(e => e.ProcedureId).HasName("PK_Procedure1");

        builder.ToTable("Procedure");

        builder.Property(e => e.ProcedureId)
            .ValueGeneratedOnAdd()
            .HasColumnName("procedure_id");
        builder.Property(e => e.ProcedureNameEn)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("procedure_name_en");
        builder.Property(e => e.TransGroupId).HasColumnName("trans_group_id");

        builder.HasOne(d => d.TransGroup).WithMany(p => p.Procedures)
            .HasForeignKey(d => d.TransGroupId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Procedure1_TransactionsGroup1");
    }
}