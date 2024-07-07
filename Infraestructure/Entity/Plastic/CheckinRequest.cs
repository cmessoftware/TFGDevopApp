namespace TFGDevopsApp1.Infraestructure.Entity.Plastic
{
    public class CheckinRequest
    {
        public string[] Paths { get; set; }
        public string Comment { get; set; }
        public bool Recurse { get; set; }
    }
}
