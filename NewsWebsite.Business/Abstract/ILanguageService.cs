using System.Threading.Tasks;
using NewsWebsite.Entities.Dtos;
using NewsWebsite.Shared.Utilities.Results.Abstract;

namespace NewsWebsite.Services.Abstract
{
    public interface ILanguageService
    {
        Task<IDataResult<LanguageDto>> Get(int languageId);
        Task<IDataResult<LanguageListDto>> GetAll();
    }
}
