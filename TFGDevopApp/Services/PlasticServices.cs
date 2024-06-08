using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Interfaces;
using TFGDevopsApp.Mediator.Queries.Plastic.ChangeSets;
using TFGDevopsApp.Mediator.Queries.Plastic.Repositories;
using TFGDevopsApp.Mediator.Queries.Plastic.WorkSpaces;
using MediatR;
using TFGDevopsApp.Components.Pages.Folder;

namespace TFGDevopsApp.Services
{
    public class PlasticServices : IPlasticServices
    {
        private readonly IMediator _mediator;

        public PlasticServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResultMessage<List<ChangeSetResponseDto>>> GetChangeSetsAsync(string path)
        {
            var query = new GetChangeSetsQuery(path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<string> GetFileContentAsyc(string path)
        {
            var response = RestClientHelper.GetBlob<string>(path);
            return await Task.FromResult(response);
        }

        public async Task<ResultMessage<FolderTree>> GetFolderTreeAsync(string path)
        {
            var query = new GetRepositoryFilesQuery(path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<ResultMessage<List<RepositoryResponseDto>>> GetRepositoriesAsync(string path)
        {
            var query = new GetRepositoriesQuery(path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<ResultMessage<RepositoryResponseDto>> GetRepositoryAsync(string path)
        {
            var query = new GetRepositoryQuery(path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<ResultMessage<FolderTree>> GetRepositoryFoldersAsync(string path)
        {
            var query = new GetRepositoryFilesQuery(path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<ResultMessage<List<WorkspaceResponseDto>>> GetWorkSpacesAsync(string path)
        {
            var query = new GetWorkSpacesQuery(path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }
    }
}
