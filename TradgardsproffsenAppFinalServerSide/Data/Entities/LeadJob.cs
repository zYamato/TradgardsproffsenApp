namespace TradgardsproffsenApp.Entities
{
    public class LeadJob
    {
        public int Id { get; set; }
        public Lead Lead { get; set; }
        public int LeadsId { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
    }
}
