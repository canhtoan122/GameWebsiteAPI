using GameWebsiteAPI.Data;
using GameWebsiteAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> Get()
        {
            return Ok(await _context.Comment.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Comment>>> Add(Comment comment)
        {
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(await _context.Comment.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Comment>>> Update(Comment request)
        {
            var result = await _context.Comment.FindAsync(request.Comment_ID);
            if (result == null)
                return BadRequest("Comment not found.");

            result.CommentContent = request.CommentContent;

            await _context.SaveChangesAsync();

            return Ok(await _context.Comment.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Comment>>> Delete(int id)
        {
            var result = await _context.Comment.FindAsync(id);
            if (result == null)
                return BadRequest("Comment not found.");

            _context.Comment.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Comment.ToListAsync());
        }
    }
}
