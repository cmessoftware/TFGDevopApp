namespace TFGDevopsApp1.Infraestructure.Entity.Plastic
{
    public class RevisionInfoEntityPlastic
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ItemId { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Hash { get; set; }
        public int BranchId { get; set; }
        public int ChangesetId { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime CreationDate { get; set; }
        public RepositoryIdEntityPlastic RepositoryId { get; set; }
        public OwnerEntityPlastic Owner { get; set; }

    }
}
