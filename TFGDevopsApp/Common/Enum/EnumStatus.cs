using System.ComponentModel;

namespace TFGDevopsApp.Dtos.Plastic.Build
{
    public enum EnumStatus
    {
        [Description("Success")]
        Success = 1,
        [Description("Integrado")]
        Integrated = 2,
        [Description("Publicado")]
        Published = 3,
        [Description("Error")]
        Error = 4,
    }
}