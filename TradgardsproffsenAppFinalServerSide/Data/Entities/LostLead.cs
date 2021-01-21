using System.ComponentModel.DataAnnotations;

namespace TradgardsproffsenApp.Entities
{
    public class LostLead
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
