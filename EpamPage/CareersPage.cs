using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace EpamPage
{
    /// <summary>
    /// Represents the Careers page of the application
    /// This class contains elements and actions related to the Careers page
    /// </summary>
    public class CareersPage(IWebDriver driver) : Page(driver)
    {
        // Careers link in the navigation menu  
        private IWebElement Careers => NavBar.FindElement(By.XPath("./li[5]"));

        // Keyword input field
        private IWebElement Keywords => Driver.FindElement(By.Id("new_form_job_search-keyword"));

        // Location dropdown
        private IWebElement Location => Wait.Until(driver => 
        {
            var element = Driver.FindElement(By.XPath("//div[@class='recruiting-search__column']//span[@class='select2-selection__arrow']"));
            return element.Displayed ? element : null;
        });

        // All locations option  
        private IWebElement AllLocations => Driver.FindElement(By.XPath("//li[normalize-space(text())='All Locations']"));

        // Parent element for the Remote Checkbox
        private IWebElement RemoteParent => Driver.FindElement(By.CssSelector("div.job-search__filter-list"));

        // Remote checkbox 
        private IWebElement Remote => RemoteParent.FindElement(By.XPath("//label[normalize-space(text())='Remote']"));

        // Parent element for the Find button
        private IWebElement FindForm => Driver.FindElement(By.Id("jobSearchFilterForm"));

        // Find button
        private IWebElement FindCareers => FindForm.FindElement(By.TagName("button"));

        // Parent element for the View and Apply button
        private IWebElement LatestResult => Wait.Until(driver =>
        {
            var element = Driver.FindElement(By.XPath("//ul[@class='search-result__list']/child::li[1]"));
            return element.Displayed && element.Enabled? element : null;
        });

        // View and Apply button for the latest job result  
        private IWebElement ViewAndApply => Wait.Until(driver => 
        {
            var element = LatestResult.FindElement(By.LinkText("VIEW AND APPLY"));
            return element.Displayed && element.Enabled ? element : null;
        });

        // Job title text
        private IWebElement CareersArticle => Driver.FindElement(By.ClassName("vacancy-details-23__job-title"));

        // Navigates to the Careers page  
        public CareersPage ClickCareers() 
        {
            Careers.Click(); 
            
            return this;
        }

        // Enters a keyword into the search field  
        public CareersPage SendKeysKeyword(string keyword)
        { 
            Keywords.SendKeys(keyword);

            return this;
        }

        // Opens the location dropdown  
        public CareersPage ClickLocation()
        {
            try
            {
                Location.Click();
            }
            catch (ElementClickInterceptedException)
            {
                Wait.Until(driver => Cookie.Enabled);

                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Location.Click();
            }

            return this;
        }

        // Selects all locations
        public CareersPage ClickAllLocations()
        { 
            AllLocations.Click();

            return this;
        }

        // Checks the remote filter  
        public CareersPage ClickRemote()
        {
            try
            {
                Driver.ExecuteJavaScript("arguments[0].click()", Remote);
            }

            catch (ElementClickInterceptedException)
            {
                Wait.Until(driver => Cookie.Enabled);

                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Remote.Click();
            }

            return this;
        }

        // Submits the job search  
        public CareersPage ClickFindCareers()
        { 
            FindCareers.Click();

            return this;
        }
        // Opens the latest job result
        public CareersPage ClickViewAndApply()
        {
            try
            {
                ViewAndApply.Click();
            }
            catch (ElementClickInterceptedException)
            {
                Wait.Until(driver => Cookie.Enabled);

                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                ViewAndApply.Click();
            }

            return this;
        }

        // Get the job title text  
        public string GetCareersArticleText() => CareersArticle.Text;
    }
}
