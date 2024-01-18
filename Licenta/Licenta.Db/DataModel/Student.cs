using Licenta.Db.Data;

namespace Licenta.Db.DataModel
{
    public class Student : User
    {
        public int Id { get; set; } = 0;

        public Student()
        {

        }

        public Student(int id, string firstname, string lastname, string password) 
            : base(firstname, lastname, password)
        {
            Id = id;
        }
    }
}
