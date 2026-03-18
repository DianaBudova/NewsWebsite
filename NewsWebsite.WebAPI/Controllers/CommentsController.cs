using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Services.Abstract;

namespace NewsWebsite.WebAPI.Controllers
{
    [ApiController] //було додано цей рядок для виправлення проблеми
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            var result = await _commentService.GetAll();
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _commentService.Get(id);
            if (result?.Data != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
