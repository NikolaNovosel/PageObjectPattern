using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace EpamPage
{
    /// <summary>
    /// Represents the Insights page of the application
    /// This class contains elements and actions related to the Insights page
    /// </summary>
    public class InsightsPage(IWebDriver driver) : Page(driver)
    {
        // Insight link in the navigation menu
        private IWebElement Insight => NavBar.FindElement(By.XPath("./li[3]"));

        // Carousel section on the page
        private IWebElement Carousel => Driver.FindElement(By.XPath("//main[@id='main']/div[1]/div[1]//div[@class='owl-stage']"));

        // Parent element of the main page article in the carousel
        private IWebElement MainArticleParent => Carousel.FindElement(By.XPath("./div[6]"));

        // Main page article in the carousel
        private IWebElement MainArticle => MainArticleParent.FindElement(By.CssSelector(".font-size-60:first-child"));

        // "Read More" button in the carousel
        private IWebElement ReadMore => MainArticleParent.FindElement(By.PartialLinkText("Read More"));

        // The inside article
        private IWebElement InsideArticle => 
        Driver.FindElement(By.XPath("//main[@id='main']/div[1]/div[2]//div[@class='column-control']//span[@class='museo-sans-light']"));

        // Clicks the "Insights" link 
        public void ClickInsight() => Insight.Click();

        // Swipes the carousel
        public void SwipeCarousel()
        {
            for (int swipe = 0; swipe < 2; swipe++)
            {
                Actions.DragAndDropToOffset(Carousel, -300, 0).Perform();
            }
            try
            {
                Wait.Until(driver => MainArticleParent.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                Actions.DragAndDropToOffset(Carousel, -300, 0).Perform();
            }
        }

        // Clicks the "Read More" button in the carousel
        public void ClickReadMore()
        {
            try
            {
                ReadMore.Click();
            }
            catch (ElementClickInterceptedException)
            {
                Wait.Until(driver => Cookie.Enabled);
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");
                ReadMore.Click();
            }
        }

        // Returns the trimmed text of the main page article
        public string GetMainPageArticleTextTrim() => MainArticle.Text.Trim();

        // Returns the text of the inside article
        public string GetInsideArticleText() => InsideArticle.Text;
    }
}
