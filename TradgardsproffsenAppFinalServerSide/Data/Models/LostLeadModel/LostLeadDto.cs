using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Models
{
    public class LostLeadDto
    {
        public Lead Lead { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PostNr { get; set; }
        public string Info { get; set; }
        public string Ort { get; set; }
        public string Email { get; set; }
    }
}
