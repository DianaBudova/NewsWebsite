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
    public class LanguageManager : ILanguageService
    {
        private const string LanguageNotFoundMessage = "No such language was found.";
        private const string LanguagesNotFoundMessage = "Languages are not found.";

        private readonly IUnitOfWork _unitOfWork;

        public LanguageManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<LanguageDto>> Get(int languageId)
        {
            var language = await _unitOfWork.Languages.GetAsync(
                l => l.Id == languageId,
                l => l.NewsPosts,
                l => l.Comments);

            if (language == null)
            {
                return new DataResult<LanguageDto>(ResultStatus.Error, LanguageNotFoundMessage, data: null);
            }

            return new DataResult<LanguageDto>(ResultStatus.Success, new LanguageDto
            {
                Language = language,
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IDataResult<LanguageListDto>> GetAll()
        {
            var languages = await _unitOfWork.Languages.GetAllAsync(null, l => l.NewsPosts, l => l.Comments);
            return CreateLanguageListResult(languages);
        }

        private static IDataResult<LanguageListDto> CreateLanguageListResult(IList<Language> languages)
        {
            if (languages == null)
            {
                return new DataResult<LanguageListDto>(ResultStatus.Error, LanguagesNotFoundMessage, data: null);
            }

            return new DataResult<LanguageListDto>(ResultStatus.Success, new LanguageListDto
            {
                Languages = languages,
                ResultStatus = ResultStatus.Success
            });
        }
    }
}
