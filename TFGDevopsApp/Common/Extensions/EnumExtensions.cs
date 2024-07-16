using System.ComponentModel;

namespace TFGDevopsApp.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum.EnumIssueType value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static int ToInt(this Enum.EnumIssueType value)
        {
            return (int)value;
        }
    }
}
