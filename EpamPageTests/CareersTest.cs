using EpamPage;
using FluentAssertions;
using NUnit.Framework;

namespace EpamPageTests
{
    /// <summary>
    /// Test class for Careers page functionality
    /// </summary>
    internal class CareersTest : Test
    {
        // Test Careers page interactions and article content
        [Test]
        public void TestCase1()
        {
            CareersPage careerPage = new (Driver);
            careerPage.ClickCareers();
            careerPage.ClickLocation();
            careerPage.ClickAllLocations();
            careerPage.SendKeysKeyword(Data.CareersPage);
            careerPage.ClickRemote();
            careerPage.ClickFindCareers();
            careerPage.ClickViewAndApply();
            careerPage.GetCareersArticleText().Should().Contain(Data.CareersPage);
        }
    }
}
