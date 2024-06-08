namespace TFGDevopsApp.Infraestructure.Entity.Plastic
{
    public class Changeset
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Comment { get; set; }
        public string CreationDate { get; set; }
        public string Guid { get; set; }
    }
}
