using Licenta.Db.Data;
using Licenta.SDK.Models;

namespace Licenta.Db.DataModel
{
    public class Role
    {
        public int Id { get; set; }
        public RoleType type { get; set; } = RoleType.Guest;
        public int UserId { get; set; }

        public Role()
        {
            
        }

        public Role(int id, RoleType type, int userId)
        {
            Id = id;    
            this.type = type;
            UserId = userId;
        }
    }
}
