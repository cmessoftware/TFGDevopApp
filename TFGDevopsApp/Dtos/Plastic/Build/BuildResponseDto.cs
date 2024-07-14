namespace TFGDevopsApp.Dtos.Plastic.Build
{
    public class BuildResponseDto
    {
        public string BuildId { get; set; }
        public EnumStatus BuildStatus { get; set; }
        public DateTime BuildDate { get; set; }
        public string OutputDirectory { get; set; }
    }
}
