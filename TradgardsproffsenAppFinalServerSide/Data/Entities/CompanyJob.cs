namespace TradgardsproffsenApp.Entities
{
    public class CompanyJob
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }    
        public Job Job { get; set; }
        public int JobId { get; set; }
    }
}
