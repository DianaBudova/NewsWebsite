using System.Collections.Generic;
using System.Threading.Tasks;
using NewsWebsite.Data.Abstract;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Entities.Dtos;
using NewsWebsite.Services.Abstract;
using NewsWebsite.Shared.Utilities.Results.Abstract;
using NewsWebsite.Shared.Utilities.Results.ComplexTypes;
using NewsWebsite.Shared.Utilities.Results.Concrete;

namespace NewsWebsite.Services.Concrete
{
    public class CommentManager : ICommentService
    {
        private const string CommentNotFoundMessage = "No such comment was found.";
        private const string CommentsNotFoundMessage = "Comments are not found.";

        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<CommentDto>> Get(int commentId)
        {
            var comment = await _unitOfWork.Comments.GetAsync(
                c => c.Id == commentId,
                c => c.NewsPost,
                c => c.Language);

            if (comment == null)
            {
                return new DataResult<CommentDto>(ResultStatus.Error, CommentNotFoundMessage, data: null);
            }

            return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
            {
                Comment = comment,
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAll()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(null, c => c.NewsPost, c => c.Language);
            return CreateCommentListResult(comments);
        }

        private static IDataResult<CommentListDto> CreateCommentListResult(IList<Comment> comments)
        {
            if (comments == null)
            {
                return new DataResult<CommentListDto>(ResultStatus.Error, CommentsNotFoundMessage, data: null);
            }

            return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
            {
                Comments = comments,
                ResultStatus = ResultStatus.Success
            });
        }
    }
}
