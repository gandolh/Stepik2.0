using Licenta.SDK.Interfaces;

namespace Licenta.SDK.Menu
{
    public class MenuContributor : IMenuContributor
    {
        private ApplicationMenu? _cbsMenu;
        private ApplicationMenu? _occMenu;
        private ApplicationMenu? _portalMenu;



        public async Task<ApplicationMenu> GetCbsMenuAsync()
        {
            var sharedMenuItem = new ApplicationMenu();

            // TODO: add pages in menu

            return sharedMenuItem;
        }



        public async Task<ApplicationMenu> GetSharedMenuAsync(string redirectUri)
        {
            var sharedMenuItem = new ApplicationMenu();

            sharedMenuItem.AddItem(new ApplicationMenuItem(
                 PortalMenus.Faq,
                 "Menu:Faq",
                 url: "faq",
                 icon: "bi bi-question-circle",
                 elementId: "Home"
             ));
            sharedMenuItem.AddItem(new ApplicationMenuItem(
                 PortalMenus.Contact,
                 "Menu:Contact",
                 url: "contact",
                 icon: "bi bi-envelope",
                 elementId: "Home"
             ));
            sharedMenuItem.AddItem(new ApplicationMenuItem(
                 PortalMenus.Settings,
                 "Menu:Settings",
                 url: "profile",
                 icon: "bi bi-gear-wide",
                 elementId: "Home",
                 needAuth: true
             ));
            sharedMenuItem.AddItem(new ApplicationMenuItem(
                 PortalMenus.Register,
                 "Menu:Register",
                 url: "#",
                 icon: "bi bi-card-list",
                 elementId: "Home",
                 needAuth: true
             ));
            return sharedMenuItem;
        }

        // TODO: get menu from occ, cbs, de
        public async Task<(ApplicationMenu?, ApplicationMenu?, ApplicationMenu?)> GetMainMenusync(string redirectUri)
        {
            await GetSharedMenuAsync(redirectUri);
            await GetCbsMenuAsync();
            return (_portalMenu, _occMenu, _cbsMenu);
        }



    }
}
