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


        // QUERYING
        public List<Module> Modules { get; set; } = new List<Module>();
        public List<PortalUser> Teachers { get; set; } = new List<PortalUser>();
        public List<PortalUser> Students { get; set; } = new List<PortalUser>();
    }
}
