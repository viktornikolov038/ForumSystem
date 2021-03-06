namespace ForumSystem.Data.Configurations
{
    using ForumSystem.Common;
    using ForumSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostReportConfiguration : IEntityTypeConfiguration<PostReport>
    {
        public void Configure(EntityTypeBuilder<PostReport> postReport)
        {
            postReport
                .Property(r => r.Description)
                .HasMaxLength(GlobalConstants.PostReportDescriptionMaxLength)
                .IsRequired();

            postReport
                .HasOne(pr => pr.Author)
                .WithMany(a => a.PostReports)
                .HasForeignKey(pr => pr.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            postReport
                .HasOne(pr => pr.Post)
                .WithMany(p => p.Reports)
                .HasForeignKey(pr => pr.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            postReport
                 .HasIndex(pr => pr.IsDeleted);
        }
    }
}
