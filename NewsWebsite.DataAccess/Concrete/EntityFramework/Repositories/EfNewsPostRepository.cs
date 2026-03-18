using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.Abstract;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Data.Concrete.EntityFramework;

namespace NewsWebsite.Data.Concrete.EntityFramework.Repositories
{
    public class EfNewsPostRepository : EfEntityRepositoryBase<NewsPost>, INewsPostRepository
    {
        public EfNewsPostRepository(DbContext context) : base(context)
        {
        }
    }
}
