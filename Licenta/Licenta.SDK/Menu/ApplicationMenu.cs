using System.Diagnostics.CodeAnalysis;

namespace Licenta.SDK.Menu
{
    public class ApplicationMenu
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<ApplicationMenuItem> Items { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        public ApplicationMenu()
        {
            Name = "";
            DisplayName = "";
            Items = new List<ApplicationMenuItem>();
            Icon = "";
            Description = "";
        }

        public ApplicationMenu(
            string name,
            string? displayName = null,
            string icon = "",
            string description = "")
        {
            Name = name;
            DisplayName = displayName ?? Name;
            Items = new List<ApplicationMenuItem>();
            Icon = icon;
            Description = description;
        }

        public ApplicationMenu AddItem([NotNull] ApplicationMenuItem menuItem)
        {
            Items.Add(menuItem);
            return this;
        }
    }
}