using Microsoft.AspNetCore.Mvc;
using MusicSite.Services;

namespace MusicSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly SongService _songService;

        public SongsController(SongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var songs = await _songService.GetSongsAsync();
            return Ok(songs);
        }
    }
}
