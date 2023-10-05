using Licenta.SDK.Menu;

namespace Licenta.SDK.Menu.Interfaces
{
    public interface IMenuContributor
    {
        Task<ApplicationMenu> GetCbsMenuAsync();
        Task<(ApplicationMenu?, ApplicationMenu?, ApplicationMenu?)> GetMainMenusync(string redirectUri);
        Task<ApplicationMenu> GetSharedMenuAsync(string redirectUri);
    }
}