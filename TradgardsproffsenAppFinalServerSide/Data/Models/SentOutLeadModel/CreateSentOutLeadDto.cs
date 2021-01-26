using System.Collections.Generic;
using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Models
{
    public class CreateSentOutLeadDto
    {
        public ValidatedLead Lead { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<Company> ForetagListaSkickade { get; set; } = new List<Company>();
    }
}
