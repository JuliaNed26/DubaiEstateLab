using DubaiEstate.DAL.Configurations;
using DubaiEstate.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DubaiEstate.DAL;

public partial class DubaiEstateLabContext : DbContext
{
    public DubaiEstateLabContext()
    {
    }

    public DubaiEstateLabContext(DbContextOptions<DubaiEstateLabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<Procedure> Procedures { get; set; }

    public virtual DbSet<PropertySubType> PropertySubTypes { get; set; }

    public virtual DbSet<PropertyType> PropertyTypes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionsGroup> TransactionsGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");
        
        new AreaConfiguration().Configure(modelBuilder.Entity<Area>());
        new DateConfiguration().Configure(modelBuilder.Entity<Date>());
        new ProcedureConfiguration().Configure(modelBuilder.Entity<Procedure>());
        new PropertySubTypeConfiguration().Configure(modelBuilder.Entity<PropertySubType>());
        new PropertyTypeConfiguration().Configure(modelBuilder.Entity<PropertyType>());
        new TransactionConfiguration().Configure(modelBuilder.Entity<Transaction>());
        new TransactionsGroupConfiguration().Configure(modelBuilder.Entity<TransactionsGroup>());
    }
}
