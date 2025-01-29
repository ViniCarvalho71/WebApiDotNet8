using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class ArtistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<TattooModel> TattoosBooked { get; set; }
    }
}
