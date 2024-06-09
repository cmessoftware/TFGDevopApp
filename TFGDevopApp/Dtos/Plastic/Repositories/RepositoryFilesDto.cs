namespace TFGDevopsApp.Dtos.Plastic.Repositories
{
    public class RepositoryFilesDto
    {

        public bool IsExpanded { get; set; }
        public RepositoryFileModel File { get; set; }
        public string Path { get; set; }
        public List<RepositoryFileModel> SubFolders { get; set; }
    }

    public class RepositoryFileModel
    {
        public int revisionId { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string name { get; set; }
        public string path { get; set; }
    }
}