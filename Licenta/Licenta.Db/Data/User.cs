namespace Licenta.Db.Data
{
    public class User
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public User()
        {

        }

        public User(string firstname, string lastname, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
        }
    }
}
