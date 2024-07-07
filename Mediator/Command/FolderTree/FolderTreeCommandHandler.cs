using MediatR;
using System.IO;
using System.Text;
using System.Xml.Linq;
using TFGDevopsApp1.Core.Models.FolderTree;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.UseCases.Contributor.Command.CodeReviewProject;

namespace TFGDevopsApp1.UseCases.Contributor.Command.CompileProyects
{
    public class FolderTreeCommandHandler : IRequestHandler<FolderTreeCommand, Result<FolderTreeDto>>
    {
        private readonly IConfiguration _configuration;

        public FolderTreeCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<Result<FolderTreeDto>> Handle(FolderTreeCommand request, CancellationToken cancellationToken)
        {
            var projectPath = request.ProjectPath;
            var patterns = _configuration["profiles:TFGDevopsApp1.Web:environmentVariables:includeFiles"];
            var searchPatterns = string.IsNullOrEmpty(patterns) ? new List<string> { "*.cs" } :
                                 patterns.Split(",").ToList();
            var codeFiles = Directory.GetFiles(projectPath, patterns, SearchOption.AllDirectories);


            if (codeFiles.Length == 0)
            {
                return await Task.FromResult(new Result<FolderTreeDto>
                {
                    Message = $"No se encontraron archivo de código en {projectPath}",
                    Success = false,
                });
            }

            var foundFiles = codeFiles.Select(file => Path.GetDirectoryName(file)).Distinct().ToList();

            foreach (var pattern in searchPatterns)
            {
                string[] files = Directory.GetFiles(projectPath, pattern, SearchOption.AllDirectories);
                foundFiles.AddRange(files);
            }

            if (request.ExcludePaths != null && request.ExcludePaths.Any())
            {
                foundFiles = foundFiles.Where(file => !request.ExcludePaths.Any(path => file.Contains(path))).ToList();
            }

            if (!foundFiles.Any())
            {
                return await Task.FromResult(new Result<FolderTreeDto>
                {
                    Message = $"No se encontraron archivo de código en {projectPath}",
                    Success = false,
                });
            }

            var xmlFolderRoot = PrepareFoldersXml(projectPath, foundFiles);

            var folderStructure = GetFolderStructure(request.ProjectPath, xmlFolderRoot, request.ExcludePaths);

            return await Task.FromResult(new Result<FolderTreeDto>
            {
                Message = "Estructura de directorios del proyecto cargado correctamente",
                Success = true,
                Data = new FolderTreeDto
                {
                    TreeContent = folderStructure,
                    RepositoryName = request.RepositoryName
                }
            });

        }

        private string GetFolderStructure(string projectPath, IEnumerable<XElement> folderRoot, List<string> excludePaths)
        {
            var folderStructure = new StringBuilder();
            var folders = folderRoot.Select(file =>
                          Path.GetDirectoryName(file.Name.LocalName)?.
                          Replace(projectPath, string.Empty)).
                          Distinct().ToList();


            foreach (var node in folderRoot)
            {

                if (node.Name == "Folder")
                {
                    folderStructure.Append("<ul role=\"tree\" aria-labelledby=\"tree_label\">");
                    folderStructure.Append("<li role=\"treeitem\" aria-expanded=\"false\" aria-selected=\"false\">");
                    folderStructure.Append($"<span>{node.Attribute("Name").Value}</span>");
                    folderStructure.Append("<ul role=\"group\">");

                    folderStructure.Append(GetFolderStructure(node.Name.LocalName, node.Elements(), excludePaths));

                    folderStructure.Append("</ul>");
                    folderStructure.Append("</li>");
                    folderStructure.Append("</ul>");
                }
                else
                {
                    folderStructure.Append($"<li role=\"treeitem\" aria-selected=\"false\" class=\"doc\">{node.Attribute("Name").Value}</li>");
                }
            }
            // Generate HTML
            //folderStructure.Append(HTMLConverter<string>.GenerateHTML(folderList, data => $"<span>{data}</span>"));

            return folderStructure.ToString();
        }


        private static void GetFolderXml(string folderPath, XElement parentNode)
        {
            string folderName = Path.GetFileName(folderPath);
            XElement currentFolderNode = new XElement("Folder", new XAttribute("Name", folderName));
            parentNode.Add(currentFolderNode);

            // Process files
            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                string fileName = Path.GetFileName(filePath);
                currentFolderNode.Add(new XElement("File", new XAttribute("Name", fileName)));
            }

            // Recursively process subdirectories
            foreach (string subFolderPath in Directory.GetDirectories(folderPath))
            {
                GetFolderXml(subFolderPath, currentFolderNode);
            }
        }


        private static IEnumerable<XElement> PrepareFoldersXml(string projectPath, List<string> codeFiles)
        {
            var folderStructure = new StringBuilder();
            var folders = codeFiles.Select(file =>
                          Path.GetDirectoryName(file)?.
                          Replace(projectPath, string.Empty)).
                          Distinct().ToList();

            XElement xmlRoot = new XElement("FolderStructure");

            GetFolderXml(projectPath, xmlRoot);
            var folderRoot = xmlRoot.Elements();

            //var folderRootFiltered = folderRoot.Where(folder => !excludePaths.Contains(folder.Name.LocalName)).ToList();
            return folderRoot;
        }

    }
}
