﻿using Licenta.SDK.Models;
using System.Security.Claims;
using System.Text.Json;

namespace Licenta.SDK.Services
{
    public class ClaimHelper
    {
        public static readonly string RolesClaimType= "Roles";

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
            return givenName + " " + surName;
        }

        public static string GetEmail(ClaimsPrincipal? user)
        {
            return user?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? "";
        }

        public static string GetFirstName(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.GivenName)?.Value ?? "";
        }

        public static string GetLastName(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Surname)?.Value ?? "";

        }
        
        public static List<RoleType> GetRoles(ClaimsPrincipal user)
        {
            string value = user.FindFirst(ClaimHelper.RolesClaimType)?.Value ?? "";
            if(value == "") return new List<RoleType>();
            return JsonSerializer.Deserialize<List<RoleType>>(value)!;
        }

    }
}
