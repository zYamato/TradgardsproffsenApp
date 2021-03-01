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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string URL { get; set; }
        public string Info { get; set; }
        public List<LeadJob> Jobs { get; set; }
        public List<Company> CompaniesSentTo { get; set; }
    }
}
