using System.Collections.Generic;

namespace TFGDevopsApp.Models.Plastic
{
    public class DirectoryItemDto
    {
        public int RevisionId { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }

        public string Content { get; set; }

        public string Path { get; set; }
        public bool IsUnderXlink { get; set; }
        public List<DirectoryItemDto> Items { get; set; }
    }

    public class Repository
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Guid { get; set; }
        public Owner Owner { get; set; }
        public string Server { get; set; }
    }

    public class Owner
    {
        public string Name { get; set; }
        public bool IsGroup { get; set; }
    }
}

