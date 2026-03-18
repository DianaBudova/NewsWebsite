using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.Abstract;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Data.Concrete.EntityFramework;

namespace NewsWebsite.Data.Concrete.EntityFramework.Repositories
{
    public class EfCommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public EfCommentRepository(DbContext context) : base(context)
        {
        }
    }
}
