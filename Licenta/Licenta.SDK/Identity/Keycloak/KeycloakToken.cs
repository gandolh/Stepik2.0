using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Sdk.Identity.Keycloak
{
    public class KeycloakToken
    {
        public string AccessToken { get; set; } = "";
        public int ExpiresIn { get; set; } = 0;
        public int RefreshTokenExpiresIn { get; set; } = 0;
        public string RefreshToken { get; set; } = "";
        public string Scope { get; set; } = "";
        public DateTime CreationTime { get; set; }
    }
}
