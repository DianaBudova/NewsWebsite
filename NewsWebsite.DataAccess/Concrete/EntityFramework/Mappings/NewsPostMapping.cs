using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Entities.Concrete;

namespace NewsWebsite.Data.Concrete.EntityFramework.Mappings
{
    public class NewsPostMapping : IEntityTypeConfiguration<NewsPost>
    {
        public void Configure(EntityTypeBuilder<NewsPost> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ValueGeneratedOnAdd();
            builder.Property(n => n.Title).IsRequired();
            builder.Property(n => n.Title).HasMaxLength(100);
            builder.Property(n => n.Content).IsRequired();
            builder.Property(n => n.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(n => n.Thumbnail).IsRequired();
            builder.Property(n => n.Thumbnail).HasMaxLength(300);
            builder.Property(n => n.Date).IsRequired();
            builder.Property(n => n.CreatedDate).IsRequired();
            builder.Property(n => n.ModifiedDate).IsRequired();
            builder.Property(n => n.Author).IsRequired();
            builder.Property(n => n.Author).HasMaxLength(50);
            builder.Property(n => n.AuthorDescription).IsRequired();
            builder.Property(n => n.AuthorDescription).HasMaxLength(200);
            builder.Property(n => n.CreatedByName).IsRequired();
            builder.Property(n => n.CreatedByName).HasMaxLength(50);
            builder.Property(n => n.ModifiedByName).IsRequired();
            builder.Property(n => n.ModifiedByName).HasMaxLength(50);
            builder.Property(n => n.ViewsCount).IsRequired();
            builder.Property(n => n.ShareCount).IsRequired();
            builder.Property(n => n.CommentCount).IsRequired();
            builder.Property(n => n.LikeCount).IsRequired();
            builder.Property(n => n.DislikeCount).IsRequired();
            builder.Property(n => n.IsActive).IsRequired();
            builder.Property(n => n.IsDeleted).IsRequired();

            builder.HasOne<Category>(n => n.Category)
                .WithMany(c => c.NewsPosts).HasForeignKey(n => n.CategoryId);
            builder.HasOne<Language>(n => n.Language)
                .WithMany(l => l.NewsPosts).HasForeignKey(n => n.LanguageId);
            builder.HasOne<User>(n => n.User).WithMany(u => u.NewsPosts).HasForeignKey(n => n.UserId);
            builder.ToTable("NewsPosts");
            builder.HasData(
                new NewsPost
                {
                    Id = 1,
                    CategoryId = 1,
                    UserId = 1,
                    LanguageId = 1,
                    Title = "No War in Ukraine",
                    Content =
                        "Russian tennis player Andrey Rublev has appealed for peace between Russia and Ukraine by signing a camera lens with a 'no war please' message, after getting through to the final of the Dubai Tennis Championship.",
                    Thumbnail = "Default.jpg",
                    Author = "Büşra Tuğlu",
                    AuthorDescription = "The author is interested in politics, health, and sports.",
                    Date = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ViewsCount = 3500,
                    ShareCount = 355,
                    CommentCount = 156,
                    LikeCount = 1463,
                    DislikeCount = 274,
                    IsActive = true,
                    IsDeleted = false
                },
                new NewsPost
                {
                    Id = 2,
                    CategoryId = 2,
                    UserId = 1,
                    LanguageId = 1,
                    Title = "5 Healthy and Easy Lunch Ideas for Work",
                    Content =
                        "Many of my clients who work away from home have one common obstacle: they don't plan ahead when it comes to lunch. As a result, they typically wind up eating something—like a fast-food hamburger.",
                    Thumbnail = "Default.jpg",
                    Author = "Büşra Tuğlu",
                    AuthorDescription = "The author is interested in politics, health, and sports.",
                    Date = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ViewsCount = 5000,
                    ShareCount = 795,
                    CommentCount = 302,
                    LikeCount = 2600,
                    DislikeCount = 484,
                    IsActive = true,
                    IsDeleted = false
                },
                new NewsPost
                {
                    Id = 3,
                    CategoryId = 3,
                    UserId = 1,
                    LanguageId = 2,
                    Title = "Trabzon'da Trafik Lambaları da Şampiyonluk İstiyor: 'O Sene, Bu Sene",
                    Content =
                        "Süper Lig'de lider konumda bulunan Trabzonspor'da, şehri şampiyonluk havası sardı. En yakın rakibi Konyaspor ile aradaki puan farkını yükselten Trabzon'da Faroz civarında bulunan trafik ışıklarına kupa görseli yansıtıldı.",
                    Thumbnail = "Default.jpg",
                    Author = "Büşra Tuğlu",
                    AuthorDescription = "The author is interested in politics, health, and sports.",
                    Date = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ViewsCount = 706,
                    ShareCount = 57,
                    CommentCount = 5,
                    LikeCount = 19,
                    DislikeCount = 3,
                    IsActive = true,
                    IsDeleted = false
                });
        }
    }
}