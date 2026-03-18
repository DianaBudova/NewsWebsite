using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Services.Abstract;

namespace NewsWebsite.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            var result = await _languageService.GetAll();
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _languageService.Get(id);
            if (result?.Data != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
