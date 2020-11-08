using Blazored.LocalStorage;
using DnD.Entities;
using DnD.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Auth
{
    // Questo componente è incaricato di autorizzare gli utenti
    public class MyAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly IUserRepository userRepository;
        private readonly string secret = "mipiacelaziapina";

        // Inizializziamo il provider usando dependency injection
        public MyAuthenticationStateProvider(ILocalStorageService localStorage, IUserRepository userRepository)
        {
            this.localStorage = localStorage;
            this.userRepository = userRepository;
        }

        // Questo metodo ricava uno stato di autenticazione dell'utente
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Chiediamo il documento all'utente
            var jwt = await localStorage.GetItemAsync<string>("jwt");

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    ClockSkew = TimeSpan.Zero
                };

                var authenticatedUser = handler.ValidateToken(jwt, validationParameters, out SecurityToken validatedToken);
                var claims = authenticatedUser.Claims;
                var username = claims.First(c => c.Type == ClaimTypes.Name).Value;
                if (await userRepository.GetAll().FirstOrDefaultAsync(u => u.Username == username) == null)
                    throw new Exception();
                return new AuthenticationState(authenticatedUser);
            }
            catch
            {
                var guest = new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "guest"),
                    new Claim(ClaimTypes.Role, "guest")
                }, "guest"));
                return new AuthenticationState(guest);
            }
        }

        public async Task<User> GetCurrentUser()
        {
            var username = await GetCurrentUsername();
            return await userRepository.GetAll().FirstOrDefaultAsync(u => u.Username == username);
        }

        private async Task<string> GetCurrentUsername()
        {
            var user = await GetAuthenticationStateAsync();
            var claims = user.User.Claims;
            return claims.First(c => c.Type == ClaimTypes.Name).Value;
        }

        public async Task AuthenticateUser(string username, string password)
        {
            var user = userRepository.GetAll().FirstOrDefault(u => u.Username == username);

            if (user == null)
                throw new UnauthorizedAccessException("Username does not exist");

            if (!BCrypt.Net.BCrypt.Verify(password, user.HashedPassword))
                throw new UnauthorizedAccessException("Password does not match");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "standard")
            };

            // Creazione del token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(null, null, claims, DateTime.UtcNow, null, creds);
            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            await localStorage.SetItemAsync("jwt", stringToken);
        }

        public async Task RegisterUser(string username, string password)
        {
            var existingUser = userRepository.GetAll().FirstOrDefault(u => u.Username == username);

            if (existingUser != null)
                throw new Exception("Username taken");

            var user = new User
            {
                Username = username,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(password)
            };

            await userRepository.Create(user);
        }

        public async Task LogoutCurrentUser()
        {
            await localStorage.RemoveItemAsync("jwt");
        }
    }
}
