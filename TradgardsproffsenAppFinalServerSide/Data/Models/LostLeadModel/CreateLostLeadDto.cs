using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Models
{
    public class CreateLostLeadDto
    {
        public Lead Lead { get; set; }
        public string Ort { get; set; }
        public string Email { get; set; }

    }
}
