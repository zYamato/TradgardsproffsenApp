using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Models
{
    public class CreateLostLeadDto
    {
        public int? LeadId { get; set; }
        public int? ValidatedLeadId { get; set; }
        public int? SentOutLeadId { get; set; }
    }
}
