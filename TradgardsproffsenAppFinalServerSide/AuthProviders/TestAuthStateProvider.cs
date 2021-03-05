
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TradgardsproffsenApp.Data.Services;

namespace TradgardsproffsenApp.AuthProviders
{
    public class TestAuthStateProvider : AuthenticationStateProvider
    {
        private const string tokenKey = "authToken";
        public List<Claim> Claims { get; set; }

        internal readonly CustomLocalStorageService storage;

        public TestAuthStateProvider(CustomLocalStorageService storage)
        {
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await this.storage.GetItem<string>(tokenKey);
            return string.IsNullOrWhiteSpace(savedToken) ? await CreateAnomymousState() : await CreateAuthenticatedState(savedToken);
        }

        private static async Task<AuthenticationState> CreateAnomymousState()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            return await Task.FromResult(new AuthenticationState(anonymousUser));
        }

        private static async Task<AuthenticationState> CreateAuthenticatedState(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
            return await Task.FromResult(new AuthenticationState(authenticatedUser));
        }

        private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }


        public async Task Login(string token)
        {
            await this.storage.SetItem(tokenKey, token);
            Claims = ParseClaimsFromJwt(token).ToList();
        }

        public async Task Logout()
        {
            await this.storage.RemoveItem(tokenKey);
        }
    }
}

