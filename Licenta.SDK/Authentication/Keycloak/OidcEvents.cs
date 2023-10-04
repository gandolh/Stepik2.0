using Licenta.SDK.Authentication.AccessTokenManagement.Interfaces;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Licenta.SDK.Authentication.Keycloak
{
    public class OidcEvents : OpenIdConnectEvents
    {
        private readonly IUserAccessTokenStore _store;

        public OidcEvents(IUserAccessTokenStore store)
        {
            _store = store;
        }

        public override async Task TokenValidated(TokenValidatedContext context)
        {
            var exp = DateTimeOffset.UtcNow.AddSeconds(double.Parse(context.TokenEndpointResponse!.ExpiresIn));

            await _store.StoreTokenAsync(
                context.Principal!,
                context.TokenEndpointResponse.AccessToken,
                exp,
                context.TokenEndpointResponse.RefreshToken);

            await base.TokenValidated(context);
        }
    }
}
