using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Dtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
        
    }
}