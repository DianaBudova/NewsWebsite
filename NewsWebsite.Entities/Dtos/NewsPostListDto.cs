using System.Collections.Generic;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Dtos
{
    public class NewsPostListDto:DtoGetBase
    {
        public IList<NewsPost> NewsPosts { get; set; }
        
    }
}