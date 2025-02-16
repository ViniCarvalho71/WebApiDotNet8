using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Artist;
using WebApi.Dto.Tattoo;
using WebApi.Models;
using WebApi.Services.Artist;
using WebApi.Services.Tattoo;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TattooController : ControllerBase
    {
        private readonly ITattooInterface _tattooInterface;
        public TattooController(ITattooInterface tattooInterface)
        {
            _tattooInterface = tattooInterface;
        }

        [HttpGet("ListTattoos")]
        public async Task<ActionResult<ResponseModel<List<TattooModel>>>> ListTattoos()
        {
            var tattoos = await _tattooInterface.ListTattoos();

            return Ok(tattoos);
        }

        [HttpGet("GetTattooById/{idTattoo}")]

        public async Task<ActionResult<ResponseModel<TattooModel>>> SearchTattooById(int idTattoo)
        {
            var tattoo = await _tattooInterface.SearchTattooById(idTattoo);

            return Ok(tattoo);
        }

        [HttpPost("CreateTattoo")]
        public async Task<ActionResult<ResponseModel<List<ArtistModel>>>> CreateTattoo(TattooCreationDto tattooCreationDto)
        {
            var tattoos = await _tattooInterface.CreateTattoo(tattooCreationDto);
            return Ok(tattoos);
        }

        [HttpPut("EditTattoo")]
        public async Task<ActionResult<ResponseModel<List<TattooModel>>>> EditTattoo(TattooEditionDto tattooEditionDto)
        {
            var tattoos = await _tattooInterface.EditTattoo(tattooEditionDto);
            return Ok(tattoos);
        }

        [HttpDelete("DeleteTattoo/{idTattoo}")]
        public async Task<ActionResult<ResponseModel<List<TattooModel>>>> DeleteTattoo(int idTattoo)
        {
            var tattoos = await _tattooInterface.DeleteTattoo(idTattoo);
            return Ok(tattoos);
        }

        [HttpGet("GetTattooByArtistId/{idArtist}")]

        public async Task<ActionResult<ResponseModel<ArtistModel>>> GetTattooByArtistId(int idArtist)
        {
            var tattoos = await _tattooInterface.SearchTattooByArtistId(idArtist);

            return Ok(tattoos);
        }
    }
}
