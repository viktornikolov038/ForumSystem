namespace ForumSystem.Data.Configurations
{
    using ForumSystem.Common;
    using ForumSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReplyReportConfiguration : IEntityTypeConfiguration<ReplyReport>
    {
        public void Configure(EntityTypeBuilder<ReplyReport> replyReport)
        {
            replyReport
                .Property(rr => rr.Description)
                .HasMaxLength(GlobalConstants.ReplyReportDescriptionMaxLength)
                .IsRequired();

            replyReport
                .HasOne(rr => rr.Author)
                .WithMany(a => a.ReplyReports)
                .HasForeignKey(rr => rr.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            replyReport
                .HasOne(rr => rr.Reply)
                .WithMany(r => r.Reports)
                .HasForeignKey(rr => rr.ReplyId)
                .OnDelete(DeleteBehavior.Restrict);

            replyReport
                .HasIndex(rr => rr.IsDeleted);
        }
    }
}
