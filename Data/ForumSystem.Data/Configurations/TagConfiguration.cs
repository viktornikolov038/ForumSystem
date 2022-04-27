namespace ForumSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ForumSystem.Common;
    using Models;

    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> tag)
        {
            tag
                .Property(t => t.Name)
                .HasMaxLength(GlobalConstants.TagNameMaxLength)
                .IsRequired();

            tag
                .HasIndex(t => t.IsDeleted);
        }
    }
}
