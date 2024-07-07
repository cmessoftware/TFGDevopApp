using System.Text;

namespace TFGDevopsApp1.Core.Models.FolderTree
{
    public class HTMLConverter<T>
    {
        public static string GenerateHTML(FolderTreeNodeDto<T> node, Func<T, string> dataToHTML)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<ul role=\"tree\" aria-labelledby=\"tree_label\">");
            html.Append(GenerateNodeHTML(node, dataToHTML));
            html.Append("</ul>");
            return html.ToString();
        }

        private static string GenerateNodeHTML(FolderTreeNodeDto<T> node, Func<T, string> dataToHTML)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<li role=\"treeitem\" aria-expanded=\"false\" aria-selected=\"false\">");
            html.Append(dataToHTML(node.Data));
            if (node.Children != null && node.Children.Length > 0)
            {
                html.Append("<ul role=\"group\">");
                foreach (var child in node.Children)
                {
                    html.Append(GenerateNodeHTML(child, dataToHTML));
                }
                html.Append("</ul>");
            }
            html.Append("</li>");
            return html.ToString();
        }
    }
}
