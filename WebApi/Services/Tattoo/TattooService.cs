using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Data;
using WebApi.Dto.Artist;
using WebApi.Dto.Tattoo;
using WebApi.Models;

namespace WebApi.Services.Tattoo
{
    public class TattooService : ITattooInterface
    {
        private readonly AppDbContext _context;

        public TattooService(AppDbContext context ) {
            this._context = context;
        }
        public async Task<ResponseModel<List<TattooModel>>> CreateTattoo(TattooCreationDto tattooCriationDto)
        {
            ResponseModel<List<TattooModel>> response = new ResponseModel<List<TattooModel>>();
            try
            {

                var artist = await _context.Artist.FirstOrDefaultAsync(artistDb => artistDb.Id == tattooCriationDto.Artist.Id);

                if(artist == null)
                {
                    response.Message = "Artist doesn't exist";
                    return response;
                }

                var tattoo = new TattooModel()
                {
                    Style = tattooCriationDto.Style,
                    Width = tattooCriationDto.Width,
                    Price = tattooCriationDto.Price,
                    Artist = artist
                };

                _context.Add(tattoo);
                await _context.SaveChangesAsync();

                response.Data = await _context.Tattoo.Include(a => a.Artist).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<TattooModel>>> DeleteTattoo(int idTattoo)
        {
            ResponseModel<List<TattooModel>> response = new ResponseModel<List<TattooModel>>();

            try
            {
                var tattoo = await _context.Tattoo.FirstOrDefaultAsync(x => x.Id == idTattoo);

                if (tattoo == null)
                {
                    response.Message = "Any tattoo found";
                    return response;
                }

                _context.Remove(tattoo);
                await _context.SaveChangesAsync();

                response.Data = await _context.Tattoo.Include(a => a.Artist).ToListAsync();
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

        public async Task<ResponseModel<List<TattooModel>>> EditTattoo(TattooEditionDto tattooEditionDto)
        {
            ResponseModel<List<TattooModel>> response = new ResponseModel<List<TattooModel>>();

            try
            {
                var tattoo = await _context.Tattoo.Include(a => a.Artist).FirstOrDefaultAsync(tattooDb => tattooDb.Id == tattooEditionDto.Id);

                var artist = await _context.Artist.FirstOrDefaultAsync(artistDb => artistDb.Id == tattooEditionDto.Artist.Id);


                if (artist == null)
                {
                    response.Message = "Artist doesn't exist";
                    return response;
                }


                if (tattoo == null)
                {
                    response.Message = "Tattoo doesn't exist";
                    return response;
                }

                tattoo.Style = tattooEditionDto.Style;
                tattoo.Width = tattooEditionDto.Width;
                tattoo.Price = tattooEditionDto.Price;
                tattoo.Artist = artist;

                _context.Update(tattoo);
                await _context.SaveChangesAsync();

                response.Data = await _context.Tattoo.Include(a => a.Artist).ToListAsync();

                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }

        public async Task<ResponseModel<List<TattooModel>>> ListTattoos()
        {
            ResponseModel<List<TattooModel>> response = new ResponseModel<List<TattooModel>>();

            try
            {
                var tattoos = await _context.Tattoo.Include(a => a.Artist).ToListAsync();
                response.Data = tattoos;
                return response;
            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TattooModel>> SearchTattooById(int idTattoo)
        {
            ResponseModel<TattooModel> response = new ResponseModel<TattooModel>();

            try
            {
                var tattoo = await _context.Tattoo.Include(a => a.Artist).FirstOrDefaultAsync(x => x.Id == idTattoo);

                if (tattoo == null)
                {
                    response.Message = "Any Tattoo located";
                    return response;
                }

                response.Data = tattoo;
                response.Message = "Success";



                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<TattooModel>>> SearchTattooByArtistId(int idTattoo)
        {
            ResponseModel<List<TattooModel>> response = new ResponseModel<List<TattooModel>>();
            try
            {

                var tattoo = await _context.Tattoo.Include(a => a.Artist).Where(tattooDb => tattooDb.Artist.Id == idTattoo).ToListAsync();

                if (tattoo.IsNullOrEmpty())
                {
                    response.Message = "Any record found";
                    return response;
                }
                
                
                    response.Data = tattoo;
                    response.Message = "Success";
                    return response;
                

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }
    }
}
