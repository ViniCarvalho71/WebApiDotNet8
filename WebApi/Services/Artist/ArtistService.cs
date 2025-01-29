using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services.Artist
{
    public class ArtistService : IArtistInterface
    {
        private readonly AppDbContext _context;
        public ArtistService(AppDbContext context) {
            _context = context;
        }
        public async Task<ResponseModel<List<ArtistModel>>> ListArtists()
        {   
            ResponseModel<List<ArtistModel>> response = new ResponseModel<List<ArtistModel>>();
            try
            {
                
                var artists = await _context.Artist.ToListAsync();
                response.Data = artists;
                response.Message = "Success";

                return response;


            } catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public Task<ResponseModel<ArtistModel>> SearchArtistByBookId(int idBook)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<ArtistModel>> SearchArtistById(int idArtist)
        {
            ResponseModel<ArtistModel> response = new ResponseModel<ArtistModel>();

            try
            {
                var artist = await _context.Artist.FirstOrDefaultAsync(x => x.Id == idArtist);

                if(artist == null)
                {
                    response.Message = "Any artist located";
                    return response;
                }
                
                response.Data = artist;
                response.Message = "Success";
                
                

                return response;
            } catch(Exception ex)
            {
                response.Message=ex.Message;
                response.Status = false;

                return response;
            }
        }
    }
}
