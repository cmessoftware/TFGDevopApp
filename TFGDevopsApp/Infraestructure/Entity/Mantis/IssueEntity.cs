namespace TFGDevopsApp.Infraestructure.Entity.Mantis
{
    public class IssueEntity
    {
        public long? Id { get; set; }
        public long? IssueId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
