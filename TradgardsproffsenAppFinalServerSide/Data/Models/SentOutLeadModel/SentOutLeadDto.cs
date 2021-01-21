using System.Collections.Generic;
using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Models
{
    public class SentOutLeadDto
    {
        public ValidatedLead Lead { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PostNr { get; set; }
        public string Info { get; set; }
        public List<LeadJob> Jobbs { get; set; } = new List<LeadJob>();
        public List<Company> ForetagListaSkickade { get; set; } = new List<Company>();
    }
}
