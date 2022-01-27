using DIMS_Core.Common.Services;
using Microsoft.Extensions.Configuration;

namespace DIMS_Core.Identity.Configs
{
    internal class IdentityConfiguration : CustomConfigurationBase
    {
        private const string FileName = "identitysettings.json";

        public string ConnectionString => GetSection("ConnectionString");

        protected override IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();

            return builder.AddJsonFile(FileName)
                          .Build();
        }
    }
}