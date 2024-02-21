using Licenta.Db.Data;

namespace Licenta.Db.DataModel
{
    public class PortalUser
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public int Id { get; set; } = 0;

        public PortalUser()
        {

        }

        public PortalUser(int id, string firstname, string lastname, string password)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
        }

        public List<int> Roles { get; set; } = new List<int>();

    }
}
