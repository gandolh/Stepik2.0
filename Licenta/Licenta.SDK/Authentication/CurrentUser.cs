using System.Security.Claims;

namespace Licenta.SDK.Authentication
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AccountSecretKey { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public CurrentUser()
        {
            Id = "e5d97a64-c150-47fb-ae10-6041933c8949";
            Email = "";
            FirstName = "";
            LastName = "";
            Address = "";
            City = "";
            Country = "";
            AccountSecretKey = "";
            Username = "";
            FullName = "";
            PhoneNumber = "Todo: (436) 486-3538 x29071";
        }

        public CurrentUser(ClaimsPrincipal user)
        {
            Id = ClaimHelper.GetUserId(user);
            Email = ClaimHelper.GetEmail(user);
            FirstName = ClaimHelper.GetFirstName(user);
            LastName = ClaimHelper.GetLastName(user);
            Address = ClaimHelper.GetAdress(user);
            City = ClaimHelper.GetCity(user);
            Country = ClaimHelper.GetCountry(user);
            AccountSecretKey = ClaimHelper.GetAccountSecret(user);
            Username = ClaimHelper.GetUsername(user);
            FullName = ClaimHelper.GetFullName(user);
            PhoneNumber = ClaimHelper.GetPhoneNumber(user, "Todo: (436) 486-3538 x29071");

        }
    }
}
