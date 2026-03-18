using System.Threading.Tasks;
using NewsWebsite.Entities.Dtos;
using NewsWebsite.Shared.Utilities.Results.Abstract;

namespace NewsWebsite.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<CommentDto>> Get(int commentId);
        Task<IDataResult<CommentListDto>> GetAll();
    }
}
