using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Sdk.Identity;

namespace Licenta.Sdk.Identity.Keycloak
{
    public class KeycloakUserRepresentation
    {
        public bool Totp { get; set; }
        public bool EmailVerified { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        public void CopyProprieties(CurrentUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Attributes["Address"] = user.Address;
            Attributes["City"] = user.City;
            Attributes["Country"] = user.Country;
            Attributes["AccountSecretKey"] = user.AccountSecretKey;
        }
    }
}
