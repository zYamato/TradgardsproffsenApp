using Microsoft.AspNetCore.Components;

namespace TradgardsproffsenApp.Models
{
    public class LeadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostNr { get; set; }
        public string URL { get; set; }
        public string Info { get; set; }
    }
}
