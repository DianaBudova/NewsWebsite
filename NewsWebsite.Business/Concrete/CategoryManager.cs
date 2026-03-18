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
    public class CategoryManager : ICategoryService
    {
        private readonly CategoryQueryPart _queryPart;
        private readonly CategoryCommandPart _commandPart;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _queryPart = new CategoryQueryPart(unitOfWork);
            _commandPart = new CategoryCommandPart(unitOfWork, mapper);
        }

        public Task<IDataResult<CategoryDto>> Get(int categoryId)
            => _queryPart.Get(categoryId);

        public Task<IDataResult<CategoryListDto>> GetAll()
            => _queryPart.GetAll();

        public Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
            => _queryPart.GetAllByNonDeleted();

        public Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
            => _queryPart.GetAllByNonDeletedAndActive();

        public Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
            => _commandPart.Add(categoryAddDto, createdByName);

        public Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
            => _commandPart.Update(categoryUpdateDto, modifiedByName);

        public Task<IResult> Delete(int categoryId, string modifiedByName)
            => _commandPart.Delete(categoryId, modifiedByName);

        public Task<IResult> HardDelete(int categoryId)
            => _commandPart.HardDelete(categoryId);

        // -------------------------
        // Query part (Read methods)
        // -------------------------
        private sealed class CategoryQueryPart
        {
            private readonly IUnitOfWork _unitOfWork;

            public CategoryQueryPart(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<CategoryDto>> Get(int categoryId)
            {
                var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
                return CreateCategoryResult(category);
            }

            public async Task<IDataResult<CategoryListDto>> GetAll()
            {
                var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.NewsPosts);
                return CreateCategoryListResult(categories);
            }

            public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
            {
                var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.NewsPosts);
                return CreateCategoryListResult(categories);
            }

            public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
            {
                var categories = await _unitOfWork.Categories.GetAllAsync(
                    c => !c.IsDeleted && c.IsActive,
                    c => c.NewsPosts);

                return CreateCategoryListResult(categories);
            }

            private static IDataResult<CategoryDto> CreateCategoryResult(Category category)
            {
                if (category == null)
                {
                    return new DataResult<CategoryDto>(
                        ResultStatus.Error,
                        message: "No such category was found.",
                        data: null);
                }

                return new DataResult<CategoryDto>(
                    ResultStatus.Success,
                    new CategoryDto
                    {
                        Category = category,
                        ResultStatus = ResultStatus.Success
                    });
            }

            private static IDataResult<CategoryListDto> CreateCategoryListResult(IList<Category> categories)
            {
                if (categories == null)
                {
                    return new DataResult<CategoryListDto>(
                        ResultStatus.Error,
                        message: "No such category was found.",
                        data: null);
                }

                return new DataResult<CategoryListDto>(
                    ResultStatus.Success,
                    new CategoryListDto
                    {
                        Categories = categories,
                        ResultStatus = ResultStatus.Success
                    });
            }
        }

        // ---------------------------
        // Command part (Write methods)
        // ---------------------------
        private sealed class CategoryCommandPart
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CategoryCommandPart(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
            {
                var category = _mapper.Map<Category>(categoryAddDto);
                category.CreatedByName = createdByName;
                category.ModifiedByName = createdByName;

                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result(
                    ResultStatus.Success,
                    $"The category named {categoryAddDto.Name} has been successfully added.");
            }

            public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
            {
                var category = _mapper.Map<Category>(categoryUpdateDto);
                category.ModifiedByName = modifiedByName;

                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result(
                    ResultStatus.Success,
                    $"The category named {categoryUpdateDto.Name} has been successfully updated.");
            }

            public Task<IResult> Delete(int categoryId, string modifiedByName)
            {
                return ExecuteForExistingCategory(categoryId, async category =>
                {
                    category.IsDeleted = true;
                    category.ModifiedByName = modifiedByName;
                    category.ModifiedDate = DateTime.Now;

                    await _unitOfWork.Categories.UpdateAsync(category);
                    await _unitOfWork.SaveAsync();

                    return new Result(
                        ResultStatus.Success,
                        $"The category named {category.Name} has been successfully deleted.");
                });
            }

            public Task<IResult> HardDelete(int categoryId)
            {
                return ExecuteForExistingCategory(categoryId, async category =>
                {
                    await _unitOfWork.Categories.DeleteAsync(category);
                    await _unitOfWork.SaveAsync();

                    return new Result(
                        ResultStatus.Success,
                        $"The category named {category.Name} has been successfully deleted from the database.");
                });
            }

            private async Task<IResult> ExecuteForExistingCategory(
                int categoryId,
                Func<Category, Task<IResult>> operation)
            {
                var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
                if (category == null)
                {
                    return new Result(ResultStatus.Error, message: "No such category was found.");
                }

                return await operation(category);
            }
        }
    }
}