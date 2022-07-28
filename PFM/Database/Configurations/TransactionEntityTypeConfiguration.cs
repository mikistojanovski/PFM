using Microsoft.EntityFrameworkCore;
using PFM.Database.Entities;

namespace PFM.Database.Configurations
{
   public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<TransactionEntity>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TransactionEntity> builder)
    {

      builder.ToTable("Transactions");
      builder.HasKey(x => x.id);
      builder.Property(x => x.beneficiaryname);
      builder.Property(x => x.date);
      builder.Property(x => x.direction);
      builder.Property(x => x.amount);
      builder.Property(x => x.currency);
      builder.Property(x => x.mcc);
      builder.Property(x => x.kind);
    }
  }
}