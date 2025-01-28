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
            new CareersPage (Driver!)
                .ClickCareers()
                .SendKeysKeyword(Data.CareersPage)
                .ClickLocation()
                .ClickAllLocations()
                .ClickRemote()
                .ClickFindCareers()
                .ClickViewAndApply()
                .GetCareersArticleText().Should().Contain(Data.CareersPage);
        }
    }
}
