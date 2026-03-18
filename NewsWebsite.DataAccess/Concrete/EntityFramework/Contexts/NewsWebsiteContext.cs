using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.Concrete.EntityFramework.Mappings;
using NewsWebsite.Entities.Concrete;

namespace NewsWebsite.Data.Concrete.EntityFramework.Contexts
{
    public class NewsWebsiteContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=NewsWebsite;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsPostMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new LanguageMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());

            modelBuilder.Entity<Comment>()
                .HasOne<NewsPost>(c => c.NewsPost)
                .WithMany(n => n.Comments)
                .HasForeignKey(c => c.NewsPostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}