using System;
using System.Threading.Tasks;

namespace NewsWebsite.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        ILanguageRepository Languages { get; }
        INewsPostRepository NewsPosts { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}