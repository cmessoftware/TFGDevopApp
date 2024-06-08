using TFGDevopsApp.Infraestructure.Entity.Plastic;

namespace TFGDevopsApp.Core.Models.Plastic
{
    public class ChangeSetResponseDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public string Guid { get; set; }
        public Branch Branch { get; set; }
        public OwnerEntityPlastic Owner { get; set; }
        public RepositoryModel Repository { get; set; }
    }

    public class Branch
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int LastChangeset { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public string Guid { get; set; }
        public OwnerModel Owner { get; set; }
        public RepositoryModel Repository { get; set; }
    }

}
