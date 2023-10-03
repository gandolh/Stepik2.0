using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Others
{
    public partial class ProfileIcon
    {
        [Parameter] public string Email { get; set; } = "";
        private string GavatarIconUrl = "";

        protected override Task OnInitializedAsync()
        {
            GavatarIconUrl = "https://www.gravatar.com/avatar/" +
               CreateMD5(Email.Trim().ToLower()).ToLower() +
               "?d=mp";
            return base.OnInitializedAsync();
        }

        private string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
