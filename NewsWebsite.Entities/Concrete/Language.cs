using System.Collections.Generic;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Concrete
{
    public class Language : EntityBase, IEntity
    {
        public string Name { get; set; }
        public ICollection<NewsPost> NewsPosts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}