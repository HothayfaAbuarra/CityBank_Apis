using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace CityBank_bankend
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("testapis","Test Api Scope")
        };
        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId="testclient",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("testsecret".Sha256())
                },
                AllowedScopes=
                {
                    "testapis"
                }
            }
        };
    }
}
