namespace API.Controllers
{
    public sealed class CreateTechnologyRequest
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public byte[] Icon { get; set; }
    }
}