namespace ForumSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ForumSystem.Common;
    using Models;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category
                .Property(c => c.Name)
                .HasMaxLength(GlobalConstants.CategoryNameMaxLength)
                .IsRequired();

            category
                .HasIndex(c => c.IsDeleted);
        }
    }
}