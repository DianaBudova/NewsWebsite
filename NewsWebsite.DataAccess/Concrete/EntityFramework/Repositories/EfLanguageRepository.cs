using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.Abstract;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Data.Concrete.EntityFramework;

namespace NewsWebsite.Data.Concrete.EntityFramework.Repositories
{
    public class EfLanguageRepository : EfEntityRepositoryBase<Language>, ILanguageRepository
    {
        public EfLanguageRepository(DbContext context) : base(context)
        {
        }
    }
}
