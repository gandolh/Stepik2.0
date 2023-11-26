namespace Licenta.Sdk.Models.Dtos
{
    public class EventDto
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime DueTime { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = "";
     
    }
}
