namespace Licenta.Db.DataModel
{
    public class Teacher
    {
        public int Id { get; set; } = 0;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Teacher()
        {

        }

        public Teacher(int id, string firstname, string lastname, string password)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
        }
    }
}
