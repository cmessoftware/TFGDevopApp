using AntDesign;
using AutoMapper;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Dtos.FolderTree;
using TFGDevopsApp.Dtos.Plastic.Repositories;
using TFGDevopsApp.Infraestructure.Entity.Mantis;

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


            CreateMap<RepositoryResponseDto, CreateRepositoryResponseDto>()
                .ForMember(dst => dst.MachineName, opt => opt.MapFrom(x => x.repository.server))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.repository.name))
                .ForMember(dst => dst.Comment, opt => opt.MapFrom(x => x.comment))
                .ForMember(dst => dst.CreationDate, opt => opt.MapFrom(x => x.creationDate))
                .ForMember(dst => dst.owner, opt => opt.MapFrom(x => new OwnerModel()));

            CreateMap<Issue, IssueTracking>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => 0))
                .ForMember(dest => dest.Reporter, opt => opt.MapFrom((src, dst) =>
                {
                    dst.Reporter = src.Reporter?.Name;
                    return dst;
                }))
                 .ForMember(dest => dest.Category, opt => opt.MapFrom((src, dst) =>
                 {
                     dst.Category = src.Category?.Name;
                     return dst;
                 }))
                  .ForMember(dest => dest.Project, opt => opt.MapFrom((src, dst) =>
                  {
                      dst.Project = src.Project?.Name;
                      return dst;
                  }))
                .ForMember(dest => dest.Summary, src => src.MapFrom(x => x.Summary))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description));
             
        }
    }
}
