using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace EpamPage
{
    /// <summary>
    /// Represents the About page of the application
    /// This class contains elements and actions related to the About page
    /// </summary>
    public class AboutPage(IWebDriver driver) : Page(driver)
    {
        // About link in the navigation menu
        private IWebElement About => NavBar.FindElement(By.XPath("./li[4]"));

        // "Epam At A Glance" section  
        private IWebElement EpamAtGlanceDiv => Driver.FindElement(By.XPath("//main[@id='main']/div[1]/div[5]//div[@class='colctrl__holder']"));

        // Download button in "Epam At A Glance" section  
        private IWebElement DownloadButton =>
        Wait.Until(driver => 
        {
            var element = EpamAtGlanceDiv.FindElement(By.XPath("//div[@class='button']//span[normalize-space(text())='DOWNLOAD']"));
            return element.Enabled ? element : null;
        });
        
        // Clicks the About link  
        public AboutPage ClickAbout()
        {
            About.Click();

            return this;
        } 

        // Scrolls to "Epam At A Glance" section  
        public AboutPage ScrollToEpamAtGlance() 
        {
            Actions.ScrollByAmount(0, EpamAtGlanceDiv.Location.Y).Perform();

            return this;
        } 

        // Clicks the download button  
        public AboutPage ClickDownload()
        {
            try
            {
                DownloadButton.Click();
            }
            catch (ElementClickInterceptedException)
            {
                Wait.Until(driver => Cookie.Enabled);

                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                DownloadButton.Click();
            }

            return this;
        }
    }
}
