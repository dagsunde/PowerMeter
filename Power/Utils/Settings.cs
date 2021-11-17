using Microsoft.Extensions.Configuration;
using System.IO;

namespace Power.Utils
{
    public class Settings
    {
        public static IConfigurationBuilder Getbuilder()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            return builder;
        }

        public static string GetSetting(string section, string key)
        {
            var builder = Getbuilder();
            var ConnectionString = builder.Build().GetValue<string>(section + ":" + key);
            return ConnectionString;
        }

    }
}
