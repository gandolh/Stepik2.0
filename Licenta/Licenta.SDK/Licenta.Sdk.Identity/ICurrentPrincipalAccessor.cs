//ADAUGAT
using System.Security.Claims;

namespace Licenta.Sdk.Identity
{
    public interface ICurrentPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }

        IDisposable Change(ClaimsPrincipal principal);
    }
}
