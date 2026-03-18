using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Data.Abstract;

namespace NewsWebsite.Data.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}