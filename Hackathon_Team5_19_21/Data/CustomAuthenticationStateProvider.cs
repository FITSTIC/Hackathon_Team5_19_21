using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        ISessionStorageService _sessionStorage;
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var emailAddress = await _sessionStorage.GetItemAsync<string>("email");
            ClaimsIdentity identity = emailAddress != null ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, emailAddress) }, "apiauth_type") : new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }
        public void MarkUserAsAuthenticated(string emailAddress)
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, emailAddress) }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedout()
        {
            await _sessionStorage.RemoveItemAsync("email");
            await _sessionStorage.RemoveItemAsync("admin");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
