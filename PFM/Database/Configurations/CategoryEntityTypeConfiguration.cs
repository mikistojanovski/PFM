using Microsoft.EntityFrameworkCore;
using PFM.Database.Entities;

namespace PFM.Database.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.code);
            builder.Property(x => x.name).IsRequired();
            builder.Property(x => x.parentcode);
            
        } 
    }
}