using WebApi.Dto.Artist;
using WebApi.Models;

namespace WebApi.Services.Artist
{
    public interface IArtistInterface
    {
        Task<ResponseModel<List<ArtistModel>>> ListArtists();
        Task<ResponseModel<ArtistModel>> SearchArtistById(int idArtist);
        Task<ResponseModel<ArtistModel>> SearchArtistByTattooId(int idBook);
        Task<ResponseModel<List<ArtistModel>>> CreateArtist(ArtistCreationDto artistCriationDto);
        Task<ResponseModel<List<ArtistModel>>> EditArtist(ArtistEditionDto artistEditionDto);
        Task<ResponseModel<List<ArtistModel>>> DeleteArtist(int idArtist);
    }
}
