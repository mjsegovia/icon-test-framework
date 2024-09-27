using Microsoft.Extensions.Configuration;
using System.IO;

namespace IconTestFramework.Core.Config
{
    public static class Configurator
    {
        public static IConfigurationRoot Config = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory() + @"..\..\..\..\..\IconTestFramework.Core\Config")
                                                    .AddJsonFile("appsettings.json")
                                                    .Build();

        public static string ApiUrl => GetAppSettings("Uri");
        public static string BaseUrl => GetAppSettings("base_url");
        public static string LoginUrl => GetAppSettings("login_url");

        private static string GetAppSettings(string name) => Config["AppSettings:" + name];
    }
}
