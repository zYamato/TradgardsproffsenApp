using System.ComponentModel.DataAnnotations;

namespace TradgardsproffsenApp.Entities 
{
    public class LostLead 
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string District { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Required]
        public string URL { get; set; }
        public string Info { get; set; }
    }
}