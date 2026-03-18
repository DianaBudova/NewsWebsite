using System.Threading.Tasks;
using NewsWebsite.Entities.Dtos;
using NewsWebsite.Shared.Utilities.Results.Abstract;

namespace NewsWebsite.Services.Abstract
{
    public interface INewsPostService
    {
        Task<IDataResult<NewsPostDto>> Get(int newsPostId);
        Task<IDataResult<NewsPostListDto>> GetAll();
        Task<IDataResult<NewsPostListDto>> GetAllByNonDeleted();
        Task<IDataResult<NewsPostListDto>> GetAllByCategory(int categoryId);
        Task<IDataResult<NewsPostListDto>> GetAllByNonDeletedAndActive();
        Task<IResult> Add(NewsPostAddDto newsPostAddDto, string createdByName);
        Task<IResult> Update(NewsPostUpdateDto newsPostUpdateDto, string modifiedByName);
        Task<IResult> Delete(int newsPostId, string modifiedByName);
        Task<IResult> HardDelete(int newsPostId);
    }
}