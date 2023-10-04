//ADAUGAT
using System.Security.Claims;

namespace Licenta.SDK.Authentication
{
    public interface ICurrentPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }

        IDisposable Change(ClaimsPrincipal principal);
    }
}
