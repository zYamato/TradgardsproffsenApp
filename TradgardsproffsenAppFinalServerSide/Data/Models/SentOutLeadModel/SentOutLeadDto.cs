using System.Collections.Generic;
using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Models
{
    public class SentOutLeadDto
    {
        public ValidatedLead Lead { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<Company> CompaniesSentTo { get; set; } = new List<Company>();
    }
}
