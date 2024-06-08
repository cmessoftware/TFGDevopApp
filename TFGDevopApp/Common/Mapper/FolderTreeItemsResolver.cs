using AutoMapper;
using System.Collections.Generic;
using TFGDevopsApp.Components.Pages.Folder;
using TFGDevopsApp.Models.Plastic;


namespace TFGDevopsApp.Common.Mapper
{
    public class FolderTreeItemsResolver : IValueResolver<DirectoryItemDto, FolderTree, List<FolderTree>>
    {
        public List<FolderTree> Resolve(DirectoryItemDto source, FolderTree destination, List<FolderTree> destMember, ResolutionContext context)
        {
            List<FolderTree> tree = new List<FolderTree>();
            if (source.Items != null)
            {
                foreach (var item in source.Items)
                {
                    tree.Add(new FolderTree
                    {
                        Name = item.Name,
                        Path = item.Path,
                        Type = item.Type,
                        RevisionId = item.RevisionId,
                        Children = Resolve(item, destination, destMember, context)
                    });
                }
            }

            return tree;

        }
    }
}
