using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Entities
{
    public class SentOutLead
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public ValidatedLead Lead { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Company> CompaniesSentTo { get; set; } = new List<Company>();
    }
}
