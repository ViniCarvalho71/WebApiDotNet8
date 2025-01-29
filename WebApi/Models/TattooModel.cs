namespace WebApi.Models
{
    public class TattooModel
    {
        public int Id { get; set; }

        public string Style { get; set; }

        public decimal Width { get; set; }

        public decimal Price { get; set; }

        public ArtistModel Artist { get; set; }
    }
}
