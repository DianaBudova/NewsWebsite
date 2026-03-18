using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Entities.Concrete;

namespace NewsWebsite.Data.Concrete.EntityFramework.Mappings
{
    public class LanguageMapping : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.Property(l => l.Name).IsRequired();
            builder.Property(l => l.Name).HasMaxLength(70);
            builder.Property(u => u.CreatedByName).IsRequired();
            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired();
            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedDate).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired();

            builder.HasMany<NewsPost>(l => l.NewsPosts).WithOne(n => n.Language);
            builder.HasMany<Comment>(l => l.Comments).WithOne(c => c.Language);
            builder.ToTable("Languages");
            builder.HasData(
                new Language
                {
                    Id = 1,
                    Name = "English",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Language
                {
                    Id = 2,
                    Name = "Turkish",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                });
        }
    }
}