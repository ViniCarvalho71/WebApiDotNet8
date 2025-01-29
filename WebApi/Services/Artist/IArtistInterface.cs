using WebApi.Models;

namespace WebApi.Services.Artist
{
    public interface IArtistInterface
    {
        Task<ResponseModel<List<ArtistModel>>> ListArtists();
        Task<ResponseModel<ArtistModel>> SearchArtistById(int idArtist);
        Task<ResponseModel<ArtistModel>> SearchArtistByBookId(int idBook);
    }
}
