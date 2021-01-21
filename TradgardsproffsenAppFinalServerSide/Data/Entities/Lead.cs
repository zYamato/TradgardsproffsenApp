using System.ComponentModel.DataAnnotations;

namespace TradgardsproffsenApp.Entities
{
    public class Lead
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string URL { get; set; }
        public string Info { get; set; }
    }
}
