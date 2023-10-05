using System.Diagnostics.CodeAnalysis;

namespace Licenta.SDK.Menu
{
    public class ApplicationMenuItem
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string ElementId { get; set; }
        //check if user is authenticated, then display it.
        public bool NeedAuth { get; set; }

        public ApplicationMenuItem()
        {
            Name = "";
            DisplayName = "";
            Description = "";
            Url = "";
            Icon = "";
            ElementId = GetDefaultElementId();
            NeedAuth = false;
        }

        public ApplicationMenuItem(string name, string displayName, string description = "",
       string url = "", string icon = "", string? elementId = null, bool needAuth = false)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            Url = url;
            Icon = icon;
            ElementId = elementId ?? GetDefaultElementId();
            NeedAuth = needAuth;
        }
        private string GetDefaultElementId()
        {
            return "MenuItem_" + Name;
        }
    }
}