using AutoMapper;
using TFGDevopsApp1.Dtos.FolderTree;
using TFGDevopsApp1.Dtos.Plastic.Repositories;

namespace TFGDevopsApp1.Common.Mapper
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


            CreateMap<RepositoryResponseDto, CreateRepositoryResponseDto>()
                .ForMember(dst => dst.MachineName, opt => opt.MapFrom(x => x.repository.server))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.repository.name))
                .ForMember(dst => dst.Comment, opt => opt.MapFrom(x => x.comment))
                .ForMember(dst => dst.CreationDate, opt => opt.MapFrom(x => x.creationDate))
                .ForMember(dst => dst.owner, opt => opt.MapFrom(x => new OwnerModel()));
              


        }
    }
}
