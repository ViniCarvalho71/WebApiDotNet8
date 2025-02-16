using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApi.Data;
using WebApi.Dto.Artist;
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
                response.Message = $"Success {(ClaimsPrincipal user) => user.Identity!.Name}";

                return response;


            } catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<ArtistModel>> SearchArtistByTattooId(int idTattoo)
        {
            ResponseModel<ArtistModel> response = new ResponseModel<ArtistModel>();
            try
            {

                var Tattoo = await _context.Tattoo.Include(a => a.Artist).FirstOrDefaultAsync(x => x.Id
                == idTattoo);

                if(Tattoo == null)
                {
                    response.Message = "Any record found";
                    return response;
                } else
                {
                    response.Data = Tattoo.Artist;
                    response.Message = "Success";
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
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

        public async Task<ResponseModel<List<ArtistModel>>> CreateArtist(ArtistCreationDto artistCriationDto)
        {
            ResponseModel<List<ArtistModel>> response = new ResponseModel<List<ArtistModel>>();

            try
            {
                var artist = new ArtistModel()
                {
                    Name = artistCriationDto.Name    
                };

                _context.Add(artist);
                await _context.SaveChangesAsync();

                response.Data = await _context.Artist.ToListAsync();
                response.Message = $"Success";
                return response;
            } catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<ArtistModel>>> EditArtist(ArtistEditionDto artistEditionDto)
        {
            ResponseModel<List<ArtistModel>> response = new ResponseModel<List<ArtistModel>>();

            try
            {
                var artist = await _context.Artist.FirstOrDefaultAsync(x => x.Id == artistEditionDto.Id);

                if (artist == null)
                {
                    response.Message = "Any artist found";
                    return response;
                }

                artist.Name = artistEditionDto.Name;

                _context.Update(artist);
                await _context.SaveChangesAsync();

                response.Data = await _context.Artist.ToListAsync();
                response.Message = "Success";
                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }
    

        public async Task<ResponseModel<List<ArtistModel>>> DeleteArtist(int idArtist)
        {
            ResponseModel<List<ArtistModel>> response = new ResponseModel<List<ArtistModel>>();

            try
            {
                var artist = await _context.Artist.FirstOrDefaultAsync(x => x.Id == idArtist);

                if(artist == null)
                {
                    response.Message = "Any artist found";
                    return response;
                }

                _context.Remove(artist);
                await _context.SaveChangesAsync();

                response.Data = await _context.Artist.ToListAsync();
                response.Message = "Success";
                return response;
            } catch(Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }
    }
}
