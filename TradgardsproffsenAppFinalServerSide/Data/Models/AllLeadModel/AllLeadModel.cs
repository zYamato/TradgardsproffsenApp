using System.Collections.Generic;
using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Models
{
    public class AllLeadModel
    {
        public Lead Lead { get; set; }
        public ValidatedLead ValidLead { get; set; }
        public LostLead LostLead { get; set; }
        public List<Company> ForetagListaSkickade { get; set; } = new List<Company>();
    }
}
