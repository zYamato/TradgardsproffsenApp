

namespace TradgardsproffsenApp.Models
{
    public class CreateLostLeadDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public string Info { get; set; }
        public bool WasValidated { get; set; }
        public bool WasSentOut { get; set; }
    }
}
