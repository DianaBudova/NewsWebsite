using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Entities.Dtos;
using NewsWebsite.Services.Abstract;

namespace NewsWebsite.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsPostsController : ControllerBase
    {
        private readonly INewsPostService _newsPostService;

        public NewsPostsController(INewsPostService newsPostService)
        {
            _newsPostService = newsPostService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            var newsPosts = await _newsPostService.GetAll();
            return Ok(newsPosts);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var newsPost = await _newsPostService.Get(id);
            if (newsPost != null)
            {
                return Ok(newsPost); //200 + data
            }

            return NotFound(); //404
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByNonDeleted()
        {
            var newsPost = await _newsPostService.GetAllByNonDeleted();
            return Ok(newsPost);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllByCategory(int id)
        {
            var newsPost = await _newsPostService.GetAllByCategory(id);
            return Ok(newsPost);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByNonDeletedAndActive()
        {
            var result = await _newsPostService.GetAllByNonDeletedAndActive();
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(NewsPostAddDto newsPostAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _newsPostService.Add(newsPostAddDto, "Büşra Tuğlu");
                return Ok(result); //200 + data
            }

            return BadRequest(); //400
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(NewsPostUpdateDto newsPostUpdateDto)
        {
            var result = await _newsPostService.Get(newsPostUpdateDto.Id);
            if (result != null)
            {
                var updateResult =
                    await _newsPostService.Update(newsPostUpdateDto, modifiedByName: "Büşra Tuğlu"); //200 + data
                return Ok(updateResult);
            }

            return NotFound(); //404
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _newsPostService.Get(id);
            if (result != null)
            {
                var deleteResult = await _newsPostService.Delete(id, modifiedByName: "Büşra Tuğlu");
                return Ok(deleteResult); //200 
            }

            return NotFound(); //404
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> HardDelete(int id)
        {
            var result = await _newsPostService.Get(id);
            if (result != null)
            {
                var deleteResult = await _newsPostService.HardDelete(id);
                return Ok(deleteResult); //200 
            }

            return NotFound(); //404
        }
    }
}