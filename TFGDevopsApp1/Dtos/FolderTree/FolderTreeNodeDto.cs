namespace TFGDevopsApp.Core.Models.FolderTree
{
    public class FolderTreeNodeDto<T>
    {
        public T Data { get; set; }
        public FolderTreeNodeDto<T>[] Children { get; set; }
    }

}
