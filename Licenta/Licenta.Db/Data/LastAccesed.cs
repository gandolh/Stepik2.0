namespace Licenta.Db.Data
{
    public class LastAccesed
    {
        public string Id { get; set; } = "";
        public string CourseId { get; set; } = "";

        //todo: add to db
        public string LessonId { get; set; } = "";
        public string UserId { get; set; } = "";
        public int Module { get; set; }
        public int Step { get; set; }

    }
}
