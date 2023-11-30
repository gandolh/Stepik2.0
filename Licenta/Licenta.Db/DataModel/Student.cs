namespace Licenta.Db.DataModel
{
    internal class Student
    {
        public int Id { get; set; } = 0;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Student()
        {

        }

        public Student(int id, string firstname, string lastname, string password)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
        }
    }
}
