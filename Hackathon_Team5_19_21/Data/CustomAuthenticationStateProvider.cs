using Blazored.SessionStorage;
using Hackathon_Team5_19_21.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        ISessionStorageService _sessionStorage;
        ApplicationDbContext _db;
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage, ApplicationDbContext db)
        {
            _sessionStorage = sessionStorage;
            _db = db;
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
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        public async Task<Amministratore> VerificaCredenziali(string email, string password)
        {
            return await _db.Amministratori.FirstOrDefaultAsync(x => x.Email == email && x.Password == password.Sha256());
        }
    }
}
