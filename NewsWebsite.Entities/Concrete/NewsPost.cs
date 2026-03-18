using System;
using System.Collections.Generic;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Concrete
{
    public class NewsPost : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Thumbnail { get; set; }
        public int ViewsCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public int ShareCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
        public int DislikeCount { get; set; } = 0;
        public string Author { get; set; }
        public string AuthorDescription { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}