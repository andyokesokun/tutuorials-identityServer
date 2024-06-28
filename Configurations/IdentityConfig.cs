using IdentityServer4.Models;

namespace tutorials.IdentityService.Configurations
{
    public static class IdentityConfig
    {

        public static IEnumerable<ApiScope> GetApiScopes =>

               new List<ApiScope>
            {
                new ApiScope("Payment-read", "Payment-write"),
                new ApiScope("Payment-write", "Payment-write")
            };
        
        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>() {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Payment service", "Payment service"),
                new ApiResource("Account service", "Payment service")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "Payment-read" },
                },

            };
        }
    }
}
