using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Dtos
{
    public class NewsPostDto : DtoGetBase
    {
        public NewsPost NewsPost { get; set; }
        
    }
}