namespace Licenta.Db.Data
{
    public class Profesor
    {
        public int Id { get; set; } = 0;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Profesor()
        {

        }

        public Profesor(int id, string firstname, string lastname, string password)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
        }
    }
}
