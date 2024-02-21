namespace Licenta.SDK.Models.Dtos
{
    public class PortalUserDto : IDtoWithId
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<RoleType> Roles { get; set; } = new List<RoleType>();

        public string FullName => Firstname + Lastname;
    }
}
