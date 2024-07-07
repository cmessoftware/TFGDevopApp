using MediatR;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dto.Plastic.Workspaces;
using TFGDevopsApp1.Dtos.FolderTree;
using TFGDevopsApp1.Dtos.Plastic.ChangeSets;
using TFGDevopsApp1.Dtos.Plastic.Repositories;
using TFGDevopsApp1.Dtos.Plastic.Workspaces;
using TFGDevopsApp1.Interfaces;
using TFGDevopsApp1.Mediator.Command.Repositories;
using TFGDevopsApp1.Mediator.Command.WorkSpaces;
using TFGDevopsApp1.Mediator.Queries.Plastic.ChangeSets;
using TFGDevopsApp1.Mediator.Queries.Plastic.Repositories;
using TFGDevopsApp1.Mediator.Queries.Plastic.WorkSpaces;

namespace TFGDevopsApp1.Services
{
    public class PlasticServices : IPlasticServices
    {
        private readonly IMediator _mediator;

        public PlasticServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result<CreateRepositoryResponseDto>> CreateRepositoryAsync(RepositoryCreateRequestDto repository)
        {
            var query = new CreateRepositoryCommand(repository);
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

        public async Task<Result<bool>> CreateWorkSpaceAsync(WorkspaceRequestDto workspace)
        {
            var query = new CreateWorkSpacesCommand(workspace);
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

        public async Task<Result<bool>> EditWorkspaceAsync(EditWorkspaceRequestDto workspace)
        {
            var query = new UpdateWorkSpacesCommand(workspace);
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

        public async Task<Result<List<ChangeSetResponseDto>>> GetChangeSetsAsync(string path)
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

        public async Task<Result<FolderTree>> GetFolderTreeAsync(string path)
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

        public async Task<Result<List<RepositoryResponseDto>>> GetRepositoriesAsync(string path)
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

        public async Task<Result<RepositoryResponseDto>> GetRepositoryAsync(string path)
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

        public async Task<Result<FolderTree>> GetRepositoryFoldersAsync(string path)
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

        public async Task<Result<WorkspaceResponseDto>> GetWorkSpaceByNameAsync(string path, string name)
        {
            var query = new GetWorkSpaceQuery(path, name);
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

        public async Task<Result<List<WorkspaceResponseDto>>> GetWorkSpacesAsync(string path)
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

        public async Task<Result<bool>> RemoveWorkSpacesAsync(string name)
        {
            var query = new RemoveRepositoryCommand(name);
            var result = await _mediator.Send(query);

            if (result.Data)
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
