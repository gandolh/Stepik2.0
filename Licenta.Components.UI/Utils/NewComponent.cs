using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Utils
{
    public class NewComponent : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public virtual string Style { get; set; } = "";
        [Parameter] public virtual bool Visible { get; set; } = true;
        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? Attributes { get; set; }
        public string? UniqueID { get; set; }


        /// <summary>
        /// Gets the component CSS class.
        /// </summary>
        protected virtual string GetComponentCssClass()
        {
            return "";
        }

        /// <summary>
        /// Gets the final CSS class rendered by the component. Combines it with a <c>class</c> custom attribute.
        /// </summary>
        protected string GetCssClass()
        {
            if (Attributes != null && Attributes.TryGetValue("class", out var @class) && !string.IsNullOrEmpty(Convert.ToString(@class)))
            {
                return $"{GetComponentCssClass()} {@class}";
            }

            return GetComponentCssClass();
        }

        /// <summary>
        /// Gets the unique identifier. 
        /// </summary>
        /// <returns>Returns the <c>id</c> attribute (if specified) or generates a random one.</returns>
        protected virtual string GetId()
        {
            if (Attributes != null && Attributes.TryGetValue("id", out var id) && !string.IsNullOrEmpty(Convert.ToString(@id)))
            {
                return $"{@id}";
            }

            return UniqueID ?? "";
        }

    }
}
