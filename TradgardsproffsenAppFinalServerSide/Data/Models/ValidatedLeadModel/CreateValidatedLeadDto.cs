using System.Collections.Generic;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Models
{
    public class CreateValidatedLeadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public string Info { get; set; }
        public List<JobDto> Jobbs { get; set; } = new List<JobDto>();
    }
}
