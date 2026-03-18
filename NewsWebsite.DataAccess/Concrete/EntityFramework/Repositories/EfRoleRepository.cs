using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.Abstract;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Data.Concrete.EntityFramework;

namespace NewsWebsite.Data.Concrete.EntityFramework.Repositories
{
    public class EfRoleRepository : EfEntityRepositoryBase<Role>, IRoleRepository
    {
        public EfRoleRepository(DbContext context) : base(context)
        {
        }
    }
}
