using AutoMapper;
using TFGDevopsApp.Dtos.FolderTree;
using TFGDevopsApp.Dtos.Plastic.Repositories;

namespace TFGDevopsApp.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<DirectoryItemDto, FolderTree>()
                .ForMember(dst => dst.Children, opt => opt.MapFrom(x => x.Items))
                .ForMember(dst => dst.RevisionId, opt => opt.MapFrom(x => x.RevisionId))
                .ForMember(dst => dst.IsExpanded, opt => opt.Ignore())
                .ForMember(dst => dst.Path, opt => opt.MapFrom(x => x.Path))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(x => x.Type))
                .ForMember(dst => dst.Children, opt => opt.MapFrom<FolderTreeItemsResolver>());

        }
    }
}
