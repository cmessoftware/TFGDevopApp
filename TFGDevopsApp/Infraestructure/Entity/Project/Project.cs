using TFGDevopsApp.Infraestructure.Entity.Plastic;

namespace TFGDevopsApp.Infraestructure.Entity.Project
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string Repository { get; set; }
        public string Branch { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string OwnerEmail { get; set; }
        public virtual ICollection<Changeset> ChangeSets { get; set; }
        public virtual ICollection<ProjectBuild> ProjectBuilders { get; set; }

    }

}
