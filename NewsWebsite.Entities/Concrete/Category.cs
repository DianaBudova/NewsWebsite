using System.Collections.Generic;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<NewsPost> NewsPosts { get; set; }
    }
}