using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace EpamPageTests.Core
{
    /// <summary>
    /// Helper class for configuring Chrome, Firefox, and Edge driver options.
    /// </summary>
    internal static class DriverOption
    {
        // Gets ChromeOptions for headless Chrome with downloads to TestData.DownloadDir
        internal static ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            chromeOptions.AddUserProfilePreference("download.default_directory", ConfigReader.Config["downloadDir"]);
            return chromeOptions;
        }

        // Gets FirefoxOptions for headless Firefox with downloads to TestData.DownloadDir
        internal static FirefoxOptions GetFirefoxOptions()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("browser.download.folderList", 2);
            firefoxOptions.SetPreference("browser.download.dir", ConfigReader.Config["downloadDir"]);
            firefoxOptions.AddArgument("--headless");
            return firefoxOptions;
        }

        // Gets EdgeOptions for headless Edge with downloads to TestData.DownloadDir
        internal static EdgeOptions GetEdgeOptions()
        {
            var edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--headless");
            edgeOptions.AddUserProfilePreference("download.default_directory", ConfigReader.Config["downloadDir"]);
            return edgeOptions;
        }
    }
}
