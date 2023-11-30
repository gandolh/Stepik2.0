namespace Licenta.Db.DataModel
{
    public class Course
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public Course()
        {

        }

        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
