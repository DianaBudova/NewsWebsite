using System.Collections.Generic;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Dtos
{
    public class LanguageListDto : DtoGetBase
    {
        public IList<Language> Languages { get; set; }
    }
}
