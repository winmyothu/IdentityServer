using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api1", "My API"),
                new ApiScope("api2", "Test API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "api2" }
                },
                
                // interactive ASP.NET Core MVC client
              new Client
{
    ClientName = "Angular-Client",
    ClientId = "angular-client",
    AllowedGrantTypes = GrantTypes.Code,
    RedirectUris = new List<string>{ "http://localhost:4200/signin-callback", "http://localhost:4200/assets/silent-callback.html" },
    PostLogoutRedirectUris = new List<string> { "http://localhost:4200/signout-callback" },
    RequirePkce = true,
    AllowAccessTokensViaBrowser = true,
    AllowedScopes =
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        "api2"
    },
    AllowedCorsOrigins = { "http://localhost:4200" },
    RequireClientSecret = false,
    RequireConsent = false,
    AccessTokenLifetime = 600
}
            };
    }
}