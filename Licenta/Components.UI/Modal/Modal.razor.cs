using Microsoft.AspNetCore.Components;
using Components.UI.Enums;
using Components.UI.Utils;

namespace Components.UI.Modal
{

    public partial class Modal : NewComponent
    {
        [Parameter] public string ModalId { get; set; } = "";
        [Parameter] public bool EnabledBackdrop { get; set; } = true;
        [Parameter] public bool VerticalCenter { get; set; } = true;
        [Parameter] public ModalSize Size { get; set; } = ModalSize.Medium;

        private string GetModalSize()
        {
            return Size switch
            {
                ModalSize.Small => "modal-sm",
                ModalSize.Medium => "",
                ModalSize.Large => "modal-lg",
                ModalSize.ExtraLarge => "modal-xl",
                ModalSize.FullScreen => "modal-fullscreen",
                _ => ""
            };
        }

        protected override string GetId()
        {
            string id = base.GetId();
            return string.IsNullOrEmpty(ModalId) ? id : ModalId;
        }

    }
}