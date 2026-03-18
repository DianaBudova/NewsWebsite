using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Dtos
{
    public class LanguageDto : DtoGetBase
    {
        public Language Language { get; set; }
    }
}
