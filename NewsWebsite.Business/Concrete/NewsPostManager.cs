using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NewsWebsite.Data.Abstract;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Entities.Dtos;
using NewsWebsite.Services.Abstract;
using NewsWebsite.Shared.Utilities.Results.Abstract;
using NewsWebsite.Shared.Utilities.Results.ComplexTypes;
using NewsWebsite.Shared.Utilities.Results.Concrete;

namespace NewsWebsite.Services.Concrete
{
    public class NewsPostManager : INewsPostService
    {
        private const string NewsPostNotFoundMessage = "No such news post was found.";
        private const string NewsPostsNotFoundMessage = "News posts are not found.";
        private const string CategoryNotFoundMessage = "No such category was found.";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsPostManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<NewsPostDto>> Get(int newsPostId)
        {
            var newsPost = await _unitOfWork.NewsPosts.GetAsync(
                n => n.Id == newsPostId,
                n => n.User,
                n => n.Category);

            return CreateNewsPostResult(newsPost);
        }

        public async Task<IDataResult<NewsPostListDto>> GetAll()
        {
            var newsPosts = await _unitOfWork.NewsPosts.GetAllAsync(null, n => n.User, n => n.Category);
            return CreateNewsPostListResult(newsPosts);
        }

        public async Task<IDataResult<NewsPostListDto>> GetAllByNonDeleted()
        {
            var newsPosts = await _unitOfWork.NewsPosts.GetAllAsync(n => !n.IsDeleted, n => n.User, n => n.Category);
            return CreateNewsPostListResult(newsPosts);
        }

        public async Task<IDataResult<NewsPostListDto>> GetAllByCategory(int categoryId)
        {
            if (!await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId))
                return CategoryNotFoundListResult();

            var newsPosts = await _unitOfWork.NewsPosts.GetAllAsync(
                n => n.CategoryId == categoryId,
                n => !n.IsDeleted && n.IsActive,
                n => n.User,
                n => n.Category);

            return CreateNewsPostListResult(newsPosts);
        }

        public async Task<IDataResult<NewsPostListDto>> GetAllByNonDeletedAndActive()
        {
            var newsPosts = await _unitOfWork.NewsPosts.GetAllAsync(
                n => !n.IsDeleted && n.IsActive,
                n => n.User,
                n => n.Category);

            return CreateNewsPostListResult(newsPosts);
        }

        public async Task<IResult> Add(NewsPostAddDto newsPostAddDto, string createdByName)
        {
            var newsPost = _mapper.Map<NewsPost>(newsPostAddDto);
            newsPost.CreatedByName = createdByName;
            newsPost.ModifiedByName = createdByName;
            newsPost.UserId = 1;

            await _unitOfWork.NewsPosts.AddAsync(newsPost);
            await SaveAsync();

            return SuccessResult($"The news post titled {newsPostAddDto.Title} has been successfully added.");
        }

        public async Task<IResult> Update(NewsPostUpdateDto newsPostUpdateDto, string modifiedByName)
        {
            var newsPost = _mapper.Map<NewsPost>(newsPostUpdateDto);
            newsPost.ModifiedByName = modifiedByName;

            await _unitOfWork.NewsPosts.UpdateAsync(newsPost);
            await SaveAsync();

            return SuccessResult($"The news post titled {newsPostUpdateDto.Title} has been successfully updated.");
        }

        public async Task<IResult> Delete(int newsPostId, string modifiedByName)
        {
            var newsPost = await GetExistingNewsPost(newsPostId);
            if (newsPost == null)
                return NewsPostNotFoundResult();

            newsPost.IsDeleted = true;
            newsPost.ModifiedByName = modifiedByName;
            newsPost.ModifiedDate = DateTime.Now;

            await _unitOfWork.NewsPosts.UpdateAsync(newsPost);
            await SaveAsync();

            return SuccessResult($"The news post titled {newsPost.Title} has been successfully deleted.");
        }

        public async Task<IResult> HardDelete(int newsPostId)
        {
            var newsPost = await GetExistingNewsPost(newsPostId);
            if (newsPost == null)
                return NewsPostNotFoundResult();

            await _unitOfWork.NewsPosts.DeleteAsync(newsPost); // fixed (was UpdateAsync)
            await SaveAsync();

            return SuccessResult(
                $"The news post titled {newsPost.Title} has been successfully deleted from the database.");
        }

        // ---------- Helpers ----------

        private async Task<NewsPost> GetExistingNewsPost(int newsPostId)
        {
            if (!await _unitOfWork.NewsPosts.AnyAsync(n => n.Id == newsPostId))
                return null;

            return await _unitOfWork.NewsPosts.GetAsync(n => n.Id == newsPostId);
        }

        private async Task SaveAsync()
        {
            await _unitOfWork.SaveAsync();
        }

        private static IResult SuccessResult(string message)
        {
            return new Result(ResultStatus.Success, message);
        }

        private static IResult NewsPostNotFoundResult()
        {
            return new Result(ResultStatus.Error, NewsPostNotFoundMessage);
        }

        private static IDataResult<NewsPostListDto> CategoryNotFoundListResult()
        {
            return new DataResult<NewsPostListDto>(ResultStatus.Error, CategoryNotFoundMessage, data: null);
        }

        private static IDataResult<NewsPostDto> CreateNewsPostResult(NewsPost newsPost)
        {
            if (newsPost == null)
                return new DataResult<NewsPostDto>(ResultStatus.Error, NewsPostNotFoundMessage, data: null);

            return new DataResult<NewsPostDto>(ResultStatus.Success, new NewsPostDto
            {
                NewsPost = newsPost,
                ResultStatus = ResultStatus.Success
            });
        }

        private static IDataResult<NewsPostListDto> CreateNewsPostListResult(IList<NewsPost> newsPosts)
        {
            // Залишено вашу логіку (Count > -1), хоча фактично це завжди true для не-null колекції.
            if (newsPosts != null && newsPosts.Count > -1)
            {
                return new DataResult<NewsPostListDto>(ResultStatus.Success, new NewsPostListDto
                {
                    NewsPosts = newsPosts,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<NewsPostListDto>(ResultStatus.Error, NewsPostsNotFoundMessage, data: null);
        }
    }
}