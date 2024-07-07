namespace TFGDevopsApp1.Dtos.Plastic.Repositories
{
    public class RepositoryResponseDto
    {
        public string name { get; set; }
        public int id { get; set; }
        public int parentId { get; set; }
        public int lastChangeset { get; set; }
        public string comment { get; set; }
        public DateTime creationDate { get; set; }
        public string guid { get; set; }
        public OwnerModel owner { get; set; }
        public RepositoryModel repository { get; set; }
    }

    public class OwnerModel
    {
        public string name { get; set; }
        public bool isGroup { get; set; }
    }

    public class RepositoryModel
    {
        public string name { get; set; }
        public RepIdModel repId { get; set; }
        public string guid { get; set; }
        public OwnerModel owner { get; set; }
        public string server { get; set; }
    }

    public class RepIdModel
    {
        public int id { get; set; }
        public int moduleId { get; set; }
    }
}