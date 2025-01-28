using Microsoft.Extensions.Configuration;

namespace EpamPageTests.Core
{
    /// </summary>
    /// Class for reading the app config data for testing purposes
    /// </summary>
    internal static class ConfigProvider
    {
        // Initialize a ConfigurationBuilder and add the specified JSON configuration file
        private static readonly IConfigurationBuilder _builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

        // Build the configuration and assign it to the Configuration property
        private static readonly IConfiguration Config = _builder.Build();

        // Provide path to the downloaded file
        public static readonly string? FilePath =
        Path.Combine(Config["downloadDir"]!, Config["fileName"]!);

        // Provide the downloaded file name
        public static readonly string? DownloadDir = Config["downloadDir"];

        // Provide the WebDriver Url
        public static readonly string? Url = Config["url"];
    }
}
