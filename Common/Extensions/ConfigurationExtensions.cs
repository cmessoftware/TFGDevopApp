namespace TFGDevopsApp1.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetValue(this IConfiguration configuration, string key)
        {
            return configuration[key];
        }
    }
}
