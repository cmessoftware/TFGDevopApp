using System.ComponentModel;

namespace TFGDevopsApp.Common.Enum
{
    public enum EnumIssueType
    {
        [Description("Change Set")]
        ChangeSet = 1,
        [Description("Request Code Review")]
        RequestCodeReview = 2,
        [Description("Build")]
        Build = 3,
    }
}