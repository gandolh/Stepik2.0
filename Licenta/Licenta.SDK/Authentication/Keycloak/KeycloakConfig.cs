namespace Licenta.SDK.Authentication.Keycloak
{
    public class KeycloakConfig
    {
        public string ServerRealm { get; set; } = "";
        public string Metadata { get; set; } = "";
        public string TokenExchange { get; set; } = "";
        public string OidcProtocol { get; set; } = "";
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string Audience { get; set; } = "";

        //(used for reseting password)
        public string Host { get; set; } = "";
        public string Realm { get; set; } = "";
        public string AdminUsername { get; set; } = "";
        public string AdminPassword { get; set; } = "";

    }
}
