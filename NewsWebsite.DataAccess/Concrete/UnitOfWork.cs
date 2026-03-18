using System.Threading.Tasks;
using NewsWebsite.Data.Abstract;
using NewsWebsite.Data.Concrete.EntityFramework.Contexts;
using NewsWebsite.Data.Concrete.EntityFramework.Repositories;

namespace NewsWebsite.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsWebsiteContext _context;
        private EfNewsPostRepository _newsPostRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfLanguageRepository _languageRepository;
        private EfRoleRepository _roleRepository;
        private EfUserRepository _userRepository;

        public UnitOfWork(NewsWebsiteContext context)
        {
            _context = context;
        }

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);
        public ILanguageRepository Languages => _languageRepository ?? new EfLanguageRepository(_context);
        public INewsPostRepository NewsPosts => _newsPostRepository ?? new EfNewsPostRepository(_context);
        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);
        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}