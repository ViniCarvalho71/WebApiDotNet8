using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Artist;
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
            var artists = await _artistInterface.SearchArtistById(idArtist);

            return Ok(artists);
        }

        [HttpGet("GetArtistiByTattooId/{idTattoo}")]

        public async Task<ActionResult<ResponseModel<ArtistModel>>> GetArtistByTattooId(int idTattoo)
        {
            var artists = await _artistInterface.SearchArtistByTattooId(idTattoo);

            return Ok(artists);
        }
        [HttpPost("CreateArtist")]
        public async Task<ActionResult<ResponseModel<List<ArtistModel>>>> CreateArtist(ArtistCreationDto artistCreationDto)
        {
            var artists = await _artistInterface.CreateArtist(artistCreationDto);
            return Ok(artists);
        }

        [HttpPut("EditArtist")]
        public async Task<ActionResult<ResponseModel<List<ArtistModel>>>> EdtiArtist(ArtistEditionDto artistEditionDto)
        {
            var artists = await _artistInterface.EditArtist(artistEditionDto);
            return Ok(artists);
        }

        [HttpDelete("DeleteArtist/{idArtist}")]
        public async Task<ActionResult<ResponseModel<List<ArtistModel>>>> DeleteArtist(int idArtist)
        {
            var artists = await _artistInterface.DeleteArtist(idArtist);
            return Ok(artists);
        }
    }
}
