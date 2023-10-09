namespace Licenta.Sdk.Models.Data
{
    public class ToDoItem
    {
        public string Title { get; set; } = "";
        public DateTime? DueTime { get; set; }
        public string Description { get; set; } = "";
        public ToDoItem(){ }

        public ToDoItem(string title, DateTime? dueTime, string description)
        {
            Title = title;
            DueTime = dueTime;
            Description = description;
        }
    }
}
