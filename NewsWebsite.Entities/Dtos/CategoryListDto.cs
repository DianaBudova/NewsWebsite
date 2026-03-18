using System.Collections.Generic;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Dtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}