using Licenta.Components.UI.Enums;

namespace Licenta.Components.UI.Utils
{
    public static class ClassnameProvider
    {

        public static string getClassname(IconName iconName)
        {
            return iconName switch
            {
                IconName.FileUpload => "bi bi-file-earmark-arrow-up-fill",
                IconName.Times => "bi bi-x-circle",
                IconName.QuestionCircle => "bi bi-question-circle",
                IconName.FileDownload => "bi bi-file-earmark-arrow-down",
                IconName.FileDownloadFill => "bi bi-file-earmark-arrow-down-fill",
                IconName.MinusCircle => "bi bi-dash-circle",
                IconName.Check => "bi bi-check-circle",
                IconName.Add => "bi bi-plus",
                IconName.Thrash => "bi bi-trash3",
                IconName.ThrashFill => "bi bi-trash3-fill",
                IconName.ThrashCan => "bi bi-trash",
                IconName.ThrashCanFill => "bi bi-trash-fill",
                IconName.UserCircle => "bi bi-person-circle",
                IconName.FileSignature => "bi bi-vector-pen",
                IconName.Image => "bi bi-image",
                IconName.File => "bi bi-file-earmark",
                IconName.Eye => "bi bi-eye-fill",
                IconName.Ban => "bi bi-slash-circle",
                IconName.CaretDown => "bi bi-caret-down-fill",
                IconName.CaretRight => "bi bi-caret-right-fill",
                IconName.Caretleft => "bi bi-caret-left-fill",
                IconName.Forward => "bi bi-fast-forward-fill",
                IconName.Backward => "bi bi-skip-backward-fill",
                IconName.Paste => "bi bi-clipboard",
                IconName.Copy => "bi bi-clipboard",
                IconName.CloudArrowUp => "bi bi-cloud-arrow-up-fill",
                IconName.Cloud => "bi bi-cloud-fill",
                IconName.Bell => "bi bi-bell",
                _ => "",
            };
        }
    }
}
