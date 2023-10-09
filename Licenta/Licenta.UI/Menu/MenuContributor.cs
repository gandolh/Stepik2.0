namespace Licenta.SDK.Menu
{
    public class MenuContributor
    {
        public ApplicationMenu GetMainMenu()
        {
            var mainMenuItem = new ApplicationMenu();

            // TODO: add pages in menu

            mainMenuItem.AddItem(new ApplicationMenuItem(
                PortalMenus.Events,
                "Menu:Courses",
                url: "courses",
                icon: "bi bi-book",
                elementId: "course"
            ));
            mainMenuItem.AddItem(new ApplicationMenuItem(
             PortalMenus.Events,
             "Menu:Events",
             url: "events",
             icon: "bi bi-calendar",
             elementId: "events"
         ));
            return mainMenuItem;
        }



        public ApplicationMenu GetSharedMenu(string redirectUri)
        {
            var sharedMenuItem = new ApplicationMenu();

            sharedMenuItem.AddItem(new ApplicationMenuItem(
                 PortalMenus.Faq,
                 "Menu:Faq",
                 url: "faq",
                 icon: "bi bi-question-circle",
                 elementId: "faq"
             ));
            sharedMenuItem.AddItem(new ApplicationMenuItem(
                 PortalMenus.Contact,
                 "Menu:Contact",
                 url: "contact",
                 icon: "bi bi-envelope",
                 elementId: "contact"
             ));
            sharedMenuItem.AddItem(new ApplicationMenuItem(
                 PortalMenus.Settings,
                 "Menu:Settings",
                 url: "profile",
                 icon: "bi bi-gear-wide",
                 elementId: "settings",
                 needAuth: true
             ));
            sharedMenuItem.AddItem(new ApplicationMenuItem(
                 PortalMenus.Register,
                 "Menu:Register",
                 url: "#",
                 icon: "bi bi-card-list",
                 elementId: "register",
                 needAuth: true
             ));
            return sharedMenuItem;
        }

        // TODO: get menu from occ, cbs, de
        public (ApplicationMenu, ApplicationMenu) GetMainMenu(string redirectUri)
        {
            return (GetSharedMenu(redirectUri), GetMainMenu());
        }



    }
}
