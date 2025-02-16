
using WebApi.Dto.Tattoo;
using WebApi.Models;

namespace WebApi.Services.Tattoo
{
    public interface ITattooInterface
    {
        Task<ResponseModel<List<TattooModel>>> ListTattoos();
        Task<ResponseModel<TattooModel>> SearchTattooById(int idTattoo);
        Task<ResponseModel<List<TattooModel>>> SearchTattooByArtistId(int idTattoo);
        Task<ResponseModel<List<TattooModel>>> CreateTattoo(TattooCreationDto tattooCriationDto);
        Task<ResponseModel<List<TattooModel>>> EditTattoo(TattooEditionDto tattooEditionDto);
        Task<ResponseModel<List<TattooModel>>> DeleteTattoo(int idTattoo);
    }
}
