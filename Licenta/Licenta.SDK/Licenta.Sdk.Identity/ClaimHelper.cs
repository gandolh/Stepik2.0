using System.Security.Claims;

namespace Licenta.Sdk.Identity
{
    public class ClaimHelper
    {
        private static readonly string CountryClaim = "Country";
        private static readonly string CityClaim = "City";
        private static readonly string AddressClaim = "Address";
        private static readonly string AccountSecretKeyClaim = "AccountSecretKey";
        private static readonly string PreferredUsernameClaim = "preferred_username";
        private static readonly string PhoneNumberClaim = "PhoneNumber";

        public static string GetUserInitials(ClaimsPrincipal? user)
        {
            string givenName = user?.FindFirst(c => c.Type == ClaimTypes.GivenName)?.Value ?? "";
            string surName = user?.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value ?? "";
            if (string.IsNullOrEmpty(givenName) || string.IsNullOrEmpty(surName))
                return "";
            string initials = string.Concat(givenName.First(), surName.First());
            return initials;
        }

        public static string GetFullName(ClaimsPrincipal? user)
        {
            string givenName = user?.FindFirst(c => c.Type == ClaimTypes.GivenName)?.Value ?? "";
            string surName = user?.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value ?? "";
            return surName + " " + givenName;
        }

        public static string GetEmail(ClaimsPrincipal? user)
        {
            return user?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? "";
        }
        public static string GetGivenName(ClaimsPrincipal? user)
        {
            return user?.FindFirst(c => c.Type == ClaimTypes.GivenName)?.Value ?? "";
        }

        public static string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        }

        public static string GetUsername(ClaimsPrincipal user)
        {
            return user.FindFirst(PreferredUsernameClaim)?.Value ?? "";
        }

        public static string? GetFirstName(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.GivenName)?.Value ?? "";
        }

        public static string? GetLastName(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Surname)?.Value;

        }

        public static string GetAdress(ClaimsPrincipal user)
        {
            return user.FindFirst(AddressClaim)?.Value ?? "";
        }

        public static string GetCity(ClaimsPrincipal user)
        {
            return user.FindFirst(CityClaim)?.Value ?? "";
        }

        public static string GetCountry(ClaimsPrincipal user)
        {
            return user.FindFirst(CountryClaim)?.Value ?? "";
        }

        public static string GetAccountSecret(ClaimsPrincipal user)
        {
            // TODO: generate account secret
            return user.FindFirst(AccountSecretKeyClaim)?.Value ?? "";

        }

        internal static string GetPhoneNumber(ClaimsPrincipal user, string defaultValue = "")
        {
            // TODO: save phone number
            return user.FindFirst(PhoneNumberClaim)?.Value ?? defaultValue;

        }
    }
}
