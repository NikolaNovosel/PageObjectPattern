using EpamPageTests.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace EpamPageTests
{
    /// <summary>
    /// Test class for browser interactions, utilizing DriverSingleton and Data class for test data
    /// Initializes and tears down WebDriver within the Setup and TearDown methods
    /// </summary>
    internal class Test
    {
        // Reads and stores search page parameters from a source
        protected readonly static IEnumerable<string> SearchPage = DataReader.GetSearchPageParams();

        // Deserializes and stores test data
        protected readonly static Data Data = DataReader.DeserializeData();

        // Stores and access to the WebDriver instance
        private IWebDriver? _driver;

        // Provides access to the WebDriver instances
        protected IWebDriver? Driver => _driver;

        // Initializes and configures  the WebDriver instance
        [SetUp]
        public void Setup()
        {
            _driver = DriverSingleton.SwitchBetweenChromeAndFirefox();
            DriverSingleton.ManageWindow();
            DriverSingleton.GetUrl();
        }

        // Disposes of the WebDriver instance
        [TearDown]
        public void TearDown()
        {
            DriverSingleton.Dispose();
        }
    }
}
