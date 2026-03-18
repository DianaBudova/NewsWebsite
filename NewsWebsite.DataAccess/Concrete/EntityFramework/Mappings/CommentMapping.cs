using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Entities.Concrete;

namespace NewsWebsite.Data.Concrete.EntityFramework.Mappings
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(750);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();

            builder.HasOne<NewsPost>(c => c.NewsPost)
                .WithMany(n => n.Comments).HasForeignKey(c => c.NewsPostId);
            builder.HasOne<Language>(c => c.Language)
                .WithMany(l => l.Comments).HasForeignKey(c => c.LanguageId);
            builder.ToTable("Comments");
            builder.HasData(
                new Comment
                {
                    Id = 1,
                    NewsPostId = 1,
                    LanguageId = 1,
                    Text = "No war, stop war!",
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                },
                new Comment
                {
                    Id = 2,
                    NewsPostId = 2,
                    LanguageId = 1,
                    Text = "These are good advice, I hope I can apply them.",
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                },
                new Comment
                {
                    Id = 3,
                    NewsPostId = 3,
                    LanguageId = 2,
                    Text = "Bu sene o sene mi, göreceğiz.",
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                });
        }
    }
}