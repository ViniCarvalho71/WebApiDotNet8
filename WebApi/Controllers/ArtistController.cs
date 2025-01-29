using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Artist;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistInterface _artistInterface;
        public ArtistController(IArtistInterface artistInterface) {
            _artistInterface = artistInterface;
        }

        [HttpGet("ListArtists")]
        public async Task<ActionResult<ResponseModel<List<ArtistModel>>>> ListArtists()
        {
            var artists = await _artistInterface.ListArtists();

            return Ok(artists);
        }

        [HttpGet("GetArtistById/{idArtist}")]

        public async Task<ActionResult<ResponseModel<ArtistModel>>> GetArtistById(int idArtist){
            var artist = await _artistInterface.SearchArtistById(idArtist);

            return Ok(artist);
        }
    }
}
