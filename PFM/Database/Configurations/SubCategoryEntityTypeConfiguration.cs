using Microsoft.EntityFrameworkCore;
using PFM.Database.Entities;

namespace PFM.Database.Configurations
{
    public class SubCategoryEntityTypeConfiguration : IEntityTypeConfiguration<SubCategoryEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SubCategoryEntity> builder)
        {
            builder.ToTable("SubCategories");
            builder.HasKey(x => x.code);
            builder.Property(x => x.name);
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.parentcode);
            builder.HasOne(x => x.Transaction).WithMany().HasForeignKey(x => x.TransactionId);
            
        }
    }
}