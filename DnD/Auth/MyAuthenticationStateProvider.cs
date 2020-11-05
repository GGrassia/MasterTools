using Blazored.LocalStorage;
using DnD.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DnD.Auth
{
    // Questo componente è incaricato di autorizzare gli utenti
    public class MyAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly IUserRepository userRepository;

        // Inizializziamo il provider usando dependency injection
        public MyAuthenticationStateProvider(ILocalStorageService localStorage, IUserRepository userRepository)
        {
            this.localStorage = localStorage;
            this.userRepository = userRepository;
        }

        // Questo metodo ricava uno stato di autenticazione dell'utente
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Identità anonima dummy, placeholder
            var anonymous = new ClaimsIdentity(new List<Claim>
            {
                new Claim("key1", "value1"),
                new Claim(ClaimTypes.Name, "Giulio"),
                new Claim(ClaimTypes.Role, "Admin")
            }, "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}
