using Licenta.Db.Data;

namespace Licenta.Db.DataModel
{
    public class Teacher : User
    {
        public int Id { get; set; } = 0;


        public Teacher()
        {

        }

        public Teacher(int id, string firstname, string lastname, string password)
            : base(firstname, lastname, password)
        {
            Id = id;

        }
    }
}
