namespace TFGDevopsApp.Infraestructure.Entity.Project
{
    public class ProjectBuild : BaseEntity
    {
        public int Version { get; set; }
        public string Path { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? Duration { get; set; }
        public string? Owner { get; set; }
        public string? OwnerEmail { get; set; }

    }
}