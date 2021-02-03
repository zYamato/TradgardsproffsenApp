using System.ComponentModel.DataAnnotations;

namespace TradgardsproffsenApp.Entities
{
    public class LostLead
    {
            [Required]
            [Key]
            public int Id { get; set; }
            public Lead Lead { get; set; }
            public int? LeadId { get; set; }
            public ValidatedLead ValidatedLead { get; set; }
            public int? ValidatedLeadId { get; set; }
            public SentOutLead SentOutLead { get; set; }
            public int? SentOutLeadId { get; set; }
    }
}
