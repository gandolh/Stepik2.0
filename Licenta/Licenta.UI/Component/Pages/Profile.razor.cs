﻿using Licenta.SDK.Models.Dtos;
using Licenta.SDK.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace Licenta.UI.Component.Pages
{
    public partial class Profile
    {
        [Inject] IJSRuntime jSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
              await  jSRuntime.InvokeVoidAsync("MaterializeInitializer.InitTabs");
            }
            await base.OnAfterRenderAsync(firstRender);
        }


        private UserDto ConvertToDto(ClaimsPrincipal claimPrincipal)
        {
            return new UserDto()
            {
                Firstname = ClaimHelper.GetFirstName(claimPrincipal),
                Lastname = ClaimHelper.GetLastName(claimPrincipal),
                Email = ClaimHelper.GetEmail(claimPrincipal),
            };
        }
    }
}