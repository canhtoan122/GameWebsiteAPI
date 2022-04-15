using GameWebsiteAPI.Data;
using GameWebsiteAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStatisticController : ControllerBase
    {
        private readonly DataContext _context;

        public GameStatisticController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<GameList>>> Get()
        {
            var sum = _context.GameList.Count<GameList>();
            return Ok(sum);
        }
    }
}
