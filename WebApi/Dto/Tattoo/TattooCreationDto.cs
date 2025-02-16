using WebApi.Dto.Tattoo.Link;
using WebApi.Models;

namespace WebApi.Dto.Tattoo
{
    public class TattooCreationDto
    {
        public string Style { get; set; }

        public decimal Width { get; set; }

        public decimal Price { get; set; }

        public ArtistLinkDto Artist { get; set; }
    }
}
