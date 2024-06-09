using System.Collections.Generic;

namespace TFGDevopsApp.Dtos.FolderTree
{
    public class FolderTree
    {
        public FolderTree()
        {
            Children = new List<FolderTree>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }
        public int? RevisionId { get; set; }
        public bool IsExpanded { get; set; }
        public FolderTree ParentTree { get; set; }
        public virtual List<FolderTree> Children { get; set; }
    }
}
