namespace Licenta.Db.Data
{
    public class Event
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime DueTime { get; set; } = DateTime.MinValue;
        public string Description { get; set; } = "";
    }
}
