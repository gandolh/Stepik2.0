namespace Licenta.Db.Data
{
    public class LastAccesed
    {
        public Course Course { get; set; } = new Course();
        public string UserId { get; set; } = "";
        public int Module { get; set; }
        public int Step { get; set; }

    }
}
